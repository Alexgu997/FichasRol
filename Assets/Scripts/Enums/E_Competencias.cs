using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Competencias 
{
   ARMADURA_LIGERA,ARMADURA_PESADA,ARMADURA_INTERMEDIA,ARMAS_SIMPLES,ARMAS_MARCIALES,ARMAS_A_DISTANCIA_SIMPLES,ARMAS_A_DISTANCIA_MARCIALES,
}
