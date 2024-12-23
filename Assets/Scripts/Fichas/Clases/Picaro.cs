using System;
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
        DadosSubidaNivel = E_TiposDados.D8;
        Competencias = new List<E_Competencias>();
        TiradasSalvacion = new List<E_Caracteristicas>();
        AptitudMagica = E_Caracteristicas.INTELIGENCIA;
        PuedeUsarMagia = false;
        EquipoOpcional = new Dictionary<string, List<Objeto>>();
        EquipoInicial = new List<Objeto>();
        TiradasSalvacion.Add(E_Caracteristicas.INTELIGENCIA);
        TiradasSalvacion.Add(E_Caracteristicas.DESTREZA);
        Especializaciones.Add(E_Especializacion.LADRON);
        Especializaciones.Add(E_Especializacion.EMBAUCADOR_ARCANO);
        Especializaciones.Add(E_Especializacion.ASESINO);
        AtaqueFurtivo = E_TiposDados.D6;
        CantAtaqueFurtivo = 1;
        CargarSubidasNivel();
        CargarHabilidades();
        CargarTiradasSalvacion();
        CargarEquipoInicial();
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

    public override void ElegirEspecializacion(E_Especializacion nuevaEspecializacion)
    {
        switch(nuevaEspecializacion)
        {
            default:
                break;

            case E_Especializacion.LADRON:Especializacion = E_Especializacion.LADRON;
                CargarSubidasNivelLadron();
                break;
            case E_Especializacion.ASESINO:Especializacion=E_Especializacion.ASESINO;
                CargarSubidasNivelAsesino();
                break;
            case E_Especializacion.EMBAUCADOR_ARCANO:
                Especializacion = E_Especializacion.EMBAUCADOR_ARCANO;
                CargarSubidasNivelEmbaucadorArcano();
                break;
        }
    }

    private void CargarSubidasNivelEmbaucadorArcano()
    {
        Dictionary<int, List<Atributo>> rasgosEspecialidad=new Dictionary<int, List<Atributo>>();

    }

    private void CargarSubidasNivelAsesino()
    {
        throw new NotImplementedException();
    }

    private void CargarSubidasNivelLadron()
    {
        Dictionary<int, List<Atributo>> rasgosEspecialidad = new Dictionary<int, List<Atributo>>();
        List<Atributo> rasgos=new List<Atributo>();
        rasgos.Add(new Atributo("Manos rapidas", "A partir de nivel 3, puedes utilizar la acción adicional que obtuviste de Acción Astuta para hacer una prueba de Destreza  (Juego de Manos), realizar una acción de Usar un Objeto o usar  tus herramientas de ladrón para intentar desarmar una trampa  o forzar una cerradura."));
        rasgos.Add(new Atributo("Balconero", " Cuando escoges este arquetipo, a nivel 3, obtienes la capacidad  para trepar más rápido de lo normal, por lo que trepar ya no te  cuesta movimiento adicional.  Además, cuando saltes con carrerilla aumentarás la distancia  que saltasen tantos pies   como tu modificador por Destreza."));
        rasgosEspecialidad.Add(3, new List<Atributo>(rasgos));
        rasgos.Clear();
        //----------------------------------------------------------------------------//
        rasgos.Add(new Atributo("Sigilo Supremo", "A partir de nivel 9, si no te mueves másde la mitad de tu veloci dad, tendrás ventaja en las pruebasde Destreza (Sigilo) hechas  durante el mismo turno."));
        rasgosEspecialidad.Add(9, new List<Atributo>(rasgos));
        rasgos.Clear();
        //----------------------------------------------------------------------------//
        rasgos.Add(new Atributo("Usar objetos magicos", " A nivel 13 has aprendido lo suficiente sobre el funcionamiento\r\n de la magia como para poder apañártelas para usar incluso\r\n aquellos objetos mágicos que no están destinados a alguien\r\n como tú. Ignoras todas las restricciones de clase, raza y nivel a\r\n la hora de emplear objetos mágicos."));
        rasgosEspecialidad.Add(13, new List<Atributo>(rasgos));
        rasgos.Clear();
        //----------------------------------------------------------------------------//
        rasgos.Add(new Atributo("Reflejos de ladron", "Cuando alcanzas el nivel 17 te has vuelto un experto en pre parar emboscadas y escapar rápidamente del peligro. Puedes  hacer dos turnos durante el primer asalto de cualquier com bate. Llevarás a cabo tu primer turnosegún el orden de  iniciativa normal y el segundo en tu iniciativa menos 10. No  puedes usar este rasgo si estássorprendido."));
        rasgosEspecialidad.Add(17, new List<Atributo>(rasgos));
        rasgos.Clear();
        AñadirRasgosEspecialidades(rasgosEspecialidad);
    }

 

    public override int SubirNivel()
    {
        int returnvalue = 0;//-1 fallo en la funcion, 0 todo correcto, 1 significa que tiene seleccion de especializacion, 2 mejora de caracteristica
        NivelClase++;
        Picaro_SubidaNivel subidanueva = (Picaro_SubidaNivel)BuscarSubidaNivelActual();
        BonificacionCompetencia = subidanueva.BonificadorCompetenciaPorNivel;
        ataqueFurtivo = subidanueva.AtaqueFurtivo;
        cantAtaqueFurtivo = subidanueva.CantAtaqueFurtivo;
        Rasgos = subidanueva.Rasgos;
        if(NivelClase == 3) { returnvalue = 1; }
        if (NivelClase % 4 == 0 || NivelClase == 19) { returnvalue = 2; }
        return returnvalue;
    }

    public override void CargarSubidasNivel()
    {
        Picaro_SubidaNivel subidaNivelCargado= new Picaro_SubidaNivel();
        #region Nivel1
        subidaNivelCargado.Clase = E_Clases.PICARO;
        subidaNivelCargado.AtaqueFurtivo = E_TiposDados.D6;
        subidaNivelCargado.CantAtaqueFurtivo = 1;
        subidaNivelCargado.NivelSubidaClase = 1;
        subidaNivelCargado.BonificadorCompetenciaPorNivel = 2;
        subidaNivelCargado.Rasgos.Add(new Atributo("Pericia", "A nivel 1,  escoge dos de tus competencias en habilidades, o bien solo una y tu competencia con las herramientasde ladrón. Tu bonificador por competencia se duplica para cualquier prueba de característica que hagas utilizando cualquiera de las doscompetencias elegidas. A nivel 6 puedes elegir otras dos competencias (en habilidadeso con herramientasde ladrón)y obtenereste beneficio para ellas."));
        subidaNivelCargado.Rasgos.Add(new Atributo("Ataque Furtivo", " A partir de nivel 1 sabes cómo golpear sutilmente y aprovecharte de un enemigo distraído. Una vez por turno, puedes infligir ld6 de daño adicional a una criatura a la que impactes con un ataque en cuya tirada de ataque tuvieras ventaja. Este ataque debe haber sido hecho utilizando un arma sutil o a distancia. No necesitas tener ventaja en la tirada de ataque si otro enemigo del objetivo está a 5 pies o menos de él, dicho enemigo no está incapacitado, y no sufres desventaja en la tirada de ataque. La cantidad de daño adicional aumenta según subes de nivel en esta clase, tal y como se indica en la columna “ataque furtivo” de la tabla del picaro."));
        subidaNivelCargado.Rasgos.Add(new Atributo("Jerga de ladrones", "Durante tu entrenamiento como picaro aprendiste la jerga de ladrones, una mezcla de dialecto, argot y código secreto que te permite esconder mensajes en lo que parece una conversación normal y corriente. Únicamente aquellas criaturas que conozcan la jerga de ladrones podrán entender estos mensajes. Expresar un mensaje utilizando esta jerga precisa de cuatro veces el tiempo que tardarías en comunicar la misma idea directamente. Además, también comprendes un conjunto deseñales y símbolos secretos que se usan para dejar mensajescortos y sencillos, como el hecho de que una zona sea peligrosa o el territorio de un gremio de ladrones,si hay o no botín cerca, o si los lugareños de los alrededores son presas fáciles o pueden proporcionar un piso franco para ladronesa la fuga."));
        SubidasNivel.Add(new SubidaNivel(subidaNivelCargado));
        subidaNivelCargado.Rasgos.Clear();
        #endregion Nivel1
        #region Nivel2
        subidaNivelCargado.Clase = E_Clases.PICARO;
        subidaNivelCargado.AtaqueFurtivo = E_TiposDados.D6;
        subidaNivelCargado.CantAtaqueFurtivo = 1;
        subidaNivelCargado.NivelSubidaClase = 2;
        subidaNivelCargado.BonificadorCompetenciaPorNivel = 2;
        subidaNivelCargado.Rasgos.Add(new Atributo("Accion Astuta", "A partir de nivel 2 tu agilidad mental y rapidez te permiten moverte y actuar con presteza, por lo que puedes llevar a cabo una acción adicional en cada uno de tus turnosdurante un combate.Solo puedes utilizar esta acción adicional para reali zar las acciones de Correr, Destrabarse o Esconderse."));
        SubidasNivel.Add(new SubidaNivel(subidaNivelCargado));
        subidaNivelCargado.Rasgos.Clear();
        #endregion Nivel2
        #region Nivel2
        subidaNivelCargado.Clase = E_Clases.PICARO;
        subidaNivelCargado.AtaqueFurtivo = E_TiposDados.D6;
        subidaNivelCargado.CantAtaqueFurtivo = 1;
        subidaNivelCargado.NivelSubidaClase = 3;
        subidaNivelCargado.BonificadorCompetenciaPorNivel = 2;
        subidaNivelCargado.Rasgos.Add(new Atributo("Accion Astuta", "A partir de nivel 2 tu agilidad mental y rapidez te permiten moverte y actuar con presteza, por lo que puedes llevar a cabo una acción adicional en cada uno de tus turnosdurante un combate.Solo puedes utilizar esta acción adicional para reali zar las acciones de Correr, Destrabarse o Esconderse."));
        SubidasNivel.Add(new SubidaNivel(subidaNivelCargado));
        subidaNivelCargado.Rasgos.Clear();
        #endregion Nivel2


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
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(7));
        EquipoOpcional.Add("2A", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Clear();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(118));
        EquipoOpcional.Add("2B", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Clear();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(194));
        EquipoOpcional.Add("3A", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Clear();
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(193));
        EquipoOpcional.Add("3B", new List<Objeto>(listaEquipoOpcional));
        listaEquipoOpcional.Add(ControladorObjetos.BuscarObjetoPorCodigo(192));
        EquipoOpcional.Add("3C", new List<Objeto>(listaEquipoOpcional));
        EquipoInicial.Add(ControladorObjetos.BuscarObjetoPorCodigo(140));
        EquipoInicial.Add(ControladorObjetos.BuscarObjetoPorCodigo(103));
        EquipoInicial.Add(ControladorObjetos.BuscarObjetoPorCodigo(103));
        EquipoInicial.Add(ControladorObjetos.BuscarObjetoPorCodigo(169));
    
    }
    public override void CargarHabilidades()
    {
        Habilidades.Add(E_Habilidades.ACROBACIAS);
        Habilidades.Add(E_Habilidades.ATLETISMO);
        Habilidades.Add(E_Habilidades.ENGAÑO);
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
        Competencias.Add(E_Competencias.ARMADURAS_LIGERAS);
        Competencias.Add(E_Competencias.ARMAS_SIMPLES);
        Competencias.Add(E_Competencias.BALLESTAS_DE_MANO);
        Competencias.Add(E_Competencias.ESPADAS_CORTAS);
        Competencias.Add(E_Competencias.ESPADAS_LARGAS);
        Competencias.Add(E_Competencias.ESTOQUES);
    }
    public int CantAtaqueFurtivo { get => cantAtaqueFurtivo; set => cantAtaqueFurtivo = value; }
    public E_TiposDados AtaqueFurtivo { get => ataqueFurtivo; set => ataqueFurtivo = value; }

    public override string ToString()
    {
        string returnValue = base.ToString();
        returnValue += "Ataque furtivo= " + cantAtaqueFurtivo.ToString() + ataqueFurtivo.ToString()+"\n";

        return returnValue;
    }

}
