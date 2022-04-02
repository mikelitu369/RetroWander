using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasRencorosas : Habilidad
{
    public BalasRencorosas(NaveController nc)
    {
        nave = nc;
        coste = 30;
    }

    public override bool Active()
    {
        if (!base.Active()) return false;

        return true;
    }
}
