using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptorHabilidades : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GodOfGame.instance.SwapPausa();
            gameObject.SetActive(false);
        }
    }
}
