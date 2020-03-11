using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class InteractableController : MonoBehaviour
{
    public enum ObjectType
    {
        GENERIC,
        CAMERA_POLROID,
        TORCH,
    }

    public ObjectType type;
    public HandController parentHand;

    public SteamVR_Action_Boolean inputAction = null;
    public SteamVR_Behaviour_Pose tmpPose = null;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
    }

    // Update is called once per frame
    void Update()
    {
        if (parentHand)
        {
            switch (type)
            {
                case ObjectType.GENERIC:
                    {
                        break;
                    }
                case ObjectType.CAMERA_POLROID:
                    {
                        if (inputAction.GetStateDown(tmpPose.inputSource))
                        {
                            GetComponent<camera>().pic();    
                        }
                        break;
                    }
                case ObjectType.TORCH:
                    {
                        if (inputAction.GetStateDown(tmpPose.inputSource))
                        {
                            GetComponent<Torch>().toggle();
                        }
                        break;
                    }
                default:
                    {
                        Debug.LogWarning($"No Logic For Interactable Object [{name}]");
                        break;
                    }
            }
        }
    }
}
