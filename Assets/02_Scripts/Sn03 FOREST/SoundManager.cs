using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip audioClipInstruccion00;
    public AudioClip audioClipInstruccion01;//01 again
    //public AudioClip audioClipInstruccion01B;//01 again B
    public AudioClip audioClipInstruccion02;//02 chest
    public AudioClip audioClipInstruccion033;// poesia
    public AudioClip audioClipInstruccion03;// 04 belly1

    public AudioSource audioSource; //no uso get component xq tengo + de 1 audioSource
    public float delay = 4;
    public float volume = 0.5f;
    public bool IsPlaying = false;

    private void Awake()//singleton
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
        else if (SoundManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        PlayAudioClip(audioClipInstruccion00);
    }

    public void PlayInstruccion01()
    {
        //audio01.PlayOneShot(audioClipInstruccion01);
        PlayAudioClip(audioClipInstruccion01);
    }

    public void PlayInstruccion02()
    {
        //audio01.PlayOneShot(audioClipInstruccion02);
        PlayAudioClip(audioClipInstruccion02);
    }

    public void PlayInstruccion03()
    {
        PlayAudioClip(audioClipInstruccion03);
    }

    public void PlayInstruccion033()
    {
        PlayAudioClip(audioClipInstruccion033);
    }


    private void PlayAudioClip(AudioClip audioclip)
    {
        //Instruccion00.clip = audioclip;//?
        StartCoroutine(CoPlayDelayedClip(audioclip, delay));
    }

    IEnumerator CoPlayDelayedClip(AudioClip _clip, float _delay)//TODOS CON DELAY X CORRUTINA
    {
        IsPlaying = true;

        yield return new WaitForSeconds(_delay);//delay audioclips

        audioSource.clip = _clip;
        audioSource.Play();
        yield return new WaitForSeconds(_clip.length);

        IsPlaying = false;
    }

    private void OnDestroy()//singleton
    {
        if (SoundManager.instance == this)
        {
            SoundManager.instance = null;
        }
    }
}

