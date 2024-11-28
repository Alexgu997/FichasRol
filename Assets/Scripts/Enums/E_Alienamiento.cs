using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Alienamiento 
{
  MALVADO,BUENO,LEGAL,CAOTICO,CAOTICO_MALVADO,CAOTICO_NEUTRAL,CAOTICO_BUENO,NEUTRAL_MALVADO,NEUTRAL, NEUTRAL_BUENO,LEGAL_MALVADO,LEGAL_NEUTRAL,LEGAL_BUENO
}
