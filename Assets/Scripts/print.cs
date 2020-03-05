using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class print : MonoBehaviour
{
    public RenderTexture renderTexture;

    void Update()
    {
        Texture2D tex2d = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        tex2d.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex2d.Apply();
        //this.gameObject.GetComponent<Material>().mainTexture = tex2d;
    }
}
