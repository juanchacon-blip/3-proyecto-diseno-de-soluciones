package com.example.paquete.servicios;

import com.example.paquete.model.Paquete;
import com.example.paquete.model.PaqueteInput;

import java.util.List;
import java.util.Optional;

public interface IServicioPaquete {
    List<Paquete> listar(String envioCodigo, String descripcion);

    Optional<Paquete> buscarPorCodigo(String codigo);

    Optional<Paquete> buscarPorCriterios(String codigo, String envioCodigo, String descripcion);

    /** Vacio si el codigo ya existe. */
    Optional<Paquete> adicionar(PaqueteInput input);

    /** Vacio si no existe. El envio al que pertenece el paquete no cambia. */
    Optional<Paquete> actualizar(PaqueteInput input);

    Optional<Paquete> eliminar(String codigo);
}
