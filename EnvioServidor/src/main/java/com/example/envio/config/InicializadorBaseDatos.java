package com.example.envio.config;

import org.bson.Document;
import org.springframework.boot.CommandLineRunner;
import org.springframework.core.annotation.Order;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * Control de la base de datos del microservicio 1. Al arrancar (antes de cargar datos de ejemplo):
 *  1. crea de forma explicita las colecciones "envios" (clase A) y "seguimientos" (clase B),
 *  2. les aplica un esquema de validacion ($jsonSchema, strict, accion error) que obliga a los campos
 *     obligatorios, los tipos y los rangos (precio > 0, codigo postal 1..999999, orden >= 1, distancia >= 0),
 *  3. crea el indice por envioCodigo en "seguimientos" (relacion B -> A).
 * Es idempotente.
 */
@Component
@Order(1)
public class InicializadorBaseDatos implements CommandLineRunner {

    private static final String ESQUEMA_ENVIOS = """
            { "$jsonSchema": {
                "bsonType": "object",
                "required": ["_id", "origen", "destino", "precio", "fechaSalida", "departamentoDestino"],
                "properties": {
                    "_id":                 { "bsonType": "string", "minLength": 1 },
                    "origen":              { "bsonType": "string", "minLength": 1 },
                    "destino":             { "bsonType": "string", "minLength": 1 },
                    "precio":              { "bsonType": "double", "minimum": 0, "exclusiveMinimum": true },
                    "fechaSalida":         { "bsonType": "date" },
                    "departamentoDestino": { "bsonType": "string", "minLength": 1 },
                    "codigoPostalNacional":{ "bsonType": "int", "minimum": 1, "maximum": 999999 }
                } } }
            """;

    private static final String ESQUEMA_SEGUIMIENTOS = """
            { "$jsonSchema": {
                "bsonType": "object",
                "required": ["_id", "envioCodigo", "ubicacion", "orden", "distanciaKm", "fechaEvento", "confirmado"],
                "properties": {
                    "_id":         { "bsonType": "string", "minLength": 1 },
                    "envioCodigo": { "bsonType": "string", "minLength": 1 },
                    "ubicacion":   { "bsonType": "string", "minLength": 1 },
                    "orden":       { "bsonType": "int", "minimum": 1 },
                    "distanciaKm": { "bsonType": "double", "minimum": 0 },
                    "fechaEvento": { "bsonType": "date" },
                    "confirmado":  { "bsonType": "bool" }
                } } }
            """;

    private final MongoTemplate mongo;

    public InicializadorBaseDatos(MongoTemplate mongo) {
        this.mongo = mongo;
    }

    @Override
    public void run(String... args) {
        aplicar("envios", ESQUEMA_ENVIOS);
        aplicar("seguimientos", ESQUEMA_SEGUIMIENTOS);
        mongo.getDb().runCommand(new Document("createIndexes", "seguimientos")
                .append("indexes", List.of(new Document("key", new Document("envioCodigo", 1))
                        .append("name", "idx_seguimientos_envioCodigo"))));
    }

    private void aplicar(String coleccion, String esquema) {
        if (!mongo.collectionExists(coleccion)) {
            mongo.createCollection(coleccion);
        }
        mongo.getDb().runCommand(new Document("collMod", coleccion)
                .append("validator", Document.parse(esquema))
                .append("validationLevel", "strict")
                .append("validationAction", "error"));
    }
}
