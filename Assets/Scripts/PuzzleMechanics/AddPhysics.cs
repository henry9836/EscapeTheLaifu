using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhysics : MonoBehaviour
{
    public void AddRigidbody()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    public void UnfreezeRigidBody(bool useGravity)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = useGravity;
    }
}
