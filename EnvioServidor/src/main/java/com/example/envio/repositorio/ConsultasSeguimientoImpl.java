package com.example.envio.repositorio;

import com.example.envio.model.Seguimiento;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/** Implementacion del fragmento ConsultasSeguimiento (Spring Data la une a RepositorioSeguimiento). */
public class ConsultasSeguimientoImpl implements ConsultasSeguimiento {

    private final MongoTemplate mongo;

    public ConsultasSeguimientoImpl(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public List<Seguimiento> buscar(String codigo, String envioCodigo, String ubicacion) {
        List<Criteria> filtros = new ArrayList<>();
        if (hay(codigo)) {
            filtros.add(Criteria.where("_id").is(codigo.trim()));
        }
        if (hay(envioCodigo)) {
            filtros.add(Criteria.where("envioCodigo").regex("^" + Pattern.quote(envioCodigo.trim()) + "$", "i"));
        }
        if (hay(ubicacion)) {
            filtros.add(Criteria.where("ubicacion").regex(Pattern.quote(ubicacion.trim()), "i"));
        }
        Query query = new Query();
        if (!filtros.isEmpty()) {
            query.addCriteria(new Criteria().andOperator(filtros));
        }
        return mongo.find(query, Seguimiento.class);
    }

    private static boolean hay(String s) {
        return s != null && !s.isBlank();
    }
}
