using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class figure : MonoBehaviour
{
    public enum Figures
    {
        waifu1,
        waifu2,
        waifu3,
        waifu4,
    }

    public Figures fig;

    private void Start()
    {
        gameObject.tag = "figure";
    }

}
