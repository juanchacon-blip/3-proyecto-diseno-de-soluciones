package com.example.paquete.servicios;

import com.example.paquete.model.Paquete;
import com.example.paquete.model.PaqueteInput;
import com.example.paquete.repositorio.RepositorioPaquete;
import org.springframework.dao.DuplicateKeyException;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.List;
import java.util.Optional;

/** Reglas de negocio de la clase C. El acceso a MongoDB esta en la interfaz RepositorioPaquete. */
@Service
public class ServicioPaquete implements IServicioPaquete {

    private final RepositorioPaquete repositorio;

    public ServicioPaquete(RepositorioPaquete repositorio) {
        this.repositorio = repositorio;
    }

    @Override
    public List<Paquete> listar(String envioCodigo, String descripcion) {
        return repositorio.buscar(null, envioCodigo, descripcion);
    }

    @Override
    public Optional<Paquete> buscarPorCodigo(String codigo) {
        return vacio(codigo) ? Optional.empty() : repositorio.findById(codigo.trim());
    }

    @Override
    public Optional<Paquete> buscarPorCriterios(String codigo, String envioCodigo, String descripcion) {
        if (vacio(codigo) && vacio(envioCodigo) && vacio(descripcion)) {
            return Optional.empty();
        }
        return repositorio.buscar(codigo, envioCodigo, descripcion).stream().findFirst();
    }

    @Override
    public Optional<Paquete> adicionar(PaqueteInput input) {
        Paquete nuevo = construir(input);
        // Insercion atomica: la llave primaria unica de MongoDB evita duplicados aunque haya peticiones simultaneas.
        try {
            return Optional.of(repositorio.insert(nuevo));
        } catch (DuplicateKeyException e) {
            return Optional.empty();
        }
    }

    @Override
    public Optional<Paquete> actualizar(PaqueteInput input) {
        Paquete nuevo = construir(input);
        Optional<Paquete> actual = repositorio.findById(nuevo.getCodigo());
        if (actual.isEmpty()) {
            return Optional.empty();
        }
        nuevo.setEnvioCodigo(actual.get().getEnvioCodigo());
        return Optional.of(repositorio.save(nuevo));
    }

    @Override
    public Optional<Paquete> eliminar(String codigo) {
        Optional<Paquete> paquete = buscarPorCodigo(codigo);
        paquete.ifPresent(p -> repositorio.deleteById(p.getCodigo()));
        return paquete;
    }

    private static boolean vacio(String s) {
        return s == null || s.isBlank();
    }

    private static void requerido(String valor, String nombre) {
        if (vacio(valor)) {
            throw new ServicioException("El campo " + nombre + " es obligatorio.");
        }
    }

    /** Valida los datos y construye el paquete; lanza ServicioException si algo es invalido. */
    private static Paquete construir(PaqueteInput in) {
        if (in == null) {
            throw new ServicioException("Complete los datos del paquete.");
        }
        requerido(in.codigo(), "codigo");
        requerido(in.envioCodigo(), "codigo del envio");
        requerido(in.descripcion(), "descripcion");
        if (!(in.pesoKg() > 0)) {
            throw new ServicioException("El peso debe ser mayor que cero.");
        }
        if (in.unidades() < 1) {
            throw new ServicioException("Las unidades deben ser un numero entero mayor o igual a 1.");
        }
        requerido(in.fechaRegistro(), "fecha de registro");
        LocalDateTime fecha;
        try {
            fecha = LocalDateTime.parse(in.fechaRegistro().trim());
        } catch (DateTimeParseException e) {
            throw new ServicioException("La fecha de registro debe tener formato yyyy-MM-ddTHH:mm:ss.");
        }
        return new Paquete(in.codigo().trim(), in.envioCodigo().trim(), in.descripcion().trim(),
                in.pesoKg(), in.unidades(), fecha, Boolean.TRUE.equals(in.fragil()));
    }
}
