using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool toggledon = false;




    public void toggle()
    {
        toggledon = !toggledon;
        //toggle sound

        if (toggledon == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //romm lgiths off
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //rom lights off
        }
    }
}
