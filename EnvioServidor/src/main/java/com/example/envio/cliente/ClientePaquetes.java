package com.example.envio.cliente;

import com.example.envio.model.Paquete;
import com.example.envio.model.PaqueteInput;
import com.example.envio.servicios.ServicioException;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Component;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestClient;
import org.springframework.web.client.RestClientException;

import java.util.List;
import java.util.Optional;
import java.util.function.Supplier;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Cliente REST del microservicio 2 (PaqueteServicio, clase C). Es la unica clase de EnvioServidor que
 * conoce ese microservicio: el resto del servidor y los clientes GUI no saben que existe.
 */
@Component
public class ClientePaquetes {

    private static final String RUTA = "/api/paquetes";
    private static final Pattern MENSAJE = Pattern.compile("\"mensaje\"\\s*:\\s*\"((?:\\\\.|[^\"\\\\])*)\"");

    private final RestClient http;

    public ClientePaquetes(@Value("${paquetes.servicio.url:http://localhost:8082}") String url) {
        this.http = RestClient.builder().baseUrl(url).build();
    }

    public List<Paquete> listar(String envioCodigo, String descripcion) {
        List<Paquete> lista = ejecutar(() -> http.get()
                .uri(b -> b.path(RUTA)
                        .queryParamIfPresent("envioCodigo", opcional(envioCodigo))
                        .queryParamIfPresent("descripcion", opcional(descripcion))
                        .build())
                .retrieve()
                .body(new ParameterizedTypeReference<List<Paquete>>() {
                }));
        return lista == null ? List.of() : lista;
    }

    public Optional<Paquete> porCodigo(String codigo) {
        if (codigo == null || codigo.isBlank()) {
            return Optional.empty();
        }
        return Optional.ofNullable(ejecutar(() -> http.get()
                .uri(RUTA + "/{codigo}", codigo.trim())
                .retrieve()
                .body(Paquete.class), 404));
    }

    public Optional<Paquete> buscar(String codigo, String envioCodigo, String descripcion) {
        if (codigo == null && envioCodigo == null && descripcion == null) {
            return Optional.empty();
        }
        if (opcional(codigo).isEmpty() && opcional(envioCodigo).isEmpty() && opcional(descripcion).isEmpty()) {
            return Optional.empty();
        }
        return Optional.ofNullable(ejecutar(() -> http.get()
                .uri(b -> b.path(RUTA + "/buscar")
                        .queryParamIfPresent("codigo", opcional(codigo))
                        .queryParamIfPresent("envioCodigo", opcional(envioCodigo))
                        .queryParamIfPresent("descripcion", opcional(descripcion))
                        .build())
                .retrieve()
                .body(Paquete.class), 404));
    }

    /** Vacio si el codigo ya existe (HTTP 409). */
    public Optional<Paquete> crear(PaqueteInput input) {
        return Optional.ofNullable(ejecutar(() -> http.post()
                .uri(RUTA)
                .contentType(MediaType.APPLICATION_JSON)
                .body(input)
                .retrieve()
                .body(Paquete.class), 409));
    }

    /** Vacio si el paquete no existe (HTTP 404). */
    public Optional<Paquete> actualizar(PaqueteInput input) {
        if (input == null || input.codigo() == null || input.codigo().isBlank()) {
            throw new ServicioException("El campo codigo es obligatorio.");
        }
        return Optional.ofNullable(ejecutar(() -> http.put()
                .uri(RUTA + "/{codigo}", input.codigo().trim())
                .contentType(MediaType.APPLICATION_JSON)
                .body(input)
                .retrieve()
                .body(Paquete.class), 404));
    }

    /** Vacio si el paquete no existe (HTTP 404). */
    public Optional<Paquete> eliminar(String codigo) {
        if (codigo == null || codigo.isBlank()) {
            return Optional.empty();
        }
        return Optional.ofNullable(ejecutar(() -> http.delete()
                .uri(RUTA + "/{codigo}", codigo.trim())
                .retrieve()
                .body(Paquete.class), 404));
    }

    private static Optional<String> opcional(String valor) {
        return valor == null || valor.isBlank() ? Optional.empty() : Optional.of(valor.trim());
    }

    /**
     * Ejecuta la llamada. Los estados HTTP indicados en estadosVacios se devuelven como null; los demas
     * errores se convierten en ServicioException con un mensaje apto para el usuario.
     */
    private <T> T ejecutar(Supplier<T> llamada, int... estadosVacios) {
        try {
            return llamada.get();
        } catch (HttpClientErrorException e) {
            for (int estado : estadosVacios) {
                if (e.getStatusCode().value() == estado) {
                    return null;
                }
            }
            throw new ServicioException(mensaje(e));
        } catch (ResourceAccessException e) {
            throw new ServicioException("El microservicio de paquetes no esta disponible.");
        } catch (RestClientException e) {
            throw new ServicioException("Error al comunicarse con el microservicio de paquetes.");
        }
    }

    private static String mensaje(HttpClientErrorException e) {
        Matcher m = MENSAJE.matcher(e.getResponseBodyAsString());
        if (m.find()) {
            return m.group(1).replace("\\\"", "\"").replace("\\\\", "\\");
        }
        return "Error del microservicio de paquetes (" + e.getStatusCode().value() + ").";
    }
}
