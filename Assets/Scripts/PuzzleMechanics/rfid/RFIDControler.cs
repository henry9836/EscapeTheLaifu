using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDControler : MonoBehaviour
{
    public List<bool> correct = new List<bool> { false, false };
    private bool oncewin = false;

    void Update()
    {
        if (correct[0] == true && correct[1] == true)
        {
            if (oncewin == false)
            {
                oncewin = true;
                this.gameObject.GetComponent<GameManager>().win();
            }
        }
    }
}
