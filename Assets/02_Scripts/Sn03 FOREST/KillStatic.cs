using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillStatic : MonoBehaviour
{
    private void Awake()
    {
        var other = FindObjectOfType<StaticObject>();

        if (other != null)
        {
            Destroy(other.gameObject);//lo contratrio
            return;
        }
    }
}
