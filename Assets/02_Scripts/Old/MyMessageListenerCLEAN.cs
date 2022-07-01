using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;


public class MyMessageListenerCLEAN : MonoBehaviour 
{

    string[] vec1;

    //public GameObject sphereBelly;
    //public GameObject sphereChest;
    //public LuzBelly luz;//de la escenaCAL
    public ShaderSB luzSB;//de la escenaCAL

    public int datoL = 0;
    public int datoL2 = 0;
    public float datoNormCC;
    public float datoNormCB;

    void Update()
    {
        //////////////////////BOTONERA///////////GetKeyDown
        if (Input.GetKey("2"))//CHEST2 INHALA 
        {
            datoL2 = 2;
        }
        if (Input.GetKey("3"))//CHEST1 EXHALA
        {
            datoL2 = 1;
        }

        if (Input.GetKey("4"))//BELLY INHALA
        {
            datoL = 2;
        }
        if (Input.GetKey("5"))//BELLY EXHALA
        {
            datoL = 1;
        }
        /////////////////////////////////
    }

    void OnMessageArrived(string msg) // Invoked when a line of data is received from the serial device.
    {
        //Debug.Log("Arrived: " + msg);
        vec1 = msg.Split(',');
        string c1 = "chest";
        string c2 = (vec1[0]);
        string b1 = "belly";
        string n1 = "CC";
        string n2 = "CB";

        if ((String.Compare(c1, c2)) == 0)
        {
            datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
            //Debug.Log("chest:" + datoL2);
        }
        else if ((String.Compare(b1, c2)) == 0)
        {
            datoL = (Convert.ToInt32(vec1[1]));//belly  
            //Debug.Log("belly:" + datoL);
        }

        else if ((String.Compare(n1, c2)) == 0)//norm to vec
        {
            datoNormCC = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCC);
        }
        else if ((String.Compare(n2, c2)) == 0)//norm to vec
        {
            datoNormCB = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCB);
        }

        //////////////////TXT------GUI LABEL/////////////////

        ////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
        //if (datoL2 == CHEST_INHALE)
        //{
        //    stepsChestError++;//MARGEN DE ERROR NO FUNCIONA!
        //    Debug.Log("STEPS : " + stepsChestError);

        //if (stepsL > 3)//margen error
        //{

        ///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
        if (datoL2 == 2) //(flowManager.CurrentState == GameState.Chest && datoL2 != datoL2ant)
        {
            //pdScript.SoundUp();
            //sphereChest.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);
            luzSB.LuzUp();

            //if (luzSB != null)
            //{
            //    luzSB.LuzUp();
            //}
        }
        else
        {
            //pdScript.SoundDown();
            //sphereChest.transform.localScale = new Vector3(3, 3, 3);
            luzSB.LuzDown();

            //if (luzSB != null)
            //{
            //    luzSB.LuzDown();
            //}
        }

        ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
        if (datoL == 2)//(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE)
        {
            //sphereBelly.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);

            //if (luz != null)
            //{
            //    luz.luzUp();
            //}
        }
        else
        {
            //sphereBelly.transform.localScale = new Vector3(3, 3, 3);

            //if (luz != null)
            //{
            //    luz.luzDown();
            //}
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
