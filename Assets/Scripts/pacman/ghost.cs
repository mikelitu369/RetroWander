using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{


    [SerializeField] int distanciaMaxima;
    [SerializeField] GameObject marioneta;
    [SerializeField] float velociad;

    Vector2 posObjetivo;


    public void NuevaPosicion()
    {
        Debug.Log("NUEVA POSICION");
        int randomDireccion = Random.Range(0, 2);


        int randomDistancia = Random.Range(-distanciaMaxima, distanciaMaxima);

        if(randomDireccion == 0)
        {
            posObjetivo = new Vector2( this.transform.position.x, this.transform.position.y) + new Vector2(randomDistancia,0);
            posObjetivo.y = marioneta.transform.position.y;
        }
        else
        {
            posObjetivo = new Vector2(this.transform.position.x, this.transform.position.y) + new Vector2(0, randomDistancia);
            posObjetivo.x = marioneta.transform.position.x;
        }
    }

    private void Start()
    {
        NuevaPosicion();
        marioneta.transform.position = posObjetivo;
        NuevaPosicion();
    }

    private void Update()
    {
        if(Vector2.Distance( new Vector2( marioneta.transform.position.x , marioneta.transform.position.y), posObjetivo) < 0.5f)
        {
            NuevaPosicion();
        }
        else 
        {
            Vector2 direccion = (posObjetivo -  new Vector2(marioneta.transform.position.x, marioneta.transform.position.y )).normalized ;

            marioneta.transform.position += new Vector3( direccion.x, direccion.y, 0 ) * velociad * Time.deltaTime;
        }
    }

}
