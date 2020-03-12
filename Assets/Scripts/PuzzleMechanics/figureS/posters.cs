using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posters : MonoBehaviour
{
    public List<Material> CompletePosterMAT = new List<Material> { };
    public List<GameObject> completePoster = new List<GameObject> { };

    public void assign(List<figure.Figures> password)
    {
        Debug.Log(password[0]);
        for (int i = 0; i < 4; i++)
        {
             if (password[i] == figure.Figures.waifu1)
             {
                 completePoster[i].GetComponent<MeshRenderer>().material = CompletePosterMAT[0];
             }
             else if (password[i] == figure.Figures.waifu2)
             {
                 completePoster[i].GetComponent<MeshRenderer>().material = CompletePosterMAT[1];
             }
             else if (password[i] == figure.Figures.waifu3)
             {
                 completePoster[i].GetComponent<MeshRenderer>().material = CompletePosterMAT[2];
             }
             else if (password[i] == figure.Figures.waifu4)
             {
                 completePoster[i].GetComponent<MeshRenderer>().material = CompletePosterMAT[3];
             }

        }
    }
}
