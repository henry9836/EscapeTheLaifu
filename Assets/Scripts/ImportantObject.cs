using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantObject : MonoBehaviour
{

    public float respawnFloor = -5.0f;

    private Vector3 respawnPosition;
    private Quaternion respawnRot;

    private void Start()
    {
        respawnPosition = transform.position;
        respawnRot = transform.rotation;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < respawnFloor)
        {
            transform.position = respawnPosition;
            transform.rotation = respawnRot;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
