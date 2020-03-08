using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVObject : MonoBehaviour
{
    public Vector2 glowRange = new Vector2(0.0f, 20000.0f);
    public float exposeTime = 1.0f;
    public float exposeTimer = 0.0f;
    public bool inUVLight = false;
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
            if (exposeTimer > exposeTime)
            {
                exposeTimer = exposeTime;
            }
        }

        //If not in UVLight count down timer
        else
        {
            exposeTimer -= Time.deltaTime;
            if (exposeTimer < 0.0f)
            {
                exposeTimer = 0.0f;
            }
        }

        //Lerp glow based on timer
        float glowAmount = Mathf.Lerp(glowRange.x, glowRange.y, (exposeTimer / exposeTime));
        mr.material.SetFloat("Vector1_C091EF9A", glowAmount);

        //Reset inUVLightFlag if object is still in the light then the UV light Component will change bool to true for us
        inUVLight = false;

    }

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("UV");
        mr = GetComponent<MeshRenderer>();
    }

}
