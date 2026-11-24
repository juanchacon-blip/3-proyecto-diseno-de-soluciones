using System.Threading.Tasks;
using EnvioCliente.model;
using EnvioCliente.observer;
using EnvioCliente.servicios;

namespace EnvioCliente.controller
{
    /// <summary>
    /// Controlador (MVC) de la clase A (envios). Singleton. Consume el servicio web GraphQL.
    /// Tras cada cambio avisa a los observadores (las ventanas Listar se refrescan solas).
    /// </summary>
    public sealed class EnvioController
    {
        private static readonly EnvioController instancia = new EnvioController();

        private readonly IEnvioGateway gateway = new EnvioGatewayGraphQL();

        private EnvioController() { }

        public static EnvioController Instance
        {
            get { return instancia; }
        }

        // ---------- Consultas ----------

        public Task<EnvioData[]> ListarAsync()
        {
            return gateway.ListarAsync();
        }

        public Task<EnvioData[]> FiltrarAsync(string origen, string destino)
        {
            return gateway.FiltrarAsync(origen, destino);
        }

        public Task<EnvioData> BuscarPorCodigoAsync(string codigo)
        {
            return gateway.BuscarPorCodigoAsync(codigo);
        }

        public Task<EnvioData> BuscarPorCriteriosAsync(string codigo, string origen, string destino)
        {
            return gateway.BuscarPorCriteriosAsync(codigo, origen, destino);
        }

        // ---------- Operaciones que modifican datos ----------

        public async Task AdicionarAsync(EnvioInput input)
        {
            await gateway.AdicionarAsync(input);

            EnviosSubject.Instance.Notificar();
        }

        public async Task ActualizarAsync(EnvioInput input)
        {
            await gateway.ActualizarAsync(input);

            EnviosSubject.Instance.Notificar();
        }

        public async Task EliminarAsync(string codigo)
        {
            await gateway.EliminarAsync(codigo);

            EnviosSubject.Instance.Notificar();
        }
    }
}
