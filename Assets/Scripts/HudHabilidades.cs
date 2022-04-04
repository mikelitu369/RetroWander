using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHabilidades : MonoBehaviour
{
    [SerializeField] NaveController nave;

    Image[] iconos;

    private void Start()
    {
        iconos = transform.GetComponentsInChildren<Image>();
    }

    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            iconos[i].fillAmount = nave.GetCharge(i);
            iconos[i].GetComponent<MaterialesHabilidades>().Set(nave.GetCharge(i) >= 1);
        }
    }
}
