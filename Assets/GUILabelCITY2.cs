using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabelCITY2 : MonoBehaviour
{
    private int contador;
    private float timer = 0.0f;
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable

    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;
    }

    public void OnGUI()
    {
        //GUI.contentColor = Color.white;
        GUI.color = Color.white;
        guiStyle.fontSize = 20; //change the font size
        GUI.Label(new Rect(5, 60, 100, 600), timer + "  " + "TIEMPO ", guiStyle);
    }
}
