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
        transform.rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        sc.SpeedSet();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
    }
}
