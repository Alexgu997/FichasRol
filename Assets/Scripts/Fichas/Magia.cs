using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magia : MonoBehaviour
{
    List<Hechizo> conjurosConocidos;//int=0 Truco, ira de 0 a 9 incluidos
    E_Caracteristicas aptitudMagica;
    int bonificadorAtaqueConjuros;
    int tiradaSalvacionConjuros;
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
        NumHechizosPreparados = 0;
        NumHechizosMaxConocidos = 0;
        NumTrucosConocidos = 0;
        ConjurosPreparados = new List<Hechizo>();
    }

    public Magia(List<Hechizo> conjurosConocidos, E_Caracteristicas aptitudMagica, int bonificadorAtaqueConjuros, int tiradaSalvacionConjuros, int numHechizosPreparados, int numHechizosMaxConocidos, int numTrucosConocidos, List<Hechizo> conjurosPreparados)
    {
        ConjurosConocidos = conjurosConocidos;
        AptitudMagica = aptitudMagica;
        BonificadorAtaqueConjuros = bonificadorAtaqueConjuros;
        TiradaSalvacionConjuros = tiradaSalvacionConjuros;
        NumHechizosPreparados = numHechizosPreparados;
        NumHechizosMaxConocidos = numHechizosMaxConocidos;
        NumTrucosConocidos = numTrucosConocidos;
        ConjurosPreparados = conjurosPreparados;
    }

    public List<Hechizo> ConjurosConocidos { get => conjurosConocidos; set => conjurosConocidos = value; }
    public E_Caracteristicas AptitudMagica { get => aptitudMagica; set => aptitudMagica = value; }
    public int BonificadorAtaqueConjuros { get => bonificadorAtaqueConjuros; set => bonificadorAtaqueConjuros = value; }
    public int TiradaSalvacionConjuros { get => tiradaSalvacionConjuros; set => tiradaSalvacionConjuros = value; }
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
               numHechizosPreparados == magia.numHechizosPreparados &&
               numHechizosMaxConocidos == magia.numHechizosMaxConocidos &&
               numTrucosConocidos == magia.numTrucosConocidos &&
               EqualityComparer<List<Hechizo>>.Default.Equals(conjurosPreparados, magia.conjurosPreparados);
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(base.GetHashCode());
        hash.Add(conjurosConocidos);
        hash.Add(aptitudMagica);
        hash.Add(bonificadorAtaqueConjuros);
        hash.Add(tiradaSalvacionConjuros);
        hash.Add(numHechizosPreparados);
        hash.Add(numHechizosMaxConocidos);
        hash.Add(numTrucosConocidos);
        hash.Add(conjurosPreparados);
        return hash.ToHashCode();
    }
}
