using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreTetris : MonoBehaviour
{

    public EscenarioTetris escenario;

    public List<int> canales;

    public float velocidad;
    [SerializeField] List<GameObject> piezasHijas;


    List<Vector3> posiciones;
    public int jugador;
    public bool active;


    private void Start()
    {
        active = true;
        jugador = 2;
        posiciones = new List<Vector3>();


        for(int i = 0; i < piezasHijas.Count; ++i)
        {
            piezasHijas[i].GetComponent<PiezaIndividualTetris>().padre = this;
            posiciones.Add(piezasHijas[i].transform.localPosition);
        }
    }

    private void Update()
    {
        //if(active)this.transform.position += new Vector3(0, -1, 0) * velocidad * Time.deltaTime;
    }

    public void ComprobarActividad()
    {

        bool activo = false;

        for(int i = 0; i  < piezasHijas.Count; ++i)
        {
            if (piezasHijas[i].activeSelf) activo = true;
        }


        if (!activo) escenario.poolPiezas.Add(this.gameObject);
    }

    public void Parar()
    {
        active = false;

        for (int i = 0; i < piezasHijas.Count; ++i)
        {
            if (piezasHijas[i].activeSelf)
            {


                piezasHijas[i].GetComponent<PiezaIndividualTetris>().active = active;
                escenario.piezasIndividuales.Add(piezasHijas[i]);
            }
        }

        
    }
    public void AsignarJugador(int zjugador_)
    {
        jugador = zjugador_;
        for (int i = 0; i < piezasHijas.Count; ++i)
        {
            if (piezasHijas[i].activeSelf) piezasHijas[i].GetComponent<PiezaIndividualTetris>().CambiarColor( jugador);

        }
    }
    public void ResetPieza()
    {
        active = true;
        jugador = 2;

        //reset de las piezas hijas
        for (int i = 0; i < piezasHijas.Count; ++i)
        {

            piezasHijas[i].SetActive(true);
            piezasHijas[i].transform.localPosition  = posiciones[i];
            piezasHijas[i].GetComponent<PiezaIndividualTetris>().active = true;
            piezasHijas[i].GetComponent<PiezaIndividualTetris>().vida = piezasHijas[i].GetComponent<PiezaIndividualTetris>().vidaMax;
        }
    }
}
