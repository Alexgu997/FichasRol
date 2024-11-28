using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Paquete : MonoBehaviour
{
    string nombre;
    int valor;
    List<Objeto> equipo;//Objeto y cantidad

    public Paquete(string nombre, int valor, List<Objeto> equipo)
    {
        this.Nombre = nombre;
        this.Valor = valor;
        this.Equipo = equipo;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Valor { get => valor; set => valor = value; }
    public List<Objeto> Equipo { get => equipo; set => equipo = value; }

    public  bool Equals(Paquete paquete)
    {
        return Nombre == paquete.Nombre &&
               Valor == paquete.Valor &&
               EqualityComparer<List<Objeto>>.Default.Equals(Equipo, paquete.Equipo);
    }
}
