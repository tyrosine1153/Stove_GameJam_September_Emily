using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager> {
    [SerializeField]
    private StoryScriptableObject currentStory;

    [SerializeField]
    private int currentTextIndex = 0;

    [SerializeField]
    private GameObject objTalkPanel = null;

    [SerializeField] 
    private Image img = null;

    [SerializeField]
    private Text txtSpeaker = null;

    [SerializeField]
    private Text txtContent = null;

    [SerializeField]
    private Button btnNext = null;

    /// <summary>
    /// 주어진 panel을 현재 활성화된 panel로 설정한다
    /// </summary>
    public void SetUI(StoryPanel panel)
    {
        objTalkPanel = panel.gameObject;

        img = panel.img;
        txtSpeaker = panel.txtSpeaker;
        txtContent = panel.txtContent;
        btnNext = panel.btnNext;
    }

    public void ShowStory(StoryScriptableObject story)
    {
        currentStory = story;
        currentTextIndex = 0;

        ShowCurrentStoryText();
    }

    /// <summary>
    /// 다음 텍스트를 출력한다
    /// </summary>
    /// <param name="disableIfDone">텍스트가 끝났을 때 TalkPanel을 비활성화 할지 여부</param>
    public void ShowNextText(bool disableIfDone = true)
    {
        if (currentStory.Texts.Length <= currentTextIndex + 1)
        {
            if (disableIfDone)
            {
                objTalkPanel.SetActive(false);
            }

            return;
        }

        currentTextIndex += 1;
        ShowCurrentStoryText();
    }

    private StoryScriptableObject.Text GetCurrentText()
    {
        return currentStory.Texts[currentTextIndex];
    }

    private void ShowCurrentStoryText()
    {
        if (!objTalkPanel.activeSelf)
        {
            objTalkPanel.SetActive(true);
        }

        var text = GetCurrentText();
        txtSpeaker.text = text.Speaker;
        txtContent.text = text.Content;

        if (img.sprite != text.Image)
        {
            img.sprite = text.Image;
            if (img.sprite == null && img.gameObject.activeSelf)
            {
                img.gameObject.SetActive(false);
            } 
            else if (img.sprite != null && !img.gameObject.activeSelf)
            {
                img.gameObject.SetActive(true);
            }
        }
    }
}
