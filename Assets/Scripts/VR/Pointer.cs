using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Pointer : MonoBehaviour
{
    public SteamVR_Action_Boolean m_PinchAction = null;
    private SteamVR_Behaviour_Pose m_pose = null;


    private LayerMask uiLayer;
    private void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();

    }

    void Start()
    {
        uiLayer = LayerMask.NameToLayer("UI");
    }

    void Update()
    {


        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, uiLayer);

        UIButton button = hit.collider.gameObject.GetComponent<UIButton>();
        if (button)
        {
            button.boop();
        }

        if (m_PinchAction.GetState(m_pose.inputSource))
        {
            button.hovering = true;
        }

        if (m_PinchAction.GetStateUp(m_pose.inputSource))
        {
            SceneManager.LoadScene(1);
        }

    }
}
