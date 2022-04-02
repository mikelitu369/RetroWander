using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] float speedBase;
    float speed;
    float verticalSpeed;
    bool player2;
    [SerializeField] Material blue, red;

    public void SetPlayer(bool player)
    {
        player2 = player;
        if (!player2)
        {
            GetComponentInChildren<SpriteRenderer>().material = blue;
            speed = speedBase;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().material = red;
            speed = -speedBase;
        }

        verticalSpeed = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;
        speed = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed;
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
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
    
    public bool Player()
    {
        return player2;
    }
}
