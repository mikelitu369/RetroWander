using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMarcianos : MonoBehaviour
{

    public static PoolMarcianos instanace;

    [SerializeField] GameObject marciano;

    List<GameObject> marcianitos = new List<GameObject>();

    private void Awake()
    {
        if (!instanace) instanace = this;
        else Destroy(this.gameObject);
    }

    public GameObject CrearMarciano()
    {
        if (marcianitos.Count > 0)
        {
            GameObject g = marcianitos[0];
            g.transform.position = new Vector3(0, 12, 0);
            g.GetComponent<Marciano>().Reset();
            marcianitos.RemoveAt(0);
            return g;
        }
        else
        {
            GameObject g = Instantiate(marciano, new Vector3(0, 12, 0), Quaternion.identity);
            return g;
        }
    }
    public void anadiarMarciano(GameObject g)
    {
        marcianitos.Add(g);
    }
}
