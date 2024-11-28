using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Subraza
{
    E_Subraza nombre;
    Dictionary<E_Caracteristicas, int> mejoraCaracteristicas;
    List<Atributo> rasgos;
    public Subraza() 
    {
        this.Nombre = E_Subraza.ENANO_DE_LAS_MONTAÑAS;
        this.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        this.Rasgos = new List<Atributo>();
    }

    public Subraza(E_Subraza nombre, Dictionary<E_Caracteristicas, int> mejoraCaracteristicas, List<Atributo> rasgos)
    {
        this.Nombre = nombre;
        this.MejoraCaracteristicas = mejoraCaracteristicas;
        this.Rasgos = rasgos;
    }

    public E_Subraza Nombre { get => nombre; set => nombre = value; }
    public Dictionary<E_Caracteristicas, int> MejoraCaracteristicas { get => mejoraCaracteristicas; set => mejoraCaracteristicas = value; }
    public List<Atributo> Rasgos { get => rasgos; set => rasgos = value; }

    public  bool Equals(Subraza subraza)
    {
        return 
               nombre == subraza.nombre &&
               EqualityComparer<Dictionary<E_Caracteristicas, int>>.Default.Equals(mejoraCaracteristicas, subraza.mejoraCaracteristicas) &&
               EqualityComparer<List<Atributo>>.Default.Equals(rasgos, subraza.rasgos);
    }

    public override string ToString()
    {
        string value = "";

        value += "Subraza: " + Nombre + "\n";
        value += "Mejora Caracteristicas {\n";
        foreach (E_Caracteristicas caracteristica in mejoraCaracteristicas.Keys)
        {
            value +=  caracteristica.ToString() + " " + mejoraCaracteristicas[caracteristica].ToString() + "\n";
        }
        value += "}\n";
        value += "Atributos {\n";
        foreach(Atributo atributo in rasgos)
        {
            value += atributo.ToString() + "\n";
        }
        value += "}\n";
         return value;
    }
}
