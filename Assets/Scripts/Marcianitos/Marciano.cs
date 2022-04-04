using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marciano : MonoBehaviour
{

    [SerializeField] int vidaMaxima;
    [SerializeField] float atackRate;
    [SerializeField] float velocidad;

    [SerializeField] GameObject posDIsparo;
    float timer;

    public bool ultimoFilero;

    public bool apuntandoIzquierda;
    float random;

    public Transform posObjetivo;

    int vida;
    public FilaAbajo fila;

    private void Start()
    {
        ultimoFilero = false;
        vida = vidaMaxima;
        timer = 0;
        random = Random.Range(0, 3);

    }

    public void Reset()
    {
        transform.rotation = Quaternion.identity;
        ultimoFilero = false;
        vida = vidaMaxima;
        timer = 0;
        random = Random.Range(0, 3);

        this.gameObject.SetActive(true);
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

            if (timer > atackRate + random)
            {
                //DISPARO
                GameObject g = BalasManager.instance.NewBala();

                ShootController sc = g.GetComponent<ShootController>();
                sc.disparaPorMarciano = true;
                g.transform.position = posDIsparo.transform.position ;
                g.transform.rotation = Quaternion.identity;
                sc.SetPlayer(apuntandoIzquierda);

                random = Random.Range(0, 3);
                timer = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            if(collision.GetComponent<ShootController>())
            {
                if (collision.GetComponent<ShootController>().disparaPorMarciano) return;
            }
            --vida;


            if(vida <= 0)
            {
                PoolMarcianos.instanace.anadiarMarciano(this.gameObject);
                this.gameObject.SetActive(false);
                fila.HaMuerto(this.gameObject);
            }
        }
        
    }
}
