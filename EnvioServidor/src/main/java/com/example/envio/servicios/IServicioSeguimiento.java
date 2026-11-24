package com.example.envio.servicios;

import com.example.envio.model.Seguimiento;
import com.example.envio.model.SeguimientoInput;

import java.util.List;
import java.util.Optional;

/** Contrato de las operaciones sobre la clase B (detalle de un envio). */
public interface IServicioSeguimiento {

    List<Seguimiento> listarSeguimientos();

    List<Seguimiento> filtrarSeguimientos(String envioCodigo, String ubicacion);

    Optional<Seguimiento> buscarPorCodigo(String codigo);

    Optional<Seguimiento> buscarPorCriterios(String codigo, String envioCodigo, String ubicacion);

    /** Vacio si el codigo ya existe; lanza ServicioException si el envio (clase A) no existe o hay datos invalidos. */
    Optional<Seguimiento> addSeguimiento(SeguimientoInput input);

    /** Actualiza los datos del seguimiento; el envio al que pertenece no cambia. Vacio si no existe. */
    Optional<Seguimiento> updateSeguimiento(SeguimientoInput input);

    Optional<Seguimiento> deleteSeguimiento(String codigo);
}
