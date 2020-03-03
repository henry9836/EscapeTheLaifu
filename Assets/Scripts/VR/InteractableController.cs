using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractableController : MonoBehaviour
{

    public HandController parentHand;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
