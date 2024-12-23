using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Historia 
{
    string pasadoPersonaje { get => pasadoPersonaje; set => pasadoPersonaje = value; }
    List<string> aliadosUOrganizaciones { get => aliadosUOrganizaciones; set => aliadosUOrganizaciones = value; }
    string tesoro { get => tesoro; set => tesoro = value; }
    string rasgosAtributosAdicionales { get => rasgosAtributosAdicionales; set => rasgosAtributosAdicionales = value; }

    public Historia()
    {
        this.pasadoPersonaje ="";
        this.aliadosUOrganizaciones = new List<string>();
        this.tesoro = "";
        this.rasgosAtributosAdicionales = "";
    }

    public Historia(string pasadoPersonaje, List<string> aliadosUOrganizaciones, string tesoro, string rasgosAtributosAdicionales)
    {
        this.pasadoPersonaje = pasadoPersonaje;
        this.aliadosUOrganizaciones = aliadosUOrganizaciones;
        this.tesoro = tesoro;
        this.rasgosAtributosAdicionales = rasgosAtributosAdicionales;
    }

    public  bool Equals(Historia obj)
    {
        return pasadoPersonaje == obj.pasadoPersonaje &&
               EqualityComparer<List<string>>.Default.Equals(aliadosUOrganizaciones, obj.aliadosUOrganizaciones) &&
               tesoro == obj.tesoro &&
               rasgosAtributosAdicionales == obj.rasgosAtributosAdicionales;
    }
}
