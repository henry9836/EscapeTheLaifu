﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : MonoBehaviour
{
    public float timer = 0.0f;
    public float maxTime = 120.0f;
    public GameObject timerUI;
    public float fadeouttime = 2.0f;
    public GameObject door;

    public bool playing = true;

    public AudioClip dooropen;


    void Start()
    {
        timer = maxTime;
    }

    void Update()
    {
        if (playing == true)
        {
            timer -= Time.unscaledDeltaTime;

            if (timer <= 0.0f)
            {
                loss();
            }
            setTimer();
        }
    }





    public void setTimer()
    {
        int min = Mathf.FloorToInt(timer / 60.0f);
        int sec = Mathf.FloorToInt(timer - min * 60);
        string display = string.Format("{0:00}:{1:00}", min, sec);

        timerUI.GetComponent<Text>().text = display;
    }

    public void loss()
    {
        playing = false;
        timer = 0.0f;
        Debug.Log("!winner");
        StartCoroutine(fadescene());

        StartCoroutine(textflash());
    }

    public void win()
    {
        playing = false;
        StartCoroutine(textflash());
        door.GetComponent<AudioSource>().PlayOneShot(dooropen);
        StartCoroutine(doorslide());

    }

    public IEnumerator textflash()
    {
        while (true)
        {
            timerUI.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            timerUI.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator fadescene()
    {
        Volume post = GameObject.Find("Scene PostProcess").GetComponent<Volume>();

        yield return new WaitForSeconds(3.0f);
        for (float i = 0.0f; i < 1.0f; i += Time.unscaledDeltaTime * fadeouttime)
        {
            Exposure exposure;

            Debug.Log(post.profile);
            post.profile.TryGet<Exposure>(out exposure);

            exposure.fixedExposure.value = Mathf.Lerp(10.0f, 20.0f, i);
            yield return null;
        }
        Debug.Log("load scene");
        SceneManager.LoadScene(0);
    }

    public IEnumerator doorslide()
    {
        Vector3 startpos = door.transform.position;
        Vector3 endpos = startpos + new Vector3(0.0f, 0.0f, -0.5f);
        for (float i = 0.0f; i < 1.0f; i += Time.unscaledDeltaTime * 0.3f)
        {
            door.transform.position = Vector3.Lerp(startpos, endpos, i);
            yield return null;
        }

        yield return null;
    
    }
}
