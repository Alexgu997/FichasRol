using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Subraza 
{
   ENANO_DE_LAS_MONTAÑAS, ENANO_DE_LAS_COLINAS,ALTO_ELFO,DROW,ELFO_DE_LOS_BOSQUES,PIESLIGEROS,ROBUSTOS,GNOMO_DE_LOS_BOSQUES,GNOMO_DE_LAS_ROCAS,FORNIDO
}
