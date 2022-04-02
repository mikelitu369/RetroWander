using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullFX : MonoBehaviour
{
    public enum FXs
    {
        explosionDisparo
    }
    public static PullFX instance;
    
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }
    [SerializeField] GameObject explosionDisparo;
    List<GameObject> explosionesDisparos = new List<GameObject>();

    public GameObject NewExplosionDisparo()
    {

        GameObject explosion = null;
        if (explosionesDisparos.Count > 0)
        {
            explosion = explosionesDisparos[0];
            explosion.SetActive(true);
            explosionesDisparos.Remove(explosion);
        }
        else
        {
            explosion = Instantiate(explosionDisparo, transform);
        }


        return explosion;
    }

    public void DestroyObject(GameObject fx, FXs tipo)
    {
        switch (tipo)
        {
            case FXs.explosionDisparo:
                DestroyExplosionDisparo(fx);
                break;
        }
    }

    private  void DestroyExplosionDisparo(GameObject explosion)
    {
        explosionesDisparos.Add(explosion);
        explosion.SetActive(false);
    }
}
