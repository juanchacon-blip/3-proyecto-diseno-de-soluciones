package com.example.paquete.servicios;

/** Error de negocio con un mensaje apto para mostrar al usuario. */
public class ServicioException extends RuntimeException {
    public ServicioException(String mensaje) {
        super(mensaje);
    }
}
