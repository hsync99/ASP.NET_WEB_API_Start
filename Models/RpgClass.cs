using System.Text.Json.Serialization;

namespace rpgapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Cleric = 2,
        Mage = 3
    }
}