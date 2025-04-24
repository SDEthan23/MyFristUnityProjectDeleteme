using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip deathclip;


    [Header("Sound Sources")]
    public AudioClip jumpClip;
    public List<AudioClip> randomContainerLand;

    [Header("Sound Setting")]
    public float jumpvolume = 0.5;
    public float Landvolum = 0.5;

    private AudioSource _source;
    private float landVolume;
    private float jumpVolume;

    void Start()
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

    public void PlayerRandomLandSource()
    {
       int index = Random.Range(0, randomContainerLand.Count);
        _source.clip = randomContainerLand[index];
        _source.volume = landVolume;
        _source.Play();
    }
}
