﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenarioTetris : MonoBehaviour
{

    [SerializeField] float rateSpawn;

    [SerializeField] Transform[] posSpwan;

    [SerializeField] GameObject limite;

    [SerializeField] List<GameObject> piezasASpawnear;

    [SerializeField] Transform[] posRaycast;


    int huecoRestantes = 4;

    GameObject[] lleno = new GameObject[4];


    float timer;

    int lineasJugador1 = 0, lineasJugador2 = 0;

   public  List<GameObject> poolPiezas;

    public List<GameObject> piezasIndividuales;
    NaveController nave1, nave2;

    private void Start()
    {
        nave1 = GodOfGame.instance.nave1;
        nave2 = GodOfGame.instance.nave2;

        piezasIndividuales = new List<GameObject>();
        poolPiezas = new List<GameObject>();
        timer = 0;
        huecoRestantes = 4;
        //InvokeRepeating("LanzarRaycast", 0,1f);
    }
    private void Update()
    {
        timer += Time.deltaTime;


        if(timer > rateSpawn)
        {
            timer = 0;
            SpawnPieza();
        }
        LanzarRaycast();
    }


    public void SpawnPieza()
    {
        GameObject p;
        int randomizador = Random.Range(0, 4);
        bool encontrada = false;
        if (poolPiezas.Count > 0)
        {

            for(int i = 0; i < poolPiezas.Count && !encontrada; ++i)
            {
                PadreTetris tP = poolPiezas[i].GetComponent<PadreTetris>();
                for(int j = 0; j < tP.canales.Count && !encontrada; ++j)
                {
                    if(randomizador == tP.canales[j])
                    {
                        poolPiezas[i].transform.position = posSpwan[randomizador].position;
                        poolPiezas[i].GetComponent<PadreTetris>().ResetPieza();
                        poolPiezas.RemoveAt(i);
                        encontrada = true;
                    }
                }
            }
        }
        if(!encontrada)
        {


            bool noEntra = false;
            int numero;
            do
            {
                 numero = Random.Range(0, piezasASpawnear.Count);
                for (int i = 0; i < piezasASpawnear[numero].GetComponent<PadreTetris>().canales.Count; ++i)
                {
                    if (randomizador == piezasASpawnear[numero].GetComponent<PadreTetris>().canales[i]) noEntra = true;
                }
            } while (!noEntra);

            GameObject padre =  Instantiate(piezasASpawnear[numero], posSpwan[randomizador].position, Quaternion.identity);
            padre.GetComponent<PadreTetris>().escenario = this;

        }
    }
    public void AnadirLinea(int i)
    {
        if (i == 0)
        {
            GameObject g = Instantiate(limite, new Vector3(7.99f, 8 - (0.66f +lineasJugador1 * 1.33f), 0), Quaternion.identity);
            ++lineasJugador1;
            if(lineasJugador1 > 11)
            {
                Debug.Log("GANA EL JUGADOR 1");
                return;
            }
            nave2.LimitarTop(lineasJugador1);
        }
        else
        {
            GameObject g = Instantiate(limite, new Vector3(-7.99f, 8 - (0.66f + lineasJugador2 * 1.33f), 0), Quaternion.identity);
            ++lineasJugador2;
            if (lineasJugador2 > 11)
            {
                Debug.Log("GANA EL JUGADOR 2");
                return;
            }
            nave1.LimitarTop(lineasJugador2);
        }
    }
    public void LanzarRaycast()
    {
        if (huecoRestantes <= 0) return;
        for(int i = 0; i < posRaycast.Length; ++i)
        {

            if(!lleno[i])
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(posRaycast[i].position.x, posRaycast[i].position.y), new Vector3(0, 1, 0), 1.10f);
                Debug.DrawRay(posRaycast[i].position, new Vector3(0, 1.10f, 0));

                if(hit.collider && hit.collider.GetComponent<PiezaIndividualTetris>() && !hit.collider.GetComponent<PiezaIndividualTetris>().active)
                {
                    
                    lleno[i] = hit.collider.gameObject;
                    --huecoRestantes;
                    if(huecoRestantes == 0)
                    {
                        int jugador1points = 0;
                        int jugador2points = 0;
                        Debug.Log("proceso normal");
                        for(int j = 0; j < lleno.Length; ++j)
                        {
                            piezasIndividuales.Remove(lleno[j]);

                            lleno[j].SetActive(false);
                            lleno[j].GetComponent<PiezaIndividualTetris>().ComprobarActividadPadre();
                            if(lleno[j].GetComponent<PiezaIndividualTetris>().jugador == 1)
                            {
                                ++jugador1points;
                            }
                            else if(lleno[j].GetComponent<PiezaIndividualTetris>().jugador == 0)
                            {
                                ++jugador2points;
                            }
                            lleno[j] = null;

                        }
                        if(jugador2points > jugador1points)
                        {
                            Debug.Log("ha ganado el jugador dos una linea");
                            AnadirLinea(0);
                        }
                        else if(jugador2points < jugador1points)
                        {
                            Debug.Log("Ha ganado el jugador uno una linea");
                            AnadirLinea(1);
                        }
                        for(int j = 0; j < piezasIndividuales.Count; ++j)
                        {
                            piezasIndividuales[j].GetComponent<PiezaIndividualTetris>().active = true;
                        }
                        piezasIndividuales.Clear();
                        huecoRestantes = 4;
                        
                    }
                }
                
                /*else
                {
                    hit = Physics2D.Raycast(new Vector2(posRaycast[i].position.x, posRaycast[i].position.y), new Vector3(0, 1, 0));
                    Debug.DrawRay(posRaycast[i].position + new Vector3(0.1f,0,0), new Vector3(0, 20, 0), Color.blue);

                    if (hit.collider && hit.collider.GetComponent<PiezaIndividualTetris>() && !hit.collider.GetComponent<PiezaIndividualTetris>().active)
                    {
                        huecoRestantes = 0;
                        //proceso de emergencia
                        Debug.Log("pocho proceso");
                        for (int j = 0; j < lleno.Length; ++j)
                        {
                            if (lleno[j])
                            {
                                Debug.Log(j);
                                piezasIndividuales.Remove(lleno[j]);
                                lleno[j].SetActive(false);
                                lleno[j].GetComponent<PiezaIndividualTetris>().ComprobarActividadPadre();
                                lleno[j] = null;
                            }

                        }

                        for (int j = 0; j < piezasIndividuales.Count; ++j)
                        {
                            piezasIndividuales[j].GetComponent<PiezaIndividualTetris>().active = true;
                        }
                        piezasIndividuales.Clear();
                        huecoRestantes = 4;
                       
                    }
                }*/
            }



            /*Physics.Raycast(posRaycast[i].position, new Vector3(0, 4, 0), out hitInfo);
            Debug.DrawRay(posRaycast[i].position, new Vector3(0, 4, 0));
           if(hitInfo.collider) Debug.Log(hitInfo.collider.gameObject);*/
        }
    }
}
