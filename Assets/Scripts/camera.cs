using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject poleroid;
    
    public float kaCHEZSHHHHHHTime = 1.0f;

    private GameObject thePic;


    public void pic()
    {
        thePic = Instantiate(poleroid, this.transform);
        thePic.transform.parent = null;



        thePic.transform.GetComponent<print>().tackpic();
        StartCoroutine(kaCHEZSHHHHHH());
    }

    public IEnumerator kaCHEZSHHHHHH()
    {
        Vector3 startpos = thePic.transform.position;
        Vector3 endpos = startpos + (thePic.transform.forward * 0.1f);

        for (float i = 0; i < 1.0f; i += Time.unscaledDeltaTime * kaCHEZSHHHHHHTime)
        {
            thePic.transform.position = Vector3.Lerp(startpos, endpos, i);
            yield return null;
        }

        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
