using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play06 : MonoBehaviour
{
    public AudioSource audioextra;

    void Start()
    {
        audioextra  = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        if (Input.GetKey("6")) playaudioextra();
    }

    public void playaudioextra ()
    {
        audioextra.Play();
    }

}
