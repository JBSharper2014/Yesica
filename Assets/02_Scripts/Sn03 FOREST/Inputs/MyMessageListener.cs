using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;

public class MyMessageListener : MonoBehaviour 
{

    string[] vec1;
    public PechoOK2 ambientSound;//vol amb forest // -----------> No se usa
    public PulsoOK sphere;  // --------> No se usa
    public PanzaOK luz;  //  --------------------------->
    //public PDSensor cylinderPD;
    public PDSensor pdScript;      // -----> Se usa NPD Sensor
    public VientoOK MyWinds;
    public PechoOK2 distorsion;
    public FlowManager flowManager;   // ------> Remplazado
    public SoundManager instrucciones;   // ----------> Reemplazaodo por ForestInstructions
    [Header("Debug")]
    public bool exitOnFinish;//PONERLO EN TRUE?
    [Header("State")]
    public int steps;
    public int stepsChestError;
    public int stepsChestErrorAnt = 0;
    public int pasos = 0;

    public const int CHEST_INHALE = 2;//////
    public const int CHEST_EXHALE = 1;
    public const int BELLY_INHALE = 2;//////
    public const int BELLY_EXHALE = 1;

    public int datoL = 0;
    public int datoL2 = 0;
    public float datoNormCC;
    public float datoNormCB;
    private int datoLant = 0;
    private int datoL2ant = 1;  /////////////instruccion 01 ok, el resto no xq arranca a contar steps

    public event Action<int> OnChestValueReceived;

    public bool ToBelly = false;


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

        if (datoL2 != datoL2ant && flowManager.CurrentState == GameState.Chest && !SoundManager.instance.IsPlaying)//datoL2 == CHEST_INHALE && // si L2 NO es  1 Y no esta en play
        {

            OnChestValueReceived?.Invoke(datoL2);
            distorsion.AnimateToNextState();

            steps++;
            datoL2ant = datoL2;

            Debug.Log("STEPS : " + steps);

            if (steps == 2 )
            {
                SoundManager.instance.PlayInstruccion01();
            }
            else if (steps == 4 )
            {
                SoundManager.instance.PlayInstruccion02();//CHEST
            }
            else if (steps == 6 )
            {
                SoundManager.instance.PlayInstruccion033();//POESIA
                //pdScript.VolumenUp();
            }
            else if (steps == 8 )
            {
                flowManager.SetState(GameState.Belly);
                SoundManager.instance.PlayInstruccion03();//BELLY01               
                Debug.Log("TO BELLY");
            }
            
            //if (ToBelly == true && !SoundManager.instance.IsPlaying)
            //{
            //    flowManager.SetState(GameState.Belly);
            //    Debug.Log("TO BELLY");
            //    return;
            //}
        }
        //}
        //}
        //    else 
        //    {
        //        stepsChestError = stepsChestErrorAnt;
        //    }

        //////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY//(Input.GetKey("4"))              
        if (datoL == 2 && flowManager.CurrentState == GameState.Belly &&  !SoundManager.instance.IsPlaying)
        //(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE && !SoundManager.instance.IsPlaying)
        {
            //stepsL++;//cuento steps
            luz.inflaPanza();
            MyWinds.TurbulenceUp();

            if (datoL != datoLant)
            {
                MyWinds.soundWind();                             
            }
            //print(stepsL);
            //datoLant = datoL;
        }
        else
        {
         luz.desinflaPanza();
         MyWinds.TurbulenceDown();

         //stepsL = stepsLAnt;
        }
        datoLant = datoL;

        //////////////////PD/////chest/////////////////////////////////////
        if (datoL2 == 2)
        {
            /////////Debug.Log("datoStrech");
            pdScript.SoundUp();
        }
        else
        {
            pdScript.SoundDown();
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success' will be 'true' upon connection, and 'false' upon disconnection orfailure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
