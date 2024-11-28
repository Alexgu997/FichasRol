using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
   [SerializeField]
    TMP_InputField textoBusqueda;
    DataManager dataManager;
    private void Start()
    {
        dataManager = GetComponent<DataManager>();
    }
    public void BotonBuscarArchivos()
    {
        dataManager.BusquedaArchivo();
    }

    public void BotonBusquedaPDFS()
    {
        dataManager.IniciarBusqueda();
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonBuscarCarpeta()
    {
      dataManager.EstablecerCarpetaSalidaPDFS();
    }

    public void MeterTexto()
    {
        Debug.Log(textoBusqueda.text);
        dataManager.SetFiltre(textoBusqueda.text);
    }
}
