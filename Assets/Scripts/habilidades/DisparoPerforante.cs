﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPerforante : Habilidad
{
    public DisparoPerforante(NaveController nc)
    {
        nave = nc;
        coste = 10;
    }

    public override bool Active()
    {
        if(!base.Active())return false;

        GameObject g = BalasManager.instance.NewBalaPerf();
        g.transform.position = nave.transform.position;

        g.GetComponent<FatShootController>().SetPlayer(nave.Player2(), true);

        return true;
    }
}
