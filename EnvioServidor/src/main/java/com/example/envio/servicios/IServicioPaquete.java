package com.example.envio.servicios;

import com.example.envio.model.Paquete;
import com.example.envio.model.PaqueteInput;

import java.util.List;
import java.util.Optional;

/** Contrato de las operaciones sobre la clase C. Los controladores dependen de esta interfaz (SOLID: DIP). */
public interface IServicioPaquete {

    /** Todos los paquetes, con origen y destino de su envio (envioOrigen, envioDestino). */
    List<Paquete> listarPaquetes();

    List<Paquete> filtrarPaquetes(String envioCodigo, String descripcion);

    Optional<Paquete> buscarPorCodigo(String codigo);

    Optional<Paquete> buscarPorCriterios(String codigo, String envioCodigo, String descripcion);

    /** Vacio si el codigo ya existe; lanza ServicioException si el envio (clase A) no existe o hay datos invalidos. */
    Optional<Paquete> addPaquete(PaqueteInput input);

    /** Actualiza los datos del paquete; el envio al que pertenece no cambia. Vacio si no existe. */
    Optional<Paquete> updatePaquete(PaqueteInput input);

    Optional<Paquete> deletePaquete(String codigo);
}
