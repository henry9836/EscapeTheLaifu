using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject poleroid;
    
    public float kaCHEZSHHHHHHTime = 1.0f;

    private GameObject thePic;
    private bool picLock = false;
    private GameObject cam;

    void Start()
    {
        cam = this.gameObject.transform.GetChild(0).gameObject;

    }

    public void pic()
    {
        if (!picLock)
        {
            Debug.Log("click");
            thePic = Instantiate(poleroid, this.transform);
            thePic.gameObject.transform.localPosition += new Vector3(0.0f, 0.35f, 0.0f);

            cam.transform.parent = null;
            cam.transform.position = transform.position + (Vector3.right * 500.0f);


            StartCoroutine(delay());
            StartCoroutine(kaCHEZSHHHHHH());
        }
    }

    public IEnumerator kaCHEZSHHHHHH()
    {
        picLock = true;


        for (float i = 0; i < 1.0f; i += Time.unscaledDeltaTime * kaCHEZSHHHHHHTime)
        {
            thePic.transform.position += thePic.transform.right * Time.deltaTime * kaCHEZSHHHHHHTime * 0.2f;
            yield return null;
        }
        thePic.transform.parent = null;
        thePic.GetComponent<BoxCollider>().enabled = true;
        thePic.GetComponent<Rigidbody>().isKinematic = false;
        picLock = false;
        yield return null;
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        thePic.transform.GetComponent<print>().tackpic();
        cam.transform.parent = this.gameObject.transform;

        cam.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        cam.transform.localRotation = Quaternion.identity;
    }

}
