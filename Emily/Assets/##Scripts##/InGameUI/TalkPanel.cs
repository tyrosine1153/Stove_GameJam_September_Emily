using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    public Text txtSpeaker;

    public Text txtContent;

    public Button btnNext;

    public void Awake()
    {
        StoryManager.instance.SetUI(this);
        gameObject.SetActive(false);
    }

    public void ShowNextText()
    {
        StoryManager.instance.ShowNextText();
    }
}
