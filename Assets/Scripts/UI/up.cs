using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

    void Update()
    {
        this.transform.position += new Vector3(0.0f, 0.004f, 0.0f);
    }
}
