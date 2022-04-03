using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidero : MonoBehaviour
{
    public static Sonidero instance;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this.gameObject);
    }

    [SerializeField] GameObject sonido;
    List<AudioSource> sonidos = new List<AudioSource>();

    public void NewSound(AudioClip audio)
    {
        if(sonidos.Count != 0)
        {
            sonidos[0].gameObject.SetActive(true);
            sonidos[0].clip = audio;
            sonidos[0].Play();
            sonidos.Remove(sonidos[0]);
        }
        else
        {
            GameObject g = Instantiate(sonido, transform);
            AudioSource audSou = g.GetComponent<AudioSource>();
            audSou.clip = audio;
            audSou.Play();
        }
    }

    public void StopSound(GameObject audio)
    {
        sonidos.Add(audio.GetComponent<AudioSource>());
        audio.SetActive(false);
    }
}
