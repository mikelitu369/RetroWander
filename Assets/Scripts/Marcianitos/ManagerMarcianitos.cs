using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMarcianitos : MonoBehaviour
{

    [SerializeField] FilaAbajo filaIZquierda;
    [SerializeField] FilaAbajo filaDerecha;


    [SerializeField] float rateSpaw;

    float timer;
    float timerD;

    private void Start()
    {
        timer = 0;
        timerD = 0;
    }

    private void Update()
    {
        if(filaIZquierda.marcianos.Count  == 0)
        {
            timer += Time.deltaTime;

            if(timer > rateSpaw)
            {
                Debug.Log(timer);
                timer = 0;
                StartCoroutine( CrearMarcianosI());
            }
        }
        if (filaDerecha.marcianos.Count == 0)
        {
            timerD += Time.deltaTime;
            if (timerD > rateSpaw)
            {
                Debug.Log(timer);
                timerD = 0;
                StartCoroutine(CrearMarcianosD());
            }
        }
    }

    IEnumerator CrearMarcianosI()
    {
        Debug.Log("hola");
        for (int i = 0; i < 7; ++i)
        {
            GameObject g = PoolMarcianos.instanace.CrearMarciano();
            g.GetComponent<Marciano>().apuntandoIzquierda = true;
            g.transform.Rotate(Vector3.forward, -90);
            filaIZquierda.AnadirMarcianito(g);
            yield return new WaitForSeconds(1f);
            Debug.Log("marciano");
            filaIZquierda.Recolocar();
        }
        
    }
    IEnumerator CrearMarcianosD()
    {
        Debug.Log("hola");
        for (int i = 0; i < 7; ++i)
        {
            GameObject g = PoolMarcianos.instanace.CrearMarciano();
            g.GetComponent<Marciano>().apuntandoIzquierda = false;
            g.transform.Rotate(Vector3.forward, 90);
            filaDerecha.AnadirMarcianito(g);
            yield return new WaitForSeconds(1f);
            Debug.Log("marciano");
            filaDerecha.Recolocar();
        }

    }
}
