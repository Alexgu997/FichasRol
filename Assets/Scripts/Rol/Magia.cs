using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{
    List<Hechizo> conjurosConocidos;//int=0 Truco, ira de 0 a 9 incluidos
    E_Caracteristicas aptitudMagica;
    int bonificadorAtaqueConjuros;
    int tiradaSalvacionConjuros;
    List<E_Especializacion> especializaciones;
    int numHechizosPreparados;
    int numHechizosMaxConocidos;
    int numTrucosConocidos;
    List<Hechizo> conjurosPreparados;
    public Magia()
    {
        ConjurosConocidos =new List<Hechizo>();
        AptitudMagica = E_Caracteristicas.INTELIGENCIA;
        BonificadorAtaqueConjuros = 0;
        TiradaSalvacionConjuros = 0;
        Especializaciones = new List<E_Especializacion>();
        NumHechizosPreparados = 0;
        NumHechizosMaxConocidos = 0;
        NumTrucosConocidos = 0;
        ConjurosPreparados = new List<Hechizo>();
    }

    public Magia(List<Hechizo> conjurosConocidos, E_Caracteristicas aptitudMagica, int bonificadorAtaqueConjuros, int tiradaSalvacionConjuros, List<E_Especializacion> especializaciones, int numHechizosPreparados, int numHechizosMaxConocidos, int numTrucosConocidos, List<Hechizo> conjurosPreparados)
    {
        ConjurosConocidos = conjurosConocidos;
        AptitudMagica = aptitudMagica;
        BonificadorAtaqueConjuros = bonificadorAtaqueConjuros;
        TiradaSalvacionConjuros = tiradaSalvacionConjuros;
        Especializaciones = especializaciones;
        NumHechizosPreparados = numHechizosPreparados;
        NumHechizosMaxConocidos = numHechizosMaxConocidos;
        NumTrucosConocidos = numTrucosConocidos;
        ConjurosPreparados = conjurosPreparados;
    }

    public List<Hechizo> ConjurosConocidos { get => conjurosConocidos; set => conjurosConocidos = value; }
    public E_Caracteristicas AptitudMagica { get => aptitudMagica; set => aptitudMagica = value; }
    public int BonificadorAtaqueConjuros { get => bonificadorAtaqueConjuros; set => bonificadorAtaqueConjuros = value; }
    public int TiradaSalvacionConjuros { get => tiradaSalvacionConjuros; set => tiradaSalvacionConjuros = value; }
    public List<E_Especializacion> Especializaciones { get => especializaciones; set => especializaciones = value; }
    public int NumHechizosPreparados { get => numHechizosPreparados; set => numHechizosPreparados = value; }
    public int NumHechizosMaxConocidos { get => numHechizosMaxConocidos; set => numHechizosMaxConocidos = value; }
    public int NumTrucosConocidos { get => numTrucosConocidos; set => numTrucosConocidos = value; }
    public List<Hechizo> ConjurosPreparados { get => conjurosPreparados; set => conjurosPreparados = value; }

    public bool AgregarHechizoConocido(Hechizo hechizo) 
    {
        bool result = false;
        if (conjurosConocidos.Count < numHechizosMaxConocidos && !conjurosConocidos.Contains(hechizo))
        {
            result = true;
            conjurosConocidos.Add(hechizo);
        }
        return result;
    }
    public bool EliminarHechizoConocido(Hechizo hechizo)
    {
        bool result = false;
        if (conjurosConocidos.Contains(hechizo))
        {
            result = true;
            conjurosConocidos.Remove(hechizo);
        }
        return result;
    }

    public bool PrepararHechizo(Hechizo hechizo)
    {
        bool result = false;
        if (conjurosPreparados.Count < numHechizosPreparados&& !conjurosPreparados.Contains(hechizo))
        {
            result = true;
            conjurosPreparados.Add(hechizo);
            numHechizosPreparados++;
        }
        return result;
    }

    public bool QuitarHechizoPreparado(Hechizo hechizo)
    {
        bool result = false;
        if (conjurosPreparados.Contains(hechizo))
        {
            result = true;
            conjurosPreparados.Remove(hechizo);
            numHechizosPreparados--;

        }
        return result;
    }

    public void CalcularAptitudMagica(int bonificadorCompetencia,int caracteristicaAptitudMagica)
    {
        bonificadorAtaqueConjuros =  bonificadorCompetencia + caracteristicaAptitudMagica;
        tiradaSalvacionConjuros = 8 + bonificadorCompetencia + caracteristicaAptitudMagica;
    }

    public override bool Equals(object obj)
    {
        return obj is Magia magia &&
               base.Equals(obj) &&
               EqualityComparer<List<Hechizo>>.Default.Equals(conjurosConocidos, magia.conjurosConocidos) &&
               aptitudMagica == magia.aptitudMagica &&
               bonificadorAtaqueConjuros == magia.bonificadorAtaqueConjuros &&
               tiradaSalvacionConjuros == magia.tiradaSalvacionConjuros &&
               EqualityComparer<List<E_Especializacion>>.Default.Equals(especializaciones, magia.especializaciones) &&
               numHechizosPreparados == magia.numHechizosPreparados &&
               numHechizosMaxConocidos == magia.numHechizosMaxConocidos &&
               numTrucosConocidos == magia.numTrucosConocidos &&
               EqualityComparer<List<Hechizo>>.Default.Equals(conjurosPreparados, magia.conjurosPreparados);
    }
}
