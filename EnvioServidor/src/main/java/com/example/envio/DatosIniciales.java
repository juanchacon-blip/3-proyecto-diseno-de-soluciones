package com.example.envio;

import com.example.envio.model.EnvioNacional;
import com.example.envio.model.Seguimiento;
import com.example.envio.repositorio.RepositorioEnvioNacional;
import com.example.envio.repositorio.RepositorioSeguimiento;
import org.springframework.boot.CommandLineRunner;
import org.springframework.core.annotation.Order;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

/**
 * Datos de ejemplo de las clases A y B (a traves de sus repositorios). El cliente solo gestiona la clase C,
 * asi que los envios que los paquetes referencian se crean aqui la primera vez que arranca el servidor.
 */
@Component
@Order(2)
public class DatosIniciales implements CommandLineRunner {

    private final RepositorioEnvioNacional envios;
    private final RepositorioSeguimiento seguimientos;

    public DatosIniciales(RepositorioEnvioNacional envios, RepositorioSeguimiento seguimientos) {
        this.envios = envios;
        this.seguimientos = seguimientos;
    }

    @Override
    public void run(String... args) {
        if (envios.count() == 0) {
            envios.save(new EnvioNacional("E1", "Ibague", "Cali", 25000,
                    LocalDateTime.of(2026, 10, 21, 10, 0), "Valle", 760001));
            envios.save(new EnvioNacional("E2", "Bogota", "Medellin", 38000,
                    LocalDateTime.of(2026, 10, 22, 8, 30), "Antioquia", 50001));
            envios.save(new EnvioNacional("E3", "Ibague", "Neiva", 18000,
                    LocalDateTime.of(2026, 10, 23, 14, 0), "Huila", null));
        }
        if (seguimientos.count() == 0) {
            seguimientos.save(new Seguimiento("S1", "E1", "Centro de acopio Ibague", 1, 0,
                    LocalDateTime.of(2026, 10, 21, 10, 30), true));
            seguimientos.save(new Seguimiento("S2", "E1", "Bodega Armenia", 2, 105.5,
                    LocalDateTime.of(2026, 10, 21, 14, 0), false));
        }
    }
}
