using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompartmentPlatform : MonoBehaviour
{

    public Vector3 stopPostion;
    public float timeToMove = 3.0f;

    public bool moveLock = true;
    public float moveTimer = 0.0f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!moveLock)
        {
            moveTimer += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, stopPostion, (moveTimer/timeToMove));
        }
    }

    public void move()
    {
        moveLock = false;
    }
}
