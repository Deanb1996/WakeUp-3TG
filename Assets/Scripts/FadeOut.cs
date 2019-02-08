using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    public float fadeSpeed;
    private int drawDepth = -1000;
    private float alpha = 0;
    private int fadeDirection = 1; // -1 in and 1 out
    private bool fadeBool;

    private void OnGUI()
    {
        if (fadeBool)
        {

            alpha += fadeDirection * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
    }


    public float BeginFade()
    {
        fadeBool = true;
        return (fadeSpeed);
    }
}
