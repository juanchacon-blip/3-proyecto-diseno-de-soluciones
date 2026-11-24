package com.example.envio.repositorio;

import com.example.envio.model.Seguimiento;

import java.util.List;

/** Consulta con filtros opcionales (codigo, envioCodigo, ubicacion); los parametros vacios se ignoran. */
public interface ConsultasSeguimiento {

    List<Seguimiento> buscar(String codigo, String envioCodigo, String ubicacion);
}
