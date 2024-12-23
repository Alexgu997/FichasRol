using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    public static ControladorMenu instance;
    [SerializeField]
    private Dictionary<int, GameObject[]> paneles;
    [SerializeField]
    private GameObject[] panelesTiradorDados,panelesCreacionPersonaje,panelesMenuInicial;
    private int posicionMenuActual;
    private int posicionSubMenu;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        posicionMenuActual = 0;
        posicionSubMenu = 0;
        paneles = new Dictionary<int, GameObject[]>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CargarPaneles();
        DesactivarPaneles();
        CambiarDeMenu(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CargarPaneles()
    {
       
        paneles.Add(0, panelesMenuInicial);
        paneles.Add(1, panelesTiradorDados);
        paneles.Add(2,panelesCreacionPersonaje);

    }

    private void AvanzarSiguienteSubMenu()
    {
        
        GameObject[] panelesSubMenu = paneles[posicionMenuActual];
        if(panelesSubMenu.Length > 1)//tamaño de 6
        {
            posicionSubMenu++;//1, 1+1=2
            Debug.Log("Submenu:" + posicionSubMenu);
            if (posicionSubMenu != 1) 
            {
                if (posicionSubMenu >= panelesSubMenu.Length)
                {
                    posicionSubMenu = 1;
                    panelesSubMenu[posicionSubMenu].SetActive(true);
                    panelesSubMenu[panelesSubMenu.Length - 1].SetActive(false);
                    Debug.Log("Pasa por submenu final:"+ panelesSubMenu.Length);
                }
                else
                {
                    panelesSubMenu[posicionSubMenu].SetActive(true);
                    panelesSubMenu[posicionSubMenu - 1].SetActive(false);
                    Debug.Log("Avanza siguiente submenu, submenu actual es:" + posicionSubMenu);
                }
                
            }
            else
            {
                panelesSubMenu[posicionSubMenu].SetActive(true);
                panelesSubMenu[panelesSubMenu.Length - 1].SetActive(false);
                Debug.Log("Avanza al primer submenu desde el ultimo o inicia, submenu actual es:" + posicionSubMenu);
            }    
            Debug.Log("Tamaño array:"+ panelesSubMenu.Length);
        }
        else
        {
            posicionSubMenu = 0;
            panelesSubMenu[posicionSubMenu].SetActive(true);
        }
        Debug.Log("Submenu:"+posicionSubMenu);

    }

    private void RetrocesoAnteriorSubmenu()
    {
        GameObject[] panelesSubMenu = paneles[posicionMenuActual];
        if (panelesSubMenu.Length > 1)//tamaño de 6
        {
            posicionSubMenu--;//1, 1+1=2
            Debug.Log("Submenu:" + posicionSubMenu);
            if (posicionSubMenu != panelesSubMenu.Length-1)
            {
                if (posicionSubMenu < 1)
                {
                    posicionSubMenu = panelesSubMenu.Length-1;
                    panelesSubMenu[posicionSubMenu].SetActive(true);
                    panelesSubMenu[1].SetActive(false);
                    Debug.Log("Pasa por submenu final:" + panelesSubMenu.Length);
                }
                else
                {
                    panelesSubMenu[posicionSubMenu].SetActive(true);
                    panelesSubMenu[posicionSubMenu + 1].SetActive(false);
                    Debug.Log("Retrocede siguiente submenu, submenu actual es:" + posicionSubMenu);
                }
               
            }
            else
            {
                panelesSubMenu[panelesSubMenu.Length-1].SetActive(true);
                panelesSubMenu[1].SetActive(false);
                Debug.Log("Retrocede al primer submenu desde el ultimo o inicia, submenu actual es:" + posicionSubMenu);

            }
            Debug.Log("Tamaño array:" + panelesSubMenu.Length);
        }
        else
        {
            posicionSubMenu = 0;
            panelesSubMenu[posicionSubMenu].SetActive(true);
        }
        Debug.Log("Submenu:" + posicionSubMenu);
    }

    private void CambiarMenuPaneles(int valorNuevaPosicion)
    {
        
        if (paneles.Keys.Contains(valorNuevaPosicion))
        {
            paneles[posicionMenuActual][posicionSubMenu].SetActive(false) ;
            paneles[posicionMenuActual][0].SetActive(false);
            paneles[valorNuevaPosicion][0].SetActive(true);
            posicionSubMenu = 0;
            posicionMenuActual = valorNuevaPosicion;
            instance.AvanzarSiguienteSubMenu();

           
        }


    }

    public void AvanceSubMenu()
    {
        instance.AvanzarSiguienteSubMenu();
    }
    public void RetrocederSubMenu()
    {
        instance.RetrocesoAnteriorSubmenu();
    }

    private void DesactivarPaneles()
    {
        paneles.Keys.ToList().ForEach(key => { paneles[key].ToList().ForEach(item => { item.SetActive(false); }); });
    }

    public void CambiarDeMenu(int menu)
    {
        switch(menu)
        {
            case 0:
                instance.CambiarMenuPaneles(0);
                break;
            case 1:
                instance.CambiarMenuPaneles(1);
                break;
            case 2:
                instance.CambiarMenuPaneles(2);
                break;
            case -1:Debug.Log("Cierre Aplicacion");
                Application.Quit();
                break;
        }
    }
   
}
