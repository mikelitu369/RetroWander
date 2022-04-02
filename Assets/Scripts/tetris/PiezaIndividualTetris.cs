using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaIndividualTetris : MonoBehaviour
{
    public int vidaMax;
    public int vida;
   public  bool active = true;
     public PadreTetris padre;
    public int jugador;
    private void Start()
    {
        vida = vidaMax;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShootController>())
        {
            if (padre.active)
            {
                if (collision.GetComponent<ShootController>().Player())
                {
                    padre.AsignarJugador(0);
                }
                else
                {
                    padre.AsignarJugador(1);
                }
               
            }
            else
            {
                if (collision.GetComponent<ShootController>().Player())
                {
                    jugador = 0;
                }
                else
                {
                    jugador = 1;
                }
            }
            RecibirDano();
            
        }
    }
    void RecibirDano()
    {
        --vida;
        if(vida <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        //if (active) this.transform.position += new Vector3(0, -1, 0) * padre.velocidad * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "stopper" || collision.gameObject.GetComponent<PiezaIndividualTetris>() && collision.gameObject.GetComponent<PiezaIndividualTetris>().padre != padre)
        {
            padre.Parar();
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "stopper" || collision.gameObject.GetComponent<PiezaIndividualTetris>() && collision.gameObject.GetComponent<PiezaIndividualTetris>().padre != padre)
        {
            padre.Parar();
        }
    }



    public void ComprobarActividadPadre()
    {
        padre.ComprobarActividad();
    }
}
