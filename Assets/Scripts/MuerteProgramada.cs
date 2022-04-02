using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteProgramada : MonoBehaviour
{
    [SerializeField] float tiempoDestruccion;
    [SerializeField] PullFX.FXs tipoFX;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MuerteProgramada", tiempoDestruccion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Muerte()
    {
        PullFX.instance.DestroyObject(this.gameObject,tipoFX);
    }
}
