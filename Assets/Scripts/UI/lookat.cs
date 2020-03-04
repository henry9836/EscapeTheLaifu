using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    private GameObject cam;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        this.transform.LookAt(cam.transform.position);
        this.transform.Rotate((Vector3.up * 180));
    }
}
