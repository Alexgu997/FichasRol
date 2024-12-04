using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Armadura : Objeto
{
    [JsonProperty]
    private int valorCABase;
    [JsonProperty]
    private int requisitoFuerza;
    [JsonProperty]
    private bool desventajaSigilo;
    [JsonProperty]
    bool modificadorDestreza;
    [JsonProperty]
    private int maximoModificadorDestreza;

    static int VALORCABASEMINIMO = 10;
    static int VALORCABASEMAXIMO = 20;

    public Armadura() :base()
    {

        SetValorCABase(VALORCABASEMINIMO);
        SetRequisitoFuerza(0);
        SetDesventajaSigilo(false);
        SetModificadorDestreza(false);
        SetMaximoModificadorDestreza(0);

    }

    public Armadura(int codigoNuevo, int valor,int peso,int cantidadNueva,string nombreNuevo,E_Monedas monedasTipo,E_TipoObjeto tipoObjetoNuevo, int valorCABaseNuevo, int requisitoFuerzaNuevo, bool desventajaSigiloNuevo, bool modificadorDestrezaNuevo,int maximoModificadorDestrezaNuevo)
    : base(codigoNuevo,peso, valor, cantidadNueva,nombreNuevo,monedasTipo,tipoObjetoNuevo)
    {
        SetValorCABase(valorCABaseNuevo);
        SetRequisitoFuerza(requisitoFuerzaNuevo);
        SetDesventajaSigilo(desventajaSigiloNuevo);
        SetModificadorDestreza(modificadorDestrezaNuevo);
        SetMaximoModificadorDestreza(maximoModificadorDestrezaNuevo);
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

    public void SetMaximoModificadorDestreza(int valorMaximoModificadorDestreza)
    {
        maximoModificadorDestreza = valorMaximoModificadorDestreza;
    }

    public int GetMaximoModificadorDestreza()
    {
        return maximoModificadorDestreza;
    }

    public int CalcularCA(int valorDestreza)
    {
        int valor = GetValorCABase();
        if (modificadorDestreza)
        {
            if (maximoModificadorDestreza > 0)
            {
                valor += valorDestreza <= maximoModificadorDestreza ? valorDestreza : maximoModificadorDestreza;
            }
            else
            {
                valor += valorDestreza;
            }
            
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

    public override string ToString()
    {
        string value= base.ToString();

        value += "CA Base: " + GetValorCABase() +" " + (modificadorDestreza?"+ "+GetMaximoModificadorDestreza()+" modificador de destreza":"")+ "\n";
        value += "Requisito Fuerza: " + (requisitoFuerza > 0 ? requisitoFuerza : "No tiene requisito") + "\n";
        value += "Desventaja Sigilo: " + (desventajaSigilo ? "Tiene desventaja" : "No tiene desventaja")+"\n";

        return value;
    }
}
