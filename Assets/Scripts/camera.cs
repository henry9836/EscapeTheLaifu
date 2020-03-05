using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject poleroid;

    private void Start()
    {
        StartCoroutine(pic());
    }

    public IEnumerator pic()
    {
        yield return new WaitForSeconds(10.0f);
        GameObject pic =  Instantiate(poleroid, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        pic.transform.GetComponent<print>().tackpic();
        yield return new WaitForSeconds(10.0f);
        pic = Instantiate(poleroid, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        pic.transform.GetComponent<print>().tackpic();
    }


}
