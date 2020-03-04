using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    void Update()
    {
        this.transform.eulerAngles = new Vector3(GameObject.Find("Main Camera").transform.eulerAngles.x, GameObject.Find("Main Camera").transform.eulerAngles.y, GameObject.Find("Main Camera").transform.eulerAngles.z);
    }
}
