using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject primerBoton, explicacionSkills;
    [SerializeField] AudioMixer mixer;


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

    public void SetLevelMusic(float sliderValue)
    {
        if(sliderValue == 0) mixer.SetFloat("musicvol", -80);
        else mixer.SetFloat("musicvol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelSFX(float sliderValue)
    {
        if (sliderValue == 0) mixer.SetFloat("sfxvol", -80);
        else mixer.SetFloat("sfxvol", Mathf.Log10(sliderValue) * 20);
        GetComponentInChildren<AudioSource>().Play();
    }
}
