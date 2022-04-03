using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMarcianitos : MonoBehaviour
{

    [SerializeField] GameObject marciano;

    [SerializeField] FilaAbajo filaIZquierda;


    [SerializeField] float rateSpaw;

    float timer;

    private void Start()
    {
        timer = 0;
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
                StartCoroutine( CrearMarcianos());
            }
        }
    }

    IEnumerator CrearMarcianos()
    {
        Debug.Log("hola");
        for (int i = 0; i < 7; ++i)
        {
            GameObject g = Instantiate(marciano, new Vector3(0, 12, 0), Quaternion.identity);
            filaIZquierda.AnadirMarcianito(g);
            yield return new WaitForSeconds(1f);
            Debug.Log("marciano");
            filaIZquierda.Recolocar();
        }
        
    }
}
