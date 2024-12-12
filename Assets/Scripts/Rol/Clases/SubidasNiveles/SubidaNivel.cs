using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubidaNivel 
{
    E_Clases clase;
    int nivelSubidaClase;
    int bonificadorCompetenciaPorNivel;
    List<Atributo> rasgos;
    int cantidadTrucos;
    int conjurosConocidos;
    int [] espaciosConjuros;
    public SubidaNivel()
    {
        Clase = E_Clases.BARBARO;
        nivelSubidaClase = 0;
        BonificadorCompetenciaPorNivel = 0;
        Rasgos = new List<Atributo>();
        CantidadTrucos = 0;
        ConjurosConocidos = 0;
        EspaciosConjuros= new int[9];//contar desde 0 pero el 0 sera 1
        
    }
    public SubidaNivel(E_Clases clase, int bonificadorCompetenciaPorNivel, List<Atributo> rasgos,int cantidadTrucosNuevos, int conjurosConocidosNuevos, int[] espaciosConjurosNuevos)
    {
        Clase = clase;
        nivelSubidaClase=1;
        BonificadorCompetenciaPorNivel = bonificadorCompetenciaPorNivel;
        Rasgos = rasgos;
        CantidadTrucos = cantidadTrucosNuevos;
        ConjurosConocidos = conjurosConocidosNuevos;
        EspaciosConjuros = EspaciosConjuros;
    }

    public E_Clases Clase { get => clase; set => clase = value; }
    public int BonificadorCompetenciaPorNivel { get => bonificadorCompetenciaPorNivel; set => bonificadorCompetenciaPorNivel = value; }
    public List<Atributo> Rasgos { get => rasgos; set => rasgos = value; }
    public int NivelSubidaClase { get => nivelSubidaClase; set => nivelSubidaClase = value; }
    public int CantidadTrucos { get => cantidadTrucos; set => cantidadTrucos = value; }
    public int ConjurosConocidos { get => conjurosConocidos; set => conjurosConocidos = value; }
    public int[] EspaciosConjuros { get => espaciosConjuros; set => espaciosConjuros = value; }

    public override bool Equals(object obj)
    {
        return obj is SubidaNivel nivel &&
               clase == nivel.clase &&
               nivelSubidaClase == nivel.nivelSubidaClase &&
               bonificadorCompetenciaPorNivel == nivel.bonificadorCompetenciaPorNivel &&
               EqualityComparer<List<Atributo>>.Default.Equals(Rasgos, nivel.Rasgos);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(clase, nivelSubidaClase, bonificadorCompetenciaPorNivel, Rasgos);
    }
}
