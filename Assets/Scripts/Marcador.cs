using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    [SerializeField] Text puntos;
    
    [SerializeField] GameObject[] vidas;

    public void Set(int puntos)
    {
        this.puntos.text = puntos.ToString();
    }

    public void PerderVida()
    {
        foreach(GameObject g in vidas)
        {
            if (g.activeSelf)
            {
                g.SetActive(false);
                break;
            }
        }

        if (!vidas[vidas.Length - 1].activeSelf) End();
    }    

    void End()
    {
        print("End");
    }
}
