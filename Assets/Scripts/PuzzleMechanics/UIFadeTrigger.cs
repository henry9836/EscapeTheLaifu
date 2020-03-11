using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeTrigger : MonoBehaviour
{
    public List<Image> spriteA = new List<Image>();
    public List<Image> spriteB = new List<Image>();
    public float fadeTime = 1.0f;
    public bool testTrigger = false;

    private Color invisible = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    private List<Color> spriteAvisibleColor = new List<Color>();
    private List<Color> spriteAinvisibleColor = new List<Color>();
    private List<Color> spriteBvisibleColor = new List<Color>();
    private List<Color> spriteBinvisibleColor = new List<Color>();

    private bool spriteBActive = false;
    private float fadeTimer = 0.0f;

    private void Start()
    {

        for (int i = 0; i < spriteA.Count; i++)
        {
            spriteAvisibleColor.Add(spriteA[i].color);
            spriteAinvisibleColor.Add(spriteA[i].color * invisible);
        }

        for (int i = 0; i < spriteB.Count; i++)
        {
            spriteBvisibleColor.Add(spriteB[i].color);
            spriteBinvisibleColor.Add(spriteB[i].color * invisible);
        }

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
            for (int i = 0; i < spriteB.Count; i++)
            {
                spriteB[i].color = Color.Lerp(spriteBinvisibleColor[i], spriteBvisibleColor[i], (fadeTimer / fadeTime));
            }

            for (int i = 0; i < spriteA.Count; i++)
            {
                spriteA[i].color = Color.Lerp(spriteAvisibleColor[i], spriteAinvisibleColor[i], (fadeTimer / fadeTime));
            }
        }
        else
        {
            for (int i = 0; i < spriteB.Count; i++)
            {
                spriteB[i].color = Color.Lerp(spriteBvisibleColor[i], spriteBinvisibleColor[i], (fadeTimer / fadeTime));
            }

            for (int i = 0; i < spriteA.Count; i++)
            {
                spriteA[i].color = Color.Lerp(spriteAinvisibleColor[i], spriteAvisibleColor[i], (fadeTimer / fadeTime));
            }
        }

    }



}
