using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class pausebutton : MonoBehaviour
{
    public bool isPaused = false;
    public SteamVR_Action_Boolean inputAction = null;
    public SteamVR_Behaviour_Pose tmpPos1 = null;
    public SteamVR_Behaviour_Pose tmpPos2 = null;
    public bool once = true;

    private GameObject cam;
    private GameObject leftControler;
    private GameObject rightControler;
    private GameObject pauseUI;



    void Start()
    {
        cam = GameObject.Find("[CameraRig]").transform.GetChild(2).gameObject;

        leftControler = GameObject.Find("[CameraRig]").transform.GetChild(0).gameObject;
        tmpPos1 = leftControler.GetComponent<SteamVR_Behaviour_Pose>();
        rightControler = GameObject.Find("[CameraRig]").transform.GetChild(1).gameObject;
        tmpPos2 = rightControler.GetComponent<SteamVR_Behaviour_Pose>();

        pauseUI = GameObject.Find("pauseUI");
        pauseUI.SetActive(false);


        leftControler.GetComponent<Pointer>().enabled = false;
        leftControler.GetComponent<LineRenderer>().enabled = false;

        rightControler.GetComponent<Pointer>().enabled = false;
        rightControler.GetComponent<LineRenderer>().enabled = false;

    }


    void Update()
    {
        if (inputAction.GetStateUp(tmpPos1.inputSource) || inputAction.GetStateUp(tmpPos2.inputSource))
        {
            isPaused = !isPaused;
        }

        if (isPaused == true)
        {
            if (once == true)
            {
                once = false;
                leftControler.GetComponent<Pointer>().enabled = true;
                leftControler.GetComponent<LineRenderer>().enabled = true;
                rightControler.GetComponent<Pointer>().enabled = true;
                rightControler.GetComponent<LineRenderer>().enabled = true;

                pauseUI.SetActive(true);
                pauseUI.transform.position = cam.transform.position + (cam.transform.forward * 2.0f);
                pauseUI.transform.LookAt(cam.transform.position + (cam.transform.forward * 1000.0f));


            }
        }
        else 
        {
            if (once == false)
            {
                once = true;
                leftControler.GetComponent<Pointer>().enabled = false;
                leftControler.GetComponent<LineRenderer>().enabled = false;

                rightControler.GetComponent<Pointer>().enabled = false;
                rightControler.GetComponent<LineRenderer>().enabled = false;

                pauseUI.SetActive(false);

            }
        }
    }


}
