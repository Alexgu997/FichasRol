using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picaro : Clase
{
    int cantAtaqueFurtivo;
    E_TiposDados ataqueFurtivo;
    
    public Picaro() :base()
    {
        NivelClase = 1;
        Nombre = E_Clases.PICARO;
        DadosSubidaNivel = E_TiposDados.D6;
        Competencias = new List<E_Competencias>();
        TiradasSalvacion = new List<E_Caracteristicas>();
        AptitudMagica = E_Caracteristicas.INTELIGENCIA;
        PuedeUsarMagia = false;
        EquipoOpcional = new Dictionary<string, List<Objeto>>();
        EquipoInicial = new List<Objeto>();
        TiradasSalvacion.Add(E_Caracteristicas.INTELIGENCIA);
        TiradasSalvacion.Add(E_Caracteristicas.DESTREZA);
        CargarSubidasNivel();
        Especializaciones.Add(E_Especializacion.LADRON);
        Especializaciones.Add(E_Especializacion.EMBAUCADOR_ARCANO);
        Especializaciones.Add(E_Especializacion.ASESINO);
    }

    public Picaro(int cantAtaqueFurtivo, E_TiposDados ataqueFurtivo):base()
    {
        
        BonificacionCompetencia = 2;
        CantAtaqueFurtivo = cantAtaqueFurtivo;
        AtaqueFurtivo = ataqueFurtivo;
    }
    public override List<E_Especializacion> MostrarEspecializaciones()
    {
        return Especializaciones;
    }

    public override void SubirNivel()
    {
        NivelClase++;
        Picaro_SubidaNivel subidanueva = (Picaro_SubidaNivel)BuscarSubidaNivelActual();
        BonificacionCompetencia = subidanueva.BonificadorCompetenciaPorNivel;
        ataqueFurtivo = subidanueva.AtaqueFurtivo;
        cantAtaqueFurtivo = subidanueva.CantAtaqueFurtivo;
        Rasgos = subidanueva.Rasgos;
    }

    public override void CargarSubidasNivel()
    {
        Picaro_SubidaNivel subidaNivelCargado= new Picaro_SubidaNivel();
        #region Nivel1
        subidaNivelCargado.Clase = E_Clases.PICARO;
        subidaNivelCargado.NivelSubidaClase = 1;
        subidaNivelCargado.BonificadorCompetenciaPorNivel = 2;
        subidaNivelCargado.Rasgos.Add(new Atributo("Pericia", "A nivel 1,  escoge dos de tus competencias en habilidades, o bien solo una y tu competencia con las herramientasde ladr�n. Tu bonificador por competencia se duplica para cualquier prueba de caracter�stica que hagas utilizando cualquiera de las doscompetencias elegidas. A nivel 6 puedes elegir otras dos competencias (en habilidadeso con herramientasde ladr�n)y obtenereste beneficio para ellas."));
        subidaNivelCargado.Rasgos.Add(new Atributo("Ataque Furtivo", " A partir de nivel 1 sabes c�mo golpear sutilmente y aprovecharte de un enemigo distra�do. Una vez por turno, puedes infligir ld6 de da�o adicional a una criatura a la que impactes con un ataque en cuya tirada de ataque tuvieras ventaja. Este ataque debe haber sido hecho utilizando un arma sutil o a distancia. No necesitas tener ventaja en la tirada de ataque si otro enemigo del objetivo est� a 5 pies o menos de �l, dicho enemigo no est� incapacitado, y no sufres desventaja en la tirada de ataque. La cantidad de da�o adicional aumenta seg�n subes de nivel en esta clase, tal y como se indica en la columna �ataque furtivo� de la tabla del picaro."));
        subidaNivelCargado.Rasgos.Add(new Atributo("Jerga de ladrones", "Durante tu entrenamiento como picaro aprendiste la jerga de ladrones, una mezcla de dialecto, argot y c�digo secreto que te permite esconder mensajes en lo que parece una conversaci�n normal y corriente. �nicamente aquellas criaturas que conozcan la jerga de ladrones podr�n entender estos mensajes. Expresar un mensaje utilizando esta jerga precisa de cuatro veces el tiempo que tardar�as en comunicar la misma idea directamente. Adem�s, tambi�n comprendes un conjunto dese�ales y s�mbolos secretos que se usan para dejar mensajescortos y sencillos, como el hecho de que una zona sea peligrosa o el territorio de un gremio de ladrones,si hay o no bot�n cerca, o si los lugare�os de los alrededores son presas f�ciles o pueden proporcionar un piso franco para ladronesa la fuga."));
        #endregion Nivel1


        SubidasNivel.Add(subidaNivelCargado);
       
    }

    public override void CargarEquipoInicial()
    {
        List<Objeto> listaEquipoOpcional=new List<Objeto>();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(121));
        EquipoOpcional.Add("1A", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Clear();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(118));
        EquipoOpcional.Add("1B", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Clear();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(112));
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(118));
        EquipoOpcional.Add("1B", new List<Objeto>(listaEquipoOpcional));
    }
    public override void CargarHabilidades()
    {
        Habilidades.Add(E_Habilidades.ACROBACIAS);
        Habilidades.Add(E_Habilidades.ATLETISMO);
        Habilidades.Add(E_Habilidades.ENGA�O);
        Habilidades.Add(E_Habilidades.INTERPRETACION);
        Habilidades.Add(E_Habilidades.INTIMIDACION);
        Habilidades.Add(E_Habilidades.INVESTIGACION);
        Habilidades.Add(E_Habilidades.JUEGO_DE_MANOS);
        Habilidades.Add(E_Habilidades.PERCEPCION);
        Habilidades.Add(E_Habilidades.PERSPICACIA);
        Habilidades.Add(E_Habilidades.PERSUASION);
        Habilidades.Add(E_Habilidades.SIGILO);
    }

    public override void CargarTiradasSalvacion()
    {
        TiradasSalvacion.Add(E_Caracteristicas.DESTREZA);
        TiradasSalvacion.Add(E_Caracteristicas.INTELIGENCIA);
    }

    public override void CargarCompetencias()
    {
       
    }
    public int CantAtaqueFurtivo { get => cantAtaqueFurtivo; set => cantAtaqueFurtivo = value; }
    public E_TiposDados AtaqueFurtivo { get => ataqueFurtivo; set => ataqueFurtivo = value; }
}
