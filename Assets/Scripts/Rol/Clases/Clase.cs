using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase 
{
    int nivelClase;
    E_Clases nombre;
    E_TiposDados dadosSubidaNivel;
    List<E_Competencias> competencias;
    List<E_Caracteristicas> tiradasSalvacion;
    E_Caracteristicas aptitudMagica;
    bool puedeUsarMagia;
    int bonificacionCompetencia;
    Dictionary<string, List<Objeto>> equipoOpcional;// es diccionario por las opciones del equipo al crear el personaje
    List<Objeto> equipoInicial;
    Dictionary<E_Caracteristicas, int> requisitoMulticlase;
    

    public Clase()
    {
        NivelClase = 1;
        Nombre = E_Clases.BARBARO;
        DadosSubidaNivel = E_TiposDados.D4;
        Competencias = new List<E_Competencias>();
        TiradasSalvacion = new List<E_Caracteristicas>();
        AptitudMagica = E_Caracteristicas.INTELIGENCIA;
        PuedeUsarMagia = false;
        EquipoOpcional = new Dictionary<string, List<Objeto>>();
        EquipoInicial = new List<Objeto>();
        BonificacionCompetencia = 2;
    }

    public Clase(E_Clases nombre, E_TiposDados dadosSubidaNivel, List<E_Competencias> competencias, List<E_Caracteristicas> tiradasSalvacion, E_Caracteristicas aptitudMagica, bool puedeUsarMagia, Dictionary<string, List<Objeto>> equipoOpcional, int nivelClase = 0, List<Objeto> equipoInicial = null, int bonificacionCompetencia = 0)
    {
        Nombre = nombre;
        DadosSubidaNivel = dadosSubidaNivel;
        Competencias = competencias;
        TiradasSalvacion = tiradasSalvacion;
        AptitudMagica = aptitudMagica;
        PuedeUsarMagia = puedeUsarMagia;
        EquipoOpcional = equipoOpcional;
        NivelClase = nivelClase;
        EquipoInicial = equipoInicial;
        BonificacionCompetencia = bonificacionCompetencia;
    }

    public E_Clases Nombre { get => nombre; set => nombre = value; }
    public E_TiposDados DadosSubidaNivel { get => dadosSubidaNivel; set => dadosSubidaNivel = value; }
    public List<E_Competencias> Competencias { get => competencias; set => competencias = value; }
    public List<E_Caracteristicas> TiradasSalvacion { get => tiradasSalvacion; set => tiradasSalvacion = value; }
    public E_Caracteristicas AptitudMagica { get => aptitudMagica; set => aptitudMagica = value; }
    public bool PuedeUsarMagia { get => puedeUsarMagia; set => puedeUsarMagia = value; }
    public Dictionary<string, List<Objeto>> EquipoOpcional { get => equipoOpcional; set => equipoOpcional = value; }
    public int NivelClase { get => nivelClase; set => nivelClase = value; }
    public List<Objeto> EquipoInicial { get => equipoInicial; set => equipoInicial = value; }
    public int BonificacionCompetencia { get => bonificacionCompetencia; set => bonificacionCompetencia = value; }

    public bool Equals(Clase clase)
    {
        return EqualityComparer<E_Clases>.Default.Equals(nombre, clase.nombre) &&
               dadosSubidaNivel == clase.dadosSubidaNivel &&
               EqualityComparer<List<E_Competencias>>.Default.Equals(competencias, clase.competencias) &&
               EqualityComparer<List<E_Caracteristicas>>.Default.Equals(tiradasSalvacion, clase.tiradasSalvacion) &&
               aptitudMagica == clase.aptitudMagica &&
               puedeUsarMagia == clase.puedeUsarMagia &&
               EqualityComparer<Dictionary<string, List<Objeto>>>.Default.Equals(equipoOpcional, clase.equipoOpcional);

    }

    public override string ToString()
    {
        string valor = "";

        valor = "Nombre" + Nombre.ToString() + "/n";

       return valor;
    }
}
