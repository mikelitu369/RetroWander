using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimDebug : MonoBehaviour
{
    ShootController sc;
    private void Start()
    {
        sc = GetComponent<ShootController>();
        sc.SetPlayer(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Vector3.forward, 90);
            sc.SpeedSet();
        }
        transform.Rotate(Vector3.forward, 10);
        sc.SpeedSet();

    }
}
