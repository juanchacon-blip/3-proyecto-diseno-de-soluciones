package com.example.paquete.repositorio;

import com.example.paquete.model.Paquete;

import java.util.List;

/** Consulta con filtros opcionales (codigo, envioCodigo, descripcion); los parametros vacios se ignoran. */
public interface ConsultasPaquete {

    List<Paquete> buscar(String codigo, String envioCodigo, String descripcion);
}
