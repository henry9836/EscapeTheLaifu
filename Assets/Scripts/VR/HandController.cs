﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandController : MonoBehaviour
{
    public Collider nonTriggerCollider = null;
    public SteamVR_Action_Boolean m_GrabAction = null;
    public SteamVR_Action_Boolean m_PinchAction = null;
    public SteamVR_Behaviour_Pose m_pose = null;
    private FixedJoint m_joint = null;

    private InteractableController currentHeldObject = null;
    public List<InteractableController> m_ContactInteractable = new List<InteractableController>();

    void Drop()
    {
        //Null
        if (!currentHeldObject)
        {
            return;
        }

        StartCoroutine(ToggleHandCol());

        //Velocity
        Rigidbody targetBody = currentHeldObject.GetComponent<Rigidbody>();
        targetBody.velocity = m_pose.GetVelocity();
        targetBody.angularVelocity = m_pose.GetAngularVelocity();

        //Detach
        m_joint.connectedBody = null;

        //Reset

        currentHeldObject.parentHand = null;
        currentHeldObject.tmpPose = null;
        currentHeldObject = null;

    }

    void Pickup()
    {
        //Find nearest
        currentHeldObject = GetNearestInteractable();

        //null
        if (!currentHeldObject)
        {
            return;
        }

        StartCoroutine(ToggleHandCol());

        //already held
        if (currentHeldObject.parentHand)
        {
            currentHeldObject.parentHand.Drop();
        }

        //pos
        //currentHeldObject.transform.position = transform.position;

        //attach
        Rigidbody targetBody = currentHeldObject.GetComponent<Rigidbody>();
        m_joint.connectedBody = targetBody;

        //set active hand
        currentHeldObject.parentHand = this;
        currentHeldObject.tmpPose = m_pose;
    }

    InteractableController GetNearestInteractable()
    {
        InteractableController nearest = null;
        float minDistance = Mathf.Infinity;
        float tmpDistance = 0.0f;

        foreach (InteractableController i in m_ContactInteractable)
        {
            if (Vector3.Distance(i.transform.position, transform.position) < minDistance)
            {
                nearest = i;
                minDistance = Vector3.Distance(i.transform.position, transform.position);
            }
        }

        return nearest;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        m_ContactInteractable.Add(other.gameObject.GetComponent<InteractableController>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        m_ContactInteractable.Remove(other.gameObject.GetComponent<InteractableController>());
    }

    void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_joint = GetComponent<FixedJoint>();
    }
    void Update()
    {
        if (m_GrabAction.GetStateDown(m_pose.inputSource))
        {
            Debug.Log($"{m_pose.inputSource} Trigger Down");
            Pickup();
        }

        if (m_GrabAction.GetStateUp(m_pose.inputSource))
        {
            Debug.Log($"{m_pose.inputSource} Trigger Up");
            Drop();
        }
    }

    IEnumerator ToggleHandCol()
    {
        //Delay so no glitch if throwing
        if (!nonTriggerCollider.enabled)
        {
            yield return new WaitForSeconds(0.05f);
        }
        nonTriggerCollider.enabled = !nonTriggerCollider.enabled;

        yield return null;
    }

}
