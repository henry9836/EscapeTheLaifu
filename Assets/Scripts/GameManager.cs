using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer = 0.0f;
    public float maxTime = 120.0f;
    public GameObject timerUI;

    public bool playing = true;
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
        StartCoroutine(textflash());
    }

    public void win()
    {
        playing = false;
        StartCoroutine(textflash());

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
}
