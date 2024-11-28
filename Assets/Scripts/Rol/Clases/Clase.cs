using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase 
{
    E_Clases nombre;
    E_TiposDados dadosSubidaNivel;
    List<E_Competencias> competencias;
    List<E_Caracteristicas> tiradasSalvacion;
    E_Caracteristicas aptitudMagica;
    bool puedeUsarMagia;
    Dictionary<string, List<Objeto>> equipoInicial;
    Magia magia;
    Dictionary<E_Caracteristicas, int> requisitoMulticlase;
    int nivelClase;
    public Clase()
    {
        Nombre = E_Clases.BARBARO;
        DadosSubidaNivel = E_TiposDados.D4;
        Competencias = new List<E_Competencias>();
        TiradasSalvacion = new List<E_Caracteristicas>();
        AptitudMagica = E_Caracteristicas.INTELIGENCIA;
        PuedeUsarMagia = false;
        EquipoInicial = new Dictionary<string, List<Objeto>>();
        this.Magia = new Magia();
    }

    public Clase(E_Clases nombre, E_TiposDados dadosSubidaNivel, List<E_Competencias> competencias, List<E_Caracteristicas> tiradasSalvacion, E_Caracteristicas aptitudMagica, bool puedeUsarMagia, Dictionary<string, List<Objeto>> equipoInicial, Magia magia = null)
    {
        this.Nombre = nombre;
        this.DadosSubidaNivel = dadosSubidaNivel;
        this.Competencias = competencias;
        this.TiradasSalvacion = tiradasSalvacion;
        this.AptitudMagica = aptitudMagica;
        this.PuedeUsarMagia = puedeUsarMagia;
        this.EquipoInicial = equipoInicial;
        this.Magia = magia;
    }

    public E_Clases Nombre { get => nombre; set => nombre = value; }
    public E_TiposDados DadosSubidaNivel { get => dadosSubidaNivel; set => dadosSubidaNivel = value; }
    public List<E_Competencias> Competencias { get => competencias; set => competencias = value; }
    public List<E_Caracteristicas> TiradasSalvacion { get => tiradasSalvacion; set => tiradasSalvacion = value; }
    public E_Caracteristicas AptitudMagica { get => aptitudMagica; set => aptitudMagica = value; }
    public bool PuedeUsarMagia { get => puedeUsarMagia; set => puedeUsarMagia = value; }
    public Dictionary<string, List<Objeto>> EquipoInicial { get => equipoInicial; set => equipoInicial = value; }
    public Magia Magia { get => magia; set => magia = value; }

    public bool Equals(Clase clase)
    {
        return EqualityComparer<E_Clases>.Default.Equals(nombre, clase.nombre) &&
               dadosSubidaNivel == clase.dadosSubidaNivel &&
               EqualityComparer<List<E_Competencias>>.Default.Equals(competencias, clase.competencias) &&
               EqualityComparer<List<E_Caracteristicas>>.Default.Equals(tiradasSalvacion, clase.tiradasSalvacion) &&
               aptitudMagica == clase.aptitudMagica &&
               puedeUsarMagia == clase.puedeUsarMagia &&
               EqualityComparer<Dictionary<string, List<Objeto>>>.Default.Equals(equipoInicial, clase.equipoInicial)
               && Magia==clase.Magia;
    }

    public override string ToString()
    {
        string valor = "";

        valor = "Nombre" + Nombre.ToString() + "/n";

       return valor;
    }
}
