using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play07 : MonoBehaviour
{
    public AudioSource audioextra;

    void Start()
    {
        audioextra  = GetComponent<AudioSource>();
    }
  
    void Update()
    {
        if (Input.GetKey("7")) playaudioextra();
    }

    public void playaudioextra ()
    {
        audioextra.Play();
    }

}
