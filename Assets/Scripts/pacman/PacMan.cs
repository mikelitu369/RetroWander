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
        NuevaPosicion();
    }

    public void NuevaPosicion()
    {
        Debug.Log("posPacman");
        if(sprite.transform.position.y < 0)
        {
            posObjetivo = new Vector2(0, 10);
            sprite.transform.Rotate(Vector3.forward, 90);
        }
        else
        {
            posObjetivo = new Vector2(0, -10);
            sprite.transform.Rotate(Vector3.forward, -90);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(new Vector2(sprite.transform.position.x, sprite.transform.position.y), posObjetivo) < 1f)
        {
            timer += Time.deltaTime;
            if(timer > cooldDown)
            {
                timer = 0;
                NuevaPosicion();
            }
        }
        else 
        {
            Vector2 direccion = (posObjetivo - new Vector2(sprite.transform.position.x, sprite.transform.position.y)).normalized;

            sprite.transform.position += new Vector3(direccion.x, direccion.y, 0) * velocidad * Time.deltaTime;
        }
    }

}
