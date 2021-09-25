using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private StoryScriptableObject currentStory;

    [SerializeField] private int currentTextIndex = 0;

    [SerializeField] private GameObject objTalkPanel = null;

    [SerializeField] private Image img = null;
    [SerializeField] private Text txtSpeaker = null;
    [SerializeField] private Text txtContent = null;
    [SerializeField] private Button btnNext = null;

    [SerializeField] private Image placeImg = null;
    [SerializeField] private Image leftCharacterImg = null;
    [SerializeField] private Image rightCharacterImg = null;

    [SerializeField] private Sprite[] placeSprites;
    [SerializeField] private Sprite[] characterSprites;

    private bool isProlog;
    private bool isEnding;

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

        placeImg = panel.placeImg;
        leftCharacterImg = panel.leftCharacterImg;
        rightCharacterImg = panel.rightCharacterImg;

        placeSprites = panel.placeSprites;
        characterSprites = panel.characterSprites;
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
        }

        if (img.sprite == null && img.gameObject.activeSelf)
        {
            img.gameObject.SetActive(false);
        }
        else if (img.sprite != null && !img.gameObject.activeSelf)
        {
            img.gameObject.SetActive(true);
        }
        
        // 장소
        if (placeImg != null && placeImg.sprite != placeSprites[(int) text.Place])
        {
            placeImg.sprite = placeSprites[(int) text.Place];
        }
        
        // 대사하는 인물
        if (text.LeftCharacter != StoryScriptableObject.Character.None)
        {
            leftCharacterImg.gameObject.SetActive(true);
            leftCharacterImg.sprite = characterSprites[(int)text.LeftCharacter - 1];
        }
        else
        {
            leftCharacterImg.gameObject.SetActive(false);
        }
        
        if (text.RightCharacter != StoryScriptableObject.Character.None)
        {
            rightCharacterImg.gameObject.SetActive(true);
            rightCharacterImg.sprite = characterSprites[(int)text.LeftCharacter - 1];
        }
        else
        {
            rightCharacterImg.gameObject.SetActive(false);
        }
    }
}
