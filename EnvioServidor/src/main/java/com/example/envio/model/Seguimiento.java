package com.example.envio.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;

/**
 * CLASE B (detalle de EnvioNacional, relacion 0..*). Se guarda en la coleccion "seguimientos" de MongoDB
 * y referencia a su envio por envioCodigo. Sin listas.
 * Atributos: String (codigo = llave primaria, envioCodigo, ubicacion), int (orden), double (distanciaKm),
 * LocalDateTime (fechaEvento) y boolean (confirmado, opcional).
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
@Document(collection = "seguimientos")
public class Seguimiento {
    @Id
    private String codigo;
    private String envioCodigo;
    private String ubicacion;
    private int orden;
    private double distanciaKm;
    private LocalDateTime fechaEvento;
    private boolean confirmado;
}
