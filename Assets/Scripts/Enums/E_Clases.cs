using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Clases 
{
   BARBARO,BARDO,BRUJO,DRUIDA,GUERRERO,HECHICERO,MAGO,MONJE,PICARO,EXPLORADOR,PALADIN,CLERIGO,ARTIFICE,PISTOLERO
}
