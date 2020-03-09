using System.Collections;
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
        while (list.Count > 0)
        {
            int listpos = Random.Range(0, list.Count -1);
            password.Add(list[listpos]);
            list.RemoveAt(listpos);
        }

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
            setcolorwin(baselights[slot - 1]);
        }
        else if (state == 2 || state == 1)
        {
            correct[slot - 1] = true;
            setcolorloss(baselights[slot - 1]);
        }
        else if (state == 0)
        {
            correct[slot - 1] = false;
            setcoloroff(baselights[slot - 1]);
        }
    }

    void setcolorwin(GameObject light)
    {
        for (int i = 0; i < baselights.Count; i++)
        {
            baselights[i].GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", acceptColor);
        }
    }

    void setcolorloss(GameObject light)
    {
        for (int i = 0; i < baselights.Count; i++)
        {
            baselights[i].GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", rejectColor);
        }
    }

    void setcoloroff(GameObject light)
    {
        for (int i = 0; i < baselights.Count; i++)
        {
            baselights[i].GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", deadColor);
        }
    }

    public void whoop()
    {
        Debug.Log("winn");
    }
}
