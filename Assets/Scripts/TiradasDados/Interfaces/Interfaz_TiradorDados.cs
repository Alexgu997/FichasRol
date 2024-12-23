using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Interfaz_TiradorDados : MonoBehaviour
{
    //[SerializeField,Tooltip("Variables de cada boton")]
    //Button button_D4, button_D6, button_D8, button_D10, button_D20, button_D100;
   
    [SerializeField, Tooltip("")]
    Color color_SinPulsarBoton, color_PulsadoBoton;

    int bonificadorValor, cantidadDadosValor;
    [SerializeField]
    TMP_InputField inputBonificador, inputCantidadDados;

    [SerializeField]
    GameObject prefabTextHistorialTiradas;
    [SerializeField]
    GameObject contentHistorialTiradas;

    private static int MAXCANTIDADDADOS = 15;
    private static int MINCANTIDADDADOS = 1;
    private static int MAXBONIFICADOR = 15;
    private static int MINBONIFICADOR = -15;
    private void Awake()
    {
        bonificadorValor = 0;
        cantidadDadosValor = MINCANTIDADDADOS;
        
    }
    // Start is called before the first frame update
    void Start()
    {
      
        UpdateInputBonificador();
        UpdateInputCantDados();
       
        foreach (GameObject dado in SacarGameObjectsDados())
        {
            CambiarColoresImagenesToogle(dado);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToogleClick(GameObject botonActivador)
    {
       CambiarColoresImagenesToogle(botonActivador);
        
    }

    public void CambiarColoresImagenesToogle(GameObject botonActivador)
    {
 
        foreach (Image imagen in botonActivador.GetComponentsInChildren<Image>())
        {
           
            if (!botonActivador.GetComponent<Toggle>().isOn)
            {
                CambiarColorImagen(imagen,color_SinPulsarBoton);
            }else
            {
                CambiarColorImagen(imagen,color_PulsadoBoton);
            }
           
        }
    }

    public void BotonTirarDados()
    {
        foreach(E_TiposDados dado in ComprobarDadosActivados())
        {
            CargarPrefabMensajeHistorial(MensajeHistorialTiradaDado(dado, TiradasDados.TirarDados(dado, cantidadDadosValor, bonificadorValor)));
        }
    }
    public string MensajeHistorialTiradaDado(E_TiposDados dado,int valorDadoTirado)
    {
        string mensaje = "";
        mensaje=string.Concat("Tirado ",dado," ", cantidadDadosValor.ToString()," veces + ",bonificadorValor.ToString(),"= ",valorDadoTirado.ToString());
        return mensaje;
    }

    public void CargarPrefabMensajeHistorial(string mensaje)
    {
        Instantiate(prefabTextHistorialTiradas,contentHistorialTiradas.transform).GetComponent<TextMeshProUGUI>().text=mensaje;
    }

    public void BorrarHistorial()
    {
       foreach(TextMeshProUGUI text in contentHistorialTiradas.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Destroy(text.gameObject);
        }
    }
  

    public List<E_TiposDados> ComprobarDadosActivados()
    {
       Toggle[] toggles= SacarTooglesDados();
        E_TiposDados[] dadosEnum= { E_TiposDados.D4, E_TiposDados.D6, E_TiposDados.D8, E_TiposDados.D10, E_TiposDados.D12, E_TiposDados.D20, E_TiposDados.D100 };
        List<E_TiposDados> dadosEncontrados=new List<E_TiposDados>();
       for (int i=0;i<toggles.Length;i++)
        {
            if (toggles[i].isOn)
            {
                dadosEncontrados.Add(dadosEnum[i]);
            }
        }
        return dadosEncontrados;
    }

    public void CambiarColorImagen(Image imagenBoton,Color color)
    {
        imagenBoton.color = color;
    }

   public Toggle[] SacarTooglesDados()
    {
        return GameObject.Find("Grid_Dados").GetComponentsInChildren<Toggle>();
    }

    public GameObject[] SacarGameObjectsDados()
    {
        GameObject[] dados;
        GameObject grid = GameObject.Find("Grid_Dados");
        Toggle[] toggles = grid.GetComponentsInChildren<Toggle>();
        dados = new GameObject[toggles.Length];
        for (int i = 0; i < toggles.Length; i++)
        {
            dados[i] = toggles[i].gameObject;
        }
        return dados;
    }

    public void AumentarValor(TMP_InputField inputAñadir)
    {
       
        if (ComprobrarInput(inputAñadir) == 1)
        {
            SetBonificador(bonificadorValor+1);
            UpdateInputBonificador();
        }
        else
        {
            SetCantidadDadosValor(cantidadDadosValor+1);
            UpdateInputCantDados();
        }
    }

    public void DisminuirValor(TMP_InputField inputAñadir)
    {
       
        if (ComprobrarInput(inputAñadir) == 1)
        {
            SetBonificador(bonificadorValor-1);
            UpdateInputBonificador();
        }
        else
        {
            SetCantidadDadosValor(cantidadDadosValor-1);
            UpdateInputCantDados();
        }
    }

    private int ComprobrarInput(TMP_InputField inputAñadir)
    {
        int comprobacion = 0; 
        if (inputAñadir == inputBonificador)
        {
            comprobacion++;//si comprobacion es 1, significa que es bonificador
        }
        else
        {
            comprobacion--;//si comprobacion es -1, significa que es cantidad de dados
        }
        return comprobacion;
    }

    private void UpdateInputBonificador()
    {
        inputBonificador.text = bonificadorValor.ToString();
    }

    private void UpdateInputCantDados()
    {
        
        inputCantidadDados.text = cantidadDadosValor.ToString();
    }

    public void SetInputBonificador()
    {
        int value;
        if (int.TryParse(inputBonificador.text, out value))
        {
            SetBonificador(value);
        }
        UpdateInputBonificador();
    }

    public void SetInputCantidadDados()
    {
        int value;
        if (int.TryParse(inputCantidadDados.text, out value))
        {
            SetCantidadDadosValor(value);
        }
        UpdateInputCantDados();
    }

    private void SetCantidadDadosValor(int nuevoValor)
    {
        if (nuevoValor<MINCANTIDADDADOS)
        {
           cantidadDadosValor = MINCANTIDADDADOS;
        }
        else if(nuevoValor>MAXCANTIDADDADOS )
        {
            cantidadDadosValor= MAXCANTIDADDADOS;
        }
        else
        {
            cantidadDadosValor = nuevoValor;
        }
    }

    private void SetBonificador(int nuevoValor)
    {
        if (nuevoValor < MINBONIFICADOR)
        {
            bonificadorValor = MINBONIFICADOR;
        }
        else if (nuevoValor > MAXBONIFICADOR)
        {
            bonificadorValor = MAXBONIFICADOR;
        }
        else
        {
            bonificadorValor = nuevoValor;
        }
     
    }
}
