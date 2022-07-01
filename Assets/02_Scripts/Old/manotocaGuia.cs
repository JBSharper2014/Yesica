using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manotocaGuia : MonoBehaviour
{
    public bool hands1;
    public bool hands2;
    public bool guia;

    void Start()
    {
        guia = true;
    }
    //void Awake()
    //{
    //    guia = true;
    //}

    void Update()
    {

    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("objGuia"))
    //    {
    //        guia = false;
    //        Debug.Log("TOCA");
    //    }
    //}

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("objGuia") )
        {
            guia = false;
            Debug.Log("TOCA");
        }
    }

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "objGuia") hands1 = false;

    //    guia = false;
    //}


}

//public void OnTriggerEnter(Collider other)
//{
//    if (other.gameObject.tag == "hands1")//handRed
//    {
//        hands1 = true;
//        Debug.Log("hands1");
//    }

//    if (other.gameObject.tag == "hands2")//handBlue
//    {
//        hands2 = true;
//        Debug.Log("hands2");
//    }

//    if (other.gameObject.tag == "objGuia")
//    {
//        guia = true;
//        Debug.Log("guia");
//    }

//    if (hands1 == true && hands2 == true)//////2 MANOS EN LA CINTURA 
//    {
//        hands2 = false;
//        hands1 = false;
//        Debug.Log("HANDRED+BLUE");


//    }
//}

//public void OnTriggerExit(Collider other)///////SACO LAS MANOS
//{


//}
//}
