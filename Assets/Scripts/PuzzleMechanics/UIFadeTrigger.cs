using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeTrigger : MonoBehaviour
{
    public Image spriteA;
    public Image spriteB;
    public float fadeTime = 1.0f;
    public bool testTrigger = false;

    private Color spriteAvisibleColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private Color spriteAinvisibleColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    private Color spriteBvisibleColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private Color spriteBinvisibleColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    private bool spriteBActive = false;
    private float fadeTimer = 0.0f;

    private void Start()
    {
        spriteAvisibleColor = spriteA.color;
        spriteAinvisibleColor = spriteAvisibleColor * spriteAinvisibleColor;

        spriteBvisibleColor = spriteB.color;
        spriteBinvisibleColor = spriteBvisibleColor * spriteBinvisibleColor;

        //spriteB.color = spriteBinvisibleColor;

        fadeTimer = fadeTime;
    }

    public void TriggerFade()
    {
        spriteBActive = !spriteBActive;
        fadeTimer = 0.0f;
    }

    public void Update()
    {

        if (testTrigger)
        {
            TriggerFade();
            testTrigger = false;
        }

        fadeTimer += Time.deltaTime;

        if (spriteBActive)
        {
            spriteB.color = Color.Lerp(spriteBinvisibleColor, spriteBvisibleColor, (fadeTimer / fadeTime));
            spriteA.color = Color.Lerp(spriteAvisibleColor, spriteAinvisibleColor, (fadeTimer / fadeTime));
        }
        else
        {
            spriteA.color = Color.Lerp(spriteAinvisibleColor, spriteAvisibleColor, (fadeTimer / fadeTime));
            spriteB.color = Color.Lerp(spriteBvisibleColor, spriteBinvisibleColor, (fadeTimer / fadeTime));
        }

    }



}
