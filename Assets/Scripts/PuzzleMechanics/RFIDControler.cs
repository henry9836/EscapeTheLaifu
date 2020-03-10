using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDControler : MonoBehaviour
{

    public List<bool> keycards = new List<bool>() { false, false };

    void Update()
    {
        if (keycards[0] == true && keycards[1] == true)
        {
            StartCoroutine(gamewin());
        }
    }

    public IEnumerator gamewin()
    {

        yield return null;
    }
}
