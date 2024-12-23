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
    int alcance;//si el valor es 0 significa que es de toque el alcance
    bool requisitoVocal;
    bool requisitoSomatico;
    bool requisitoMaterial;
    List<string> componentes;
    int tiempolanzamiento;
    E_TiempoDeLanzamientoConjuro tipoLanzamientoHechizo;
    int duracion;//la duracion se basa en 
    E_TiempoDeLanzamientoConjuro tipoDuracion;
    bool concentracion;
    List<E_Clases> clasesAptas;
    public Hechizo()
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
        RequisitoVocal = false;
        RequisitoSomatico = false;
        RequisitoMaterial = false;
        TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        ClasesAptas = new List<E_Clases>();
    }

    public Hechizo(int codigo, string nombre, int nivel, E_EscuelasMagia escuelaMagica, string descripcion, int alcance, List<string> componentes, int tiempolanzamiento, E_TiempoDeLanzamientoConjuro tipoLanzamientoHechizo, int duracion, bool concentracion, E_Componentes[] requisitos, bool requisitoVocal, bool requisitoSomatico, bool requisitoMaterial, E_TiempoDeLanzamientoConjuro tipoDuracion, List<E_Clases> clasesAptas)
    {
        Codigo = codigo;
        Nombre = nombre;
        Nivel = nivel;
        EscuelaMagica = escuelaMagica;
        Descripcion = descripcion;
        Alcance = alcance;
        Componentes = componentes;
        Tiempolanzamiento = tiempolanzamiento;
        TipoLanzamientoHechizo = tipoLanzamientoHechizo;
        Duracion = duracion;
        Concentracion = concentracion;
        RequisitoVocal = requisitoVocal;
        RequisitoSomatico = requisitoSomatico;
        RequisitoMaterial = requisitoMaterial;
        TipoDuracion = tipoDuracion;
        ClasesAptas = clasesAptas;
    }

    public int Codigo { get => codigo; set => codigo = value>=0?value:0; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Nivel { get => nivel; set => SetNivel(value); }
    public E_EscuelasMagia EscuelaMagica { get => escuelaMagica; set => escuelaMagica = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Alcance { get => alcance; set => alcance = value; }
    public List<string> Componentes { get => componentes; set => componentes = value; }
    public int Tiempolanzamiento { get => tiempolanzamiento; set => tiempolanzamiento = value; }
    public E_TiempoDeLanzamientoConjuro TipoLanzamientoHechizo { get => tipoLanzamientoHechizo; set => tipoLanzamientoHechizo = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public bool Concentracion { get => concentracion; set => concentracion = value; }
    public bool RequisitoVocal { get => requisitoVocal; set => requisitoVocal = value; }
    public bool RequisitoSomatico { get => requisitoSomatico; set => requisitoSomatico = value; }
    public bool RequisitoMaterial { get => requisitoMaterial; set => requisitoMaterial = value; }
    public E_TiempoDeLanzamientoConjuro TipoDuracion { get => tipoDuracion; set => tipoDuracion = value; }
    public List<E_Clases> ClasesAptas { get => clasesAptas; set => clasesAptas = value; }

    private void SetNivel(int nivelNuevo)
    {
        if (nivelNuevo >= 0&&nivelNuevo<=9)
        {
            nivel = nivelNuevo;
        }else if (nivelNuevo > 9)
        {
            nivel = 9;
        }
        else
        {
            nivel = 0;
        }
    }


    public override bool Equals(object obj)
    {
        return obj is Hechizo hechizo &&
               codigo == hechizo.codigo &&
               nombre == hechizo.nombre &&
               nivel == hechizo.nivel &&
               escuelaMagica == hechizo.escuelaMagica &&
               descripcion == hechizo.descripcion &&
               alcance == hechizo.alcance &&
               requisitoVocal == hechizo.requisitoVocal &&
               requisitoSomatico == hechizo.requisitoSomatico &&
               requisitoMaterial == hechizo.requisitoMaterial &&
               EqualityComparer<List<string>>.Default.Equals(componentes, hechizo.componentes) &&
               tiempolanzamiento == hechizo.tiempolanzamiento &&
               tipoLanzamientoHechizo == hechizo.tipoLanzamientoHechizo &&
               duracion == hechizo.duracion &&
               TipoDuracion== hechizo.TipoDuracion &&
               concentracion == hechizo.concentracion&&
               clasesAptas==hechizo.clasesAptas;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(codigo);
        hash.Add(nombre);
        hash.Add(nivel);
        hash.Add(escuelaMagica);
        hash.Add(descripcion);
        hash.Add(alcance);
        hash.Add(requisitoVocal);
        hash.Add(requisitoSomatico);
        hash.Add(requisitoMaterial);
        hash.Add(componentes);
        hash.Add(tiempolanzamiento);
        hash.Add(tipoLanzamientoHechizo);
        hash.Add(duracion);
        hash.Add(concentracion);
        hash.Add(TipoDuracion);
        hash.Add(clasesAptas);
        return hash.ToHashCode();
    }

    public override string  ToString()
    {
        string resultado = "";

        return resultado;
    }
}
