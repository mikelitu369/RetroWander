using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsorBalas : Habilidad
{
    public RepulsorBalas(NaveController nc)
    {
        nave = nc;
        coste = 10;
    }

    public override bool Active()
    {
        if(!base.Active())return false;
        Sonidero.instance.NewSound(Sonidero.audios.escudo);
        GameObject g = PullFX.instance.NewExplosionOndaExpansiva(nave.Player2());
        g.transform.position = nave.transform.position;

        foreach (ShootController sc in BalasManager.instance.transform.GetComponentsInChildren<ShootController>())
        {
            if (sc.gameObject.activeSelf && sc.Player() != nave.Player2())
            {
                Vector3 direccion = sc.transform.position - nave.transform.position;
                if (direccion.sqrMagnitude > 15 * 15) continue;
                Auxiliar.RotacionAsistidaDirecta(sc.gameObject, direccion);
                if (nave.Player2()) sc.transform.Rotate(Vector3.forward, 180f);
                sc.SetPlayer(nave.Player2());
            }
        }


        foreach (FatShootController sc in BalasManager.instance.transform.GetComponentsInChildren<FatShootController>())
        {
            if (sc.gameObject.activeSelf && sc.Player() != nave.Player2())
            {
                Vector3 direccion = sc.transform.position - nave.transform.position;
                if (direccion.sqrMagnitude > 15 * 15) continue;
                Auxiliar.RotacionAsistidaDirecta(sc.gameObject, direccion);
                if (nave.Player2()) sc.transform.Rotate(Vector3.forward, 180f);
                sc.SetPlayer(nave.Player2());
            }
        }


        return true;
    }
}
