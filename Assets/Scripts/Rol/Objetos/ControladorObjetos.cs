using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorObjetos 
{
    static List<Objeto> objetosTotales;


    public static Objeto BuscarObjetoPorNombre(string nombre)
    {
        Objeto objetoBuscado=null;
        if(objetosTotales == null) 
        {
            CargarObjetos(E_Idiomas.Español);
        }

        for(int i = 0; i < objetosTotales.Count; i++)
        {
            if (objetosTotales[i].Nombre == nombre)
            {
                objetoBuscado = objetosTotales[i];
            }
            
        }

        return objetoBuscado;
    }

    public static Objeto BuscarObjetoPorCodigo(int codigo)
    {
        Objeto objetoBuscado = null;
        if (objetosTotales == null)
        {
            CargarObjetos(E_Idiomas.Español);
        }
        for (int i = 0; i < objetosTotales.Count; i++)
        {
            if (objetosTotales[i].Codigo == codigo)
            {
                objetoBuscado = objetosTotales[i];
            }

        }
        return objetoBuscado;
    }

    public static void CargarObjetos(E_Idiomas idioma)
    {
        objetosTotales = ControladorJsons.LeerObjetosJson(idioma);
    }
}
