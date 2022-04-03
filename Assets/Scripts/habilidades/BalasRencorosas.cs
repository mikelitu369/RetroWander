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
        Sonidero.instance.NewSound(Sonidero.audios.redireccion);
        NaveController enemigo = GodOfGame.instance.GetNave(!nave.Player2());

        foreach (ShootController sc in BalasManager.instance.transform.GetComponentsInChildren<ShootController>())
        {
            if (sc.gameObject.activeSelf && sc.Player() == nave.Player2())
            {
                Auxiliar.RotacionAsistida(sc.gameObject, enemigo.transform.position);
                if (nave.Player2()) sc.transform.Rotate(Vector3.forward, 180f);
                sc.SpeedSet();
            }
        }
        foreach (FatShootController sc in BalasManager.instance.transform.GetComponentsInChildren<FatShootController>())
        {
            if (sc.gameObject.activeSelf && sc.Player() == nave.Player2())
            {
                Auxiliar.RotacionAsistida(sc.gameObject, enemigo.transform.position);
                if (nave.Player2()) sc.transform.Rotate(Vector3.forward, 180f);
                sc.SpeedSet();
            }
        }
        return true;
    }
}
