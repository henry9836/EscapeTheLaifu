using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDToaster : MonoBehaviour
{
    public List<GameObject> RFID = new List<GameObject> { };
    public int nextPop = 0;

    public bool test = false;

    void Update()
    {
        if (test == true)
        {
            pop();
            test = false;
        }
    }

    public void pop()
    {
        Debug.Log("pop");

        GameObject card = Instantiate(RFID[nextPop], this.gameObject.transform.position, Quaternion.identity);
        card.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
        nextPop++;

        card.GetComponent<Rigidbody>().AddForce((new Vector3(0.0f, 1.0f, -0.05f) * 4.0f), ForceMode.Impulse);
    }
}
