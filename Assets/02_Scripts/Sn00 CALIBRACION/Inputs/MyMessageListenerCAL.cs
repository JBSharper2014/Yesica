using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;


public class MyMessageListenerCAL : MonoBehaviour {

    //public GameObject sphereBelly;
    //public GameObject sphereChest;
    //public PDSensorSHARED pdScript;//chest de la escenaCITY

    //public LuzBelly luz;//de la escenaCAL
    //public ShaderSB luzSB;//de la escenaCAL


    public Text belly;
    public Text chest;

    public float datoNormCC;
    public float datoNormCB;
    //public int datoP = 0;
    public int datoL = 0;
    public int datoL2 = 0;
    //private int datoPant = 0;
    //private int stepsL = 0;
    //private int stepsLAnt = 0;

    //public int speed;
    //public int max;

    string[] vec1;
	
    void Update ()        //////////////////////BOTONERA///////////GetKeyDown
    {
 
        if (Input.GetKey(KeyCode.UpArrow))//CHEST2 INHALA 
        {
            datoL2 = 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))//CHEST1 EXHALA
        {
            datoL2 = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))//BELLY INHALA
        {
            datoL = 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//BELLY EXHALA
        {
            datoL = 1;
        }
        /////////////////////////////////
        /////////////////////////////////
    }

    public void OnMessageArrived(string msg)
    {
        //Debug.Log("Arrived: " + msg);
        vec1 = msg.Split(',');
        string c1 = "chest";
        string c2 = (vec1[0]);
        string b1 = "belly";
        string n1 = "CC";
        string n2 = "CB";

        if ((String.Compare(c1, c2)) == 0)//chest to vec
        {
            datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
            //Debug.Log("chest:" + datoL2);
        }
        else if ((String.Compare(b1, c2)) == 0)//belly to vec
        {
            datoL = (Convert.ToInt32(vec1[1]));//belly  
            //Debug.Log("belly:" + datoL);
        }
        else if ((String.Compare(n1, c2)) == 0)//norm to vec
        {
            datoNormCC = float.Parse(vec1 [1]);          
            //Debug.Log("calibracion:" + datoNormCC);
        }
        else if ((String.Compare(n2, c2)) == 0)//norm to vec
        {
            datoNormCB = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCB);
        }
        ///////////////////////////////////////////////txt 
        belly.text = "belly: " + datoL;
        chest.text = "chest: " + datoL2;
        //calibracion.text = "calibracion" + datoNorm;

        ///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
        if (datoL2 == 2) //(flowManager.CurrentState == GameState.Chest && datoL2 != datoL2ant)
        {           
            //luzSB.LuzUp();
            //sphereChest.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);
        }
        else
        {           
            //luzSB.LuzDown();
            //sphereChest.transform.localScale = new Vector3(3, 3, 3);
        }

        ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
        if (datoL == 2)//(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE)
        {
            //luz.luzUp();      
            //sphereBelly.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);
        }
        else
        {
           //luz.luzDown();
           //sphereBelly.transform.localScale = new Vector3(3, 3, 3);
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
