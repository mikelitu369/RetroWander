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
    [SerializeField] GameObject balaPerf;
    List<GameObject> balasPerf = new List<GameObject>();

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

    public GameObject NewBalaPerf()
    {
        GameObject g = null;

        if (balasPerf.Count > 0)
        {
            g = balasPerf[0];
            g.SetActive(true);
            g.gameObject.transform.rotation = Quaternion.identity;
            balasPerf.Remove(g);
        }
        else
        {
            g = Instantiate(balaPerf, transform);
        }

        return g;
    }

    public void DestroyBalaPerf(GameObject g)
    {
        balasPerf.Add(g);
        g.SetActive(false);
    }


    //Depprecated
    /*public void ClearScreen()
    {
        foreach(ShootController sc in transform.GetComponentsInChildren<ShootController>())
        {
            if (sc.gameObject.activeSelf) DestroyBala(sc.gameObject);
        }
    }
    public void ClearScreen(bool player)
    {
        foreach (ShootController sc in transform.GetComponentsInChildren<ShootController>())
        {
            if (sc.Player() == player && sc.gameObject.activeSelf) DestroyBala(sc.gameObject);
        }
    }*/
}
