using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;

public class SensorManagerTT : MonoBehaviour {

    // Debug.Log("test");
    SerialPort serialPort = new SerialPort("COM14", 9600);//WIFI
    //SerialPort serialPort = new SerialPort("/dev/cu.usbserial-14140",9600);
    
   // Debug.Log("ici");

    //public PulseSphere PulseSphere;
    //public BellyCube BellyCube;
    //public LigtPoint IntensityLight;
    //public ChestCapsule ChestCapsule;
    //public PDSensor2 cylinder;

    //string prueba;
    public int datoL = 0;
    public int datoL2 = 0;

    private int datoP = 0;
    private int datoPant = 0;
    private int stepsL = 0;
    private int stepsL2 = 0;
    private int stepsL2Ant = 0;
    private int stepsLAnt = 0;


    string[] vec1;

    public Text txtBelly;
    public Text txtChest;

   // void Start()
   // {
   //     serialPort.ReadTimeout = 1;
   //     serialPort.Open();
   // }

    // Use this for initialization
     void Start () {
        try{
            serialPort.Open();
            serialPort.DataReceived += DataReceivedHandler;
            Debug.Log("prueba");
        }
        catch(Exception e){
            Debug.Log("Could not open serial port: " + e.Message);
 
        }
  
     }

    
    private void DataReceivedHandler(
                         object sender,
                         SerialDataReceivedEventArgs e)
     {
         SerialPort sp = (SerialPort)sender;
         string prueba = sp.ReadLine();
         Debug.Log(prueba);
         Debug.Log("hey prueba");
     }
  
 }
 /*

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                //print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino               
                vec1 = value.Split(',');

                //Debug.Log("dato : " + vec1[1]);
                //Debug.Log("value : " + vec1[0]);

                string c1 = "chest";
                string c2 = (vec1[0]);
                string b1 = "belly";

                if ((String.Compare(c1, c2)) == 0)
                {
                    datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
                    Debug.Log("chest:" + datoL2);
                }
                else if ((String.Compare(b1, c2)) == 0)
                {
                    datoL = (Convert.ToInt32(vec1[1]));//belly  
                    Debug.Log("belly:" + datoL);
                }

                txtBelly.text = "belly: " + datoL;
                txtChest.text = "chest: " + datoL2;


////////////////BELLY----CUBE-----------------SENSOR L-----------------------------------------
                if (datoL == 2)//cuando 1  NO SEA IGUAL a 0 //cuando es 2 y NO ES el anterior (1). 
                {
                    IntensityLight.LightOn();//inhalo: 222 y ilumina
                    ChestCapsule.PlayFirstBreathAnimation();////////////// CHEST CORRUTINE vol amb forest 
                    
                    stepsL++;//empieza sumando con 1(al prender)- suma solo cuando cambia!!!

                    if (stepsL > 3)//margen error
                    {
                        BellyCube.agrandarC();                                           
                    }
                    ///////print(stepsL);
                }
                else
                {
                    BellyCube.achicarC();
                    IntensityLight.LightOff();
                                      
                    stepsL = stepsLAnt;//reseteo conteo OK
                }

//////////////////SENSOR L2 --------------CHEST-----------PECHO-----------------
                if (datoL2 == 2) //cuando respiro 2 Y es diferente dl anterior 1
                {

                    stepsL2++;  //cuenta 
                    if (stepsL2 == 3) //margen error
                    {
                        ChestCapsule.agrandarCa();
                        stepsL2 = stepsL2Ant;
                    }
                    //////////print(stepsL2);
                }
                else
                {
                    ChestCapsule.achicarCa();
                    stepsL2 = stepsL2Ant;//reseteo conteo
                }

                ///////////////////PD//////////////////////////////////////////
                if (datoL2 == 2)
                {
                    /////////Debug.Log("datoStrech");
                    cylinder.SoundUp();
                }
                else
                {
                    cylinder.SoundDown();
                }
///////////////////////////SENSOR PULSE -------------------cambio estado-------------------------------------------
                if (datoP == 2 && datoP != datoPant)// cuando recibe 2 y cuando el dato  SEA DIFERENTE DE SU ANTERIOR 1
                {
                    PulseSphere.agrandarS();
                    ///////////////////////print(datoPant);
                }
                else
                {
                    PulseSphere.achicarS();
                }
                datoPant = datoP;//actualizo estados

            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
            }
        }

    }


}
*/
