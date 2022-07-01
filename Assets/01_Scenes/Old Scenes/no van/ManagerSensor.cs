using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class ManagerSensor : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);
    void Start()
    {
        serialPort.ReadTimeout = 100;
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
            try
            {
                if (serialPort.IsOpen)
                {
                print(serialPort.ReadLine());
                }

            }
            
            catch (System.Exception ex)
            {
                ex = new System.Exception();
            }






    }



}







