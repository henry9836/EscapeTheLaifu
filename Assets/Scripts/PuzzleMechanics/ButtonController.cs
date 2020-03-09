using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public GameObject triggerObject;
    public bool TriggerOnStay = false;
    public float maxDistanceFromStartPosition = 0.8f;

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
    }

    public void Trigger()
    {
        triggerEvent.Invoke();
    }

}
