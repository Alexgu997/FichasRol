
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_TiposDados 
{
    D4,D6,D8,D10,D12,D20,D100
}
