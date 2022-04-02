using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasManager : MonoBehaviour
{
    public static BalasManager instance;
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }

    [SerializeField] GameObject bala;
    List<GameObject> balas = new List<GameObject>();

    public GameObject NewBala()
    {
        GameObject g = null;

        if (balas.Count > 0)
        {
            g = balas[0];
            g.SetActive(true);
            balas.Remove(g);
        }
        else
        {
            g = Instantiate(bala, transform);
        }

        return g;
    }

    public void DestroyBala(GameObject g)
    {
        balas.Add(g);
        g.SetActive(false);
    }
}
