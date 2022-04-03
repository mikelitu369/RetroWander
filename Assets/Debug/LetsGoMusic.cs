using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsGoMusic : MonoBehaviour
{
    [SerializeField] GameObject music;
    void Start()
    {
        if (!MusicPersist.instance) Instantiate(music);
    }
}
    
