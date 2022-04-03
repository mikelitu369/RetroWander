using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] string escena;
    private void Start()
    {
        SceneManager.LoadScene(escena);
    }
}
