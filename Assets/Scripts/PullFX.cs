using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullFX : MonoBehaviour
{
    public enum FXs
    {
        explosionDisparo,
        explosionDisparoPerf,
        expansion
    }

    public static PullFX instance;    
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }

    [SerializeField] GameObject explosionDisparo;
    List<GameObject> explosionesDisparos = new List<GameObject>();
    [SerializeField] GameObject explosionDisparoPerf;
    List<GameObject> explosionesDisparosPerf = new List<GameObject>();
    [SerializeField] GameObject ondaExpansiva;
    List<GameObject> ondasExpansivas = new List<GameObject>();

    public GameObject NewExplosionDisparo(bool player2 = false)
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

        explosion.GetComponent<SwapMaterial>().Set(player2);

        return explosion;
    }

    public void DestroyObject(GameObject fx, FXs tipo)
    {
        switch (tipo)
        {
            case FXs.explosionDisparo:
                DestroyExplosionDisparo(fx);
                break;
            case FXs.explosionDisparoPerf:
                DestroyExplosionDisparoPerf(fx);
                break;
        }
    }

    private  void DestroyExplosionDisparo(GameObject explosion)
    {
        explosionesDisparos.Add(explosion);
        explosion.SetActive(false);
    }

    public GameObject NewExplosionDisparoPerf(bool player2 = false)
    {

        GameObject explosion = null;
        if (explosionesDisparosPerf.Count > 0)
        {
            explosion = explosionesDisparosPerf[0];
            explosion.SetActive(true);
            explosionesDisparosPerf.Remove(explosion);
        }
        else
        {
            explosion = Instantiate(explosionDisparoPerf, transform);
        }

        explosion.GetComponent<SwapMaterial>().Set(player2);

        return explosion;
    }

    private void DestroyExplosionDisparoPerf(GameObject explosion)
    {
        explosionesDisparosPerf.Add(explosion);
        explosion.SetActive(false);
    }
}
