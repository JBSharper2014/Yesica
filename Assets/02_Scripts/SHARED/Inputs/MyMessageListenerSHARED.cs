using UnityEngine;
using System;
using Valve.VR;

public class MyMessageListenerSHARED : MonoBehaviour
{
    public PDSensorSHARED pdScript;//chest de la escenaCITY -> Reemplazado por NPDSensor
    //de la escenaCALIBRACION
    public LuzBelly luzB; // ->  ShaderManager
    public ShaderSB3 luzSB;  // ->  ShaderManager (Reemplazado por ShaderController)
    public LuzHandL luzmanoL; // ->  ShaderManager
    public LuzHandR luzmanoR; // ->  ShaderManager
    //hice esto para controlar el scale de sphere con input de sensores

    //public Text belly;
    //public Text chest;
    //datos de sensores
    public float datoNormCC; 
    public float datoNormCB;

    public int datoL = 0;
    private int datoLant = 1;

    public int chestLimpio = 0;
    string[] vec1;



    public FlowCal flowCal;
    public FlowManCITY flowCity; // Se usa al descomentar las instrucciones después del input de sensores

    public int stepB;
    public int stepsAntB = 0;


    private void OnLevelWasLoaded(int level)
    {
        Initialize();
    }


    // Metodo reemplazado por ShaderManager
    private void Initialize() ////// componentes compartidos entre escenas (Shader)
    {
        luzB = FindObjectOfType<LuzBelly>();//luz belly
        luzSB = FindObjectOfType<ShaderSB3>();//ShaderSB3
        luzmanoL = FindObjectOfType<LuzHandL>();//luz mano
        luzmanoR = FindObjectOfType<LuzHandR>();//luz mano
        flowCal = FindObjectOfType<FlowCal>();
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
            chestLimpio = (Convert.ToInt32(vec1[1]));//CHEST
            //Debug.Log("chest:" + datoL2);
        }
        else if ((String.Compare(b1, c2)) == 0)//belly to vec
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

        ////////////////////////////////////////////////////////
        //////      Hasta aca reemplazado por los inputs
        ////////////////////////////////////////////////////////

        // Esta condición está para hacer que el pure data se ejecute cuando con el input del pecho, chest
        // y no con el input del microfono

        // 2 es inhalar
        // 1 es exalar (Siempre se mantiene en 1)

        ///////comentar al usar solo! esc.SHADER /////////descomentar p/ cambiar scene///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (chestLimpio == 2){ // && flowCity.CurrentState0 == GameState0.Chest0) {
            pdScript.SoundUp();
            //Debug.Log("pdCITY");
        }
        else { pdScript.SoundDown(); }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////
        //////      Hasta aca reemplazado en el script instrucciones de la city
        ///////////////////////////////////////////////////////////////////////////////////

        // A partir de aca es usado en la escena SHADER unicamente


        if (flowCal != null) //////componentes compartidos entre escenas
        {
            ///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
            if (chestLimpio == 2 && flowCal.CurrentState1 == GameState1.Chest1 )//|| flowC.CurrentState0 == GameState0.Chest0) 
            {
                pdScript.SoundUp();

                

                //////componentes compartidos entre escenas
                //luzSB.LuzUp();
                if (luzSB != null)
                {
                    luzSB.LuzUp();
                }

/*
                 if (luzSB != null )
                 {
                       luzSB.LuzUp();/////////////////////ShaderSB3
 
                    stepC++;
                    Debug.Log("CONTADOR : " + stepC);

                    if (stepC >= 50 )//&& stepC < 65)
                    {                       
                        luzSB = null;//dejar de leer input PERO VOLVER A LEER NORMAL...
                        flag = true;
                    }

                    if (flag == true )// && datoL2 == 1)
                    {
                        luzSB.LuzUp();
                        //_ = luzSB != null;
                    }

                 }
*/
                //luzmanoL.luzHandL();
                if (luzmanoL != null)
                {
                    luzmanoL.luzHandL();
                }
                //luzmanoR.luzHandR();
                if (luzmanoR != null)
                {
                    luzmanoR.luzHandR();
                }
            }
            else
            {
                pdScript.SoundDown();

                //luzSB.LuzDown();
                if (luzSB != null)
                {
                    luzSB.LuzDown();
                }
            }

            // ( Refactorizado hasta acá 30/03/2022 ) Script ShaderController

            // Si el input de la panza, es distinto al dato anterior (1) constante, es decir 2.
            // Y ademas estamos dentro del flow belly, y no hay nada sonando en SoundManagerGuia(SHADER)

            ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
            if (datoL != datoLant && flowCal.CurrentState1 == GameState1.Belly1 && !SoundManagerGuia.instance.IsPlaying)//(datoL == 2 && flow.CurrentState1 == GameState1.Belly1)
                {

                stepB++;
                Debug.Log("STEPS : " + stepB);
                    
                // los pasos avanzan 

                    if (stepB == 2)
                    {
                        SoundManagerGuia.instance.PlayInstruccion07();
                        return;
                    }

                    if (stepB == 4)
                    {
                        SoundManagerGuia.instance.PlayInstruccion08();
                    SteamVR_LoadLevel.Begin("03_ForestNEW");
                    return;
                    }
                    datoLant = datoL;
                    stepsAntB = stepB;
            }

            //////componentes compartidos entre escenas
            if (datoL == 2 && flowCal.CurrentState1 == GameState1.Belly1)
            {
                if (luzB != null)
                {
                    luzB.luzUpBELLY();
                }
            }
            else
            {
                if (luzB != null)
                {
                    luzB.luzDownB();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //////      Hasta aca reemplazado en el script ShaderManager 
        ///////////////////////////////////////////////////////////////////////////////////
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

}