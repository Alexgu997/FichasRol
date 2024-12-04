using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Arma : Objeto
{
    
    int cantidadDaño;
    
    int cantidadSegundoDaño;
    
    E_TiposDados tipoDadoDaño;
   
    E_TiposDados tipoDadoSegundoDaño;
   
    List<E_Propiedades> propiedades;
    
    int alcanceMinimo;
    
    int alcanceMaximo;
    static int CANTIDIDADDAÑOMINIMA=1;
    static int CANTIDIDADDAÑOMAXIMA = 20;
    
    static E_TiposDados TIPODADODAÑOMINIMO=E_TiposDados.D4;

    public int CantidadDaño { get => cantidadDaño; set => SetCantidadDaño(value); }
    public int CantidadSegundoDaño { get => cantidadSegundoDaño; set => cantidadSegundoDaño = value; }
    public E_TiposDados TipoDadoDaño { get => tipoDadoDaño; set => tipoDadoDaño = value; }
    public List<E_Propiedades> Propiedades { get => propiedades; set => propiedades = value; }
    public static int CANTIDIDADDAÑOMINIMA1 { get => CANTIDIDADDAÑOMINIMA; set => CANTIDIDADDAÑOMINIMA = value; }
    public static int CANTIDIDADDAÑOMAXIMA1 { get => CANTIDIDADDAÑOMAXIMA; set => CANTIDIDADDAÑOMAXIMA = value; }
    public static E_TiposDados TIPODADODAÑOMINIMO1 { get => TIPODADODAÑOMINIMO; set => TIPODADODAÑOMINIMO = value; }
    public E_TiposDados TipoDadoSegundoDaño { get => tipoDadoSegundoDaño; set => tipoDadoSegundoDaño = value; }
    public int AlcanceMinimo { get => alcanceMinimo; private set => alcanceMinimo = value; }
    public int AlcanceMaximo { get => alcanceMaximo; private set => alcanceMaximo = value; }

    public Arma()
    {
        CantidadDaño=CANTIDIDADDAÑOMINIMA;
        TipoDadoDaño= TIPODADODAÑOMINIMO;
        Propiedades = new List<E_Propiedades>();
        CantidadSegundoDaño = 0;
        TipoDadoSegundoDaño = TIPODADODAÑOMINIMO;
        AlcanceMinimo = 0;
        AlcanceMaximo = 0;
    }

    public Arma(int codigoNuevo, int valor, int peso, int cantidadNueva, string nombreNuevo, E_Monedas monedasTipo, E_TipoObjeto tipoObjetoNuevo, int cantidadDaño, E_TiposDados tipoDadoDaño, List<E_Propiedades> propiedades, int cantidadSegundoDañoNuevo, E_TiposDados tipoDadoSegundoDaño, int alcanceMinimo, int alcanceMaximo) : base(codigoNuevo, peso, valor, cantidadNueva, nombreNuevo, monedasTipo, tipoObjetoNuevo)
    {

        CantidadDaño = cantidadDaño;
        TipoDadoDaño = tipoDadoDaño;
        Propiedades = propiedades;
        CantidadSegundoDaño = cantidadSegundoDañoNuevo;
        TipoDadoSegundoDaño = tipoDadoSegundoDaño;
        AlcanceMinimo = alcanceMinimo;
        AlcanceMaximo = alcanceMaximo;
    }

    public int GetCantidadDaño()
    {
        return cantidadDaño;
    }
    public void SetCantidadDaño(int cantidadDañoNuevo)
    {
        if(cantidadDañoNuevo < CANTIDIDADDAÑOMINIMA)
        {
            cantidadDaño = CANTIDIDADDAÑOMINIMA;
        }else if(cantidadDañoNuevo>CANTIDIDADDAÑOMAXIMA)
        {
            cantidadDaño = CANTIDIDADDAÑOMAXIMA;

        }
        else
        {
            cantidadDaño = cantidadDañoNuevo;
        }
    }

    public E_TiposDados GetTipoDadoDaño()
    {
        return tipoDadoDaño;
    }

    public void SetTipoDadoDaño(E_TiposDados tipoDadoDañosNuevo)
    {
        
        tipoDadoDaño = tipoDadoDañosNuevo;
    }

    public List<E_Propiedades> GetPropiedades()
    {
        return propiedades;
    }

    public void SetPropiedades(List<E_Propiedades> propiedadesNuevas)
    {
        propiedades = propiedadesNuevas;
    }

    public void AñadirPropiedad(E_Propiedades propiedadNueva)
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

    public void CambiarDaños()
    {
        int valorCambio;
        if (BuscarPropiedad(E_Propiedades.VERSATIL))
        {
            valorCambio = CantidadDaño;
            CantidadDaño = CantidadSegundoDaño;
            cantidadSegundoDaño= valorCambio;
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
               cantidadDaño == armaComparar.GetCantidadDaño() &&
               tipoDadoDaño == armaComparar.GetTipoDadoDaño() &&
               propiedades== armaComparar.GetPropiedades()&&
               cantidadSegundoDaño==armaComparar.cantidadSegundoDaño&&
               tipoDadoSegundoDaño==armaComparar.tipoDadoSegundoDaño;


    }

    public override string ToString()
    {
        string value = base.ToString();
        
        value += "Daño: " + cantidadDaño + tipoDadoDaño.ToString() + "\n";
        Propiedades.ForEach(p => value += p.ToString());
        if (Propiedades.Contains(E_Propiedades.ALCANCE))
        {
            value += "Alcance: " + alcanceMinimo + "/" + alcanceMaximo + "\n";
        }
        if (propiedades.Contains(E_Propiedades.VERSATIL))
        {
            value += "Versatil: " + cantidadSegundoDaño + tipoDadoSegundoDaño.ToString()+"\n";
        }
        return value;
        
    }
}
