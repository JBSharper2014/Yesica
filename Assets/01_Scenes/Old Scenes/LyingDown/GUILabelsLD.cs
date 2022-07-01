using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabelsLD : MonoBehaviour
{
    public MyMessageListenerCAL datos;

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        //style.richText = true;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(5, 5, 100, 600), "Belly " + datos.datoNormCB);//calibracionCB
        GUI.Label(new Rect(5, 30, 100, 600), "Chest " + datos.datoNormCC);//calibracionCC

        //GUI.Label(new Rect(840, 35, 100, 20), datos.datoNormCB, style);

        //GUILayout.Label("<size=30> <color=yellow>CHEST</color> + datoL2</size>", style);

        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        //GUILayout.Label("<size=30>hola <color=yellow>HOLA</color> chau</size>", style);
    }
}