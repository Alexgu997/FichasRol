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
        EspaciosConjuros= new int [9]{ 0, 0, 0, 0, 0, 0, 0, 0, 0 };//contar desde 0 pero el 0 sera 1
        
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

    public SubidaNivel (SubidaNivel subidaNivelNueva)
    {
        Clase = subidaNivelNueva.Clase;
        NivelSubidaClase = subidaNivelNueva.NivelSubidaClase;
        BonificadorCompetenciaPorNivel = subidaNivelNueva.bonificadorCompetenciaPorNivel;
        Rasgos =new List<Atributo>( subidaNivelNueva.Rasgos);
        CantidadTrucos = subidaNivelNueva.cantidadTrucos;
        ConjurosConocidos = subidaNivelNueva.ConjurosConocidos;
        EspaciosConjuros = subidaNivelNueva.EspaciosConjuros;
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

    public override string ToString()
    {
        string returnvalue = "";
        returnvalue += "Clase= " + Clase.ToString() + "\n";
        returnvalue += "Nivel=" + NivelSubidaClase.ToString() + "\n";
        returnvalue += "Bonificador Competencia=" + BonificadorCompetenciaPorNivel + "\n";
        returnvalue += "Rasgos=" + "\n";
        Rasgos.ForEach(x => returnvalue += x.ToString()+"\n");
        returnvalue +="Cantidad Trucos="+CantidadTrucos.ToString() +"\n";
        returnvalue += "Conjuros Conocidos=" + ConjurosConocidos.ToString() + "\n";
        returnvalue += "Espacios de conjuros=" +"\n";
        for(int i = 0;i<espaciosConjuros.Length;i++) { returnvalue+=espaciosConjuros[i].ToString()+"\n"; }
        return returnvalue;

    }
}
