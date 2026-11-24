package com.example.envio.repositorio;

import com.example.envio.model.EnvioNacional;

import java.util.List;

/** Consulta con filtros opcionales (codigo, origen, destino); los parametros vacios se ignoran. */
public interface ConsultasEnvioNacional {

    List<EnvioNacional> buscar(String codigo, String origen, String destino);
}
