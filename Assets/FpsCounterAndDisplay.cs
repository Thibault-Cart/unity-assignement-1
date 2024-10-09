using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

   
    public TextMeshProUGUI txtFps;
    void Update()
    {
        print(1.0 / Time.deltaTime);
        //fps
        txtFps.text = " FPS:" + (Math.Round(1.0 / Time.deltaTime));


       
    }
}
