using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying) Sonidero.instance.StopSound(this.gameObject);
    }
}
