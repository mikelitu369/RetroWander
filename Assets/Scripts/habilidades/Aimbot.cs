using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimbot : ShootController
{
    float turnSpeed = 1f;
    GameObject target;

    private void Start()
    {
        Set();
    }

    private void Set(GameObject enemy = null)
    {
        if (!enemy)
        {
            foreach(NaveController nc in FindObjectsOfType<NaveController>())
            {
                if (nc.Player2() != GetComponent<ShootController>().Player()) enemy = nc.gameObject;
            }
        }
        print(enemy);
        target = enemy;
    }

    protected override void Update()
    {
        Vector3 distancia = target.transform.position - transform.position;
        transform.Rotate(Vector3.forward, Mathf.Atan2(distancia.y, distancia.x) * turnSpeed * Time.deltaTime);
        SpeedSet();

        base.Update();
    }

    protected override void Destroy()
    {
        GameObject explosion = PullFX.instance.NewExplosionDisparo(player2);
        explosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
