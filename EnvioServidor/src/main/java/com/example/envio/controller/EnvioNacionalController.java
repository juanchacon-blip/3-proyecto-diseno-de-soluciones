package com.example.envio.controller;

import com.example.envio.model.EnvioInput;
import com.example.envio.model.EnvioNacional;
import com.example.envio.servicios.IServicioEnvioNacional;
import com.example.envio.servicios.ServicioException;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

/** Servicio web GraphQL del microservicio 1: expone las operaciones de la clase A. */
@Controller
public class EnvioNacionalController {

    private final IServicioEnvioNacional servicio;

    public EnvioNacionalController(IServicioEnvioNacional servicio) {
        this.servicio = servicio;
    }

    @QueryMapping
    public List<EnvioNacional> envios() {
        return servicio.listarEnvios();
    }

    @QueryMapping
    public List<EnvioNacional> enviosFiltrados(@Argument String origen, @Argument String destino) {
        return servicio.filtrarEnvios(origen, destino);
    }

    @QueryMapping
    public Optional<EnvioNacional> envioPorCodigo(@Argument String codigo) {
        return servicio.buscarPorCodigo(codigo);
    }

    @QueryMapping
    public Optional<EnvioNacional> envioPorCriterios(@Argument String codigo, @Argument String origen,
                                                     @Argument String destino) {
        return servicio.buscarPorCriterios(codigo, origen, destino);
    }

    @MutationMapping
    public Optional<EnvioNacional> addEnvio(@Argument("input") EnvioInput input) {
        Optional<EnvioNacional> creado = servicio.addEnvio(input);
        if (creado.isEmpty()) {
            throw new ServicioException("Ya existe un envio con ese codigo.");
        }
        return creado;
    }

    @MutationMapping
    public Optional<EnvioNacional> updateEnvio(@Argument("input") EnvioInput input) {
        Optional<EnvioNacional> actualizado = servicio.updateEnvio(input);
        if (actualizado.isEmpty()) {
            throw new ServicioException("El envio ya no existe.");
        }
        return actualizado;
    }

    @MutationMapping
    public Optional<EnvioNacional> deleteEnvio(@Argument String codigo) {
        Optional<EnvioNacional> eliminado = servicio.deleteEnvio(codigo);
        if (eliminado.isEmpty()) {
            throw new ServicioException("El envio ya no existe.");
        }
        return eliminado;
    }
}
