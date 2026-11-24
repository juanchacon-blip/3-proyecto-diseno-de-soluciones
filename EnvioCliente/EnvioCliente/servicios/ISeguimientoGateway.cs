using System.Threading.Tasks;
using EnvioCliente.model;

namespace EnvioCliente.servicios
{
    /// <summary>
    /// Contrato de acceso al servidor para seguimientos. Implementada con GraphQL; el controlador depende solo de esta interfaz.
    /// Las consultas devuelven null si no hay resultado; las operaciones que modifican datos
    /// lanzan Exception con un mensaje apto para el usuario si fallan.
    /// </summary>
    public interface ISeguimientoGateway
    {
        Task<SeguimientoData[]> ListarAsync();
        Task<SeguimientoData[]> FiltrarAsync(string envioCodigo, string ubicacion);
        Task<SeguimientoData> BuscarPorCodigoAsync(string codigo);
        Task<SeguimientoData> BuscarPorCriteriosAsync(string codigo, string envioCodigo, string ubicacion);
        Task AdicionarAsync(SeguimientoInput input);
        Task ActualizarAsync(SeguimientoInput input);
        Task EliminarAsync(string codigo);
    }
}
