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
            foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) sr.material = player1;
        }
        else
        {
            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) sr.material = player2;
        }
    }
}
