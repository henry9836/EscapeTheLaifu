using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject poleroid;
    
    public float kaCHEZSHHHHHHTime = 1.0f;

    private GameObject thePic;
    private bool picLock = false;

    public void pic()
    {
        if (!picLock)
        {
            Debug.Log("click");
            thePic = Instantiate(poleroid, this.transform);
            thePic.gameObject.transform.localPosition += new Vector3(0.0f, -0.8f, 0.0f);

            this.gameObject.transform.GetChild(0).transform.position += new Vector3(500.0f, 0.0f, 0.0f);


            thePic.transform.GetComponent<print>().tackpic();

            this.gameObject.transform.GetChild(0).transform.position += new Vector3(-500.0f, 0.0f, 0.0f);

            StartCoroutine(kaCHEZSHHHHHH());
        }
    }

    public IEnumerator kaCHEZSHHHHHH()
    {
        picLock = true;


        for (float i = 0; i < 1.0f; i += Time.unscaledDeltaTime * kaCHEZSHHHHHHTime)
        {
            thePic.transform.position += thePic.transform.forward * Time.deltaTime * kaCHEZSHHHHHHTime * 0.2f;
            yield return null;
        }
        thePic.transform.parent = null;
        thePic.GetComponent<BoxCollider>().enabled = true;
        thePic.GetComponent<Rigidbody>().isKinematic = false;
        picLock = false;
        yield return null;
    }

}
