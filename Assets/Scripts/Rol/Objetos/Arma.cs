using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Arma : Objeto
{
    
    int cantidadDa�o;
    
    int cantidadSegundoDa�o;
    
    E_TiposDados tipoDadoDa�o;
   
    E_TiposDados tipoDadoSegundoDa�o;
   
    List<E_Propiedades> propiedades;
    
    int alcanceMinimo;
    
    int alcanceMaximo;
    static int CANTIDIDADDA�OMINIMA=1;
    static int CANTIDIDADDA�OMAXIMA = 20;
    
    static E_TiposDados TIPODADODA�OMINIMO=E_TiposDados.D4;

    public int CantidadDa�o { get => cantidadDa�o; set => SetCantidadDa�o(value); }
    public int CantidadSegundoDa�o { get => cantidadSegundoDa�o; set => cantidadSegundoDa�o = value; }
    public E_TiposDados TipoDadoDa�o { get => tipoDadoDa�o; set => tipoDadoDa�o = value; }
    public List<E_Propiedades> Propiedades { get => propiedades; set => propiedades = value; }
    public static int CANTIDIDADDA�OMINIMA1 { get => CANTIDIDADDA�OMINIMA; set => CANTIDIDADDA�OMINIMA = value; }
    public static int CANTIDIDADDA�OMAXIMA1 { get => CANTIDIDADDA�OMAXIMA; set => CANTIDIDADDA�OMAXIMA = value; }
    public static E_TiposDados TIPODADODA�OMINIMO1 { get => TIPODADODA�OMINIMO; set => TIPODADODA�OMINIMO = value; }
    public E_TiposDados TipoDadoSegundoDa�o { get => tipoDadoSegundoDa�o; set => tipoDadoSegundoDa�o = value; }
    public int AlcanceMinimo { get => alcanceMinimo; private set => alcanceMinimo = value; }
    public int AlcanceMaximo { get => alcanceMaximo; private set => alcanceMaximo = value; }

    public Arma()
    {
        CantidadDa�o=CANTIDIDADDA�OMINIMA;
        TipoDadoDa�o= TIPODADODA�OMINIMO;
        Propiedades = new List<E_Propiedades>();
        CantidadSegundoDa�o = 0;
        TipoDadoSegundoDa�o = TIPODADODA�OMINIMO;
        AlcanceMinimo = 0;
        AlcanceMaximo = 0;
    }

    public Arma(int codigoNuevo, int valor, int peso, int cantidadNueva, string nombreNuevo, E_Monedas monedasTipo, E_TipoObjeto tipoObjetoNuevo, int cantidadDa�o, E_TiposDados tipoDadoDa�o, List<E_Propiedades> propiedades, int cantidadSegundoDa�oNuevo, E_TiposDados tipoDadoSegundoDa�o, int alcanceMinimo, int alcanceMaximo) : base(codigoNuevo, peso, valor, cantidadNueva, nombreNuevo, monedasTipo, tipoObjetoNuevo)
    {

        CantidadDa�o = cantidadDa�o;
        TipoDadoDa�o = tipoDadoDa�o;
        Propiedades = propiedades;
        CantidadSegundoDa�o = cantidadSegundoDa�oNuevo;
        TipoDadoSegundoDa�o = tipoDadoSegundoDa�o;
        AlcanceMinimo = alcanceMinimo;
        AlcanceMaximo = alcanceMaximo;
    }

    public int GetCantidadDa�o()
    {
        return cantidadDa�o;
    }
    public void SetCantidadDa�o(int cantidadDa�oNuevo)
    {
        if(cantidadDa�oNuevo < CANTIDIDADDA�OMINIMA)
        {
            cantidadDa�o = CANTIDIDADDA�OMINIMA;
        }else if(cantidadDa�oNuevo>CANTIDIDADDA�OMAXIMA)
        {
            cantidadDa�o = CANTIDIDADDA�OMAXIMA;

        }
        else
        {
            cantidadDa�o = cantidadDa�oNuevo;
        }
    }

    public E_TiposDados GetTipoDadoDa�o()
    {
        return tipoDadoDa�o;
    }

    public void SetTipoDadoDa�o(E_TiposDados tipoDadoDa�osNuevo)
    {
        
        tipoDadoDa�o = tipoDadoDa�osNuevo;
    }

    public List<E_Propiedades> GetPropiedades()
    {
        return propiedades;
    }

    public void SetPropiedades(List<E_Propiedades> propiedadesNuevas)
    {
        propiedades = propiedadesNuevas;
    }

    public void A�adirPropiedad(E_Propiedades propiedadNueva)
    {
        if(!propiedades.Contains(propiedadNueva)){
            propiedades.Add(propiedadNueva);
        }
    }
    public bool BuscarPropiedad(E_Propiedades propiedadBuscada)
    {
        bool encontradaPropiedad = false;
        if (propiedades.Contains(propiedadBuscada))
        {
            encontradaPropiedad = true;
        }
        return encontradaPropiedad;
    }

    public void CambiarDa�os()
    {
        int valorCambio;
        if (BuscarPropiedad(E_Propiedades.VERSATIL))
        {
            valorCambio = CantidadDa�o;
            CantidadDa�o = CantidadSegundoDa�o;
            cantidadSegundoDa�o= valorCambio;
        }   
    }

    public void BorrarPropiedad(E_Propiedades propiedadParaBorrar)
    {
        if (propiedades.Contains(propiedadParaBorrar))
        {
            propiedades.Remove(propiedadParaBorrar);
        }
    }

    public void SetAlcance(int alcanceMinimoNuevo, int alcanceMaximoNuevo) 
    {
        if (BuscarPropiedad(E_Propiedades.ALCANCE))
        {
            AlcanceMinimo = alcanceMinimoNuevo;
            AlcanceMaximo = alcanceMaximoNuevo;
        }
    
    
    }

    public bool Equals(Arma armaComparar)
    {
        return base.Equals(armaComparar) &&
               cantidadDa�o == armaComparar.GetCantidadDa�o() &&
               tipoDadoDa�o == armaComparar.GetTipoDadoDa�o() &&
               propiedades== armaComparar.GetPropiedades()&&
               cantidadSegundoDa�o==armaComparar.cantidadSegundoDa�o&&
               tipoDadoSegundoDa�o==armaComparar.tipoDadoSegundoDa�o;


    }

    public override string ToString()
    {
        string value = base.ToString();
        
        value += "Da�o: " + cantidadDa�o + tipoDadoDa�o.ToString() + "\n";
        Propiedades.ForEach(p => value += p.ToString());
        if (Propiedades.Contains(E_Propiedades.ALCANCE))
        {
            value += "Alcance: " + alcanceMinimo + "/" + alcanceMaximo + "\n";
        }
        if (propiedades.Contains(E_Propiedades.VERSATIL))
        {
            value += "Versatil: " + cantidadSegundoDa�o + tipoDadoSegundoDa�o.ToString()+"\n";
        }
        return value;
        
    }
}
