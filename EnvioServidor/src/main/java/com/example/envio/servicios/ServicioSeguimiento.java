package com.example.envio.servicios;

import com.example.envio.model.Seguimiento;
import com.example.envio.model.SeguimientoInput;
import com.example.envio.repositorio.RepositorioSeguimiento;
import org.springframework.dao.DuplicateKeyException;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.List;
import java.util.Optional;

/** Clase B. Reglas de negocio de los seguimientos; asegura la integridad referencial con la clase A. */
@Service
public class ServicioSeguimiento implements IServicioSeguimiento {

    private final RepositorioSeguimiento repositorio;
    private final IServicioEnvioNacional servicioEnvios;

    public ServicioSeguimiento(RepositorioSeguimiento repositorio, IServicioEnvioNacional servicioEnvios) {
        this.repositorio = repositorio;
        this.servicioEnvios = servicioEnvios;
    }

    @Override
    public List<Seguimiento> listarSeguimientos() {
        return repositorio.buscar(null, null, null);
    }

    @Override
    public List<Seguimiento> filtrarSeguimientos(String envioCodigo, String ubicacion) {
        return repositorio.buscar(null, envioCodigo, ubicacion);
    }

    @Override
    public Optional<Seguimiento> buscarPorCodigo(String codigo) {
        return vacio(codigo) ? Optional.empty() : repositorio.findById(codigo.trim());
    }

    @Override
    public Optional<Seguimiento> buscarPorCriterios(String codigo, String envioCodigo, String ubicacion) {
        if (vacio(codigo) && vacio(envioCodigo) && vacio(ubicacion)) {
            return Optional.empty();
        }
        return repositorio.buscar(codigo, envioCodigo, ubicacion).stream().findFirst();
    }

    @Override
    public Optional<Seguimiento> addSeguimiento(SeguimientoInput input) {
        Seguimiento nuevo = construir(input);
        if (servicioEnvios.buscarPorCodigo(nuevo.getEnvioCodigo()).isEmpty()) {
            throw new ServicioException("El envio " + nuevo.getEnvioCodigo() + " no existe.");
        }
        try {
            return Optional.of(repositorio.insert(nuevo));
        } catch (DuplicateKeyException e) {
            return Optional.empty();
        }
    }

    @Override
    public Optional<Seguimiento> updateSeguimiento(SeguimientoInput input) {
        Seguimiento nuevo = construir(input);
        Optional<Seguimiento> actual = repositorio.findById(nuevo.getCodigo());
        if (actual.isEmpty()) {
            return Optional.empty();
        }
        nuevo.setEnvioCodigo(actual.get().getEnvioCodigo());
        return Optional.of(repositorio.save(nuevo));
    }

    @Override
    public Optional<Seguimiento> deleteSeguimiento(String codigo) {
        Optional<Seguimiento> seguimiento = buscarPorCodigo(codigo);
        seguimiento.ifPresent(s -> repositorio.deleteById(s.getCodigo()));
        return seguimiento;
    }

    private static boolean vacio(String s) {
        return s == null || s.isBlank();
    }

    private static void requerido(String valor, String nombre) {
        if (vacio(valor)) {
            throw new ServicioException("El campo " + nombre + " es obligatorio.");
        }
    }

    /** Valida los datos y construye el seguimiento; lanza ServicioException si algo es invalido. */
    private static Seguimiento construir(SeguimientoInput in) {
        if (in == null) {
            throw new ServicioException("Complete los datos del seguimiento.");
        }
        requerido(in.codigo(), "codigo");
        requerido(in.envioCodigo(), "codigo del envio");
        requerido(in.ubicacion(), "ubicacion");
        if (in.orden() < 1) {
            throw new ServicioException("El orden debe ser un numero entero mayor o igual a 1.");
        }
        if (!(in.distanciaKm() >= 0)) {
            throw new ServicioException("La distancia debe ser mayor o igual a cero.");
        }
        requerido(in.fechaEvento(), "fecha del evento");
        LocalDateTime fecha;
        try {
            fecha = LocalDateTime.parse(in.fechaEvento().trim());
        } catch (DateTimeParseException e) {
            throw new ServicioException("La fecha del evento debe tener formato yyyy-MM-ddTHH:mm:ss.");
        }
        return new Seguimiento(in.codigo().trim(), in.envioCodigo().trim(), in.ubicacion().trim(), in.orden(),
                in.distanciaKm(), fecha, Boolean.TRUE.equals(in.confirmado()));
    }
}
