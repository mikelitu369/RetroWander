using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialesHabilidades : MonoBehaviour
{
    [SerializeField] Material cargando, listo;

    public void Set(bool lista)
    {
        if (lista) GetComponent<Image>().material = listo;
        else GetComponent<Image>().material = cargando;
    }
}
