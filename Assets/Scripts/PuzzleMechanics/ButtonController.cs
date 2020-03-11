using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent heldTriggerEvent;
    public UnityEvent firstFrameTriggerEvent;
    public UnityEvent exitFrameTriggerEvent;

    public GameObject indicatorLight;

    private void Start()
    {
        tag = "Button";
    }

    private void OnTriggerEnter(Collider other)
    {
        string compareTag = other.tag;
            
        //Check object that hit us is a trigger for action
        if (compareTag == "HandModel" || compareTag == "Interactable")
        {
            firstFrameTriggerEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        string compareTag = other.tag;

        //Check object that hit us is a trigger for action
        if (compareTag == "HandModel" || compareTag == "Interactable")
        {
            heldTriggerEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string compareTag = other.tag;

        //Check object that hit us is a trigger for action
        if (compareTag == "HandModel" || compareTag == "Interactable")
        {
            exitFrameTriggerEvent.Invoke();
        }
    }

}
