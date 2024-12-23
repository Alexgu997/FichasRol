using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Atributo
{
    int codigo;
    string nombre;
    string efecto;
    Hechizo hechizoAtributo;
    Objeto objetoAtributo;
    public Atributo()
    {
        Nombre = "";
        Efecto = "";
        HechizoAtributo = null;
        ObjetoAtributo = null;
    }

    public Atributo(string nombre, string efecto)
    {
        Nombre = nombre;
        Efecto = efecto;
        HechizoAtributo = null;
        ObjetoAtributo = null;
    }
    public Atributo(string nombre, string efecto, Hechizo hechizoAtributo, Objeto objetoAtributo)
    {
        Nombre = nombre;
        Efecto = efecto;
        HechizoAtributo = hechizoAtributo;
        ObjetoAtributo = objetoAtributo;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Efecto { get => efecto; set => efecto = value; }
    public Hechizo HechizoAtributo { get => hechizoAtributo; set => SetHechizoAtributo(value); }
    public Objeto ObjetoAtributo { get => objetoAtributo; set => SetObjetoAtributo(value); }

    public void SetHechizoAtributo(Hechizo hechizo)
    {
        if (hechizo != null)
        {
            hechizoAtributo = hechizo;
        }

    }


    public void SetObjetoAtributo(Objeto obj)
    {
        if (obj!=null){
        objetoAtributo = obj;
        }

    }


    public bool TieneHechizo()
    {
        bool result = false;
        if (hechizoAtributo != null)
            result = true;
        return result;
    }

    public bool TieneObjeto()
    {
        bool result = false;
        if (objetoAtributo != null)
            result = true;
        return result;
    }

    public  bool Equals(Atributo atributo)
    {
        bool result=false;
        if (nombre == atributo.nombre &&efecto == atributo.efecto)
        {
            
            if (atributo.TieneHechizo() && TieneHechizo()|| !atributo.TieneHechizo()&& !TieneHechizo())
            {
                if (atributo.hechizoAtributo == hechizoAtributo)
                {
                    if (atributo.TieneObjeto()&&TieneObjeto()|| !atributo.TieneObjeto() && !TieneObjeto())
                    {
                        if (atributo.ObjetoAtributo == objetoAtributo)
                        {
                            result = true;
                        }
                    }
                }
            }
        }
              
              


        return result;
    }

    public override string ToString()
    {
        return "Nombre: "+nombre + "\n"+ "Efecto: "+efecto + "\n"+ "Hechizo: "+ (TieneHechizo()?hechizoAtributo.ToString():"No tiene hechizo")+"\n" + (TieneObjeto()?objetoAtributo.ToString():"No tiene objeto")+"\n";
    }
}
