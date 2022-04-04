using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodOfGame : MonoBehaviour
{

    public static GodOfGame instance;

    public NaveController nave1, nave2;
    [SerializeField] GameObject TextoPlayer1Win;
    [SerializeField] GameObject TextoPlayer2Win;
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
    public void RecargarPartida(bool player)
    {
        if(player)TextoPlayer1Win.GetComponent<Animator>().SetInteger("Estado", -1);
        else TextoPlayer2Win.GetComponent<Animator>().SetInteger("Estado", -1);
        StartCoroutine(AcabarRonda());
    }


    IEnumerator AcabarRonda()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

public NaveController GetNave(bool player)
    {
        if (nave1.Player2() == player) return nave1;
        else return nave2;
    }

    private void Update()
    {
        if(Input.GetKeyDown(nave1.Accion()) || Input.GetKeyDown(nave2.Accion()))
        {
            SwapPausa();         
        }
    }

    public void SwapPausa()
    {
        if (!menuPausa.activeSelf)
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
            menuPausa.GetComponent<MenuPausa>().Active();
        }
        else
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    public bool InputAccion()
    {
        if (Input.GetKeyDown(nave1.b1)) return true;
        if (Input.GetKeyDown(nave1.b2)) return true;
        if (Input.GetKeyDown(nave1.b3)) return true;
        if (Input.GetKeyDown(nave1.b4)) return true;
        if (Input.GetKeyDown(nave1.b5)) return true;
        if (Input.GetKeyDown(nave1.b6)) return true;

        if (Input.GetKeyDown(nave2.b1)) return true;
        if (Input.GetKeyDown(nave2.b2)) return true;
        if (Input.GetKeyDown(nave2.b3)) return true;
        if (Input.GetKeyDown(nave2.b4)) return true;
        if (Input.GetKeyDown(nave2.b5)) return true;
        if (Input.GetKeyDown(nave2.b6)) return true;

        return false;
    }
}
