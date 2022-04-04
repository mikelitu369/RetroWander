using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobertura : MonoBehaviour
{
    [SerializeField] int vida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            --vida;
            if (vida < 0)
            {

                this.gameObject.SetActive(false);

            }
        }

    }
}
