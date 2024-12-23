using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_TiempoDeLanzamientoConjuro
{
   ACCION,ACCION_ADICIONAL,HORA,MINUTO,INSTANTANEO,DIAS,ASALTO,REACCION
}
