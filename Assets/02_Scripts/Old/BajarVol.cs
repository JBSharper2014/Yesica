using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BajarVol : MonoBehaviour
{
    public AudioSource amb;
    public float maxVol;
    public float value;

    void Start()
    {
        amb = GetComponent<AudioSource>();
    }


    public void BajarAmb(float newVol)
    {
        //amb.volume = Mathf.Lerp(amb.volume, maxVol, value * Time.deltaTime);

        maxVol = newVol;
    }

    private void Update()
    {
        amb.volume = Mathf.Lerp(amb.volume, maxVol, value * Time.deltaTime);
    }

}
