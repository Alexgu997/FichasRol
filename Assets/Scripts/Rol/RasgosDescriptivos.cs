using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasgosDescriptivos : MonoBehaviour
{
    E_Ojos ojos { get => ojos; set => ojos = value; }
    int edad { get => edad; set => edad = value; }
    float altura { get => altura; set => altura = value; }
    int peso { get => peso; set => peso = value; }
    E_Pieles piel { get => piel; set => piel = value; }
    E_Pelos pelo { get => pelo; set => pelo = value; }

    public RasgosDescriptivos()
    {
        this.ojos = ojos;
        this.edad = edad;
        this.altura = altura;
        this.peso = peso;
        this.piel = piel;
        this.pelo = pelo;
    }

    public RasgosDescriptivos(E_Ojos ojos, int edad, float altura, int peso, E_Pieles piel, E_Pelos pelo)
    {
        this.ojos = ojos;
        this.edad = edad;
        this.altura = altura;
        this.peso = peso;
        this.piel = piel;
        this.pelo = pelo;

    }

    public E_Ojos GetOjos()
    {
        return ojos;
    }

    public void SetOjos(E_Ojos ojosNuevos)
    {
        ojos = ojosNuevos;
    }

    public int GetEdad()
    {
        return edad;
    }

    public void SetEdad(int edadNueva)
    {
        edad = edadNueva;
    }

    public float GetAltura()
    {
        return altura;
    }

    public void SetAltura(float alturaNueva)
    {
        altura = alturaNueva;
    }
    public int GetPeso()
    {
        return peso;
    }

    public void SetPeso(int pesoNuevo)
    {
       peso = pesoNuevo;
    }
    public E_Pieles GetPiel()
    {
        return piel;
    }

    public void SetPiel(E_Pieles pielNueva)
    {
        piel = pielNueva;
    }
    public E_Pelos GetPelo()
    {
        return pelo;
    }

    public void SetPelo(E_Pelos peloNuevo)
    {
        pelo = peloNuevo;
    }

    public  bool Equals(RasgosDescriptivos obj)
    {
        return ojos.Equals(obj.GetOjos())&&
               edad == obj.GetEdad() &&
               altura == obj.GetAltura() &&
               peso == obj.GetPeso() &&
               EqualityComparer<E_Pieles>.Default.Equals(piel, obj.GetPiel()) &&
               EqualityComparer<E_Pelos>.Default.Equals(pelo, obj.GetPelo());
    }
}


