using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Paquete : Objeto
{

    List<Objeto> equipo;//Objeto y cantidad

    public Paquete():base()
    {
        this.Equipo = new List<Objeto>();
    }

    public Paquete(string nombre, int valor, List<Objeto> equipo, E_Monedas tipoValor):base()
    {

        this.Equipo = equipo;

    }

    public List<Objeto> Equipo { get => equipo; set => equipo = value; }


    public override bool Equals(object obj)
    {
        Paquete objeto = obj as Paquete;
        return base.Equals(obj)&& objeto.Equipo==Equipo;
    }

    public override int GetHashCode()
    {
        base.GetHashCode();
        return HashCode.Combine(equipo);
    }

    public override string ToString()
    {
        string value= base.ToString();
        equipo.ForEach(x => value += x.ToString());

        return value;
    }
}
