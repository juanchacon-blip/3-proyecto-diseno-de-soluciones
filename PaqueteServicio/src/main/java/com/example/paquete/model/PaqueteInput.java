package com.example.paquete.model;

/** Cuerpo de POST/PUT. fragil es opcional (si es null se toma como false). */
public record PaqueteInput(String codigo, String envioCodigo, String descripcion, double pesoKg,
                           int unidades, String fechaRegistro, Boolean fragil) {
}
