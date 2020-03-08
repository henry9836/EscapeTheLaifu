using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class pausebutton : MonoBehaviour
{
    public bool isPaused = false;
    public SteamVR_Action_Boolean inputAction = null;
    private SteamVR_Behaviour_Pose tmpPose = null;
    public bool once = true;

    private GameObject leftControler;
    private GameObject rightControler;
    private GameObject pauseUI;

    void Awake()
    {
        tmpPose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        leftControler = GameObject.Find("[CameraRig]").transform.GetChild(0).gameObject;
        rightControler = GameObject.Find("[CameraRig]").transform.GetChild(1).gameObject;
        pauseUI = GameObject.Find("[CameraRig]").transform.GetChild(2).GetChild(0).gameObject;

        leftControler.GetComponent<Pointer>().enabled = false;
        rightControler.GetComponent<Pointer>().enabled = false;
        pauseUI.GetComponent<Pointer>().enabled = false;
    }


    void Update()
    {
        if (inputAction.GetStateDown(tmpPose.inputSource))
        {
            isPaused = !isPaused;
        }

        if (isPaused == true)
        {
            if (once == true)
            {
                once = false;
                leftControler.GetComponent<Pointer>().enabled = true;
                rightControler.GetComponent<Pointer>().enabled = true;
                pauseUI.GetComponent<Pointer>().enabled = true;

            }
        }
        else 
        {
            if (once == false)
            {
                once = true;
                leftControler.GetComponent<Pointer>().enabled = false;
                rightControler.GetComponent<Pointer>().enabled = false;
                pauseUI.GetComponent<Pointer>().enabled = false;

            }
        }
    }


}
