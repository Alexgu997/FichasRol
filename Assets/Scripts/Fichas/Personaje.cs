using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Personaje 
{
    Raza raza;
    Subraza subraza;
    Clase clase;
    int nivel;//nivel de personaje min 1 y maximo 20
    string nombrePersonaje;
    string nombreJugador;
    Transfondo transfondo;
    E_Alienamiento alienamiento;
    int bonificadorCompetencia;//min 1 a 6
    int puntosExperiencia;//min 0 a 355,000
    List<E_Competencias> competencias;//lista de competencias y idiomas
    int valorCA;//valor clase de armadura
    int valorIniciativa;
    Caracteristicas caracteristicas;
    Habilidades habilidades;
    Inventario inventario;
    RasgosDescriptivos rasgosDescriptivos;
    Magia magia;
    bool usaMagia;
    List<Atributo> atributos;
    Caracteristicas tiradasSalvacion;

    public Personaje()
    {
        this.Raza = new Raza();
        this.Subraza = Raza.Subraza.Count==0?null: Raza.Subraza.First();
        this.Clase = new Clase();
        this.Nivel = 1;
        this.NombrePersonaje = "";
        this.NombreJugador = "";
        this.Transfondo = new Transfondo();
        this.Alienamiento = E_Alienamiento.NEUTRAL;
        this.BonificadorCompetencia = 1;
        this.PuntosExperiencia = 0;
        this.Competencias = new List<E_Competencias>();
        this.ValorCA = 10;
        this.ValorIniciativa = 0;
        this.Caracteristicas = new Caracteristicas() ;
        this.Habilidades = new Habilidades();
        this.Inventario = new Inventario();
        this.RasgosDescriptivos = new RasgosDescriptivos();
        this.Magia = new Magia();
        this.UsaMagia = false;
        this.Atributos = new List<Atributo>();
        this.TiradasSalvacion = new Caracteristicas();
    }

    public Personaje(Raza raza,Subraza subraza ,Clase clase, int nivel, string nombrePersonaje, string nombreJugador, Transfondo transfondo, E_Alienamiento alienamiento, int bonificadorCompetencia, int puntosExperiencia, List<E_Competencias> competencias, int valorCA, int valorIniciativa, Caracteristicas caracteristicas, Habilidades habilidades, Inventario inventario, RasgosDescriptivos rasgosDescriptivos, Magia magia, bool usaMagia, List<Atributo> atributos, Caracteristicas tiradasSalvacion)
    {
        this.Raza = raza;
        this.Subraza = subraza;
        this.Clase = clase;
        this.Nivel = nivel;
        this.NombrePersonaje = nombrePersonaje;
        this.NombreJugador = nombreJugador;
        this.Transfondo = transfondo;
        this.Alienamiento = alienamiento;
        this.BonificadorCompetencia = bonificadorCompetencia;
        this.PuntosExperiencia = puntosExperiencia;
        this.Competencias = competencias;
        this.ValorCA = valorCA;
        this.ValorIniciativa = valorIniciativa;
        this.Caracteristicas = caracteristicas;
        this.Habilidades = habilidades;
        this.Inventario = inventario;
        this.RasgosDescriptivos = rasgosDescriptivos;
        this.Magia = magia;
        this.UsaMagia = usaMagia;
        this.Atributos = atributos;
        this.TiradasSalvacion = tiradasSalvacion;
    }

    public Raza Raza { get => raza; set => raza = value; }
    public Subraza Subraza 
    { 
        get => subraza; 
        set
        { if (value != null) 
            { 
                subraza = value; 
            } 
        }  
    }
    public Clase Clase { get => clase; set => clase = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public string NombrePersonaje { get => nombrePersonaje; set => nombrePersonaje = value; }
    public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
    public Transfondo Transfondo { get => transfondo; set => transfondo = value; }
    public E_Alienamiento Alienamiento { get => alienamiento; set => alienamiento = value; }
    public int BonificadorCompetencia { get => bonificadorCompetencia; set => bonificadorCompetencia = value; }
    public int PuntosExperiencia { get => puntosExperiencia; set => puntosExperiencia = value; }
    public List<E_Competencias> Competencias { get => competencias; set => competencias = value; }
    public int ValorCA { get => valorCA; set => valorCA = value; }
    public int ValorIniciativa { get => valorIniciativa; set => valorIniciativa = value; }
    public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    public Habilidades Habilidades { get => habilidades; set => habilidades = value; }
    public Inventario Inventario { get => inventario; set => inventario = value; }
    public RasgosDescriptivos RasgosDescriptivos { get => rasgosDescriptivos; set => rasgosDescriptivos = value; }
    public Magia Magia { get => magia; set => magia = value; }
    public bool UsaMagia { get => usaMagia; set => usaMagia = value; }
    public List<Atributo> Atributos { get => atributos; set => atributos = value; }
    public Caracteristicas TiradasSalvacion { get => tiradasSalvacion; set => tiradasSalvacion = value; }
   
}
