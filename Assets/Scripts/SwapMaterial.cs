using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    [SerializeField] Material player1, player2;

    public void Set(bool player)
    {
        if (!player)
        {
            GetComponentInChildren<SpriteRenderer>().material = player1;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().material = player2;
        }
    }
}
