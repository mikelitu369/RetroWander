using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHabilidades : MonoBehaviour
{
    [SerializeField] NaveController nave;

    MaterialesHabilidades[] iconos;

    private void Start()
    {
        iconos = transform.GetComponentsInChildren<MaterialesHabilidades>();
    }

    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            iconos[i].GetComponent<Image>().fillAmount = nave.GetCharge(i);
            iconos[i].Set(nave.GetCharge(i) >= 1);
        }
    }
}
