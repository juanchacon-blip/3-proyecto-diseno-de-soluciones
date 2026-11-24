using System;
using System.Threading.Tasks;
using EnvioCliente.model;

namespace EnvioCliente.servicios
{
    /// <summary>Acceso a los envios mediante el servicio web GraphQL.</summary>
    public sealed class EnvioGatewayGraphQL : IEnvioGateway
    {
        private const string Campos =
            "codigo origen destino precio fechaSalida departamentoDestino codigoPostalNacional";

        private readonly ServicioGraphQL servicio = ServicioGraphQL.Instance;

        public async Task<EnvioData[]> ListarAsync()
        {
            return await servicio.EjecutarAsync<EnvioData[]>(
                       "query { envios { " + Campos + " } }", null, "envios")
                   ?? new EnvioData[0];
        }

        public async Task<EnvioData[]> FiltrarAsync(string origen, string destino)
        {
            return await servicio.EjecutarAsync<EnvioData[]>(
                       "query($origen: String, $destino: String) { " +
                       "enviosFiltrados(origen: $origen, destino: $destino) { " +
                       Campos + " } }",
                       new { origen = Limpiar(origen), destino = Limpiar(destino) },
                       "enviosFiltrados")
                   ?? new EnvioData[0];
        }

        public Task<EnvioData> BuscarPorCodigoAsync(string codigo)
        {
            return servicio.EjecutarAsync<EnvioData>(
                "query($codigo: String!) { envioPorCodigo(codigo: $codigo) { " + Campos + " } }",
                new { codigo = Limpiar(codigo) }, "envioPorCodigo");
        }

        public Task<EnvioData> BuscarPorCriteriosAsync(string codigo, string origen, string destino)
        {
            return servicio.EjecutarAsync<EnvioData>(
                "query($codigo: String, $origen: String, $destino: String) { " +
                "envioPorCriterios(codigo: $codigo, origen: $origen, destino: $destino) { " +
                Campos + " } }",
                new { codigo = Limpiar(codigo), origen = Limpiar(origen), destino = Limpiar(destino) },
                "envioPorCriterios");
        }

        public async Task AdicionarAsync(EnvioInput input)
        {
            var creado = await servicio.EjecutarAsync<EnvioData>(
                "mutation($input: EnvioInput!) { addEnvio(input: $input) { " + Campos + " } }",
                new { input = input }, "addEnvio");

            if (creado == null)
            {
                throw new Exception("No se pudo adicionar el envio.");
            }
        }

        public async Task ActualizarAsync(EnvioInput input)
        {
            var actualizado = await servicio.EjecutarAsync<EnvioData>(
                "mutation($input: EnvioInput!) { updateEnvio(input: $input) { " + Campos + " } }",
                new { input = input }, "updateEnvio");

            if (actualizado == null)
            {
                throw new Exception("El envio ya no existe.");
            }
        }

        public async Task EliminarAsync(string codigo)
        {
            var eliminado = await servicio.EjecutarAsync<EnvioData>(
                "mutation($codigo: String!) { deleteEnvio(codigo: $codigo) { " + Campos + " } }",
                new { codigo = Limpiar(codigo) }, "deleteEnvio");

            if (eliminado == null)
            {
                throw new Exception("El envio ya no existe.");
            }
        }

        private static string Limpiar(string valor)
        {
            return (valor ?? "").Trim();
        }
    }
}
