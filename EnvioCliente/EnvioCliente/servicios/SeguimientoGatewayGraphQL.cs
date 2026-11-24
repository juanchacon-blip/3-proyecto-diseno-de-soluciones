using System;
using System.Threading.Tasks;
using EnvioCliente.model;

namespace EnvioCliente.servicios
{
    /// <summary>Acceso a los seguimientos mediante el servicio web GraphQL.</summary>
    public sealed class SeguimientoGatewayGraphQL : ISeguimientoGateway
    {
        private const string Campos =
            "codigo envioCodigo ubicacion orden distanciaKm fechaEvento confirmado";

        private readonly ServicioGraphQL servicio = ServicioGraphQL.Instance;

        public async Task<SeguimientoData[]> ListarAsync()
        {
            return await servicio.EjecutarAsync<SeguimientoData[]>(
                       "query { seguimientos { " + Campos + " } }", null, "seguimientos")
                   ?? new SeguimientoData[0];
        }

        public async Task<SeguimientoData[]> FiltrarAsync(string envioCodigo, string ubicacion)
        {
            return await servicio.EjecutarAsync<SeguimientoData[]>(
                       "query($envioCodigo: String, $ubicacion: String) { " +
                       "seguimientosFiltrados(envioCodigo: $envioCodigo, ubicacion: $ubicacion) { " +
                       Campos + " } }",
                       new { envioCodigo = Limpiar(envioCodigo), ubicacion = Limpiar(ubicacion) },
                       "seguimientosFiltrados")
                   ?? new SeguimientoData[0];
        }

        public Task<SeguimientoData> BuscarPorCodigoAsync(string codigo)
        {
            return servicio.EjecutarAsync<SeguimientoData>(
                "query($codigo: String!) { seguimientoPorCodigo(codigo: $codigo) { " + Campos + " } }",
                new { codigo = Limpiar(codigo) }, "seguimientoPorCodigo");
        }

        public Task<SeguimientoData> BuscarPorCriteriosAsync(string codigo, string envioCodigo, string ubicacion)
        {
            return servicio.EjecutarAsync<SeguimientoData>(
                "query($codigo: String, $envioCodigo: String, $ubicacion: String) { " +
                "seguimientoPorCriterios(codigo: $codigo, envioCodigo: $envioCodigo, ubicacion: $ubicacion) { " +
                Campos + " } }",
                new { codigo = Limpiar(codigo), envioCodigo = Limpiar(envioCodigo), ubicacion = Limpiar(ubicacion) },
                "seguimientoPorCriterios");
        }

        public async Task AdicionarAsync(SeguimientoInput input)
        {
            var creado = await servicio.EjecutarAsync<SeguimientoData>(
                "mutation($input: SeguimientoInput!) { addSeguimiento(input: $input) { " + Campos + " } }",
                new { input = input }, "addSeguimiento");

            if (creado == null)
            {
                throw new Exception("No se pudo adicionar el seguimiento.");
            }
        }

        public async Task ActualizarAsync(SeguimientoInput input)
        {
            var actualizado = await servicio.EjecutarAsync<SeguimientoData>(
                "mutation($input: SeguimientoInput!) { updateSeguimiento(input: $input) { " + Campos + " } }",
                new { input = input }, "updateSeguimiento");

            if (actualizado == null)
            {
                throw new Exception("El seguimiento ya no existe.");
            }
        }

        public async Task EliminarAsync(string codigo)
        {
            var eliminado = await servicio.EjecutarAsync<SeguimientoData>(
                "mutation($codigo: String!) { deleteSeguimiento(codigo: $codigo) { " + Campos + " } }",
                new { codigo = Limpiar(codigo) }, "deleteSeguimiento");

            if (eliminado == null)
            {
                throw new Exception("El seguimiento ya no existe.");
            }
        }

        private static string Limpiar(string valor)
        {
            return (valor ?? "").Trim();
        }
    }
}
