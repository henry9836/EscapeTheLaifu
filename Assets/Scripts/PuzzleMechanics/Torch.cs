using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool toggledon = false;
    public List<GameObject> roofaeralights = new List<GameObject> { }; //0 and 1 or bright 2 and 3 are off

    //public bool test = false;

    //void Update()
    //{
    //    if (test == true)
    //    {
    //        test = false;
    //        toggle();
    //    }
    //}


    public void toggle()
    {
        toggledon = !toggledon;
        //toggle sound


        if (toggledon == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < roofaeralights.Count; i++)
            {
                if (i == 2 || i == 3)
                {
                    roofaeralights[i].SetActive(true);
                }
                else
                {
                    roofaeralights[i].SetActive(false);
                }
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            for (int i = 0; i < roofaeralights.Count; i++)
            {
                if (i == 0 || i == 1)
                {
                    roofaeralights[i].SetActive(true);
                }
                else
                {
                    roofaeralights[i].SetActive(false);
                }
            }
        }
    }
}
