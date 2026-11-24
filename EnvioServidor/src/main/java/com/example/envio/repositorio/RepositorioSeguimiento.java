package com.example.envio.repositorio;

import com.example.envio.model.Seguimiento;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

/** INTERFAZ de control de la base de datos para la clase B (coleccion "seguimientos"). */
public interface RepositorioSeguimiento extends MongoRepository<Seguimiento, String>, ConsultasSeguimiento {

    List<Seguimiento> findByEnvioCodigo(String envioCodigo);

    boolean existsByEnvioCodigo(String envioCodigo);
}
