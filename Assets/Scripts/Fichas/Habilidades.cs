using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Habilidades 
{
    #region Variables
    int valorAcrobacias;
    bool competenciaAcrobacias;
    int valorAtletismo;
    bool competenciaAtletismo;
    int valorConocimientoArcano;
    bool competenciaConocimientoArcano;
    int valorEngaño;
    bool competenciaEngaño;
    int valorHistoria;
    bool competenciaHistoria;
    int valorInterpretacion;
    bool competenciaInterpretacion;
    int valorIntimidacion;
    bool competenciaIntimidacion;
    int valorInvestigacion;
    bool competenciaInvestigacion;
    int valorJuegoManos;
    bool competenciaJuegoManos;
    int valorMedicina;
    bool competenciaMedicina;
    int valorNaturaleza;
    bool competenciaNaturaleza;
    int valorPercepcion;
    bool competenciaPercepcion;
    int valorPerspicacia;
    bool competenciaPerspicacia;
    int valorPersuasion;
    bool competenciaPersuasion;
    int valorReligion;
    bool competenciaReligion;
    int valorSigilo;
    bool competenciaSigilo;
    int valorSupervivencia;
    bool competenciaSupervivencia;
    int valorTratoConAnimales;
    bool competenciaTratoConAnimales;

    public int ValorAcrobacias { get => valorAcrobacias; set => valorAcrobacias = value; }
    public bool CompetenciaAcrobacias { get => competenciaAcrobacias; set => competenciaAcrobacias = value; }
    public int ValorAtletismo { get => valorAtletismo; set => valorAtletismo = value; }
    public bool CompetenciaAtletismo { get => competenciaAtletismo; set => competenciaAtletismo = value; }
    public int ValorConocimientoArcano { get => valorConocimientoArcano; set => valorConocimientoArcano = value; }
    public bool CompetenciaConocimientoArcano { get => competenciaConocimientoArcano; set => competenciaConocimientoArcano = value; }
    public int ValorEngaño { get => valorEngaño; set => valorEngaño = value; }
    public bool CompetenciaEngaño { get => competenciaEngaño; set => competenciaEngaño = value; }
    public int ValorHistoria { get => valorHistoria; set => valorHistoria = value; }
    public bool CompetenciaHistoria { get => competenciaHistoria; set => competenciaHistoria = value; }
    public int ValorInterpretacion { get => valorInterpretacion; set => valorInterpretacion = value; }
    public bool CompetenciaInterpretacion { get => competenciaInterpretacion; set => competenciaInterpretacion = value; }
    public int ValorIntimidacion { get => valorIntimidacion; set => valorIntimidacion = value; }
    public bool CompetenciaIntimidacion { get => competenciaIntimidacion; set => competenciaIntimidacion = value; }
    public int ValorInvestigacion { get => valorInvestigacion; set => valorInvestigacion = value; }
    public bool CompetenciaInvestigacion { get => competenciaInvestigacion; set => competenciaInvestigacion = value; }
    public int ValorJuegoManos { get => valorJuegoManos; set => valorJuegoManos = value; }
    public bool CompetenciaJuegoManos { get => competenciaJuegoManos; set => competenciaJuegoManos = value; }
    public int ValorMedicina { get => valorMedicina; set => valorMedicina = value; }
    public bool CompetenciaMedicina { get => competenciaMedicina; set => competenciaMedicina = value; }
    public int ValorNaturaleza { get => valorNaturaleza; set => valorNaturaleza = value; }
    public bool CompetenciaNaturaleza { get => competenciaNaturaleza; set => competenciaNaturaleza = value; }
    public int ValorPercepcion { get => valorPercepcion; set => valorPercepcion = value; }
    public bool CompetenciaPercepcion { get => competenciaPercepcion; set => competenciaPercepcion = value; }
    public int ValorPerspicacia { get => valorPerspicacia; set => valorPerspicacia = value; }
    public bool CompetenciaPerspicacia { get => competenciaPerspicacia; set => competenciaPerspicacia = value; }
    public int ValorPersuasion { get => valorPersuasion; set => valorPersuasion = value; }
    public bool CompetenciaPersuasion { get => competenciaPersuasion; set => competenciaPersuasion = value; }
    public int ValorReligion { get => valorReligion; set => valorReligion = value; }
    public bool CompetenciaReligion { get => competenciaReligion; set => competenciaReligion = value; }
    public int ValorSigilo { get => valorSigilo; set => valorSigilo = value; }
    public bool CompetenciaSigilo { get => competenciaSigilo; set => competenciaSigilo = value; }
    public int ValorSupervivencia { get => valorSupervivencia; set => valorSupervivencia = value; }
    public bool CompetenciaSupervivencia { get => competenciaSupervivencia; set => competenciaSupervivencia = value; }
    public int ValorTratoConAnimales { get => valorTratoConAnimales; set => valorTratoConAnimales = value; }
    public bool CompetenciaTratoConAnimales { get => competenciaTratoConAnimales; set => competenciaTratoConAnimales = value; }
    #endregion Variables
    public Habilidades()
    {
        AsignarHabilidadesFuerza(0, 0);
        AsignarHabilidadesDestreza(0, 0);
        AsignarHabilidadesInteligencia(0, 0);
        AsignarHabilidadesSabiduria(0, 0);
        AsignarHabilidadesCarisma(0, 0);
    }

    public Habilidades(int modificadorFuerza,int modificadorDestreza, int modificadorConstitucion, int modificadorInteligencia, int modificadorSabiduria, int modificadorCarisma)
    {
        AsignarHabilidadesFuerza(modificadorFuerza,0);
        AsignarHabilidadesDestreza(modificadorDestreza, 0);
        AsignarHabilidadesInteligencia(modificadorInteligencia,0);
        AsignarHabilidadesSabiduria(modificadorSabiduria, 0);
        AsignarHabilidadesCarisma(modificadorCarisma,0);
    }
    
    #region GETTERYSETTERS
    public int GetValorAcrobacias()
    {
        return ValorAcrobacias;
    }
    public void SetValorAcrobacias(int valor)
    {
        ValorAcrobacias=valor;
    }
    #endregion GETTERSYSETTERS
    #region Funciones
    public void AsignarHabilidadesFuerza(int modificadorFuerza,int bonificador)
    {
        int value=ComprobarModificador(modificadorFuerza);
        ValorAtletismo = CompetenciaAtletismo ? value : value + bonificador;
    }
    public void AsignarHabilidadesDestreza(int modificadorDestreza, int bonificador)
    {
        int value = ComprobarModificador(modificadorDestreza);
        ValorAcrobacias = CompetenciaAcrobacias ? value : value + bonificador; ;
        ValorSigilo = CompetenciaSigilo ? value : value + bonificador;
    }
    public void AsignarHabilidadesInteligencia(int modificadorInteligencia, int bonificador)
    {
        int value = ComprobarModificador(modificadorInteligencia);
        ValorConocimientoArcano=CompetenciaConocimientoArcano ? value : value + bonificador;
        ValorHistoria=CompetenciaHistoria ? value : value + bonificador;
        ValorInvestigacion=CompetenciaInvestigacion ? value : value + bonificador;
        ValorNaturaleza=CompetenciaNaturaleza ? value : value + bonificador;
        ValorReligion=CompetenciaReligion ? value : value + bonificador;
        
    }
    public void AsignarHabilidadesSabiduria(int modificadorSabiduria, int bonificador)
    {
        int value = ComprobarModificador(modificadorSabiduria);
        ValorMedicina=CompetenciaMedicina ? value : value + bonificador;
        ValorPercepcion=CompetenciaPercepcion ? value : value + bonificador;
        ValorPerspicacia=CompetenciaPerspicacia ? value : value + bonificador;
        ValorSupervivencia=CompetenciaSupervivencia ? value : value + bonificador;

    }
    public void AsignarHabilidadesCarisma(int modificadorCarisma, int bonificador)
    {
        int value = ComprobarModificador(modificadorCarisma);
        ValorEngaño=CompetenciaEngaño ? value : value + bonificador;
        ValorInterpretacion=CompetenciaInterpretacion ? value : value + bonificador;
        ValorIntimidacion=CompetenciaIntimidacion ? value : value + bonificador;
        ValorPersuasion=CompetenciaPersuasion ? value : value + bonificador;
    }

    private int ComprobarModificador(int modificador)
    {
        int value = modificador;
        if(modificador <= -5)
        {
            value = -5;
        }else if(modificador >= 5)
        {
            value = 5;
        }
      return value;
    }
    #endregion Funciones
}
