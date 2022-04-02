using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaIndividualTetris : MonoBehaviour
{

     public PadreTetris padre;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        padre.Parar();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PiezaIndividualTetris>() && collision.gameObject.GetComponent<PiezaIndividualTetris>().padre != padre)
        {
            padre.Parar();
        }
    }
}
