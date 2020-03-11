﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCodeController : MonoBehaviour
{
    public UnityEvent correctCodeResult;
    public UnityEvent inncorrectCodeResult;
    public List<string> codes = new List<string>();
    public bool locked = true;
    public bool hasSumbitButton = false;

    public string currentInput = "";

    public void inputCharacter(int input)
    {
        inputCharacter(input.ToString());
    }

    public void inputCharacter(string input)
    {
        if (locked)
        {
            //Add input
            currentInput += input;
        }

        //If we are at length of input check input
        if (!hasSumbitButton)
        {
            if (currentInput.Length >= 4)
            {
                submitInput();
            }
        }
    }


    public void clearInput()
    {
        currentInput = "";
    }

    public void submitInput()
    {
        if (locked)
        {
            

            if (currentInput.Length >= 4)
            {
                //correct code
                if (currentInput == code)
                {
                    locked = false;
                    correctCodeResult.Invoke();
                }
                //incorrect code
                else
                {
                    inncorrectCodeResult.Invoke();
                    clearInput();
                }
            }
            else
            {
                inncorrectCodeResult.Invoke();
                clearInput();
            }
        }
    }


}
