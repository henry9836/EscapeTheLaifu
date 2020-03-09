﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public UnityEvent firstFrameTriggerEvent;
    public GameObject triggerObject;
    public bool TriggerOnStay = false;
    public float maxDistanceFromStartPosition = 0.8f;

    private bool heldDown = false;
    private bool firstHeldFrame = false;
    private Vector3 startPos;
    private void Start()
    {
        tag = "Button";
        startPos = transform.position;
        if (triggerObject)
        {
            ButtonListener bl = triggerObject.AddComponent<ButtonListener>();
            bl.TriggerWhenStay = TriggerOnStay;
            bl.parentButton = this;
        }
        else
        {
            Debug.LogWarning($"No trigger object set on button [{gameObject.name}]");
        }
    }


    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, startPos) > maxDistanceFromStartPosition)
        {
            transform.position = startPos;
        }

        if (TriggerOnStay && !firstHeldFrame)
        {
            //If close enough to our startposition reset bools
            if (Vector3.Distance(transform.position, startPos) < 0.1f)
            {
                firstHeldFrame = false;
            }
        }

    }

    public void Trigger()
    {
        heldDown = true;
        triggerEvent.Invoke();
        if (TriggerOnStay && firstHeldFrame)
        {
            firstHeldFrame = true;
            firstFrameTriggerEvent.Invoke();
        }
    }

}
