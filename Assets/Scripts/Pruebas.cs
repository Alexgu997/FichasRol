using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iText;
using System;
using System.IO;
using iText.Kernel;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text;

public class Pruebas 
{
    
   // public static readonly String DEST = "results/sandbox/parse";

    //public static readonly String SRC = "D:/Programas/Unity/Proyectos/PDFReader/Assets/PDFS/HOLAMUNDOPRUEBA.pdf";

    // Ruta del archivo PDF
    //private string pdfFilePath = "Assets/PDFS/HOLAMUNDOPRUEBA.pdf";  // Asegúrate de poner la ruta correcta
    public void SacarDatos()
    {
  
            //Directory.CreateDirectory(DEST);

           // ManipulatePdf(DEST);

       
    }

    // Método para extraer texto de un archivo PDF
    public string ExtractTextFromPDF(string path)
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
            return output.ToString();
        }
    }
}

