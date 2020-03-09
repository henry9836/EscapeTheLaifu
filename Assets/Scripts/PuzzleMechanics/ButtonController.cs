using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public GameObject triggerObject;
    public bool TriggerOnStay = false;
    private void Start()
    {
        tag = "Button";

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

    public void Trigger()
    {
        triggerEvent.Invoke();
    }

}
