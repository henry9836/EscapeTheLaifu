using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDController : MonoBehaviour
{

    public Color startColor;

    private void Start()
    {
        ColorChange(startColor);
    }

    public void TurnOff()
    {
        ColorChange(Color.black);
    }
    public void turnMagenta()
    {
        ColorChange(Color.magenta);
    }
    public void turnBlue()
    {
        ColorChange(Color.blue);
    }

    public void turnGreen()
    {
        ColorChange(Color.green);
    }

    public void turnRed()
    {
        ColorChange(Color.red);
    }

    public void ColorChange(Color color)
    {
        GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", color);
    }
}
