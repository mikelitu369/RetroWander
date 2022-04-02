using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float speed;
    public bool player2;

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BalasManager.instance.DestroyBala(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("nave"))
        {
            NaveController nave = collision.GetComponent<NaveController>();
            if (player2 != nave.Player2())
            {
                BalasManager.instance.DestroyBala(this.gameObject);
                nave.ReciveHit();
            }
        }
    }
}
