using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class ManagerSensorBTx2 : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM5", 9600);
    private int datoP = 0;
    private int datoL = 0;
    private int datoL2 = 0;
    private int datoL2ant = 0;

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
                datoP = (Convert.ToInt32(vec3[2]));//chest ultima pos
                datoL = (Convert.ToInt32(vec3[1]));
                datoL2 = (Convert.ToInt32(vec3[0]));

                ////////////////CHEST 
                if (datoP >= 20)
                {
                    Debug.Log("+CHEST+");
                }

                if (datoP < 20)
                {
                    //Debug.Log("-CHEST-");
                }

                //////////////BELLY 
                if (datoL >= 30)
                {
                    Debug.Log("+BELLY+");
                }

                if (datoL < 30)
                {
                    //Debug.Log("-BELLY-");
                }

                //SENSOR PULSE -------------------cambio estado-------------------------------------------
                if (datoL2 == 2 && datoL2 != datoL2ant)// cuando recibe 2 y cuando el dato  SEA DIFERENTE DE SU ANTERIOR 1
                {
                    //PulseSphere.agrandarS();
                    print(datoL2ant);
                }
                else
                {
                    //PulseSphere.achicarS();
                }
                datoL2ant = datoL2;//actualizo estados
            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
            }
        }






    }



}







