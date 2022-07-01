using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fadeOut2 : MonoBehaviour
{
        private void Update()
        {
            if (Input.GetKey("up"))
        {
            SteamVR_LoadLevel.Begin("03ForestNEW");
            }
        }

 }
