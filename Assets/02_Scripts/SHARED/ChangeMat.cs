using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material avatar;
    public Material fake;

    public void Update()
    {
        //if (Input.GetKeyDown("8"))
        //{
        //    Debug.Log("change");
        //    mirrorFake();
        //}
    }

    public void mirrorAvatar()
    {
        GetComponent<Renderer>().material = avatar;//?
        //LevelManager asd;
    }

    public void mirrorFake()
    {
        GetComponent<Renderer>().material = fake;
    }

    public void changeMirror()
    {
    }
}
