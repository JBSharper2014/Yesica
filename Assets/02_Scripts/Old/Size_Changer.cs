using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size_Changer : MonoBehaviour
{
    public Vector3 maxLocalScale;
    float maxlocalScaleMagnitude;

    void Start()
    {

        maxLocalScale = new Vector3(5, 5, 1);
        maxlocalScaleMagnitude = maxLocalScale.magnitude;
    }


    void Update()
    {
        scaleUp();

    }

    void scaleUp()
    {
        float actualLocalScaleMagnitude = transform.localScale.magnitude;
        if (actualLocalScaleMagnitude < maxlocalScaleMagnitude)
        {
            transform.localScale += new Vector3(0.1F, 0.1F, 0);
        }
    }
        



}
