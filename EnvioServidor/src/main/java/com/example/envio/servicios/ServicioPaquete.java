package com.example.envio.servicios;

import com.example.envio.cliente.ClientePaquetes;
import com.example.envio.model.EnvioNacional;
import com.example.envio.model.Paquete;
import com.example.envio.model.PaqueteInput;
import org.springframework.stereotype.Service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

/**
 * Operaciones sobre la clase C. Este microservicio NO guarda paquetes: los delega, de forma transparente
 * para el cliente, en el microservicio 2 (ClientePaquetes) y les agrega los datos de la clase A
 * (origen y destino del envio). Tambien asegura la integridad referencial: no se adiciona un paquete
 * si su envio no existe.
 */
@Service
public class ServicioPaquete implements IServicioPaquete {

    private final IServicioEnvioNacional servicioEnvios;
    private final ClientePaquetes remoto;

    public ServicioPaquete(IServicioEnvioNacional servicioEnvios, ClientePaquetes remoto) {
        this.servicioEnvios = servicioEnvios;
        this.remoto = remoto;
    }

    @Override
    public List<Paquete> listarPaquetes() {
        return completar(remoto.listar(null, null));
    }

    @Override
    public List<Paquete> filtrarPaquetes(String envioCodigo, String descripcion) {
        return completar(remoto.listar(envioCodigo, descripcion));
    }

    @Override
    public Optional<Paquete> buscarPorCodigo(String codigo) {
        return remoto.porCodigo(codigo).map(this::completar);
    }

    @Override
    public Optional<Paquete> buscarPorCriterios(String codigo, String envioCodigo, String descripcion) {
        return remoto.buscar(codigo, envioCodigo, descripcion).map(this::completar);
    }

    @Override
    public Optional<Paquete> addPaquete(PaqueteInput input) {
        if (input == null || input.envioCodigo() == null || input.envioCodigo().isBlank()) {
            throw new ServicioException("El campo codigo del envio es obligatorio.");
        }
        if (servicioEnvios.buscarPorCodigo(input.envioCodigo()).isEmpty()) {
            throw new ServicioException("El envio " + input.envioCodigo().trim() + " no existe.");
        }
        return remoto.crear(input).map(this::completar);
    }

    @Override
    public Optional<Paquete> updatePaquete(PaqueteInput input) {
        return remoto.actualizar(input).map(this::completar);
    }

    @Override
    public Optional<Paquete> deletePaquete(String codigo) {
        return remoto.eliminar(codigo).map(this::completar);
    }

    private Paquete completar(Paquete p) {
        completar(List.of(p));
        return p;
    }

    /** Completa envioOrigen y envioDestino (datos de la clase A) consultando cada envio una sola vez. */
    private List<Paquete> completar(List<Paquete> paquetes) {
        Map<String, Optional<EnvioNacional>> envios = new HashMap<>();
        for (Paquete p : paquetes) {
            Optional<EnvioNacional> envio = envios.computeIfAbsent(p.getEnvioCodigo(), servicioEnvios::buscarPorCodigo);
            envio.ifPresent(e -> {
                p.setEnvioOrigen(e.getOrigen());
                p.setEnvioDestino(e.getDestino());
            });
        }
        return paquetes;
    }
}
