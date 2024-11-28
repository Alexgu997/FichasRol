using SFB;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class BusquedaArchivos
{

   

   public static string BuscarArchivo(string mensaje)
    {

        ExtensionFilter[] extensions = new ExtensionFilter[]
       {
            new ExtensionFilter("Archivos PDF o ZIP", "pdf", "zip")
       };

        string path = "";
        string initialPath = Application.dataPath; // Carpeta "Assets" del proyecto
        string[] paths = StandaloneFileBrowser.OpenFilePanel(mensaje, initialPath+"/PDFS", extensions, false);

        if (paths.Length > 0)
        {
            path = paths[0];

        }
        return path;
    }

    public static string BuscarCarpeta(string mensaje)
    {
        string path = "";
        string initialPath = Application.dataPath; // Carpeta "Assets" del proyecto
        string[] paths = StandaloneFileBrowser.OpenFolderPanel(mensaje, initialPath + "/PDFS" ,false);
        if (paths.Length > 0)
        {
            path = paths[0];

        }
       
        return path;
        
    }

}
