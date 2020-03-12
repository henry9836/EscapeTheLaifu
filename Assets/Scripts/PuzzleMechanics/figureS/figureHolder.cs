using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class figureHolder : MonoBehaviour
{
    public List<GameObject> bases = new List<GameObject>();
    public List<GameObject> baselights = new List<GameObject>();
    public List<GameObject> popOutBlocks = new List<GameObject>();
    public List<Transform> popOutBlocksPOS = new List<Transform>();


    private List<figure.Figures> password = new List<figure.Figures>();
    public List<figure.Figures> list = new List<figure.Figures>();
    public List<bool> correct = new List<bool>() {false, false, false, false };
    public UnityEvent haswon;
    private bool oncewin = true;
    private bool win = true;

    public Color acceptColor;
    public Color rejectColor;
    private Color deadColor = Color.black;

    public string shadowPassword;


    void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            figure.Figures temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
            password.Add(list[i]);

        }

        list.Clear();


        for (int i = 0; i < 4; i++)
        {
            bases[i].GetComponent<figureSlot>().slot = i;
            bases[i].GetComponent<figureSlot>().correctID = password[i];
        }


        GameObject.Find("posterHolder").GetComponent<posters>().assign(password);
    }


    void Update()
    {
        win = true;
        for (int i = 0; i < 4; i++)
        {
            if (correct[i] == false)
            {
                win = false;
            }
        }


        if (win == true && oncewin == true)
        {
            oncewin = false;
            haswon.Invoke();
        }
    }

    public void placed(int state, int slot)
    {
        //swith statments are for nerds
        if (oncewin == false)
        {
            setcolorwin(baselights[slot]);
        }
        else if (state == 2 || state == 1)
        {
            if (state == 2)
            {
                correct[slot] = true;
            }
            else
            {
                correct[slot] = false;
            }
            setcolorloss(baselights[slot]);
        }
        else if (state == 0)
        {
            correct[slot] = false;
            setcoloroff(baselights[slot]);
        }
    }

    public void setcolorwin(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", acceptColor);
        
    }

    public void setcolorloss(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", rejectColor);
        
    }

    public void setcoloroff(GameObject light)
    {

        light.GetComponent<MeshRenderer>().material.SetColor("Color_FE39FBE8", deadColor);
        
    }

    public void whoop()
    {
        Debug.Log("winn");

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, 10);
            StartCoroutine(blockSlide(popOutBlocks[rand], i));
            shadowPassword += rand.ToString();
        }

        GameObject.Find("rightMonitor").transform.GetChild(0).GetChild(1).gameObject.GetComponent<KeyCodeController>().codes[2] = shadowPassword;
        

    }


    public IEnumerator blockSlide(GameObject obj, int number)
    {
        Vector3 endpos = popOutBlocksPOS[number].position;
        Vector3 startpos = endpos - (new Vector3(0.0f, 0.0f, 1.0f) * 0.3f);

        GameObject temp =  Instantiate(obj, popOutBlocksPOS[number].position, Quaternion.identity);


        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * 0.25f)
        {
            temp.transform.position = Vector3.Lerp(startpos, endpos, i);
            yield return null;
        }

        yield return null;

    }
}
