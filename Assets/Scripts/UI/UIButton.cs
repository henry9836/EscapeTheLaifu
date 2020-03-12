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

    public GameObject credits;
    public Vector3 spawnPos;

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
        else if (Types.other == type)
        {


            if (credits)
            {
                Instantiate(credits, spawnPos, Quaternion.identity);
            }
            //GameObject p = GameObject.FindWithTag("Player");
            //p.AddComponent<SphereCollider>();
            //p.AddComponent<Rigidbody>();
        }
        else if (Types.exit == type)
        {
            Application.Quit();

        }
    }
}
