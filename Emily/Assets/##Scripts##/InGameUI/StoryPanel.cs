using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPanel : MonoBehaviour
{
    public Image img;

    public Text txtSpeaker;

    public Text txtContent;

    public Button btnNext;

    public void Awake()
    {
        UIManager.instance.SetUI(this);
        gameObject.SetActive(false);
    }

    public void ShowNextText()
    {
        UIManager.instance.ShowNextText();
    }
}
