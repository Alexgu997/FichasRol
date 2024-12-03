using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{
    Dictionary<int, List<Hechizo>> conjurosClase;//int=0 Truco, ira de 0 a 9 incluidos
    E_Caracteristicas aptitudMagica;
    int bonificadorAtaqueConjuros;
    int tiradaSalvacionConjuros;
    List<E_Especializacion> especializaciones;
    int numHechizosPreparados;
    int numHechizosMaxConocidos;
    int numTrucosConocidos;


    public void CalcularAptitudMagica(int bonificadorCompetencia,int caracteristicaAptitudMagica)
    {
        bonificadorAtaqueConjuros =  bonificadorCompetencia + caracteristicaAptitudMagica;
        tiradaSalvacionConjuros = 8 + bonificadorCompetencia + caracteristicaAptitudMagica;
    }
}
