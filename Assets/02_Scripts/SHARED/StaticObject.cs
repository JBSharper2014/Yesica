using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : MonoBehaviour
{
    private void Awake()
    {
        var other = FindObjectOfType<StaticObject>();

        if (other != null && other != this)//solo sobrevive uno de ese tipo
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
