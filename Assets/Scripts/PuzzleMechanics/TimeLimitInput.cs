using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeLimitInput : MonoBehaviour
{
    private bool locked = true;
    private bool keyOneActive = false;
    private bool keyTwoActive = false;
    private float holdActiveTimer = 0.0f;

    public UnityEvent resultActions;
    public UnityEvent resetActions;
    public float holdActiveTime = 2.0f;
    

    public void InsertKey(bool isKeyTwo)
    {
        if (isKeyTwo)
        {
            keyTwoActive = true;
        }
        else 
        {
            keyOneActive = true;    
        }
    }

    public void RemoveKey(bool isKeyTwo)
    {
        if (isKeyTwo)
        {
            keyTwoActive = false;
        }
        else
        {
            keyOneActive = false;
        }
    }

    private void FixedUpdate()
    {
        if (locked) {
            //if (keyOneActive || keyTwoActive)
            //{
            //    holdActiveTimer += Time.deltaTime;
            //}

            //if (holdActiveTimer > holdActiveTime)
            //{
            //    keyTwoActive = false;
            //    keyOneActive = false;
            //    holdActiveTimer = 0.0f;
            //    resetActions.Invoke();
            //}

            //else if (keyOneActive && keyTwoActive)
            //{
            //    resultActions.Invoke();
            //    locked = false;
            //    holdActiveTimer = 0.0f;
            //}

            if (keyOneActive && keyTwoActive)
            {
                resultActions.Invoke();
                locked = false;
                holdActiveTimer = 0.0f;
            }

        }

    }

}
