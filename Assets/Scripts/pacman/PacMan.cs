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

    int direccion = 1;
    private void Start()
    {
        nave1 = GodOfGame.instance.nave1;
        nave2 = GodOfGame.instance.nave2;
        cabreoConJugadorUno = cabreoConJugador2 = 0;
        enfadado = false;
        sprite.GetComponent<HijoPacman>().padre = this;
        NuevaPosicion();
    }
    public void Cabrear(int i)
    {

        if(i == 0)
        {
            if (cabreoConJugador2 > 4) 
            {
                Debug.Log("Supercabreo " + cabreoConJugador2);
                return;
            }

            ++cabreoConJugador2;
            if (cabreoConJugadorUno > 0) --cabreoConJugadorUno;
            sprite.transform.Rotate(Vector3.forward,  -18 * direccion);
        }
        else
        {
            if (cabreoConJugadorUno > 4)
            {
                Debug.Log("Supercabreo " + cabreoConJugadorUno);
                return;
            }
            ++cabreoConJugadorUno;
            if (cabreoConJugador2 > 0) --cabreoConJugador2;
            sprite.transform.Rotate(Vector3.forward, 18 * direccion);
        }


    }
    public void NuevaPosicion()
    {
        sprite.transform.rotation = Quaternion.identity;
        float anguloExtra = 18 * (cabreoConJugadorUno - cabreoConJugador2);
        Debug.Log(anguloExtra);
        if (sprite.transform.position.y < 0)
        {
            direccion = 1;
            posObjetivo = new Vector2(0, 12);
            sprite.transform.Rotate(Vector3.forward, 90 + anguloExtra);
        }
        else
        {
            direccion = -1;
            posObjetivo = new Vector2(0, -12);
            sprite.transform.Rotate(Vector3.forward, -90 - anguloExtra);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(new Vector2(sprite.transform.position.x, sprite.transform.position.y), posObjetivo) < 1f)
        {
            timer += Time.deltaTime;
            if (timer > cooldDown)
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
