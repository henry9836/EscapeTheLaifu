using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMe : MonoBehaviour
{

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}
