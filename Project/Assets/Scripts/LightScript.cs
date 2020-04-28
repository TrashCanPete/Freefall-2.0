using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light light;
    //Set the Color to white to start off
    public Color Cavecolor;
    public Color outsideColor;

    void Start()
    {
        //Fetch the Renderer of the GameObject
        light = GetComponent<Light>();
        Cavecolor = new Color(107, 171, 204, 255);
        outsideColor = new Color(219, 166, 51, 255);
        light.color = Cavecolor;
        light.intensity = 1;
    }
}
