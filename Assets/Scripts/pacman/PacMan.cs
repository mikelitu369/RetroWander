using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{



    [SerializeField] float cooldDown;
    [SerializeField] float steering;
    [SerializeField] float velocidad;
    [SerializeField] float limiteCabreo;
    [SerializeField] GameObject sprite;
    [SerializeField] GameObject Trail;

    int cabreoConJugadorUno, cabreoConJugador2;



    bool enfadado;

    float timer;
    float timerCabreo;

    NaveController nave1, nave2, naveENfado;


    Vector2 posObjetivo;

    int direccion = 1;
    private void Start()
    {
        
        nave1 = GodOfGame.instance.nave1;
        nave2 = GodOfGame.instance.nave2;
        cabreoConJugadorUno = cabreoConJugador2 = 0;
        timer = 0;
        timerCabreo = 0;
        enfadado = false;
        sprite.GetComponent<HijoPacman>().padre = this;
        NuevaPosicion();
    }
    public void Cabrear(int i)
    {

        if (i == 0)
        {
            if (cabreoConJugador2 > 4)
            {
                Trail.SetActive(true);
                enfadado = true;
                naveENfado = nave2;
                Debug.Log("Supercabreo " + cabreoConJugador2);
                return;
            }

            ++cabreoConJugador2;
            if (cabreoConJugadorUno > 0) --cabreoConJugadorUno;
            sprite.transform.Rotate(Vector3.forward, -18 * direccion);
        }
        else
        {
            if (cabreoConJugadorUno > 4)
            {
                Trail.SetActive(true);
                enfadado = true;
                naveENfado = nave1;
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
        if (!enfadado)
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
        else
        {
            timerCabreo += Time.deltaTime;
            if(timerCabreo > limiteCabreo)
            {
                Debug.Log("reposiciono");
                enfadado = false;
                Trail.SetActive(false);
                timerCabreo = 0;
                direccion = 1;
                cabreoConJugador2 = 0;
                cabreoConJugadorUno = 0;
                timer = 0;
                sprite.GetComponent<Rigidbody2D>().angularVelocity = 0;
                sprite.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                sprite.transform.position = new Vector3(0, -12, 0);
                sprite.transform.rotation = Quaternion.identity;
                NuevaPosicion();
            }
        }
    }
    private void FixedUpdate()
    {
        if (enfadado)
        {
            timerCabreo += Time.deltaTime;
            Debug.Log("hola");
            Vector2 direccion = (Vector2)naveENfado.gameObject.transform.position - (Vector2)sprite.transform.position;

            direccion.Normalize();

            float rotateAmount = Vector3.Cross(direccion, sprite.transform.right).z;


            sprite.GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * steering;
            sprite.GetComponent<Rigidbody2D>().velocity = sprite.transform.right * velocidad * 4;
        }
    }


}
