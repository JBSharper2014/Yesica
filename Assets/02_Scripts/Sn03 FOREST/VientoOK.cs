using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VientoOK : MonoBehaviour
{
    public static VientoOK instance;

    public WindZone wind;

    public float Maxturbulence;
    public float Minturbulence;

    [Range(0, 5)] public float lerpSpeed = 1;

    public AudioSource winds;////////winds
    public AudioClip windsclip;
    public float musicFadeSpeed;
    public float maxVolume;
    public float volume = 1;

    public bool IsAnimating;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start()
    {
        wind.windTurbulence = 0;
    }

    public void TurbulenceUp()
    {
        wind.windTurbulence = Mathf.Lerp(wind.windTurbulence, Maxturbulence, Time.deltaTime * lerpSpeed);
    }

    public void TurbulenceDown()
    {
        wind.windTurbulence = Mathf.Lerp(wind.windTurbulence, Minturbulence, Time.deltaTime * lerpSpeed);
    }

    public void soundWind()
    {
        winds.PlayOneShot(windsclip,volume);
        //winds.volume = Mathf.Lerp(winds.volume, maxVolume, musicFadeSpeed * Time.deltaTime);
        //winds.Play();
        


    }

}
