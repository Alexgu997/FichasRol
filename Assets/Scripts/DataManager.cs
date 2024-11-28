using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string pathArchivo;
    private string pathCarpetaSalida;
    private string filter;
    private List<string> pdfs;


    public void SetFiltre(string value)
    {
        filter = value;
    }
    public void BusquedaArchivo()
    {
        pathArchivo = BusquedaArchivos.BuscarArchivo("Seleccione archivo pdf");
    }

    public void EstablecerCarpetaSalidaPDFS()
    {
        pathCarpetaSalida = BusquedaArchivos.BuscarCarpeta("Seleccione Carpeta de salida pdfs");
    }

    public void IniciarBusqueda()
    {
        if (pathArchivo.EndsWith(".pdf"))
        {
            ManipuladorPDFS.ExtractTextFromPDF(pathArchivo);
        }
        else if(pathArchivo.EndsWith(".zip"))
        {
            pdfs=LecturaArchivosComprimidos.ExtractPdfsFromZip(pathArchivo, pathCarpetaSalida);
            foreach (string pdf in pdfs)
            {
                ProcessAndSavePDF(pdf);
                System.IO.File.Delete(pdf); // Eliminar el archivo temporal
            }

        }

    }

    private bool FilterPDF(string pdf)
    {
        // Aquí puedes agregar tus criterios de filtrado
        // Por ejemplo, filtrar por texto específico en el PDF
        string text = ManipuladorPDFS.ExtractTextFromPDF(pdf);
        return text.Contains(filter); // Cambia esto por tus criterios
    }

    private void ProcessAndSavePDF(string pdf)
    {

        if (FilterPDF(pdf))
        {
            string fileName = System.IO.Path.GetFileName(pdf);
            string destinationPath = System.IO.Path.Combine(pathCarpetaSalida, fileName);
            System.IO.File.Copy(pdf, destinationPath, true);
            Debug.Log("PDF guardado: " + destinationPath);
        }
        else
        {
            Debug.Log("PDF no cumple con los criterios de filtrado: " + pdf);
        }
    }
}
