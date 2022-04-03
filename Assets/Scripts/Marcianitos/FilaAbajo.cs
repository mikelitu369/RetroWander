using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaAbajo : MonoBehaviour
{


    [SerializeField] float velocidad;
    [SerializeField] float tiempoHaciaUnlado;

    float timer;
    int direccion = 1;
    [SerializeField] GameObject[] posiciones;

    public List<GameObject> marcianos = new List<GameObject>();
    [SerializeField] FilaAbajo abajo;


    bool colocados = true;


    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > tiempoHaciaUnlado)
        {
            direccion = direccion * -1;
            timer = 0;
        }

        this.transform.position += Vector3.up * velocidad * Time.deltaTime * direccion;

        if (abajo && abajo.marcianos.Count < 7 && marcianos.Count > 0)
        {


            abajo.AnadirMarcianito(marcianos[0]);
            marcianos.RemoveAt(0);
            Recolocar();
            abajo.Recolocar();
        }
    }


    public void HaMuerto(GameObject marciano)
    {
        colocados = false;
        
        marcianos.Remove(marciano);

        Recolocar();
    }

    public void Recolocar()
    {
        for(int i = 0; i < marcianos.Count; ++i)
        {
            marcianos[i].GetComponent<Marciano>().posObjetivo = posiciones[i].transform;
        }
    }

    public void AnadirMarcianito(GameObject marcianito)
    {
        if(marcianos.Count > 6 || marcianos.Contains(marcianito))
        {
            Debug.LogError("SE HA INTENTADO ANADIR UN MARCIANITO DE MALA MANERA");
            return;
        }

       if(!abajo) marcianito.GetComponent<Marciano>().ultimoFilero = true;




        marcianos.Add(marcianito);
    }
}
