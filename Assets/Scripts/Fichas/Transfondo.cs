using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfondo : MonoBehaviour
{
    E_Transfondos nombre;
    string rasgodePersonalidad;
    List<string> rasgosdePersonalidadrasgosdes;
    string ideal;
    List<string> ideales;
    string vinculo;
    List<string> vinculos;
    string defecto;
    List<string> defectos;
    Historia historia;
    string especialidad;
    List <E_Habilidades> habilidadesCompetentes;
    List<E_Competencias> competencias;
    List<Objeto> equipo;//objeto y cantidad

    public Transfondo()
    {
        Nombre = E_Transfondos.ACOLITO;
        RasgodePersonalidad = "";
        Ideal = "";
        Ideales = new List<string>();
        Vinculo = "";
        Defecto = "";
        Defectos = new List<string>();
        Historia = new Historia();
        especialidad = "";
        HabilidadesCompetentes = new List<E_Habilidades>();
        Competencias = new List<E_Competencias>();
        Equipo=new List<Objeto>();
    }

    public Transfondo(E_Transfondos nombre, string rasgodePersonalidad, List<string> rasgosdePersonalidadrasgosdes, string ideal, List<string> ideales, string vinculo, List<string> vinculos, string defecto, List<string> defectos, Historia historia, string especialidad, List<E_Habilidades> habilidadesCompetentes, List<E_Competencias> competencias, List<Objeto> equipo)
    {
        this.nombre = nombre;
        this.rasgodePersonalidad = rasgodePersonalidad;
        this.rasgosdePersonalidadrasgosdes = rasgosdePersonalidadrasgosdes;
        this.ideal = ideal;
        this.ideales = ideales;
        this.vinculo = vinculo;
        this.vinculos = vinculos;
        this.defecto = defecto;
        this.defectos = defectos;
        this.historia = historia;
        this.especialidad = especialidad;
        this.habilidadesCompetentes = habilidadesCompetentes;
        this.competencias = competencias;
        this.equipo = equipo;
    }

    public E_Transfondos Nombre { get => nombre; set => nombre = value; }
    public string RasgodePersonalidad { get => rasgodePersonalidad; set => rasgodePersonalidad = value; }
    public List<string> RasgosdePersonalidadrasgosdes { get => rasgosdePersonalidadrasgosdes; set => rasgosdePersonalidadrasgosdes = value; }
    public string Ideal { get => ideal; set => ideal = value; }
    public List<string> Ideales { get => ideales; set => ideales = value; }
    public string Vinculo { get => vinculo; set => vinculo = value; }
    public List<string> Vinculos { get => vinculos; set => vinculos = value; }
    public string Defecto { get => defecto; set => defecto = value; }
    public List<string> Defectos { get => defectos; set => defectos = value; }
    public Historia Historia { get => historia; set => historia = value; }
    public string Especialidad { get => especialidad; set => especialidad = value; }
    public List<E_Habilidades> HabilidadesCompetentes { get => habilidadesCompetentes; set => habilidadesCompetentes = value; }
    public List<E_Competencias> Competencias { get => competencias; set => competencias = value; }
    public List<Objeto> Equipo { get => equipo; set => equipo = value; }

    public  bool Equals(Transfondo transfondo)
    {
        return EqualityComparer<E_Transfondos>.Default.Equals(nombre, transfondo.nombre) &&
               rasgodePersonalidad == transfondo.rasgodePersonalidad &&
               EqualityComparer<List<string>>.Default.Equals(rasgosdePersonalidadrasgosdes, transfondo.rasgosdePersonalidadrasgosdes) &&
               ideal == transfondo.ideal &&
               EqualityComparer<List<string>>.Default.Equals(ideales, transfondo.ideales) &&
               vinculo == transfondo.vinculo &&
               EqualityComparer<List<string>>.Default.Equals(vinculos, transfondo.vinculos) &&
               defecto == transfondo.defecto &&
               EqualityComparer<List<string>>.Default.Equals(defectos, transfondo.defectos) &&
               EqualityComparer<Historia>.Default.Equals(historia, transfondo.historia) &&
               especialidad == transfondo.especialidad &&
               EqualityComparer<List<E_Habilidades>>.Default.Equals(habilidadesCompetentes, transfondo.habilidadesCompetentes) &&
               EqualityComparer<List<E_Competencias>>.Default.Equals(competencias, transfondo.competencias) &&
               EqualityComparer<List<Objeto>>.Default.Equals(equipo, transfondo.equipo);
    }
}
