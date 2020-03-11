using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeyCodeController : MonoBehaviour
{
    public UnityEvent codeOneEvent;
    public UnityEvent codeTwoEvent;
    public UnityEvent codeThreeEvent;
    public UnityEvent codeFourEvent;
    public UnityEvent correctCodeResult;
    public UnityEvent inncorrectCodeResult;
    public List<string> codes = new List<string>();
    public Text textField;
    public string currentInput = "";

    private bool inputLock = false;


    private void Start()
    {
        clearInput();
    }

    public void inputCharacter(int input)
    {
        inputCharacter(input.ToString());
    }

    public void inputCharacter(string input)
    {
        if (!inputLock)
        {
            //Add input
            currentInput += input;

            textField.text = "";

            //Update Display
            for (int i = 1; i < 5; i++)
            {
                //Do we have a character at position?
                if (currentInput.Length >= i)
                {
                    //Append to textField
                    textField.text += currentInput.Substring(i - 1, 1);
                }
                //Append _
                else
                {
                    textField.text += "_";
                }

                //Append Two Spaces if not on final loop
                if (i <= 3)
                {
                    textField.text += "  ";
                }
            }

            //If we are at length of input check input
            if (currentInput.Length >= 4)
            {
                submitInput();
            }
        }
    }


    public void clearInput()
    {
        currentInput = "";
        textField.text = "_  _  _  _";
    }

    public void submitInput()
    {

        bool foundValidCode = false;

        for (int i = 0; i < codes.Count; i++)
        {
            //correct code
            if (currentInput == codes[i])
            {
                correctCodeResult.Invoke();
                foundValidCode = true;
                switch (i)
                {
                    case 1:
                        {
                            codeOneEvent.Invoke();
                            break;
                        }
                    case 2:
                        {
                            codeTwoEvent.Invoke();
                            break;
                        }
                    case 3:
                        {
                            codeThreeEvent.Invoke();
                            break;
                        }
                    case 4:
                        {
                            codeFourEvent.Invoke();
                            break;
                        }
                    default:
                        {
                            Debug.LogWarning($"No action exists for code element [{i}]");
                            break;
                        }
                }

            }
        }

        if (!foundValidCode)
        {
            //incorrect code
            inncorrectCodeResult.Invoke();
        }

    }

    public void WrongAction()
    {
        StartCoroutine(WrongCor());
    }

    public void ValidAction()
    {
        StartCoroutine(CorrectCor());
    }

    IEnumerator WrongCor()
    {
        inputLock = true;
        for (int i = 0; i < 3; i++)
        {
            textField.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            textField.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        inputLock = false;
        clearInput();
        yield return null;
    }

    IEnumerator CorrectCor()
    {
        inputLock = true;
        textField.color = Color.green;
        yield return new WaitForSeconds(1.2f);
        textField.color = Color.white;
        inputLock = false;
        clearInput();
        yield return null;
    }


}
