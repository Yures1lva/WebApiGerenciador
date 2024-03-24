using System.Text.Json.Serialization;

namespace WebApiGerenciador.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CargosEnum
    {
        Analista_de_suporte,
        Analista_de_desenvolvimento_jr,
        RH,
        Tech_lead,
    }
}
