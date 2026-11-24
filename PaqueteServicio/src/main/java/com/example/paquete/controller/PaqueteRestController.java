package com.example.paquete.controller;

import com.example.paquete.model.Paquete;
import com.example.paquete.model.PaqueteInput;
import com.example.paquete.servicios.IServicioPaquete;
import com.example.paquete.servicios.ServicioException;
import org.springframework.dao.DataAccessException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;
import java.util.Optional;

/**
 * Servicio web REST del microservicio 2 (clase C).
 *  GET    /api/paquetes?envioCodigo=&descripcion=   lista (filtros opcionales)
 *  GET    /api/paquetes/buscar?codigo=&envioCodigo=&descripcion=   un paquete por 1 o 2 criterios
 *  GET    /api/paquetes/{codigo}   por codigo
 *  POST   /api/paquetes            adiciona (201, 400, 409 si el codigo existe)
 *  PUT    /api/paquetes/{codigo}   actualiza (200, 400, 404)
 *  DELETE /api/paquetes/{codigo}   elimina (200, 404)
 */
@RestController
@RequestMapping("/api/paquetes")
public class PaqueteRestController {

    private final IServicioPaquete servicio;

    public PaqueteRestController(IServicioPaquete servicio) {
        this.servicio = servicio;
    }

    @GetMapping
    public List<Paquete> listar(@RequestParam(name = "envioCodigo", required = false) String envioCodigo,
                                @RequestParam(name = "descripcion", required = false) String descripcion) {
        return servicio.listar(envioCodigo, descripcion);
    }

    @GetMapping("/buscar")
    public ResponseEntity<?> buscar(@RequestParam(name = "codigo", required = false) String codigo,
                                    @RequestParam(name = "envioCodigo", required = false) String envioCodigo,
                                    @RequestParam(name = "descripcion", required = false) String descripcion) {
        if (vacio(codigo) && vacio(envioCodigo) && vacio(descripcion)) {
            return error(HttpStatus.BAD_REQUEST, "Ingrese al menos un criterio de busqueda.");
        }
        return respuesta(servicio.buscarPorCriterios(codigo, envioCodigo, descripcion), HttpStatus.OK,
                "No se encontro ningun paquete con los criterios ingresados.");
    }

    @GetMapping("/{codigo}")
    public ResponseEntity<?> porCodigo(@PathVariable("codigo") String codigo) {
        return respuesta(servicio.buscarPorCodigo(codigo), HttpStatus.OK, "No existe un paquete con ese codigo.");
    }

    @PostMapping
    public ResponseEntity<?> adicionar(@RequestBody PaqueteInput input) {
        Optional<Paquete> creado = servicio.adicionar(input);
        if (creado.isEmpty()) {
            return error(HttpStatus.CONFLICT, "Ya existe un paquete con ese codigo.");
        }
        return ResponseEntity.status(HttpStatus.CREATED).body(creado.get());
    }

    @PutMapping("/{codigo}")
    public ResponseEntity<?> actualizar(@PathVariable("codigo") String codigo, @RequestBody PaqueteInput input) {
        PaqueteInput conCodigo = new PaqueteInput(codigo, input.envioCodigo(), input.descripcion(), input.pesoKg(),
                input.unidades(), input.fechaRegistro(), input.fragil());
        return respuesta(servicio.actualizar(conCodigo), HttpStatus.OK, "El paquete ya no existe.");
    }

    @DeleteMapping("/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable("codigo") String codigo) {
        return respuesta(servicio.eliminar(codigo), HttpStatus.OK, "El paquete ya no existe.");
    }

    @ExceptionHandler(ServicioException.class)
    public ResponseEntity<?> negocio(ServicioException ex) {
        return error(HttpStatus.BAD_REQUEST, ex.getMessage());
    }

    @ExceptionHandler(DataAccessException.class)
    public ResponseEntity<?> baseDeDatos(DataAccessException ex) {
        return error(HttpStatus.INTERNAL_SERVER_ERROR,
                "La base de datos rechazo la operacion (no disponible o datos que no cumplen sus reglas).");
    }

    private static ResponseEntity<?> respuesta(Optional<Paquete> p, HttpStatus ok, String noExiste) {
        return p.isPresent() ? ResponseEntity.status(ok).body(p.get()) : error(HttpStatus.NOT_FOUND, noExiste);
    }

    private static ResponseEntity<Map<String, String>> error(HttpStatus estado, String mensaje) {
        return ResponseEntity.status(estado).body(Map.of("mensaje", mensaje));
    }

    private static boolean vacio(String s) {
        return s == null || s.isBlank();
    }
}
