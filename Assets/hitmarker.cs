using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class hitmarker : MonoBehaviour
{
    private Volume volum;
    Vignette vignette;
    float intesity;
    // Start is called before the first frame update
    void Start()
    {
        volum = GetComponent<Volume>();
        volum.profile.TryGet(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        intesity = vignette.intensity.value;
        intesity -= 0.01f;
        vignette.intensity.value=intesity;
    }
}
