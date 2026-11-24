package com.example.envio.model;

/** codigoPostalNacional es opcional (null si no se informa). fechaSalida: yyyy-MM-ddTHH:mm:ss. */
public record EnvioInput(String codigo, String origen, String destino, double precio, String fechaSalida,
                         String departamentoDestino, Integer codigoPostalNacional) {
}
