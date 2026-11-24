using System.Text.Json.Serialization;

namespace EnvioCliente.model
{
    // Seguimiento tal como lo devuelve el servidor (GraphQL).
    public class SeguimientoData
    {
        [JsonPropertyName("codigo")]
        public string codigo { get; set; }

        [JsonPropertyName("envioCodigo")]
        public string envioCodigo { get; set; }

        [JsonPropertyName("ubicacion")]
        public string ubicacion { get; set; }

        [JsonPropertyName("orden")]
        public int orden { get; set; }

        [JsonPropertyName("distanciaKm")]
        public double distanciaKm { get; set; }

        [JsonPropertyName("fechaEvento")]
        public string fechaEvento { get; set; }

        [JsonPropertyName("confirmado")]
        public bool confirmado { get; set; }
    }

    // Datos que se envian al servidor: variable "input" (GraphQL).
    public class SeguimientoInput
    {
        [JsonPropertyName("codigo")]
        public string codigo { get; set; }

        [JsonPropertyName("envioCodigo")]
        public string envioCodigo { get; set; }

        [JsonPropertyName("ubicacion")]
        public string ubicacion { get; set; }

        [JsonPropertyName("orden")]
        public int orden { get; set; }

        [JsonPropertyName("distanciaKm")]
        public double distanciaKm { get; set; }

        [JsonPropertyName("fechaEvento")]
        public string fechaEvento { get; set; }

        [JsonPropertyName("confirmado")]
        public bool confirmado { get; set; }
    }
}
