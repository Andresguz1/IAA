using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioClip audioExplosion;
    public AudioClip audioDead;
    public AudioClip audioBara;
    public AudioClip audioFlecha;
    public AudioClip ola;
    public AudioClip audioGameOver;
    public AudioClip audiogolpe;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    void Start()
    {
        if (SoundSystem.instance == null)//si no tiene nada asigando se lo asigna 
        {
            SoundSystem.instance = this;

        }
        else if (SoundSystem.instance != this)//si tiene asigando y no es la instancia se destuye
        {
            Destroy(gameObject);
        }
    }
    public void PlayExplosion()
    {
        PlayAudioClip(audioExplosion);
    }
    public void PlayBara()
    {
        PlayAudioClip2(audioBara);
    }
    public void PlayDeath()
    {
        PlayAudioClip3(audioDead);
    }
    public void PlayFlecha()
    {
        PlayAudioClip(audioFlecha);
    }
    public void PlayGameOver()
    {
        PlayAudioClip(audioGameOver);
    }
    public void PlayGolpe()
    {
        PlayAudioClip(audiogolpe);
    }
    public void PlayOla()
    {
        PlayAudioClip3(ola);
    }
    

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void PlayAudioClip2(AudioClip audioClip2)
    {
        audioSource2.clip = audioClip2;
        audioSource2.Play();
    }
    private void PlayAudioClip3(AudioClip audioClip3)
    {
        audioSource3.clip = audioClip3;
        audioSource3.Play();
    }
    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
