using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    public ButtonController parentButton;
    public LayerMask triggerLayerMask;

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
        if (other.gameObject.layer == triggerLayerMask) {
            parentButton.Trigger();
        }
    }


}
