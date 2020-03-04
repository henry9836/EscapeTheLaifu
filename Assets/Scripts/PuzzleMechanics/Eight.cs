using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
}
