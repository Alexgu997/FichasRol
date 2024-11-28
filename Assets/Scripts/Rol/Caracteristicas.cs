using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracteristicas : MonoBehaviour
{
    int valorDestreza,valorFuerza,valorConstitucion, valorInteligencia, valorSabiduria,valorCarisma;
    int bonificadorDestreza, bonificadorFuerza, bonificadorConstitucion, bonificadorInteligencia, bonificadorSabiduria, bonificadorCarisma;
   
    public Caracteristicas()
    {
        SetValorDestreza(0);
        SetValorFuerza(0);
        SetValorConstitucion(0);
        SetValorInteligencia(0);
        SetValorSabiduria(0);
        SetValorCarisma(0);
    }

    public Caracteristicas(int valorDestreza, int valorFuerza, int valorConstitucion, int valorInteligencia, int valorSabiduria, int valorCarisma, int bonificadorDestreza, int bonificadorFuerza, int bonificadorConstitucion, int bonificadorInteligencia, int bonificadorSabiduria, int bonificadorCarisma)
    {
        SetValorDestreza(valorDestreza);
        SetValorFuerza(valorFuerza);
        SetValorConstitucion(valorConstitucion);
        SetValorInteligencia(valorInteligencia);
        SetValorSabiduria(valorSabiduria);
       SetValorCarisma(valorCarisma);
    }
    #region Setters Y Getters
    public void SetValorDestreza(int valor)
    {
        if (valor >= 1 && valor<= 20)
        {
            valorDestreza=valor;
            SacarBonificador(E_Caracteristicas.DESTREZA);
        }
    }
    public void SetValorFuerza(int valor)
    {
        if (valor >= 1 && valor <= 20)
        {
            valorFuerza = valor;
            SacarBonificador(E_Caracteristicas.FUERZA);
        }
    }
    public void SetValorConstitucion(int valor)
    {
        if (valor >= 1 && valor <= 20)
        {
            valorConstitucion = valor;
            SacarBonificador(E_Caracteristicas.CONSTITUCION);
        }
    }
    public void SetValorInteligencia(int valor)
    {
        if (valor >= 1 && valor <= 20)
        {
            valorInteligencia = valor;
            SacarBonificador(E_Caracteristicas.INTELIGENCIA);
        }
    }

    public void SetValorSabiduria(int valor)
    {
        if (valor >= 1 && valor <= 20)
        {
            valorSabiduria = valor;
            SacarBonificador(E_Caracteristicas.SABIDURIA);
        }
    }
 
    public void SetValorCarisma(int valor)
    {
        if (valor >= 1 && valor <= 20)
        {
            valorCarisma = valor;
            SacarBonificador(E_Caracteristicas.CARISMA);
        }
    }


    #endregion Setters y Getters

    private void SacarBonificador(E_Caracteristicas caracteristica)
    {
       
        switch (caracteristica)
        {
            case E_Caracteristicas.FUERZA:bonificadorFuerza = CalcularBonificador(valorFuerza);
                break;
            case E_Caracteristicas.DESTREZA:bonificadorDestreza= CalcularBonificador(valorDestreza);
                break;
            case E_Caracteristicas.CONSTITUCION:bonificadorConstitucion= CalcularBonificador(valorConstitucion);
                break;
            case E_Caracteristicas.INTELIGENCIA:bonificadorInteligencia = CalcularBonificador(valorInteligencia);
                break;
            case E_Caracteristicas.SABIDURIA: bonificadorSabiduria= CalcularBonificador(valorSabiduria);
                break;
            case E_Caracteristicas.CARISMA:bonificadorCarisma= CalcularBonificador(valorCarisma);
                break;

        }
    }

    private int CalcularBonificador(int value)
    {
        return  (int)MathF.Ceiling((value - 10) % 2);
    }
}
