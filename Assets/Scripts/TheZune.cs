using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheZune : MonoBehaviour
{

    public List<AudioClip> tracks = new List<AudioClip>();

    private AudioSource aS;


    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If we are not playing a track
        if (!aS.isPlaying)
        {
            //Load a new track
            aS.clip = tracks[Random.Range(0, tracks.Count)];
            aS.Play();
        }
    }
}
