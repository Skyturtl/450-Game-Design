using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    //Outlets
    AudioSource audioSource;
    public AudioClip bite;
    public AudioClip skinPeel;
    public AudioClip beheading;
    public AudioClip bodyCrunch;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBite()
    {
        audioSource.PlayOneShot(bite);
    }
}
