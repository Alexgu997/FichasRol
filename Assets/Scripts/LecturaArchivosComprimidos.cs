using iText.Kernel.Geom;
using MimeKit;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Windows;
using System.Linq;
using System.IO;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;

public static class LecturaArchivosComprimidos
{


    // Ruta del archivo ZIP
    //private string zipFilePath = "Assets/YourEmails.zip"; // Asegúrate de poner la ruta correcta
    //private string outputFolderPath = "Assets/ExtractedPDFs/";


    /* public static void ExtractPdfsFromZip1(string zipPath, string outputPath)
     {
         List<string> extractedPDFs = new List<string>();

         // Crear el directorio de salida si no existe
         if (!System.IO.Directory.Exists(outputPath))
         {
             System.IO.Directory.CreateDirectory(outputPath);
         }

         // Extraer el contenido del ZIP
         using (ZipArchive archive = ZipFile.OpenRead(zipPath))
         {
             foreach (ZipArchiveEntry entry in archive.Entries)
             {
                 // Solo procesar archivos EML
                 if (entry.FullName.EndsWith(".eml", System.StringComparison.OrdinalIgnoreCase))
                 {
                     // Leer el contenido del archivo EML
                     using (Stream stream = entry.Open())
                     {
                         MimeMessage message = MimeMessage.Load(stream);

                         // Extraer los adjuntos
                         foreach (var attachment in message.Attachments)
                         {
                             //Comprueba si es un tipo mimepart && y si acaba con .pdf en mayusculas o minusculas
                             if (attachment is MimePart mimePart && mimePart.FileName.EndsWith(".pdf", System.StringComparison.OrdinalIgnoreCase))
                             {


                                     string tempPath = Path.Combine(Path.GetTempPath(), mimePart.FileName);
                                     using (var fileStream = File.Create(tempPath))
                                     {
                                         mimePart.Content.DecodeTo(fileStream);
                                         extractedPDFs.Add(tempPath);
                                         Debug.Log("PDF extraído temporalmente: " + tempPath);
                                     }

                                 //Aqui hacer el filtrado
                                 if ()
                                 {
                                     //Combina la ruta de salida con el archivo para guardarlo
                                     string fileName = System.IO.Path.Combine(outputPath, mimePart.FileName);
                                     //Crea el archivo en la ruta asignada
                                     using (FileStream fileStream = System.IO.File.Create(fileName))
                                     {
                                         //guarda el contenido del adjunto en este caso el pdf en el archivo
                                         mimePart.Content.DecodeTo(fileStream);
                                         Debug.Log("PDF extraído: " + fileName);
                                     }
                                 }

                             }
                         }
                     }
                 }
             }
         }
     }*/
    public static List<string> ExtractPdfsFromZip(string zipPath, string outputPath)
    {
        List<string> extractedPDFs = new List<string>();
        
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            Debug.Log("Crea archivo legible");
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                Debug.Log("Crea entradas de archivo");
                if (entry.FullName.EndsWith(".eml", System.StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = entry.Open())
                    {
                        MimeMessage message = MimeMessage.Load(stream);
                        foreach (var attachment in message.Attachments)
                        {
                            if (attachment is MimePart mimePart && mimePart.FileName.EndsWith(".pdf", System.StringComparison.OrdinalIgnoreCase))
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), mimePart.FileName);
                                using (var fileStream = System.IO.File.Create(tempPath))
                                {
                                    mimePart.Content.DecodeTo(fileStream);
                                    extractedPDFs.Add(tempPath);
                                    Debug.Log("PDF extraído temporalmente: " + tempPath);
                                }
                            }
                        }
                    }
                }else if (entry.FullName.EndsWith(".pdf", System.StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("es un pdf");
                }
            }
        }

      return extractedPDFs;
    }
  

}
