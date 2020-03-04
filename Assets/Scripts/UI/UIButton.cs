using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public Color og;
    public Color hoverd;

    public bool hovering = false;

    void Update()
    {
        if (hovering == true)
        {
            this.gameObject.GetComponent<Image>().color = hoverd;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = og;

        }

        if (hovering == true)
        {
            hovering = false;
        }
    }

    public void boop()
    {
        Debug.Log("Push da Button");
    }
}
