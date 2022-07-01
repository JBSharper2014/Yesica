using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fadeIn : MonoBehaviour
{
   private float _fadeDuration = 2f;

   private void Start()
   {
       FadeFromWhite();     
   }

    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.View(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.View(Color.black, _fadeDuration);
    }


        //private void FadeToWhite()
        //    {
        //        //set start color
        //        SteamVR_Fade.Start(Color.clear, 0f);
        //        //set and start fade to
        //        SteamVR_Fade.Start(Color.red, _fadeDuration);
        //    }

    //private void Update()
    //{
    //    if (Input.anyKey)
    //    {
    //        FadeToWhite();
    //        //SteamVR_LoadLevel.Begin("02CalibrationBlack");
    //    }
    //}
}


