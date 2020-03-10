using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDReader : MonoBehaviour
{
    public int readerno;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RFIDcard>())
        {
            if (readerno == other.GetComponent<RFIDcard>().cardno)
            {

            }
        }
    }

    void Update()
    {

    }
}
