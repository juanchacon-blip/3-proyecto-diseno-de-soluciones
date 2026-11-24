package com.example.envio.repositorio;

import com.example.envio.model.EnvioNacional;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/** Implementacion del fragmento ConsultasEnvioNacional (Spring Data la une a RepositorioEnvioNacional). */
public class ConsultasEnvioNacionalImpl implements ConsultasEnvioNacional {

    private final MongoTemplate mongo;

    public ConsultasEnvioNacionalImpl(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public List<EnvioNacional> buscar(String codigo, String origen, String destino) {
        List<Criteria> filtros = new ArrayList<>();
        if (hay(codigo)) {
            filtros.add(Criteria.where("_id").is(codigo.trim()));
        }
        if (hay(origen)) {
            filtros.add(Criteria.where("origen").regex(Pattern.quote(origen.trim()), "i"));
        }
        if (hay(destino)) {
            filtros.add(Criteria.where("destino").regex(Pattern.quote(destino.trim()), "i"));
        }
        Query query = new Query();
        if (!filtros.isEmpty()) {
            query.addCriteria(new Criteria().andOperator(filtros));
        }
        return mongo.find(query, EnvioNacional.class);
    }

    private static boolean hay(String s) {
        return s != null && !s.isBlank();
    }
}
