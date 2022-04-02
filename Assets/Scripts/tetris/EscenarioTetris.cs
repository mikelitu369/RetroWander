using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenarioTetris : MonoBehaviour
{

    [SerializeField] float rateSpawn;

    [SerializeField] Transform[] posSpwan;


    [SerializeField] List<GameObject> piezasASpawnear1, piezasASpawnear2, piezasASpawnear3, piezasASpawnear4;

    [SerializeField] Transform[] posRaycast;


    int huecoRestante;
    float timer;



   public  List<GameObject> poolPiezas;

    public List<GameObject> piezasIndividuales;

    private void Start()
    {
        piezasIndividuales = new List<GameObject>();
        poolPiezas = new List<GameObject>();
        timer = 0;
        huecoRestante = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;


        if(timer > rateSpawn)
        {
            timer = 0;
            SpawnPieza();
        }
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
                        poolPiezas[0].transform.position = posSpwan[Random.Range(0, posSpwan.Length)].position;
                        //reseteo de la pieza aqui
                        encontrada = true;
                    }
                }
            }
        }
        if(!encontrada)
        {

            switch (randomizador)
            {
                case 0:
                    p = Instantiate(piezasASpawnear1[Random.Range(0, piezasASpawnear1.Count)], posSpwan[Random.Range(0, posSpwan.Length)].position, Quaternion.identity);
                    p.GetComponent<PadreTetris>().escenario = this;
                    break;
                case 1:
                    p = Instantiate(piezasASpawnear2[Random.Range(0, piezasASpawnear2.Count)], posSpwan[Random.Range(0, posSpwan.Length)].position, Quaternion.identity);
                    p.GetComponent<PadreTetris>().escenario = this;
                    break;
                case 2:
                    p = Instantiate(piezasASpawnear3[Random.Range(0, piezasASpawnear3.Count)], posSpwan[Random.Range(0, posSpwan.Length)].position, Quaternion.identity);
                    p.GetComponent<PadreTetris>().escenario = this;
                    break;
                case 3:
                    p = Instantiate(piezasASpawnear4[Random.Range(0, piezasASpawnear4.Count)], posSpwan[Random.Range(0, posSpwan.Length)].position, Quaternion.identity);
                    p.GetComponent<PadreTetris>().escenario = this;
                    break;
            }



        }
    }
}
