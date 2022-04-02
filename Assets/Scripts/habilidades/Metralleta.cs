using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metralleta : Habilidad
{
    float duration, cadence;
    public Metralleta(NaveController nc)
    {
        nave = nc;
        duration = 4;
        cadence = 0.1f;
        coste = 20;
    }

    public override bool Active()
    {
        if (!base.Active()) return false;

        nave.StartCoroutine(Activacion());

        return true;
    }

    IEnumerator Activacion()
    {
        for (int i = 0; i < duration / cadence; i++)
        {
            Disparar();
            yield return new WaitForSeconds(cadence);
        }
    }

    void Disparar()
    {
        GameObject g = BalasManager.instance.NewBala();
        g.transform.position = nave.transform.position;
        g.transform.rotation = Quaternion.identity;
        g.GetComponent<ShootController>().SetPlayer(nave.Player2());
    }
}
