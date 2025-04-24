using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioSource : MonoBehaviour
{
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start(object Source)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = audioClip;
        Source.play();
        Destroy(Source, audioClip.length);
    }

    private void Destroy(object source, float length)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
