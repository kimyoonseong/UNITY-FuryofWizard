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


    public IEnumerator FadeTextToFullAlpha() // ���İ� 0���� 1�� ��ȯ
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)//���İ��� 1�� �ɶ�����
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));//2�ʵ��� �����
            yield return null;
        }
        //StartCoroutine(FadeTextToZero());
    }

    //public IEnumerator FadeTextToZero()  // ���İ� 1���� 0���� ��ȯ
    //{
    //    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //    while (text.color.a > 0.0f)//���İ��� 0�� �ɶ�����
    //    {
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
    //        yield return null;
    //    }
    //}
}
