using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arma : Objeto
{
    int cantidadDaño;
    E_TiposDados tipoDadoDaño;
    List<E_Propiedades> propiedades;
    static int CANTIDIDADDAÑOMINIMA=1;
    static int CANTIDIDADDAÑOMAXIMA = 20;
    static E_TiposDados TIPODADODAÑOMINIMO=E_TiposDados.D4;

    public Arma()
    {
        SetCantidad(CANTIDIDADDAÑOMINIMA);
        SetTipoDadoDaño(TIPODADODAÑOMINIMO);
    }

    public Arma(int codigoNuevo, int valor, int peso, int cantidadNueva, string nombreNuevo, E_Monedas monedasTipo,E_TipoObjeto tipoObjetoNuevo, int cantidadDaño, E_TiposDados tipoDadoDaño, List<E_Propiedades> propiedades):base(codigoNuevo, peso, valor, cantidadNueva, nombreNuevo, monedasTipo, tipoObjetoNuevo)
    {
       
        this.cantidadDaño = cantidadDaño;
        this.tipoDadoDaño = tipoDadoDaño;
        this.propiedades = propiedades;
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

    public void BorrarPropiedad(E_Propiedades propiedadParaBorrar)
    {
        if (propiedades.Contains(propiedadParaBorrar))
        {
            propiedades.Remove(propiedadParaBorrar);
        }
    }

    public bool Equals(Arma armaComparar)
    {
        return base.Equals(armaComparar) &&
               cantidadDaño == armaComparar.GetCantidadDaño() &&
               tipoDadoDaño == armaComparar.GetTipoDadoDaño() &&
               propiedades== armaComparar.GetPropiedades();


    }
}
