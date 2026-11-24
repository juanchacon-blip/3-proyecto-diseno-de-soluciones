package com.example.paquete.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;

/**
 * CLASE C. Coleccion "paquetes" de la base de datos propia de este microservicio.
 * Atributos: String (codigo = llave primaria, envioCodigo, descripcion), double (pesoKg), int (unidades),
 * LocalDateTime (fechaRegistro) y boolean (fragil, opcional: por defecto false).
 * envioCodigo referencia a la clase A del microservicio 1 (la existencia del envio la valida ese microservicio).
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
@Document(collection = "paquetes")
public class Paquete {
    @Id
    private String codigo;
    private String envioCodigo;
    private String descripcion;
    private double pesoKg;
    private int unidades;
    private LocalDateTime fechaRegistro;
    private boolean fragil;
}
