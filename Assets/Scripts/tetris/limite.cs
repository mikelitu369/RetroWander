using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limite : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;


    public void AsignarJugador(int jugador)
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[jugador];
        }
    }
}
