using System.Text.Json.Serialization;

namespace EnvioCliente.model
{
    // Envio tal como lo devuelve el servidor (GraphQL).
    public class EnvioData
    {
        [JsonPropertyName("codigo")]
        public string codigo { get; set; }

        [JsonPropertyName("origen")]
        public string origen { get; set; }

        [JsonPropertyName("destino")]
        public string destino { get; set; }

        [JsonPropertyName("precio")]
        public double precio { get; set; }

        [JsonPropertyName("fechaSalida")]
        public string fechaSalida { get; set; }

        [JsonPropertyName("departamentoDestino")]
        public string departamentoDestino { get; set; }

        [JsonPropertyName("codigoPostalNacional")]
        public int? codigoPostalNacional { get; set; }
    }

    // Datos que se envian al servidor: variable "input" (GraphQL).
    public class EnvioInput
    {
        [JsonPropertyName("codigo")]
        public string codigo { get; set; }

        [JsonPropertyName("origen")]
        public string origen { get; set; }

        [JsonPropertyName("destino")]
        public string destino { get; set; }

        [JsonPropertyName("precio")]
        public double precio { get; set; }

        [JsonPropertyName("fechaSalida")]
        public string fechaSalida { get; set; }

        [JsonPropertyName("departamentoDestino")]
        public string departamentoDestino { get; set; }

        [JsonPropertyName("codigoPostalNacional")]
        public int? codigoPostalNacional { get; set; }
    }
}
