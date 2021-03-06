using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidero : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipsAudios;
    public enum audios
    {
        disparo = 0,
        disparoPerf = 1,
        escopeta = 2,
        racimo = 3,
        perderVida = 4,
        escudo = 5,
        redireccion = 6,
        muerte= 7
    }

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

    public void NewSound(audios audio)
    {
        NewSound(Audio(audio));
    }

    public void StopSound(GameObject audio)
    {
        sonidos.Add(audio.GetComponent<AudioSource>());
        audio.SetActive(false);
    }

    public AudioClip Audio(audios id)
    {
        return clipsAudios[(int)id];
    }
}
