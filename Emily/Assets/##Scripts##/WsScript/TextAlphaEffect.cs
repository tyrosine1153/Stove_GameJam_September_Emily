using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAlphaEffect : MonoBehaviour
{
    [SerializeField] private float addAlphaValue;
    [SerializeField] private Text text;
    Color startColor;
    Color endColor;
    Color temp;

    private void Start()
    {
        startColor = text.color;
        startColor.a = 0;

        endColor = text.color;
        endColor.a = 1;

        StartCoroutine(TextAlphaColorChangeCoroutine());
    }

    IEnumerator TextAlphaColorChangeCoroutine()
    {
        text.color = startColor;
        yield return null;

        while (true)
        {
            while(temp.a + addAlphaValue < 1)
            {
                ChangeTextColor(addAlphaValue);
                yield return null;
            }


            while (temp.a - addAlphaValue > 0)
            {
                ChangeTextColor(-addAlphaValue);
                yield return null;
            }
        }
    }

    private void ChangeTextColor(float addValue)
    {
        temp = text.color;
        temp.a += addValue;
        text.color = temp;
    }
}
