﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Habilidad
{
    public enum habilidades
    {
        none,
        tiroEscopeta
    }


    static float ManaCharge = 1;
    protected float coste;
    float mana;
    protected NaveController nave;

    

    public virtual bool Active()
    {
        if (mana < coste) return false;
        else
        {
            mana = 0;
            return true;
        }
    }
    
    public void ChargeMana()
    {
        mana += ManaCharge;
    }
}
