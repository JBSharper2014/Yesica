using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ManosCintura : MonoBehaviour, IUseInputs
{

    public GameObject handRed;//1
    public GameObject handBlue;//2

    public bool hands1 = true;
    public bool hands2 = true;
    public bool manoscintura;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;

    private MeshRenderer salvaVidasMeshRenderer;

    private void Awake()//start?
    {
        salvaVidasMeshRenderer = GetComponent<MeshRenderer>();//salvavidas
        GetComponent<MeshRenderer>().enabled = false;
        AddInputListeners();
    }

    private void OnDestroy() {
        RemoveInputListeners();
    }

    // Interfaz IUseInputs
    public void AddInputListeners() {
        AllKeyInputs.x.AddListener(EnableMeshRenderer);
        AllKeyInputs.c.AddListener(DisableMeshRenderer);
        Debug.Log("Salvavidas On Desde input");
    }
    public void RemoveInputListeners() {
        AllKeyInputs.x.RemoveListener(EnableMeshRenderer);
        AllKeyInputs.c.RemoveListener(DisableMeshRenderer);
        Debug.Log("Salvavidas Off Desde input");
    }

    public void EnableMeshRenderer() {
        salvaVidasMeshRenderer.enabled = true;
        Debug.Log("salvavidasON");
    }
    public void DisableMeshRenderer() {
        salvaVidasMeshRenderer.enabled = false;
        Debug.Log("salvavidasOFF");
    }

    public void OnTriggerStay (Collider other)//OnTriggerEnter
    {

        if (other.gameObject.tag == "hands1")//handRed
        {
            hands1 = true;
            //Debug.Log("hands1");               
        }

        if (other.gameObject.tag == "hands2")//handBlue
        {
            hands2 = true;
            //Debug.Log("hands2");          
        }


        if (hands1 == true && hands2 == true)//////2 MANOS EN LA CINTURA 
        {
            hands2 = false;
            hands1 = false;
            Debug.Log("HANDRED+BLUE");
            manoscintura = true;
   
            ////////////////VER CAPSULA SOLO PARA DEBUG
            GetComponent<MeshRenderer>().enabled = true;
            salvaVidasMeshRenderer.material.color = enterColor;//pinta SALVAVIDAS rojo
        }

    }

    private void OnTriggerExit(Collider other)///////SACO LAS MANOS
    {
            salvaVidasMeshRenderer.material.color = normalColor;//salvavidas CAMBIA COLOR AL SACAR MANOS
            GetComponent<MeshRenderer>().enabled = false;

            if (other.gameObject.tag == "hands1") hands1 = false;
            if (other.gameObject.tag == "hands2") hands2 = false;
    }

}
