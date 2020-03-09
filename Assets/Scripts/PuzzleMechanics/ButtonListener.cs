using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    public ButtonController parentButton;
    public LayerMask triggerLayerMask;

    public bool TriggerWhenStay = false;

    private void Start()
    {
        if (!GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check layer mask if matches then call trigger
        if (other.gameObject.tag == "Button") {
            parentButton.Trigger();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Check layer mask if matches then call trigger
        if (TriggerWhenStay)
        {
            if (other.gameObject.tag == "Button")
            {
                parentButton.Trigger();
            }
        }
    }

}
