using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class GeneradorPdfFich : MonoBehaviour
{
    string inputpath, outputpath, temporalpath;
    string outputPdfName = "Ficha";
    // Start is called before the first frame update
    private void Awake()
    {
        temporalpath = System.IO.Path.Combine(Application.persistentDataPath, outputPdfName);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetInputPath()
    {
        inputpath = BusquedaArchivos.BuscarArchivo("Busca la ficha de personaje editable");
    }

    private void SetOutputPath()
    {
        outputpath = BusquedaArchivos.BuscarCarpeta("Selecciona carpeta para guardar fichas");


    }

    public void InitiateGeneration()
    {
        if (inputpath == null || inputpath == "")
            SetInputPath();
        if (outputpath == null || outputpath == "")
            SetOutputPath();
        Debug.Log(inputpath);
        // FillPdfForm();
        FillPdfForm(inputpath, outputPdfName);

    }
    public void FillPdfForm()
    {
        // Abrir el PDF existente
        PdfReader reader = new PdfReader(inputpath);
        PdfWriter writer = new PdfWriter(Application.persistentDataPath);
        PdfDocument pdfDoc = new PdfDocument(reader, writer);

        // Obtener el formulario del PDF
        PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

        // Rellenar campos específicos (cambiar los nombres de los campos según tu PDF)
        IDictionary<string, PdfFormField> fields = form.GetFormFields();
        Debug.Log(fields.ToString());
        /*
        fields["Nombre"].SetValue("Grommash Hellscream");
        fields["Clase"].SetValue("Barbaro 5");
        fields["Fuerza"].SetValue("18");
        fields["Destreza"].SetValue("14");
        */
        // Hacer que los campos no sean  editables (opcional)
        //form.FlattenFields();

        // Cerrar el PDF
        pdfDoc.Close();
        ManipuladorPDFS.MovePdfToSelectedFolder(inputpath, "Ficha", outputpath);
        Debug.Log("Formulario PDF rellenado y guardado en: " + outputpath);
    }

    public void FillPdfForm(string inputPdfPath, string outputPdfName)
    {
        // Cambiar la ruta de guardado a persistentDataPath
        string outputPdfPath = System.IO.Path.Combine(Application.persistentDataPath, outputPdfName);

        // Abrir el PDF existente
        PdfReader reader = new PdfReader(inputPdfPath);
        PdfWriter writer = new PdfWriter(outputPdfPath);
        PdfDocument pdfDoc = new PdfDocument(reader, writer);

        // Obtener el formulario del PDF
        PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

        // Rellenar campos específicos (cambiar los nombres de los campos según tu PDF)
        IDictionary<string, PdfFormField> fields = form.GetFormFields();
        Debug.Log(fields["Race"].GetValue().GetObjectType());
       
       

        // Cerrar el PDF
        pdfDoc.Close();

        // Ruta donde se guardó el PDF
        Debug.Log("Formulario PDF rellenado y guardado en: " + outputPdfPath);
    }
}

