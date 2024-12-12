using MimeKit.Cryptography;
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
    List<E_Habilidades> habilidades;
    E_Caracteristicas aptitudMagica;
    bool puedeUsarMagia;
    int bonificacionCompetencia;
    Dictionary<string, List<Objeto>> equipoOpcional;// es diccionario por las opciones del equipo al crear el personaje
    List<Objeto> equipoInicial;
    Dictionary<E_Caracteristicas, int> requisitoMulticlase;
    List<SubidaNivel> subidasNivel;
    List<E_Especializacion> especializaciones;
    E_Especializacion especializacion;
    List<Atributo> rasgos;
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
        Especializacion = E_Especializacion.SIN_ASIGNACION;
        Rasgos = rasgos;
        Especializaciones = new List<E_Especializacion>();
        SubidasNivel = new List<SubidaNivel>();
        Habilidades = new List<E_Habilidades>();
    }

    public Clase(int nivelClaseNuevo, E_Clases nombre, E_TiposDados dadosSubidaNivel, List<E_Competencias> competencias, List<E_Caracteristicas> tiradasSalvacion, E_Caracteristicas aptitudMagica, bool puedeUsarMagia, Dictionary<string, List<Objeto>> equipoOpcional, int nivelClase, List<Objeto> equipoInicial, int bonificacionCompetencia, List<E_Especializacion> especializaciones, E_Especializacion especializacion, List<Atributo> rasgos, List<SubidaNivel> subidasNivelNuevas, List<E_Habilidades> habilidades = null)
    {
        NivelClase = nivelClaseNuevo;
        Nombre = nombre;
        DadosSubidaNivel = dadosSubidaNivel;
        Competencias = competencias;
        TiradasSalvacion = tiradasSalvacion;
        AptitudMagica = aptitudMagica;
        PuedeUsarMagia = puedeUsarMagia;
        EquipoOpcional = equipoOpcional;
        EquipoInicial = equipoInicial;
        BonificacionCompetencia = bonificacionCompetencia;
        Especializacion = especializacion;
        Rasgos = rasgos;
        Especializaciones = especializaciones;
        SubidasNivel = subidasNivelNuevas;
        Habilidades = habilidades;
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
    public E_Especializacion Especializacion { get => especializacion; set => especializacion = value; }
    public List<Atributo> Rasgos { get => rasgos; set => rasgos = value; }
    public Dictionary<E_Caracteristicas, int> RequisitoMulticlase { get => requisitoMulticlase; set => requisitoMulticlase = value; }
    public List<E_Especializacion> Especializaciones { get => especializaciones; set => especializaciones = value; }
    public List<SubidaNivel> SubidasNivel { get => subidasNivel; set => subidasNivel = value; }
    public List<E_Habilidades> Habilidades { get => habilidades; set => habilidades = value; }

    public void ElegirEspecializacion(E_Especializacion nuevaEspecializacion)
    {
        Especializacion = nuevaEspecializacion;
    }
    public virtual List<E_Especializacion> MostrarEspecializaciones() 
    {

        return new List<E_Especializacion>();

    }


    public virtual void SubirNivel()
    {

    }

    public virtual void CargarSubidasNivel()
    {

    }



    public SubidaNivel BuscarSubidaNivelActual()
    {
        SubidaNivel subidaNueva=new SubidaNivel();
       foreach(SubidaNivel subida in subidasNivel)
        {
            if(subida.NivelSubidaClase==nivelClase)
            {
                subidaNueva = subida;
            }
        }
        return subidaNueva;
    }

    public virtual void CargarEquipoInicial()
    {

    }

   public virtual void CargarCompetencias()
    {

    }

    public virtual void CargarTiradasSalvacion()
    {

    }

    public virtual void CargarHabilidades()
    {

    }

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
