using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Raza 
{
    int codigo;
    E_Razas nombre;
    int edadMaxima;
    int tamañoMaximo;
    int tamañoMinimo;
    int velocidad;
    E_Alienamiento alienamiento;
    Dictionary<E_Caracteristicas, int> mejoraCaracteristicas;
    List<E_Habilidades> habilidades;
    List<Atributo> atributos;
    List<Subraza> subrazas;

    public Raza()
    {
        Nombre = E_Razas.ELFO;
        TamañoMaximo = 190;//medida en cm
        TamañoMinimo = 140;
        Velocidad = 30;
        Habilidades = new List<E_Habilidades>();
        Atributos = new List<Atributo>();
        Subraza = new List<Subraza>();
        MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        EdadMaxima = 30;
        Alienamiento = E_Alienamiento.NEUTRAL;
    }
    public Raza(E_Razas nombre, int tamañoMaximo, int tamañoMinimo, int velocidad, List<E_Habilidades> habilidades, List<Atributo> atributos, List<Subraza> subrazas, Dictionary<E_Caracteristicas, int> mejoraCaracteristicas, int edadMaxima, E_Alienamiento alienamiento)
    {
        Nombre = nombre;
        TamañoMaximo = tamañoMaximo;
        TamañoMinimo = tamañoMinimo;
        Velocidad = velocidad;
        Habilidades = habilidades;
        Atributos = atributos;
        Subraza = subrazas;
        MejoraCaracteristicas = mejoraCaracteristicas;
        EdadMaxima = edadMaxima;
        Alienamiento = alienamiento;
    }

    public E_Razas Nombre { get => nombre; set => nombre = value; }
    public int TamañoMaximo { get => tamañoMaximo; set => tamañoMaximo = value; }
    public int TamañoMinimo { get => tamañoMinimo; set => tamañoMinimo = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public List<E_Habilidades> Habilidades { get => habilidades; set => habilidades = value; }
    public List<Atributo> Atributos { get => atributos; set => atributos = value; }
    public List<Subraza> Subraza { get => subrazas; set => subrazas = value; }
    public Dictionary<E_Caracteristicas, int> MejoraCaracteristicas { get => mejoraCaracteristicas; set => mejoraCaracteristicas = value; }
    public int EdadMaxima { get => edadMaxima; set => edadMaxima = value; }
    public E_Alienamiento Alienamiento { get => alienamiento; set => alienamiento = value; }

    public bool Equals(Raza raza)
    {
        return nombre == raza.nombre &&
               tamañoMaximo == raza.tamañoMaximo &&
               tamañoMinimo == raza.tamañoMinimo &&
               velocidad == raza.velocidad &&
               EqualityComparer<Dictionary<E_Caracteristicas, int>>.Default.Equals(mejoraCaracteristicas, raza.mejoraCaracteristicas) &&
               EqualityComparer<List<E_Habilidades>>.Default.Equals(habilidades, raza.habilidades) &&
               EqualityComparer<List<Atributo>>.Default.Equals(atributos, raza.atributos) &&
               EqualityComparer<List<Subraza>>.Default.Equals(subrazas, raza.subrazas);
    }

    public override string ToString()
    {
        string valor = "";
        
        valor+= "Nombre: "+nombre.ToString() +"\n";
        valor += "Edad Maxima: " + edadMaxima.ToString() + "\n";
        valor += "Tamaño Maximo: " + tamañoMaximo.ToString()+ "\n";
        valor += "Tamaño Minimo: " + tamañoMinimo.ToString()+ "\n";
        valor += "Velocidad: " + velocidad.ToString()+ "\n";


        valor += "Mejora Caracteristicas: {" + "\n";
        foreach (E_Caracteristicas caracteristica in mejoraCaracteristicas.Keys)
        {
            valor += caracteristica.ToString() + " " + mejoraCaracteristicas[caracteristica].ToString() + "\n";
        }
        /* foreach (KeyValuePair<E_Caracteristicas,int> value in mejoraCaracteristicas )Segundo metodo
         {
             valor += value.Key.ToString()+ value.Value.ToString() + "\n";
         }*/
        valor += "}" + "\n";
        valor += "Habilidades: {" + "\n";
        foreach(E_Habilidades habilidad in habilidades)
        {
            valor += habilidad.ToString()+"\n";
        }
        valor += "}" + "\n";
        valor += "Atributos: {" + "\n";
        foreach (Atributo atributo in atributos)
        {
            valor += atributo.ToString()+"\n";
        }
        valor += "}" + "\n";
        valor += "SubRazas: {" + "\n";
        foreach (Subraza subraza in subrazas)
        {
            valor += subraza.ToString()+"\n";
        }
        valor += "}" + "\n";

        return valor;
    }
}
