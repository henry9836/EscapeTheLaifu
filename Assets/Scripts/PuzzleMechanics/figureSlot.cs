using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class figureSlot : MonoBehaviour
{
    public figure.Figures correctID;
    public int slot;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "figure")
        {
            if (other.GetComponent<figure>().fig == correctID)
            {
                this.transform.GetComponentInParent<figureHolder>().placed(2, slot); //win
            }
            else
            {
                this.transform.GetComponentInParent<figureHolder>().placed(1, slot); // loss
            }
        }
        else
        {
            this.transform.GetComponentInParent<figureHolder>().placed(0, slot); // not figure
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.transform.GetComponentInParent<figureHolder>().placed(0, slot); // not figure

    }
}
