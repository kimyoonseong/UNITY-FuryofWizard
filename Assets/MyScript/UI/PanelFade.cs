using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelFade : MonoBehaviour
{
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
    }


    public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)//알파값이 1이 될때까지
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));//2초동안 생기게
            yield return null;
        }
        //StartCoroutine(FadeTextToZero());
    }

    //public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    //{
    //    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //    while (text.color.a > 0.0f)//알파값이 0이 될때까지
    //    {
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
    //        yield return null;
    //    }
    //}
}
