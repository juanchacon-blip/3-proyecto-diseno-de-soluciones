using System.Threading.Tasks;
using EnvioCliente.model;
using EnvioCliente.observer;
using EnvioCliente.servicios;

namespace EnvioCliente.controller
{
    /// <summary>
    /// Controlador (MVC) de la clase B (seguimientos). Singleton. Consume el servicio web GraphQL.
    /// Tras cada cambio avisa a los observadores (las ventanas Listar se refrescan solas).
    /// </summary>
    public sealed class SeguimientoController
    {
        private static readonly SeguimientoController instancia = new SeguimientoController();

        private readonly ISeguimientoGateway gateway = new SeguimientoGatewayGraphQL();

        private SeguimientoController() { }

        public static SeguimientoController Instance
        {
            get { return instancia; }
        }

        // ---------- Consultas ----------

        public Task<SeguimientoData[]> ListarAsync()
        {
            return gateway.ListarAsync();
        }

        public Task<SeguimientoData[]> FiltrarAsync(string envioCodigo, string ubicacion)
        {
            return gateway.FiltrarAsync(envioCodigo, ubicacion);
        }

        public Task<SeguimientoData> BuscarPorCodigoAsync(string codigo)
        {
            return gateway.BuscarPorCodigoAsync(codigo);
        }

        public Task<SeguimientoData> BuscarPorCriteriosAsync(string codigo, string envioCodigo, string ubicacion)
        {
            return gateway.BuscarPorCriteriosAsync(codigo, envioCodigo, ubicacion);
        }

        // ---------- Operaciones que modifican datos ----------

        public async Task AdicionarAsync(SeguimientoInput input)
        {
            await gateway.AdicionarAsync(input);

            EnviosSubject.Instance.Notificar();
        }

        public async Task ActualizarAsync(SeguimientoInput input)
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
