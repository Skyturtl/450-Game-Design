using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    // Outlets
    AudioSource audioSource;
    public AudioClip bite;
    public AudioClip skinPeel;
    public AudioClip beheading;
    public AudioClip bodyCrunch;
    public AudioClip swordSwing;
    public AudioClip swordKill;
    public AudioClip monsterKillMagic;
    public AudioClip chestOpen;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBite1()
    {
        PlayAudioClip(bite, 0.97f, 1.03f);
    }

    public void PlayBite2()
    {
        PlayAudioClip(skinPeel, 0.95f, 1.05f);
    }

    public void PlayBite3()
    {
        PlayAudioClip(beheading, 0.98f, 1.02f);
    }

    public void PlayBite4()
    {
        PlayAudioClip(bodyCrunch, 0.96f, 1.04f);
    }

    public void PlaySwordSwing()
    {
        PlayAudioClip(swordSwing, 0.99f, 1.01f);
    }

    public void PlaySwordKill()
    {
        PlayAudioClip(swordKill, 0.94f, 1.06f);
    }

    public void PlayChestOpen()
    {
        PlayAudioClip(chestOpen, 0.99f, 1.01f);
    }

    public void PlayMagicKill()
    {
        PlayAudioClip(monsterKillMagic, 0.95f, 1.05f);
    }

    private void PlayAudioClip(AudioClip clip, float minPitch, float maxPitch)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.clip = clip;
        audioSource.Play();
    }
}

