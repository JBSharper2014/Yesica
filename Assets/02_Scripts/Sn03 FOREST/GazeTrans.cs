using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrans : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle;
    private bool estaAndando = false;
    private float TransparencyLevel;
    public float speed;
    Renderer rend;
    public float currentValue;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        TransparencyLevel = 0;
        currentValue = 0;
    }

    void Update()
    {
        if (Input.GetKey("5"))
        {
            rend.enabled = true;
            float currentValue = rend.material.GetFloat("_BumpAmt1");
            TransparencyLevel += Time.deltaTime * speed;           
            rend.material.SetFloat("_BumpAmt1", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
            Debug.Log("ActivaBody");
        }

        //if (FlowManager.instance.CurrentState == GameState.Belly)
        //{
        //    //rend.enabled = true;
        //    float currentValue = rend.material.GetFloat("_BumpAmt1");

        if (FlowManager.instance.CurrentState == GameState.Belly &&!estaAndando && MiraAbajo)
        {
            rend.enabled = true;
            float currentValue = rend.material.GetFloat("_BumpAmt1");
            TransparencyLevel += Time.deltaTime * speed;
            rend.material.SetFloat("_BumpAmt1", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
            Debug.Log("mira");

        }
        else if (!MiraAbajo)
        {
            currentValue = 0;
        }

        

    }   

    public bool MiraAbajo
    {
        get
        {
            return vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f; //la cam X esta entre 30 y 90 
            //return vrCamera.eulerAngles.x <= 40 && vrCamera.eulerAngles.x < 90.0f; //la cam X esta entre 30 y 90           
        }


    }



}
 
