package com.example.paquete.repositorio;

import com.example.paquete.model.Paquete;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/** Implementacion del fragmento ConsultasPaquete (Spring Data la une automaticamente a RepositorioPaquete). */
public class ConsultasPaqueteImpl implements ConsultasPaquete {

    private final MongoTemplate mongo;

    public ConsultasPaqueteImpl(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public List<Paquete> buscar(String codigo, String envioCodigo, String descripcion) {
        List<Criteria> filtros = new ArrayList<>();
        if (hay(codigo)) {
            filtros.add(Criteria.where("_id").is(codigo.trim()));
        }
        if (hay(envioCodigo)) {
            filtros.add(Criteria.where("envioCodigo").regex("^" + Pattern.quote(envioCodigo.trim()) + "$", "i"));
        }
        if (hay(descripcion)) {
            filtros.add(Criteria.where("descripcion").regex(Pattern.quote(descripcion.trim()), "i"));
        }
        Query query = new Query();
        if (!filtros.isEmpty()) {
            query.addCriteria(new Criteria().andOperator(filtros));
        }
        return mongo.find(query, Paquete.class);
    }

    private static boolean hay(String s) {
        return s != null && !s.isBlank();
    }
}
