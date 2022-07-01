using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practicaMR1 : MonoBehaviour
{
	public Transform vrCamera;
	public float toggleAngle;
	private bool estaAndando = false;

	public Material materialA;//rojo
	public Renderer objectRenderer;
	
	//public Light myLight;
	//public float intensity;
	//public float range;

	void Start()
	{	
		//vrCamera = Camera.main.transform;
	}

	void Update()
	{

		if (!estaAndando && MiraAbajo) //(vrCamera.eulerAngles.x > -10.0f && vrCamera.eulerAngles.x < 13.0f)
		{
			GetComponent<Renderer>().material = materialA;//rojo
			//myLight.intensity += intensity * Time.deltaTime;
			//myLight.range += range * Time.deltaTime;
			Debug.Log("baja");
		}
	}

    private bool MiraAbajo
    {
        get
        {
            return vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f; //la cam X esta entre 30 y 90 
        }
    }
}
