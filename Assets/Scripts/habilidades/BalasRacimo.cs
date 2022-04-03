using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasRacimo : Habilidad
{
    float balasDividir;

    public BalasRacimo(NaveController nc)
    {
        nave = nc;
        balasDividir = 8;
        coste = 30;
    }

    public override bool Active()
    {
        if (!base.Active()) return false;
        nave.ReproducirLaser(3);
        foreach(ShootController sc in BalasManager.instance.transform.GetComponentsInChildren<ShootController>())
        {
            if(sc.gameObject.activeSelf && sc.Player() == nave.Player2())
            {
                Vector3 position = sc.transform.position;
                BalasManager.instance.DestroyBala(sc.gameObject);
                for (int i = 0; i < balasDividir; i++)
                {
                    float angulo = i * (360 / balasDividir);
                    GameObject g = BalasManager.instance.NewBala();
                    g.transform.position = position;
                    g.transform.Rotate(Vector3.forward, angulo);
                    g.GetComponent<ShootController>().SetPlayer(nave.Player2());
                }
            }
        }
        foreach (FatShootController sc in BalasManager.instance.transform.GetComponentsInChildren<FatShootController>())
        {
            if (sc.gameObject.activeSelf && sc.Player() == nave.Player2())
            {
                Vector3 position = sc.transform.position;
                BalasManager.instance.DestroyBalaPerf(sc.gameObject);
                for (int i = 0; i < balasDividir; i++)
                {
                    float angulo = i * (360 / balasDividir);
                    GameObject g = BalasManager.instance.NewBalaPerf();
                    g.transform.position = position;
                    g.transform.Rotate(Vector3.forward, angulo);
                    g.GetComponent<FatShootController>().SetPlayer(nave.Player2());
                }
            }
        }

        return true;
    }
}
