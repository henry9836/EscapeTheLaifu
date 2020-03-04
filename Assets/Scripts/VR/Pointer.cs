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


    public LayerMask uiLayer;
    private void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log($"I hit {hit.collider.gameObject.name}");
            if (hit.collider.gameObject.GetComponent<UIButton>())
            {
                hit.collider.gameObject.GetComponent<UIButton>().boop();

                if (m_PinchAction.GetState(m_pose.inputSource))
                {
                    hit.collider.gameObject.GetComponent<UIButton>().hovering = true;
                }

                if (m_PinchAction.GetStateUp(m_pose.inputSource))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
