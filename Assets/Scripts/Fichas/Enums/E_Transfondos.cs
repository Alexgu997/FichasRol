using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Transfondos
{
    ACOLITO,ANIMADOR,ARTESANO_GREMIAL,CHARLATAN,CRIMINAL,ERUDITO,HEROE_DEL_PUEBLO,HUERFANO,MARINERO,NOBLE,SALVAJE,SOLDADO
}
