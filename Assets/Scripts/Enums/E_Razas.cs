using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Razas
{
   ELFO,ENANO,DRACONICO,HUMANO,ORCO,SEMIELFO,SEMIORCO,TIEFLING,FORJADO,MEDIANO,GNOMO
}


