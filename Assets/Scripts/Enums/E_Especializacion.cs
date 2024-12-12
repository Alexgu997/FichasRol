using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Especializacion
{
   LADRON,ASESINO, EMBAUCADOR_ARCANO,SIN_ASIGNACION
}
