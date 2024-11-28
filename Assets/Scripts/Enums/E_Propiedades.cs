using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Propiedades 
{
    A_DOS_MANOS,ALCANCE,ARROJADIZA,ESPECIAL,GRAN_ALCANCE,
    LIGERA,MUNICION,PESADA,RECARGA,SUTIL,VERSATIL, 
    PERFORANTE, CONTUNDENTE, CORTANTE
}
