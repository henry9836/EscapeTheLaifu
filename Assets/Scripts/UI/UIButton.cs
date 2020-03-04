using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class UIButton : MonoBehaviour
{
    public Color og;
    public Color hoverd;

    public bool hovering = false;

    public enum Types
    { 
        menu,
        other,
        exit,
    }

    public Types type;

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
        if (Types.menu == type)
        {
            SceneManager.LoadScene(1);
        }
        if (Types.other == type)
        {
            GameObject p = GameObject.FindWithTag("Player");
            p.AddComponent<SphereCollider>();
            p.AddComponent<Rigidbody>();
            //SceneManager.LoadScene(1);
        }
        if (Types.exit == type)
        {
            Application.Quit();

        }
    }
}
