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
        Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        transform.Rotate(Vector3.forward, 180 * Mathf.Atan2(direccion.y,direccion.x) * Time.deltaTime);
        sc.SpeedSet();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
    }
}
