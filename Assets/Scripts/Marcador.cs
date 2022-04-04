using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Marcador : MonoBehaviour
{
    [SerializeField] TextMeshPro puntos;
    [SerializeField] GameObject[] vidas;

    
    public void Set(int puntos)
    {
        this.puntos.text = puntos.ToString();
    }

    public void PerderVida(bool player)
    {
        foreach(GameObject g in vidas)
        {
            if (g.activeSelf)
            {
                Sonidero.instance.NewSound(Sonidero.audios.perderVida);
                g.SetActive(false);
                break;
            }
        }

        if (!vidas[vidas.Length - 1].activeSelf) End(player);
    }    

    void End(bool player)
    {
        if (player) Score.player2++;
        else Score.player1++;
        GodOfGame.instance.RecargarPartida(player);
    }
    public float ReturnVidas()
    {
        print(vidas);
        return vidas.Length;
    }
}
