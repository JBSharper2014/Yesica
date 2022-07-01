using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;


public class SensorManager : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM18", 9600);

    public PechoOK2 ambientSound;///vol amb forest
    public PulsoOK sphere;
    public PanzaOK luz;
    public PDSensor cylinderPD;
    public VientoOK MyWinds;

    public Text belly;

    public const int CHEST_INHALE = 2;//////3 (chest,2)
    public const int CHEST_EXHALE = 1;
    public const int BELLY_INHALE = 2;//////3
    public const int BELLY_EXHALE = 1;
    public const int PULSE_INHALE = 2;
    public const int PULSE_EXHALE = 1;

    public int datoP = 0;
    public int datoL = 0;
    public int datoL2 = 0;
    private int datoPant = 0;
    private int datoLant = 0;
    private int datoL2ant = 0;
    private int stepsPulso = 0;
    private int stepsL = 0;
    private int stepsLAnt = 0;
    private int stepsL2 = 0;
    private int stepsL2Ant = 0;

    public event Action<int> OnChestValueReceived;
    //public event Action<int> OnBellyValueChanged;
    //public event Action<int> OnPulseValueChanged;

    string[] vec3;

    public FlowManager flowManager;

    void Start()
    {
        serialPort.ReadTimeout = 1;///////!!!!
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino

                vec3 = value.Split(','); //Separamos el String leido valiendonos de las comas y almacenamos los valores en un array.
                //RECIBIA (1,1,1)  O (2,2,2)  
                datoP = (Convert.ToInt32(vec3[0]));//PULSE
                datoL = (Convert.ToInt32(vec3[1]));//BELLY
                datoL2 = (Convert.ToInt32(vec3[2]));//CHEST

                belly.text = "belly: " + datoL;

                ///////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
                if (flowManager.CurrentState == GameState.Chest && datoL2 >= CHEST_INHALE) //(flowManager.CurrentState == GameState.Chest && datoL2 != datoL2ant)
                {
                    OnChestValueReceived?.Invoke(datoL2);
                }

//////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY              
                if (flowManager.CurrentState == GameState.Belly && datoL >= BELLY_INHALE)//(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE)
                {
                    //OnBellyValueChanged?.Invoke(datoL);

                    //ambientSound.PlayFirstBreathAnimation();////////////// CHEST CORRUTINE vol amb forest sucede???

                    stepsL++;//cuento steps

                    if (stepsL > 3)//margen error
                    {
                        luz.inflaPanza();
                        MyWinds.TurbulenceUp();
                        MyWinds.soundWind();
                        ambientSound.PlayFirstBreathAnimation();////////////// CHEST CORRUTINE vol amb forest sucede???
                        //Debug.Log("panzaON");
                    }
                    //print(stepsL);
                }
                else
                {
                    luz.desinflaPanza();
                    MyWinds.TurbulenceDown();

                    stepsL = stepsLAnt;
                }
//////////////////PD//////////////////////////////////////////
                if (datoL2 >= 3)
                {
                    /////////Debug.Log("datoStrech");
                    //cylinderPD.SoundUp();
                }
                else
                {
                    //cylinderPD.SoundDown();
                }
//////////////////PULSE////////////////////////////////////////////////////////////
                if (datoP != datoPant)//?? (datoP == 2 && datoP != datoPant)
                {
                    //OnPulseValueChanged?.Invoke(datoP);

                    if (datoP == PULSE_INHALE)
                    {
                        sphere.lateOn();
                        //////////////////////Debug.Log("pulso");
                    }
                    else
                    {
                        sphere.lateOff();
                    }

                    datoPant = datoP; //actualizo estados
                }

            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
                //Debug.Log(ex.Message);
            }
        }
    }




}

