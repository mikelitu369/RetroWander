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
            Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            transform.rotation = Quaternion.identity;
            Debug.Log(Mathf.Atan2(direccion.x, direccion.y));
            transform.Rotate(Vector3.forward, Mathf.Rad2Deg * Mathf.Atan2(direccion.y, direccion.x));

            sc.SpeedSet();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
    }
}
