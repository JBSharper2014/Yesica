using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class ManagerSensor1 : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);
    private int datoP = 0;
    void Start()
    {
        serialPort.ReadTimeout = 100;
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                string[] vec3 = value.Split(','); //Separamos el String leido valiendonos de las comas y almacenamos los valores en un array.
                datoP = (Convert.ToInt32(vec3[0]));

                /////////////////PD
                if (datoP > 6)
                {
                    Debug.Log("+++++");
                }

                if (datoP < 3)
                {
                    Debug.Log("------");
                }
            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
            }
        }






    }



}







