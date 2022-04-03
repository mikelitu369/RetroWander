using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject primerBoton, explicacionSkills;


    public void Active()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(primerBoton);
    }

    private void Update()
    {
        if (GodOfGame.instance.InputAccion())
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>())
            {
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }

    public void Continue()
    {
        GodOfGame.instance.SwapPausa();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Skills()
    {
        explicacionSkills.SetActive(true);
        gameObject.SetActive(false);
    }
}
