using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject firstButton;

    private void Start()
    {
        Time.timeScale = 1f;
        Score.Reset();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }

        if( Input.GetKeyDown(KeyCode.U) ||
            Input.GetKeyDown(KeyCode.I) ||
            Input.GetKeyDown(KeyCode.O) ||
            Input.GetKeyDown(KeyCode.J) ||
            Input.GetKeyDown(KeyCode.K) ||
            Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.Keypad1) ||
            Input.GetKeyDown(KeyCode.Keypad2) ||
            Input.GetKeyDown(KeyCode.Keypad3) ||
            Input.GetKeyDown(KeyCode.Keypad4) ||
            Input.GetKeyDown(KeyCode.Keypad5) ||
            Input.GetKeyDown(KeyCode.Keypad6) ||
            Input.GetKeyDown(KeyCode.Insert) ||
            Input.GetKeyDown(KeyCode.Home) ||
            Input.GetKeyDown(KeyCode.PageUp) ||
            Input.GetKeyDown(KeyCode.Delete) ||
            Input.GetKeyDown(KeyCode.End) ||
            Input.GetKeyDown(KeyCode.PageDown))
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>())
            {
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
