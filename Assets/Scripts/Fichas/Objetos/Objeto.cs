using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Objeto 
{
   
    int codigo;
    
    private string nombre;
    [JsonProperty]
    private float peso;
    [JsonProperty]
    private int cantValor;
   
    private E_Monedas tipoValor;
    [JsonProperty]
    private int cantidad;
    
    E_TipoObjeto tipo;
    static float PESOMAXIMO=1000;
    static float PESOMINIMO=1;
    static int VALORMAXIMO=1000000;
    static int VALORMINIMO=1;
    static int CANTIDADMAXIMA=100;
    static int CANTIDADMINIMA = 1;

    public int Codigo { get => codigo; set =>SetCodigo(value); }
    public string Nombre { get => nombre; set => nombre = value; }
    public E_Monedas TipoValor { get => tipoValor; set => tipoValor = value; }
    public E_TipoObjeto Tipo { get => tipo; set => tipo = value; }

    public Objeto()
    {
        SetCodigo(0);
        SetPeso(0);
        SetValor(0);
        SetCantidad(0);
        Nombre = "";
        TipoValor = E_Monedas.PC;
        Tipo = E_TipoObjeto.Objeto_Mundano;
    }

    public Objeto(int codigoNuevo, int pesoNuevo, int valorNuevo, int cantidadNueva, string nombreNuevo, E_Monedas tipoValorNuevo, E_TipoObjeto tipoNuevo)
    {
        SetCodigo(codigoNuevo);
        SetPeso(pesoNuevo);
        SetValor(valorNuevo);
        SetCantidad(cantidadNueva);
        Nombre = nombreNuevo;
        TipoValor = tipoValorNuevo;
        Tipo = tipoNuevo;
    }



    public float GetPeso() { return peso; }
    public int GetValor() {  return cantValor; }
    public int GetCantidad() {  return cantidad; }

    public void SetCodigo(int codigoNuevo)
    {
        if (codigoNuevo >= 0)
        {
            codigo= codigoNuevo;
        }
    }
    public void SetPeso(float pesoNuevo)
    {
        if(pesoNuevo<1)
        {
            peso = PESOMINIMO;
        }else if(pesoNuevo>PESOMAXIMO) 
        { 
            peso = PESOMAXIMO;
        }else
        { 
            peso =pesoNuevo;
        }
    }

    public void SetValor(int valorNuevo)
    {
        if (valorNuevo < VALORMINIMO)
        {
            cantValor = VALORMINIMO;
        }
        else if (valorNuevo > VALORMAXIMO)
        {
            cantValor = VALORMAXIMO;
        }
        else
        {
            cantValor = valorNuevo;
        }
    }

    public void SetCantidad(int cantidadNueva)
    {
        if (cantidadNueva < CANTIDADMINIMA)
        {
            cantidad = CANTIDADMINIMA;
        }
        else if (cantidadNueva> CANTIDADMAXIMA)
        {
            cantidad = CANTIDADMAXIMA;
        }
        else
        {
            cantidad = cantidadNueva;
        }
    }


    public bool Equals(Objeto obj)
    {
       

        return (codigo==obj.codigo&&peso == obj.GetPeso() && cantValor == obj.GetValor() && cantidad == obj.GetCantidad()&&obj.TipoValor==TipoValor);
    }

    public override string ToString()
    {
        string value = "";

        value += "Codigo: " + Codigo + "\n";
        value += "Nombre: " + Nombre + "\n";
        value += "Peso: " + GetPeso() + "\n";
        value += "Precio: " + GetCantidad() + " "+tipoValor.ToString() + "\n";

        return value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(codigo, nombre, peso, cantValor, tipoValor, cantidad, tipo);
    }
}
