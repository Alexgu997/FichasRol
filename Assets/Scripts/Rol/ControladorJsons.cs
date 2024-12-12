using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ControladorJsons 
{
    static string PATHLOADOBJETOSESPAÑOL= "Assets/Resources/Jsons/RazasEsp.json";
    public static List<Objeto> LeerObjetosJson(E_Idiomas idioma)
    {
        List<Objeto> objetosJson= new List<Objeto>();
        string pathload = ObtenerRutaObjetosPorIdioma(idioma);
        if (File.Exists(pathload))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(pathload);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            objetosJson = JsonConvert.DeserializeObject<List<Objeto>>(fileContents);



        }
        else
        {
            objetosJson = null;
        }
       

        return objetosJson;
    }


    private static string ObtenerRutaObjetosPorIdioma(E_Idiomas idioma)
    {
        string pathload = "";
        switch (idioma)
        {
            case E_Idiomas.Español:pathload = PATHLOADOBJETOSESPAÑOL;
                break;
            case E_Idiomas.Ingles:
                break;
            case E_Idiomas.Frances:
                break;
        }


        return pathload;
    }
}
