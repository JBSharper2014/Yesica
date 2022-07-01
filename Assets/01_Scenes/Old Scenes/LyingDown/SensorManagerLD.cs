using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;

public class SensorManagerLD : MonoBehaviour
{
    public string port;
    public int baudrate;
    private SerialPort sp;
    bool isStreaming = false;

    public GameObject sphereBelly;
    public GameObject sphereChest;

    public GameObject handRight;
    public GameObject handLeft;

    public Text pulse;
    public Text belly;
    public Text chest;
    public Text calibracion;

    public int datoP = 0;
    public int datoL = 0;
    public int datoL2 = 0;
    private int datoPant = 0;
    private int stepsL = 0;
    private int stepsLAnt = 0;

    public int speed;
    public int max;

    string[] vec1;

    void Start()
    {
        Open(); //CON BOTON
    }

    void Update()
    {
        if (isStreaming)
        {
            try 
            { 

                string value = ReadSerialPort();
               // print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                vec1 = value.Split(','); //Separamos el String leido valiendonos de las comas y almacenamos los valores en un array.

                string c1 = "chest";
                string c2 = (vec1[0]);
                string b1 = "belly";

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

///////////////////////////////////////////////txt 
                pulse.text = "MIRA AQUI " ;
                belly.text = "belly: " + datoL;
                chest.text = "chest: " + datoL2;
                //calibracion.text = "calibracion" + 

///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
                if (datoL2 == 2) //(flowManager.CurrentState == GameState.Chest && datoL2 != datoL2ant)
                {
                    sphereChest.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime) ;
                }
                else
                {
                    sphereChest.transform.localScale = new Vector3(3, 3, 3);
                }

                ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
                if (datoL == 2)//(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE)
                {
                    sphereBelly.transform.localScale += new Vector3(3, 3, 3) * 2 *( Time.deltaTime);
                    
                }
                else
                {
                    sphereBelly.transform.localScale = new Vector3(3, 3, 3);
                }

//////////////////PULSE////////////////////////////////////////////////////////////
                if (datoP != datoPant)//?? (datoP == 2 && datoP != datoPant)
                {
                    //OnPulseValueChanged?.Invoke(datoP);

                    if (datoP == 2)
                    {
                        //sphere.transform.localScale = new Vector3(5, 5, 5);
                        //////////////////////Debug.Log("pulso");
                    }
                    else
                    {
                        //sphere.transform.localScale = new Vector3(1, 1, 1);
                    }

                    datoPant = datoP; //actualizo estados
                }

        }
            catch (System.Exception ex)
        {
            ex = new System.Exception();
        }
    }
}

    //void PosManos()
    //{
    //    if (handRight.transform.position.y >= 1.24 && handRight.transform.position.z >= 0.39
    //        && handLeft.transform.position.z >= 0.39 && handLeft.transform.position.y >= 1.24)
    //    {
    //        Debug.Log("OK");
    //    }

    //}

    public void Open()
    {
        isStreaming = true;
        sp = new SerialPort(port, baudrate);
        sp.ReadTimeout = 1;
        sp.Open();//this open the serial port
        Debug.Log("Port open OK");
    }

    public string ReadSerialPort(int timeout = 1)
    {
        string message;
        sp.ReadTimeout = timeout;

        try
        {
            message = sp.ReadLine();
            return message;
        }
        catch (TimeoutException)
        {
            return null;
        }
    }

    public void Close()
    {
        sp.Close();
    }


}

