using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsoOK : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip clip;
    public float volume;
    public GameObject sphere;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void lateOn()
    {
        //audioSource.Play();
        audioSource.PlayOneShot(audioSource.clip, volume);
        sphere.transform.localScale = new Vector3(3, 3, 3);
        //Debug.Log("pulso on");

    }

    public void lateOff()
    {
        audioSource.Stop();
        sphere.transform.localScale = new Vector3(1, 1, 1);
        //Debug.Log("pulso off");
    }
}
