package com.example.envio.servicios;

import com.example.envio.model.EnvioInput;
import com.example.envio.model.EnvioNacional;

import java.util.List;
import java.util.Optional;

/** Contrato de las operaciones sobre la clase A. buscarPorCodigo tambien lo usan ServicioPaquete y ServicioSeguimiento. */
public interface IServicioEnvioNacional {

    List<EnvioNacional> listarEnvios();

    List<EnvioNacional> filtrarEnvios(String origen, String destino);

    Optional<EnvioNacional> buscarPorCodigo(String codigo);

    Optional<EnvioNacional> buscarPorCriterios(String codigo, String origen, String destino);

    /** Vacio si el codigo ya existe; lanza ServicioException si hay datos invalidos. */
    Optional<EnvioNacional> addEnvio(EnvioInput input);

    /** Actualiza los datos del envio. Vacio si no existe. */
    Optional<EnvioNacional> updateEnvio(EnvioInput input);

    /** Vacio si no existe; lanza ServicioException si el envio tiene seguimientos o paquetes asociados. */
    Optional<EnvioNacional> deleteEnvio(String codigo);
}
