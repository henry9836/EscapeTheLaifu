using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCodeController : MonoBehaviour
{
    public UnityEvent correctCodeResult;
    public UnityEvent inncorrectCodeResult;
    public string code = "1234";
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
            if (currentInput.Length >= code.Length)
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
        if (!locked)
        {
            if (currentInput.Length >= code.Length)
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
