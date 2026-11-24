package com.example.envio.controller;

import com.example.envio.model.Seguimiento;
import com.example.envio.model.SeguimientoInput;
import com.example.envio.servicios.IServicioSeguimiento;
import com.example.envio.servicios.ServicioException;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

/** Servicio web GraphQL del microservicio 1: expone las operaciones de la clase B. */
@Controller
public class SeguimientoController {

    private final IServicioSeguimiento servicio;

    public SeguimientoController(IServicioSeguimiento servicio) {
        this.servicio = servicio;
    }

    @QueryMapping
    public List<Seguimiento> seguimientos() {
        return servicio.listarSeguimientos();
    }

    @QueryMapping
    public List<Seguimiento> seguimientosFiltrados(@Argument String envioCodigo, @Argument String ubicacion) {
        return servicio.filtrarSeguimientos(envioCodigo, ubicacion);
    }

    @QueryMapping
    public Optional<Seguimiento> seguimientoPorCodigo(@Argument String codigo) {
        return servicio.buscarPorCodigo(codigo);
    }

    @QueryMapping
    public Optional<Seguimiento> seguimientoPorCriterios(@Argument String codigo, @Argument String envioCodigo,
                                                         @Argument String ubicacion) {
        return servicio.buscarPorCriterios(codigo, envioCodigo, ubicacion);
    }

    @MutationMapping
    public Optional<Seguimiento> addSeguimiento(@Argument("input") SeguimientoInput input) {
        Optional<Seguimiento> creado = servicio.addSeguimiento(input);
        if (creado.isEmpty()) {
            throw new ServicioException("Ya existe un seguimiento con ese codigo.");
        }
        return creado;
    }

    @MutationMapping
    public Optional<Seguimiento> updateSeguimiento(@Argument("input") SeguimientoInput input) {
        Optional<Seguimiento> actualizado = servicio.updateSeguimiento(input);
        if (actualizado.isEmpty()) {
            throw new ServicioException("El seguimiento ya no existe.");
        }
        return actualizado;
    }

    @MutationMapping
    public Optional<Seguimiento> deleteSeguimiento(@Argument String codigo) {
        Optional<Seguimiento> eliminado = servicio.deleteSeguimiento(codigo);
        if (eliminado.isEmpty()) {
            throw new ServicioException("El seguimiento ya no existe.");
        }
        return eliminado;
    }
}
