using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDReader : MonoBehaviour
{
    public int readerno;
    public GameObject theLights;

    public AudioClip win;
    public AudioClip loss;

    private RFIDControler theManager;
    private bool locked = false;

    void Start()
    {
        theManager = GameObject.Find("GameManager").GetComponent<RFIDControler>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RFIDcard>())
        {
            if (other.GetComponent<RFIDcard>().cardno == readerno)
            {
                if (locked == false)
                {
                    StartCoroutine(correct());
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(win);
                }
            }
            else
            {
                if (locked == false)
                {
                    StartCoroutine(wrong());
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(loss);
                }
            }
        }
    }



    public IEnumerator correct()
    {
        locked = true;
        theManager.correct[readerno] = true;
        GameObject.Find("place").GetComponent<figureHolder>().setcolorwin(theLights);

        yield return new WaitForSeconds(2.0f);

        GameObject.Find("place").GetComponent<figureHolder>().setcoloroff(theLights);
        theManager.correct[readerno] = false;
        locked = false;
    }

    public IEnumerator wrong()
    {
        locked = true;
        GameObject.Find("place").GetComponent<figureHolder>().setcolorloss(theLights);
        yield return new WaitForSeconds(2.0f);
        GameObject.Find("place").GetComponent<figureHolder>().setcoloroff(theLights);
        locked = false;
    }
}
