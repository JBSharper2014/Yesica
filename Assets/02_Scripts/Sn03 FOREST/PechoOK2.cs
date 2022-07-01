using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PechoOK2 : MonoBehaviour
{
    public static PechoOK2 instance;

    Renderer rend;
    public Light luz;

    public float lerpedValue;
    public float targetValue;
    public int steps;
    public float stepAmount;
    public float MinDistortion;
    public float MaxDistortion;
    [Range(0, 5)] public float lerpSpeed = 1;

    public AudioSource audioSource;
    public float maxVolume;
    public float musicFadeSpeed;
    public float maxLightIntensity;//para luz y volumen
    
    public GameObject iluminacion;
    public float intensity;

    public bool IsAnimating;
    private float currentValue;
    private Coroutine distortionCoroutine;
    //float currentValue = rend.material.GetFloat("_BumpAmt");

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_BumpAmt");//SE REPITE EN EL VOID...
        stepAmount = (currentValue - MinDistortion) / steps;
        MaxDistortion = currentValue;

        audioSource.Play();
        audioSource.volume = 0;     
    }

    public void AnimateToNextState()
    {
        if (IsAnimating) return;       

        if (distortionCoroutine != null)
        {
            StopCoroutine(distortionCoroutine);
        }

        distortionCoroutine = StartCoroutine(LerpDistortionShader());
    }

    private IEnumerator LerpDistortionShader()
    {
        IsAnimating = true;

        currentValue = rend.material.GetFloat("_BumpAmt");
        targetValue = currentValue - stepAmount;
        
        while (Mathf.Abs(currentValue - targetValue) > 0.001f)
        {
            lerpedValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * lerpSpeed);
                
            rend.material.SetFloat("_BumpAmt", Mathf.Clamp(lerpedValue, MinDistortion, MaxDistortion));

            currentValue = rend.material.GetFloat("_BumpAmt");

            yield return new WaitForEndOfFrame();
        }

        IsAnimating = false;
    }

    public void PlayFirstBreathAnimation()
    {
        StartCoroutine(AnimateLight());
        StartCoroutine(AnimateVolume());
    }

    private IEnumerator AnimateLight()
    {
        while (luz.intensity < maxLightIntensity)
        {
            luz.intensity = Mathf.Lerp(luz.intensity, maxLightIntensity, musicFadeSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator AnimateVolume()
    {
        while (audioSource.volume < maxVolume)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, maxVolume, musicFadeSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }



}
