using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Habilidades 
{
   ATLETISMO,ACROBACIAS, CONOCIMIENTO_ARCANO,ENGAÑO,HISTORIA,INTERPRETACION,INTIMIDACION,JUEGO_DE_MANOS
   ,MEDICINA,NATURALEZA, PERCEPCION, PERSUASION,RELIGION,SIGILO,SUPERVIVENCIA,TRATO_CON_ANIMALES
}
