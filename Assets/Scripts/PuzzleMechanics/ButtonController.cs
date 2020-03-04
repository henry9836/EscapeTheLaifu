using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public GameObject triggerObject;
    private void Start()
    {
        if (triggerObject)
        {
            triggerObject.AddComponent<ButtonListener>();
            triggerObject.GetComponent<ButtonListener>().parentButton = this;
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
