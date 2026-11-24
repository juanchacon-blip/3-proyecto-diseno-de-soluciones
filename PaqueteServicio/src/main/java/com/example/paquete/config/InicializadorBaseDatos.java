package com.example.paquete.config;

import org.bson.Document;
import org.springframework.boot.CommandLineRunner;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * Control de la base de datos. Al arrancar el microservicio:
 *  1. crea la coleccion "paquetes" de forma explicita (no depende del primer insert),
 *  2. le aplica un esquema de validacion ($jsonSchema, nivel strict, accion error): MongoDB rechaza
 *     cualquier documento sin los campos obligatorios, con tipos incorrectos, peso <= 0 o unidades < 1,
 *     aunque el dato no pase por la API,
 *  3. crea el indice por envioCodigo (usado al filtrar). La llave primaria (_id = codigo) ya es unica.
 * Es idempotente: se puede ejecutar en cada arranque.
 */
@Component
public class InicializadorBaseDatos implements CommandLineRunner {

    static final String COLECCION = "paquetes";

    private static final String ESQUEMA = """
            { "$jsonSchema": {
                "bsonType": "object",
                "required": ["_id", "envioCodigo", "descripcion", "pesoKg", "unidades", "fechaRegistro", "fragil"],
                "properties": {
                    "_id":           { "bsonType": "string", "minLength": 1 },
                    "envioCodigo":   { "bsonType": "string", "minLength": 1 },
                    "descripcion":   { "bsonType": "string", "minLength": 1 },
                    "pesoKg":        { "bsonType": "double", "minimum": 0, "exclusiveMinimum": true },
                    "unidades":      { "bsonType": "int", "minimum": 1 },
                    "fechaRegistro": { "bsonType": "date" },
                    "fragil":        { "bsonType": "bool" }
                } } }
            """;

    private final MongoTemplate mongo;

    public InicializadorBaseDatos(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public void run(String... args) {
        if (!mongo.collectionExists(COLECCION)) {
            mongo.createCollection(COLECCION);
        }
        mongo.getDb().runCommand(new Document("collMod", COLECCION)
                .append("validator", Document.parse(ESQUEMA))
                .append("validationLevel", "strict")
                .append("validationAction", "error"));
        mongo.getDb().runCommand(new Document("createIndexes", COLECCION)
                .append("indexes", List.of(new Document("key", new Document("envioCodigo", 1))
                        .append("name", "idx_paquetes_envioCodigo"))));
    }
}
