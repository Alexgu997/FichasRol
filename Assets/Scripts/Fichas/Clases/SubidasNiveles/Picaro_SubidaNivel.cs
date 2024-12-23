using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picaro_SubidaNivel : SubidaNivel
{
    int cantAtaqueFurtivo;
    E_TiposDados ataqueFurtivo;

    public Picaro_SubidaNivel() : base()
    {

        this.cantAtaqueFurtivo = 1;
        this.ataqueFurtivo = E_TiposDados.D6;
    }

    public Picaro_SubidaNivel(E_Clases clase, int bonificadorCompetenciaPorNivel, List<Atributo> rasgos,int cantTrucosNuevos,int cantConjurosNuevos,int[] espaciosConjurosNuevos, int cantAtaqueFurtivo, E_TiposDados ataqueFurtivo): base(clase, bonificadorCompetenciaPorNivel, rasgos, cantTrucosNuevos, cantConjurosNuevos,espaciosConjurosNuevos)
    {
        this.cantAtaqueFurtivo = cantAtaqueFurtivo;
        this.ataqueFurtivo = ataqueFurtivo;
    }

    public int CantAtaqueFurtivo { get => cantAtaqueFurtivo; set => cantAtaqueFurtivo = value; }
    public E_TiposDados AtaqueFurtivo { get => ataqueFurtivo; set => ataqueFurtivo = value; }

    public override bool Equals(object obj)
    {
        return obj is Picaro_SubidaNivel nivel &&
               base.Equals(obj) &&
               cantAtaqueFurtivo == nivel.cantAtaqueFurtivo &&
               ataqueFurtivo == nivel.ataqueFurtivo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), cantAtaqueFurtivo, ataqueFurtivo);
    }

    public override string ToString()
    {
        string returnValue= base.ToString();
        returnValue+= "Ataque furtivo= "+cantAtaqueFurtivo.ToString()+ataqueFurtivo.ToString()+"\n";
        return returnValue;
    }
}
