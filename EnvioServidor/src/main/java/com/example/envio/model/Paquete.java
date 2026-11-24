package com.example.envio.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 * CLASE C tal como la ve el microservicio 1 (EnvioServidor). El objeto se guarda en la base de datos
 * del microservicio 2 (PaqueteServicio); aqui solo es el DTO que viaja por GraphQL.
 * envioOrigen y envioDestino NO pertenecen a C: los completa este microservicio con datos de la clase A.
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Paquete {
    private String codigo;
    private String envioCodigo;
    private String descripcion;
    private double pesoKg;
    private int unidades;
    private String fechaRegistro;
    private boolean fragil;
    private String envioOrigen;
    private String envioDestino;
}
