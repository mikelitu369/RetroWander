using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Marcador : MonoBehaviour
{
    [SerializeField] TextMeshPro puntos;
    [SerializeField] GameObject[] vidas;
    [SerializeField] GameObject stages;
    Image[] marcas;
    int puntos2;
    bool ended;
    
    public void Set(int puntos)
    {
        this.puntos.text = puntos.ToString();
        if (marcas == null) marcas = stages.transform.GetComponentsInChildren<Image>();
        foreach (Image t in marcas) t.gameObject.SetActive(false);
        for (int i = 0; i < puntos; i++) marcas[i].gameObject.SetActive(true);
        print(marcas.Length);
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
        if (ended) return;
        ended = true;
        Set(puntos2 + 1);
        GodOfGame.instance.fin = true;
        if (player) Score.player1++;
        else Score.player2++;
        GodOfGame.instance.RecargarPartida(player);
    }
    public float ReturnVidas()
    {
        print(vidas);
        return vidas.Length;
    }
}
