using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : Objeto
{
    private int valorCABase;
    private int requisitoFuerza;
    private bool desventajaSigilo;
    bool modificadorDestreza;
    static int VALORCABASEMINIMO = 10;
    static int VALORCABASEMAXIMO = 20;

    public Armadura() :base()
    {

        SetValorCABase(VALORCABASEMINIMO);
        SetRequisitoFuerza(0);
        SetDesventajaSigilo(false);
        SetModificadorDestreza(false);
    }

    public Armadura(int codigoNuevo, int valor,int peso,int cantidadNueva,string nombreNuevo,E_Monedas monedasTipo,E_TipoObjeto tipoObjetoNuevo, int valorCABaseNuevo, int requisitoFuerzaNuevo, bool desventajaSigiloNuevo, bool modificadorDestrezaNuevo)
    : base(codigoNuevo,peso, valor, cantidadNueva,nombreNuevo,monedasTipo,tipoObjetoNuevo)
    {
        SetValorCABase(valorCABaseNuevo);
        SetRequisitoFuerza(requisitoFuerzaNuevo);
        SetDesventajaSigilo(desventajaSigiloNuevo);
        SetModificadorDestreza(modificadorDestrezaNuevo);
    }

    public int GetValorCABase()
    {
        return valorCABase;
    }

    public void SetValorCABase(int valorCABaseNuevo)
    {
        if (valorCABaseNuevo < VALORCABASEMINIMO)
        {
            valorCABase = VALORCABASEMINIMO;
        }
        else if(valorCABaseNuevo > VALORCABASEMAXIMO)
        {
            valorCABase=VALORCABASEMAXIMO;
        }
        else
        {
            valorCABase=valorCABaseNuevo;
        }
    }

    public int GetRequisitoFuerza()
    {
        return requisitoFuerza;
    }

    public void SetRequisitoFuerza(int requisitoFuerzaNueva)
    {

    }

    public bool GetDesventajaSigilo()
    {
        return desventajaSigilo;
    }

    public void SetDesventajaSigilo(bool desventajaSigiloNuevo)
    {
        desventajaSigilo = desventajaSigiloNuevo;
    }

    public bool GetModificadorDestreza()
    {
        return modificadorDestreza;
    }

    public void SetModificadorDestreza(bool modificadorDestrezaNuevo)
    {
        modificadorDestreza = modificadorDestrezaNuevo;
    }

    public int CalcularCA(int valorDestreza)
    {
        int valor = GetValorCABase();
        if (modificadorDestreza)
        {
            valor += valorDestreza <= 2 ?valorDestreza:2;
        }
        return valor;
    }


    public bool Equals(Armadura obj)
    {
        return base.Equals(obj) &&
               valorCABase == obj.GetValorCABase() &&
               requisitoFuerza == obj.GetRequisitoFuerza() &&
               desventajaSigilo == obj.GetDesventajaSigilo();
    }
}
