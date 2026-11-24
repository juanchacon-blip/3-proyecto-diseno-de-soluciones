using System.Threading.Tasks;
using EnvioCliente.model;

namespace EnvioCliente.servicios
{
    /// <summary>
    /// Contrato de acceso al servidor para envios. Implementada con GraphQL; el controlador depende solo de esta interfaz.
    /// Las consultas devuelven null si no hay resultado; las operaciones que modifican datos
    /// lanzan Exception con un mensaje apto para el usuario si fallan.
    /// </summary>
    public interface IEnvioGateway
    {
        Task<EnvioData[]> ListarAsync();
        Task<EnvioData[]> FiltrarAsync(string origen, string destino);
        Task<EnvioData> BuscarPorCodigoAsync(string codigo);
        Task<EnvioData> BuscarPorCriteriosAsync(string codigo, string origen, string destino);
        Task AdicionarAsync(EnvioInput input);
        Task ActualizarAsync(EnvioInput input);
        Task EliminarAsync(string codigo);
    }
}
