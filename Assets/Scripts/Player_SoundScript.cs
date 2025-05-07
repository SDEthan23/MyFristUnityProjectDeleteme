using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_SoundScript : MonoBehaviour
{
    [Header("Sound Sources")]
    public AudioClip jumpClip;
    public List<AudioClip> randomContainerLand;

    [Header("Sound Settings")]
    public float jumpVolume = 0.5f;
    public float landVolume = 0.5f;

    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = jumpClip;
        _source.loop = false;
        _source.playOnAwake = false;
        

    }



    public void PlayerJumpSound()
    {
        _source.clip = jumpClip;
        _source.volume = jumpVolume;
        _source.Play();
    }
    public void PlayerRandomLandSound()
    {
        int index = Random.Range(0,randomContainerLand.Count );
        _source.clip = randomContainerLand[index];
        _source.volume = landVolume;
        _source.Play();
    }
}


