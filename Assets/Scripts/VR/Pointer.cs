using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Pointer : MonoBehaviour
{
    public SteamVR_Action_Boolean m_PinchAction = null;
    public LayerMask uiLayer;

    private SteamVR_Behaviour_Pose m_pose = null;


    void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, uiLayer))
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, hit.point);

            if (hit.collider.gameObject.GetComponent<UIButton>())
            {
                if (m_PinchAction.GetState(m_pose.inputSource))
                {
                    hit.collider.gameObject.GetComponent<UIButton>().hovering = true;
                }

                if (m_PinchAction.GetStateUp(m_pose.inputSource))
                {
                    hit.collider.gameObject.GetComponent<UIButton>().boop();

                }
            }
        }
    }
}
