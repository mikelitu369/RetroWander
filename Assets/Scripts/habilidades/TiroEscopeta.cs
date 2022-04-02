using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroEscopeta : Habilidad
{
    float maxAngle;
    int numDisparos;

    public TiroEscopeta(NaveController nc)
    {
        nave = nc;
        maxAngle = 45f;
        numDisparos = 7;
        coste = 10;
    }

    public override bool Active()
    {
        if (!base.Active()) return false;

        float angleDesfase = (maxAngle * 2) / numDisparos;
        float angle = maxAngle;

        for (int i = 0; i < numDisparos; i++)
        {
            GameObject g = BalasManager.instance.NewBala();
            g.transform.position = nave.transform.position;
            g.transform.rotation = Quaternion.identity;
            g.transform.Rotate(Vector3.forward, angle);
            g.GetComponent<ShootController>().SetPlayer(nave.Player2());

            angle -= angleDesfase;
        }
        return true;
    }
}
