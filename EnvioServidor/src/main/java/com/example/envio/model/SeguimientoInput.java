package com.example.envio.model;

/** confirmado es opcional (si es null se toma como false). fechaEvento: yyyy-MM-ddTHH:mm:ss. */
public record SeguimientoInput(String codigo, String envioCodigo, String ubicacion, int orden,
                               double distanciaKm, String fechaEvento, Boolean confirmado) {
}
