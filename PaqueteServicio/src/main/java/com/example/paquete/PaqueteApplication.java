package com.example.paquete;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/** Microservicio 2: gestiona la clase C (Paquete) con su propia base de datos MongoDB. */
@SpringBootApplication
public class PaqueteApplication {
    public static void main(String[] args) {
        SpringApplication.run(PaqueteApplication.class, args);
    }
}
