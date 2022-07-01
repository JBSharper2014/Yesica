using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManos1 : MonoBehaviour
{
    public bool hand1;//f
    /////se tocan porque nacen juntos y pasa a TRUE

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("hands2"))//|| collider.gameObject.tag == "objGuia")//WHYHAND2?
        {
            Debug.Log("SE TOCAN Y TRUE");//guia+mano
            hand1 = true;
        }
    }
}

    