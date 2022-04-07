using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodOfGame : MonoBehaviour
{

    public static GodOfGame instance;
    public static int lastStage = 3;

    public bool fin;

    bool finalPartida = false;

    public NaveController nave1, nave2;
    [SerializeField] GameObject TextoPlayer1Win;
    [SerializeField] GameObject TextoPlayer2Win;
    [SerializeField] GameObject TextoPlayer1WinScore;
    [SerializeField] GameObject TextoPlayer2Score;
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject[] juegos;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start()
    {
        fin = false;
        int random;
        do
        {
            random = Random.Range(0, juegos.Length);
        } while (random == lastStage);
        
        Instantiate(juegos[random], this.transform);
        lastStage = random;
    }
    public void RecargarPartida(bool player)
    {

        Time.timeScale = 0.5f;
        if (!Score.Fin())
        {
            if (player) TextoPlayer1WinScore.GetComponent<Animator>().SetInteger("Estado", -1);
            else TextoPlayer2Score.GetComponent<Animator>().SetInteger("Estado", -1);
            StartCoroutine(AcabarRonda(SceneManager.GetActiveScene().name));
        }
        else
        {
            if(player)TextoPlayer1Win.GetComponent<Animator>().SetInteger("Estado", -1);
            else TextoPlayer2Win.GetComponent<Animator>().SetInteger("Estado", -1);
            StartCoroutine(AcabarPartida());
        }
    }


    IEnumerator AcabarRonda(string s)
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(s);
    }

    IEnumerator AcabarPartida()
    {
        yield return new WaitForSeconds(5);
        finalPartida = true;
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

        if(finalPartida && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
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
