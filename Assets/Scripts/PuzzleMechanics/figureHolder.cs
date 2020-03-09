﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class figureHolder : MonoBehaviour
{
    public List<GameObject> bases = new List<GameObject>();
    public List<GameObject> baselights = new List<GameObject>();
    private List<figure.Figures> password = new List<figure.Figures>();
    public List<figure.Figures> list = new List<figure.Figures>();
    public List<bool> correct = new List<bool>() {false, false, false, false };
    public UnityEvent haswon;
    private bool oncewin = true;
    private bool win = true;

    public Color acceptColor;
    public Color rejectColor;
    private Color deadColor = Color.black;


    void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            figure.Figures temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
            password.Add(list[i]);

        }

        list.Clear();


        for (int i = 0; i < 4; i++)
        {
            bases[i].GetComponent<figureSlot>().slot = i;
            bases[i].GetComponent<figureSlot>().correctID = password[i];
        }
    }


    void Update()
    {
        win = true;
        for (int i = 0; i < 4; i++)
        {
            if (correct[i] == false)
            {
                win = false;
            }
        }


        if (win == true && oncewin == true)
        {
            oncewin = false;
            haswon.Invoke();
        }
    }

    public void placed(int state, int slot)
    {
        //swith statments are for nerds
        if (oncewin == false)
        {
            setcolorwin(baselights[slot]);
        }
        else if (state == 2 || state == 1)
        {
            if (state == 2)
            {
                correct[slot] = true;
            }
            else
            {
                correct[slot] = false;
            }
            setcolorloss(baselights[slot]);
        }
        else if (state == 0)
        {
            correct[slot] = false;
            setcoloroff(baselights[slot]);
        }
    }

    void setcolorwin(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", acceptColor);
        
    }

    void setcolorloss(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", rejectColor);
        
    }

    void setcoloroff(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", deadColor);
        
    }

    public void whoop()
    {
        Debug.Log("winn");
    }
}
