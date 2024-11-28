using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arma : Objeto
{
    int cantidadDa�o;
    E_TiposDados tipoDadoDa�o;
    List<E_Propiedades> propiedades;
    static int CANTIDIDADDA�OMINIMA=1;
    static int CANTIDIDADDA�OMAXIMA = 20;
    static E_TiposDados TIPODADODA�OMINIMO=E_TiposDados.D4;

    public Arma()
    {
        SetCantidad(CANTIDIDADDA�OMINIMA);
        SetTipoDadoDa�o(TIPODADODA�OMINIMO);
    }

    public Arma(int codigoNuevo, int valor, int peso, int cantidadNueva, string nombreNuevo, E_Monedas monedasTipo,E_TipoObjeto tipoObjetoNuevo, int cantidadDa�o, E_TiposDados tipoDadoDa�o, List<E_Propiedades> propiedades):base(codigoNuevo, peso, valor, cantidadNueva, nombreNuevo, monedasTipo, tipoObjetoNuevo)
    {
       
        this.cantidadDa�o = cantidadDa�o;
        this.tipoDadoDa�o = tipoDadoDa�o;
        this.propiedades = propiedades;
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
               cantidadDa�o == armaComparar.GetCantidadDa�o() &&
               tipoDadoDa�o == armaComparar.GetTipoDadoDa�o() &&
               propiedades== armaComparar.GetPropiedades();


    }
}
