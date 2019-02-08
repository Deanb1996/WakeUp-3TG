using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Texture2D fadeInTexture;
    public float fadeSpeed;
    private int drawDepth = -1000;
    private float alpha = 1;
    private int fadeDirection = -1; // -1 in and 1 out

    private void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeInTexture);
    }


    public float BeginFade()
    {
        return (fadeSpeed);
    }
}
