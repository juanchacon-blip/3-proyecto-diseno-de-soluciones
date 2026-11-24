package com.example.envio.servicios;

import com.example.envio.cliente.ClientePaquetes;
import com.example.envio.model.EnvioInput;
import com.example.envio.model.EnvioNacional;
import com.example.envio.repositorio.RepositorioEnvioNacional;
import com.example.envio.repositorio.RepositorioSeguimiento;
import org.springframework.dao.DuplicateKeyException;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.List;
import java.util.Optional;

/**
 * Clase A. Reglas de negocio y acceso a los envios; la integridad referencial se asegura al eliminar:
 * un envio con seguimientos (clase B) o paquetes (clase C) no se puede borrar. Bean singleton de Spring.
 */
@Service
public class ServicioEnvioNacional implements IServicioEnvioNacional {

    private final RepositorioEnvioNacional repositorio;
    private final RepositorioSeguimiento seguimientos;
    private final ClientePaquetes paquetes;

    public ServicioEnvioNacional(RepositorioEnvioNacional repositorio, RepositorioSeguimiento seguimientos,
                                 ClientePaquetes paquetes) {
        this.repositorio = repositorio;
        this.seguimientos = seguimientos;
        this.paquetes = paquetes;
    }

    @Override
    public List<EnvioNacional> listarEnvios() {
        return repositorio.buscar(null, null, null);
    }

    @Override
    public List<EnvioNacional> filtrarEnvios(String origen, String destino) {
        return repositorio.buscar(null, origen, destino);
    }

    @Override
    public Optional<EnvioNacional> buscarPorCodigo(String codigo) {
        if (vacio(codigo)) {
            return Optional.empty();
        }
        return repositorio.findById(codigo.trim());
    }

    @Override
    public Optional<EnvioNacional> buscarPorCriterios(String codigo, String origen, String destino) {
        if (vacio(codigo) && vacio(origen) && vacio(destino)) {
            return Optional.empty();
        }
        return repositorio.buscar(codigo, origen, destino).stream().findFirst();
    }

    @Override
    public Optional<EnvioNacional> addEnvio(EnvioInput input) {
        EnvioNacional nuevo = construir(input);
        // Insercion atomica: la llave primaria unica de MongoDB evita duplicados aunque haya peticiones simultaneas.
        try {
            return Optional.of(repositorio.insert(nuevo));
        } catch (DuplicateKeyException e) {
            return Optional.empty();
        }
    }

    @Override
    public Optional<EnvioNacional> updateEnvio(EnvioInput input) {
        EnvioNacional nuevo = construir(input);
        if (repositorio.findById(nuevo.getCodigo()).isEmpty()) {
            return Optional.empty();
        }
        return Optional.of(repositorio.save(nuevo));
    }

    @Override
    public Optional<EnvioNacional> deleteEnvio(String codigo) {
        Optional<EnvioNacional> envio = buscarPorCodigo(codigo);
        if (envio.isEmpty()) {
            return envio;
        }
        String cod = envio.get().getCodigo();
        if (seguimientos.existsByEnvioCodigo(cod)) {
            throw new ServicioException("No se puede eliminar el envio " + cod + ": tiene seguimientos asociados.");
        }
        if (!paquetes.listar(cod, null).isEmpty()) {
            throw new ServicioException("No se puede eliminar el envio " + cod + ": tiene paquetes asociados.");
        }
        repositorio.deleteById(cod);
        return envio;
    }

    private static boolean vacio(String s) {
        return s == null || s.isBlank();
    }

    private static void requerido(String valor, String nombre) {
        if (vacio(valor)) {
            throw new ServicioException("El campo " + nombre + " es obligatorio.");
        }
    }

    /** Valida los datos y construye el envio; lanza ServicioException si algo es invalido. */
    private static EnvioNacional construir(EnvioInput in) {
        if (in == null) {
            throw new ServicioException("Complete los datos del envio.");
        }
        requerido(in.codigo(), "codigo");
        requerido(in.origen(), "origen");
        requerido(in.destino(), "destino");
        if (!(in.precio() > 0)) {
            throw new ServicioException("El precio debe ser mayor que cero.");
        }
        requerido(in.fechaSalida(), "fecha de salida");
        LocalDateTime fecha;
        try {
            fecha = LocalDateTime.parse(in.fechaSalida().trim());
        } catch (DateTimeParseException e) {
            throw new ServicioException("La fecha de salida debe tener formato yyyy-MM-ddTHH:mm:ss.");
        }
        requerido(in.departamentoDestino(), "departamento de destino");
        Integer postal = in.codigoPostalNacional();
        if (postal != null && (postal < 1 || postal > 999999)) {
            throw new ServicioException("El codigo postal debe estar entre 1 y 999999.");
        }
        return new EnvioNacional(in.codigo().trim(), in.origen().trim(), in.destino().trim(), in.precio(), fecha,
                in.departamentoDestino().trim(), postal);
    }
}
