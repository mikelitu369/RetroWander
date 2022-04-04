using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] float speedBaseOriginal;
    
    float speedBase;
    float speed;
    float verticalSpeed;
    protected bool player2;

    public bool disparaPorMarciano = false;
    public void SetPlayer(bool player)
    {
        player2 = player;
        if (!player2)
        {
            GetComponent<SwapMaterial>().Set(player2);
            speedBase = speedBaseOriginal;
        }
        else
        {
            GetComponent<SwapMaterial>().Set(player2);
            speedBase = -speedBaseOriginal;
        }

        SpeedSet();
    }

    public void SpeedSet()
    {
        verticalSpeed = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speedBase;
        speed = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speedBase;
    }

    protected virtual void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("nave"))
        {
            NaveController nave = collision.GetComponent<NaveController>();
            if (player2 != nave.Player2())
            {
                Destroy();
                nave.ReciveHit();
                
            }
        }
        else if (collision.CompareTag("obstaculo"))
        {
            Destroy();
        }
        else if (collision.CompareTag("limite"))
        {
            Destroy();
        }
        else if (collision.CompareTag("marciano") && !disparaPorMarciano)
        {
            Destroy();
        }
    }
    
    public bool Player()
    {
        return player2;
    }
   
    protected virtual void Destroy()
    {
        GameObject explosion = PullFX.instance.NewExplosionDisparo(player2);
        explosion.transform.position = transform.position;
        BalasManager.instance.DestroyBala(this.gameObject);
        disparaPorMarciano = false;
    }
}
