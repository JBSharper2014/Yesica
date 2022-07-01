using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class scaleLimited : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scaleLim();
    }

    void scaleLim ()
    {
        if (transform.localScale.sqrMagnitude < 2 * 2)
        {
            transform.localScale += new Vector3(3, 3, 3); // * 2 * (Time.deltaTime);
        }

    }
}
