using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVObject : MonoBehaviour
{
    public Vector2 glowRange = new Vector2(0.0f, 20000.0f);
    public float exposeTime = 1.0f;
    private float exposeTimer = 0.0f;
    private static bool inUVLight = false;
    private MeshRenderer mr;
 
    public void invokeLight()
    {
        inUVLight = true;
    }

    private void FixedUpdate()
    {
        //If in light start glow timer
        if (inUVLight)
        {
            exposeTimer += Time.deltaTime;
        }

        //If not in UVLight count down timer
        else
        {
            exposeTimer -= Time.deltaTime;
        }

        //Lerp glow based on timer
        float glowAmount = Mathf.Lerp(glowRange.x, glowRange.y, (exposeTimer / exposeTime));
        mr.material.SetFloat("Vector1_C091EF9A", glowAmount);

    }

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("UV");
        mr = GetComponent<MeshRenderer>();
    }

}
