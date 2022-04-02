using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodOfGame : MonoBehaviour
{

    public static GodOfGame instance;

    public NaveController nave1, nave2;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }
    public void RecargarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
