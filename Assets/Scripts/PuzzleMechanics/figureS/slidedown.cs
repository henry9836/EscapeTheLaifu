using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidedown : MonoBehaviour
{
    public void henryThisOne()
    {
        Debug.Log("Henry Called!");
        StartCoroutine(slide());
    }

    public IEnumerator slide()
    {
        Debug.Log("Time to slide ");
        Vector3 startpos = this.gameObject.transform.position;
        Vector3 endpos = startpos + (new Vector3(0.0f, 1.0f, 0.0f) * -0.3f); //-0.01402f 
        this.GetComponent<BoxCollider>().enabled = false;

        for (float i = 0.0f; i < 1.0f; i += Time.unscaledDeltaTime * 0.3f)
        {
            this.gameObject.transform.position = Vector3.Lerp(startpos, endpos, i);
            yield return null;
        }
        yield return null;
    }

}
