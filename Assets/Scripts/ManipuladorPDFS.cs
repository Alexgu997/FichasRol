using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SFB;

public static class ManipuladorPDFS 
{
   
    // Método para extraer texto de un archivo PDF
    public static string ExtractTextFromPDF(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        using (PdfDocument pdfDoc = new PdfDocument(reader))
        {
            StringWriter output = new StringWriter();
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                
                output.WriteLine(text);
            }
            Debug.Log(output.ToString());
            return output.ToString();
        }
    }


   /* public static void ProcessAndSavePDF(string path, string pathOutFolder)
    {
        if (FilterPDF(path))
        {
            string fileName = Path.GetFileName(path);
            string destinationPath = Path.Combine(pathOutFolder, fileName);
            File.Copy(path, destinationPath, true);
            Debug.Log("PDF guardado: " + destinationPath);
        }
        else
        {
            Debug.Log("PDF no cumple con los criterios de filtrado: " + path);
        }
    }*/

    public static void MovePdfToSelectedFolder(string inputFilePath,string pdfFileName, string outputFilePath)
    {

        // Asegurarse de que el archivo existe
        if (!File.Exists(inputFilePath))
        {
            Debug.LogError("El archivo no existe en: " + inputFilePath);
            return;
        }


       
        if (string.IsNullOrEmpty(outputFilePath))
        {
            Debug.Log("No se seleccionó ninguna carpeta.");
            return;
        }

        // Nueva ruta en la carpeta seleccionada
        string destinationPath = Path.Combine(outputFilePath, pdfFileName);

        try
        {
            // Mover el archivo
            File.Move(inputFilePath, destinationPath);

            // Confirmación en consola
            Debug.Log("Archivo movido a: " + destinationPath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al mover el archivo: " + ex.Message);
        }
    }
}
