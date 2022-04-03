using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{



    [SerializeField] float cooldDown;
    [SerializeField] float steering;
    [SerializeField] float velocidad;
    [SerializeField] int limiteCabreo;
    [SerializeField] GameObject sprite;

    int cabreoConJugadorUno, cabreoConJugador2;
    


    bool enfadado;

    float timer;

    NaveController nave1, nave2;

    Vector2 posObjetivo;


    private void Start()
    {
        nave1 = GodOfGame.instance.nave1;
        nave2 = GodOfGame.instance.nave2;
        cabreoConJugadorUno = cabreoConJugador2 = 0;
        enfadado = false;
    }

    public void NuevaPosicion()
    {
        if(this.transform.position.y < 0)
        {
            posObjetivo = new Vector2(0, 10);
           
        }
        else
        {
            posObjetivo = new Vector2(0, -10);
        }
    }

}
