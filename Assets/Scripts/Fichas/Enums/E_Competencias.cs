using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[JsonConverter(typeof(StringEnumConverter))]
public enum E_Competencias 
{
   ARMADURAS_LIGERAS,ARMADURAS_PESADAS,ARMADURAS_INTERMEDIAS,ARMAS_SIMPLES,ARMAS_MARCIALES,ARMAS_A_DISTANCIA_SIMPLES,ARMAS_A_DISTANCIA_MARCIALES,
    #region Objetos
    #region Armas
    BALLESTAS_DE_MANO, ESPADAS_CORTAS,ESPADAS_LARGAS,ESTOQUES,
    #endregion Armas
    #region Herramientas
    HERRAMIENTAS_DE_LADRON
    #endregion Herramientas
    #endregion Objetos
}
