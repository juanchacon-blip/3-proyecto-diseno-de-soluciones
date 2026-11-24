package com.example.envio.repositorio;

import com.example.envio.model.EnvioNacional;
import org.springframework.data.mongodb.repository.MongoRepository;

/**
 * INTERFAZ de control de la base de datos para la clase A (coleccion "envios"). Spring Data la implementa.
 * Las busquedas con filtros opcionales estan en ConsultasEnvioNacional.
 */
public interface RepositorioEnvioNacional extends MongoRepository<EnvioNacional, String>, ConsultasEnvioNacional {
}
