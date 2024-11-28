using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TiradasDados
{
    
    public static int TirarDados(E_TiposDados tipoDado,int numDados,int bonificador)
    {
        int resultado = 0;
        int numDadosCalculados = 0;
       while (numDadosCalculados<numDados)
        {
            resultado+=sacarValorDado(tipoDado)+bonificador;
            numDadosCalculados++;
        }
        return resultado;
    }

    public static int TirarDados(E_TiposDados tipoDado, int numDados)
    {
        int resultado = 0;
        int numDadosCalculados = 0;
        while (numDadosCalculados < numDados)
        {
            resultado += sacarValorDado(tipoDado);
            numDadosCalculados++;
        }
        return resultado;
    }

    public static int TirarDados(E_TiposDados tipoDado)
    {
            return sacarValorDado(tipoDado);
    }
    public static int sacarValorDado(E_TiposDados tipoDado)
    {
        int dado = 1;
        switch (tipoDado)
        {
            case E_TiposDados.D4:
                Random.Range(1, 4);
                break;
            case E_TiposDados.D6:
                dado = Random.Range(1, 6);
                break;
            case E_TiposDados.D8:
                dado = Random.Range(1, 8);
                break;
            case E_TiposDados.D10:
                dado = Random.Range(1, 10);
                break;
            case E_TiposDados.D12:
                dado = Random.Range(1, 12);
                break;
            case E_TiposDados.D20:
                dado = Random.Range(1, 20);
                break;
            case E_TiposDados.D100:
                dado = Random.Range(1, 100);
                break;
        }
        return dado;
    }
   
    
}
