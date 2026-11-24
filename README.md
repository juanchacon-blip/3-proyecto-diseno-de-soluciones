# Tercer proyecto – Microservicios (Envíos / Paquetes)

## Arquitectura (Figura 4)

```
Cliente C# WinForms ──GraphQL──▶ EnvioServidor (microservicio 1, :8081) ──REST──▶ PaqueteServicio (microservicio 2, :8082)
                                  MongoDB envios_db: envios (A), seguimientos (B)    MongoDB paquetes_db: paquetes (C)
```

| Carpeta | Tecnología | Rol |
|---|---|---|
| `EnvioServidor` | Java 17 + Spring Boot + GraphQL + MongoDB | Microservicio 1: clases **A** (`EnvioNacional`) y **B** (`Seguimiento`). Expone GraphQL y llama al microservicio 2 de forma transparente |
| `PaqueteServicio` | Java 17 + Spring Boot + REST + MongoDB | Microservicio 2: clase **C** (`Paquete`) con su **propia base de datos** |
| `EnvioCliente` | C# WinForms (.NET Framework 4.8) | Cliente en un lenguaje distinto al de los servidores |

## Clases
- **A `EnvioNacional`** (colección `envios`): `codigo`, `origen`, `destino`, `precio` (double), `fechaSalida` (LocalDateTime), `departamentoDestino`, `codigoPostalNacional` (int, opcional). Se carga con datos de ejemplo (E1, E2, E3) al primer arranque.
- **B `Seguimiento`** (colección `seguimientos`, 0..* por envío): `codigo`, `envioCodigo`, `ubicacion`, `orden` (int), `distanciaKm` (double), `fechaEvento` (LocalDateTime), `confirmado` (boolean, opcional).
- **C `Paquete`** (colección `paquetes`, microservicio 2): `codigo`, `envioCodigo` (referencia a A), `descripcion`, `pesoKg` (double), `unidades` (int), `fechaRegistro` (LocalDateTime), `fragil` (boolean, opcional). Sin listas.

## Funcionalidad sobre la clase C (la de la rúbrica)
| Caso de uso | GraphQL (microservicio 1) | REST (microservicio 2) |
|---|---|---|
| Insertar C (integridad referencial: el envío debe existir) | `addPaquete` | `POST /api/paquetes` |
| Eliminar C (previa búsqueda, muestra toda la información) | `paquetePorCodigo` + `deletePaquete` | `GET /{codigo}`, `DELETE /{codigo}` |
| Listar C con parámetro (grilla con C + origen y destino de A) | `paquetes`, `paquetesFiltrados(envioCodigo, descripcion)` | `GET /api/paquetes?envioCodigo=&descripcion=` |
| Actualizar C (previa búsqueda, muestra toda la información) | `paquetePorCodigo` + `updatePaquete` | `PUT /{codigo}` |
| Consulta C con parámetro (un solo objeto) | `paquetePorCriterios(codigo, envioCodigo, descripcion)` | `GET /buscar?...` |

El cliente solo habla con el microservicio 1; el microservicio 2 le es transparente. Las validaciones (obligatorios, peso > 0, unidades ≥ 1, formato de fecha) viven en el microservicio 2; la existencia del envío la valida el microservicio 1.

## Funcionalidad sobre las clases A y B (CRUD en el microservicio 1)
Mismo patrón que C (GraphQL → servicio → repositorio), pero se guardan directamente en `envios_db`.

| Caso de uso | A `EnvioNacional` | B `Seguimiento` |
|---|---|---|
| Insertar | `addEnvio` | `addSeguimiento` (el envío debe existir) |
| Eliminar (previa búsqueda) | `envioPorCodigo` + `deleteEnvio` (rechaza si tiene seguimientos o paquetes) | `seguimientoPorCodigo` + `deleteSeguimiento` |
| Listar (con filtro) | `envios`, `enviosFiltrados(origen, destino)` | `seguimientos`, `seguimientosFiltrados(envioCodigo, ubicacion)` |
| Actualizar (previa búsqueda) | `envioPorCodigo` + `updateEnvio` | `seguimientoPorCodigo` + `updateSeguimiento` (el envío no cambia) |
| Consulta (un solo objeto) | `envioPorCriterios(codigo, origen, destino)` | `seguimientoPorCriterios(codigo, envioCodigo, ubicacion)` |

## Control de la base de datos
Cada microservicio controla su propia base MongoDB desde el código, no la deja a merced del primer insert:
- **Interfaces de repositorio** (`repositorio/`, Spring Data): `RepositorioPaquete` (C), `RepositorioEnvioNacional` (A) y `RepositorioSeguimiento` (B) extienden `MongoRepository`; Spring genera la implementación. Los servicios solo dependen de estas interfaces y aplican reglas de negocio; la búsqueda con filtros opcionales de C está en el fragmento `ConsultasPaquete`.
- **`InicializadorBaseDatos`** (al arrancar, idempotente): crea las colecciones explícitamente (`paquetes`; `envios` y `seguimientos`), les aplica un **esquema de validación `$jsonSchema`** (obligatorios, tipos, `peso > 0`, `unidades ≥ 1`, `precio > 0`, código postal 1..999999…) con `validationLevel=strict` y `validationAction=error`, y crea índices por `envioCodigo`.
- **Llave primaria única** (`_id` = código) y **inserción atómica**: un código duplicado lo rechaza MongoDB (`DuplicateKeyException` → HTTP 409 / error GraphQL), sin condiciones de carrera.
- **Integridad referencial C → A** (entre bases distintas, MongoDB no tiene claves foráneas): la valida el microservicio 1 antes de insertar.

## Cliente (una ventana por caso de uso)
Menús **Envio**, **Seguimiento** y **Paquete**, cada uno con Adicionar, Consultar, Listar, Actualizar, Eliminar. Menú **Ayuda → Acerca de...** con integrantes y versión.

## Cómo ejecutar
1. MongoDB en `localhost:27017`. Variables opcionales (incluya el nombre de la base en la URI; son **distintas** para que cada microservicio tenga su base): `MONGODB_URI_ENVIOS`, `MONGODB_URI_PAQUETES`.
2. `cd PaqueteServicio && mvn spring-boot:run` (puerto 8082)
3. `cd EnvioServidor && mvn spring-boot:run` (puerto 8081; GraphiQL en `/graphiql`)
4. Abrir `EnvioCliente/EnvioCliente.slnx` en Visual Studio y ejecutar. Para probar use los envíos `E1`, `E2`, `E3` (o cree uno desde el menú Envio).
# ultima-entrega-diseno-de-soluciones
# 3-proyecto-diseno-de-soluciones
