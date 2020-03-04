using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    GameObject hand = null;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 stopPos;
    public float retTime = 0.4f;
    public float maxMove = 5.0f;
    public float pushableRadius = 0.5f;
    public bool returnsWhenDepressed = true;

    private float retTimer = 0.0f;

    private void Start()
    {
        gameObject.tag = "Button";
        startPos = transform.localPosition;
        stopPos = startPos + (transform.forward * maxMove);
    }

    private void Update()
    {
        if (!hand)
        {
            if (endPos == Vector3.positiveInfinity)
            {
                endPos = transform.localPosition;
            }

            transform.localPosition = Vector3.Lerp(endPos, startPos, retTimer/retTime);

            retTimer += Time.deltaTime;
        }
        else
        {
            endPos = Vector3.positiveInfinity;

            if (Vector3.Distance(hand.transform.position, transform.localPosition) < pushableRadius)
            {
                endPos = Vector3.Lerp(transform.localPosition, stopPos, Vector3.Distance(hand.transform.position, transform.localPosition)/pushableRadius);
                transform.localPosition = endPos;
            }
            retTimer = 0.0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
        {
            return;
        }

        hand = other.gameObject;

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
        {
            return;
        }

        hand = null;

    }

}
