using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marciano : MonoBehaviour
{

    [SerializeField] int vidaMaxima;
    [SerializeField] float atackRate;
    [SerializeField] float velocidad;


    float timer;

    public bool ultimoFilero;

    public Transform posObjetivo;

    int vida;

    private void Start()
    {
        ultimoFilero = false;
        vida = vidaMaxima;
        timer = 0;
    }

    private void Update()
    {
        if (!posObjetivo) return;
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), (Vector2)posObjetivo.position) > 0.01f)
        {
            Vector2 direccion = ((Vector2)posObjetivo.position - new Vector2(transform.position.x, transform.position.y)).normalized;

            transform.position += new Vector3(direccion.x, direccion.y, 0) * velocidad * Time.deltaTime;
        }
        if (ultimoFilero)
        {
            timer += Time.deltaTime;

            if(timer > atackRate)
            {
                //DISPARO
                timer = 0;
            }
        }
    }
}
