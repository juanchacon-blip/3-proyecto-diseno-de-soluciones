package com.example.paquete.repositorio;

import com.example.paquete.model.Paquete;
import org.springframework.data.mongodb.repository.MongoRepository;

/**
 * INTERFAZ de control de la base de datos para la clase C (coleccion "paquetes").
 * Spring Data genera la implementacion: findById, insert, save, deleteById, findAll...
 * Las busquedas con filtros opcionales estan en ConsultasPaquete. Ninguna otra clase accede a MongoDB.
 */
public interface RepositorioPaquete extends MongoRepository<Paquete, String>, ConsultasPaquete {
}
