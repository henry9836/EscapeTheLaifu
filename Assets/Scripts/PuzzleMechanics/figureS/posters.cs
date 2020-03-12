using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posters : MonoBehaviour
{
    public List<Material> CompletePosterMAT = new List<Material> { };
    public List<GameObject> completePoster = new List<GameObject> { };

    public void assign(List<figure.Figures> password)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (completePoster[j].GetComponent<IndividPoster>().waifupic == password[i])
                {
                    if (password[i] == figure.Figures.waifu1)
                    {
                        completePoster[j].GetComponent<MeshRenderer>().material = CompletePosterMAT[0];
                    }
                    if (password[i] == figure.Figures.waifu2)
                    {
                        completePoster[j].GetComponent<MeshRenderer>().material = CompletePosterMAT[1];
                    }
                    if (password[i] == figure.Figures.waifu3)
                    {
                        completePoster[j].GetComponent<MeshRenderer>().material = CompletePosterMAT[2];
                    }
                    if (password[i] == figure.Figures.waifu4)
                    {
                        completePoster[j].GetComponent<MeshRenderer>().material = CompletePosterMAT[3];
                    }
                }
            } 
        }
    }
}
