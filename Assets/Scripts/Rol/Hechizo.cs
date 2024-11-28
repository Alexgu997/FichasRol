using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hechizo 
{
    int codigo;
    string nombre;
    int nivel;//0=truco
    E_EscuelasMagia escuelaMagica;
    string descripcion;
    int alcance;
    E_Componentes[] requisitos;
    List<string> componentes;
    int tiempolanzamiento;
    E_TiempoDeLanzamientoConjuro tipoLanzamientoHechizo;
    int duracion;
    bool concentracion;

    public Hechizo(E_Componentes[] requisitos)
    {
        this.codigo = 0;
        this.nombre = "";
        this.nivel = 0;
        this.escuelaMagica = E_EscuelasMagia.ABJURACION;
        this.descripcion = "";
        this.alcance = 0;
        this.componentes = new List<string>();
        this.tiempolanzamiento = 0;
        this.tipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        this.duracion = 0;
        this.concentracion = false;
        this.requisitos = new E_Componentes[3] ;
    }

    public Hechizo(int codigo, string nombre, int nivel, E_EscuelasMagia escuelaMagica, string descripcion, int alcance, List<string> componentes, int tiempolanzamiento, E_TiempoDeLanzamientoConjuro tipoLanzamientoHechizo, int duracion, bool concentracion, E_Componentes[] requisitos)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.nivel = nivel;
        this.escuelaMagica = escuelaMagica;
        this.descripcion = descripcion;
        this.alcance = alcance;
        this.componentes = componentes;
        this.tiempolanzamiento = tiempolanzamiento;
        this.tipoLanzamientoHechizo = tipoLanzamientoHechizo;
        this.duracion = duracion;
        this.concentracion = concentracion;
        this.requisitos = requisitos;
    }

    public int Codigo { get => codigo; set => codigo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public E_EscuelasMagia EscuelaMagica { get => escuelaMagica; set => escuelaMagica = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Alcance { get => alcance; set => alcance = value; }
    public List<string> Componentes { get => componentes; set => componentes = value; }
    public int Tiempolanzamiento { get => tiempolanzamiento; set => tiempolanzamiento = value; }
    public E_TiempoDeLanzamientoConjuro TipoLanzamientoHechizo { get => tipoLanzamientoHechizo; set => tipoLanzamientoHechizo = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public bool Concentracion { get => concentracion; set => concentracion = value; }
    public E_Componentes[] Requisitos { get =>requisitos; set => requisitos = value; }

    public override bool Equals(object obj)
    {
        return obj is Hechizo hechizo &&
               codigo == hechizo.codigo &&
               nombre == hechizo.nombre &&
               nivel == hechizo.nivel &&
               escuelaMagica == hechizo.escuelaMagica &&
               descripcion == hechizo.descripcion &&
               alcance == hechizo.alcance &&
               componentes ==hechizo.componentes &&
               tiempolanzamiento == hechizo.tiempolanzamiento &&
               tipoLanzamientoHechizo == hechizo.tipoLanzamientoHechizo &&
               duracion == hechizo.duracion &&
               concentracion == hechizo.concentracion;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Codigo);
        hash.Add(Nombre);
        hash.Add(Nivel);
        hash.Add(EscuelaMagica);
        hash.Add(Descripcion);
        hash.Add(Alcance);
        hash.Add(Componentes);
        hash.Add(Tiempolanzamiento);
        hash.Add(TipoLanzamientoHechizo);
        hash.Add(Duracion);
        hash.Add(Concentracion);
        hash.Add(Requisitos);
        return hash.ToHashCode();
    }

    public override string  ToString()
    {
        string resultado = "";

        return resultado;
    }
}
