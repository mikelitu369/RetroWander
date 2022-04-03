using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodOfGame : MonoBehaviour
{

    public static GodOfGame instance;

    public NaveController nave1, nave2;

    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject[] juegos;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start()
    {
        Instantiate(juegos[Random.Range(0, juegos.Length)], this.transform);
    }
    public void RecargarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public NaveController GetNave(bool player)
    {
        if (nave1.Player2() == player) return nave1;
        else return nave2;
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(nave1.Accion()) || Input.GetKeyDown(nave2.Accion()))
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }
        */
    }

    
}
