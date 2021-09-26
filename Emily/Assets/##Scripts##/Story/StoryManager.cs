using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = System.Random;

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

    private PrologEndingStory prologEndingStory;
    private bool isProlog;
    private bool isEnding;
    private Random random;
    private Action actionAfterStoryDone = null;

    private bool isStoryShowing  = false;

    public bool IsStoryShowing
    {
        get { return isStoryShowing; }
    }

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

        isStoryShowing = false;

        placeImg = panel.placeImg;
        leftCharacterImg = panel.leftCharacterImg;
        rightCharacterImg = panel.rightCharacterImg;

        placeSprites = panel.placeSprites;

        try
        {
            prologEndingStory = GameObject.Find("Prolog/EndingStory").GetComponent<PrologEndingStory>();
            switch (prologEndingStory.storyType)
            {
                // Prolog
                case PrologEndingStory.StoryType.Prolog:
                    isProlog = true;
                    break;
                case PrologEndingStory.StoryType.Ending:
                    isEnding = true;
                    break;
                default:
                    isProlog = isEnding = false;
                    break;
            }
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            isProlog = isEnding = false;
        }
    }

    public void ShowStory(StoryScriptableObject story)
    {
        currentStory = story;
        currentTextIndex = 0;
        actionAfterStoryDone = null;
        isStoryShowing = true;

        ShowCurrentStoryText();
    }

    public void ShowStory(StoryScriptableObject story, Action action) {
        currentStory = story;
        currentTextIndex = 0;
        actionAfterStoryDone = action;
        isStoryShowing = true;

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
                if (isProlog)
                {
                    prologEndingStory.PrologEnd();
                }
                else if (isEnding)
                {
                    prologEndingStory.EndingEnd();
                }
                else
                {
                    if (actionAfterStoryDone != null)
                    {
                        actionAfterStoryDone.Invoke();
                    }
                    objTalkPanel.SetActive(false);
                    isStoryShowing = false;
                }
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

        if (text.Content.Length == 0)
        {
            txtContent.text = "";
        }
        else if (text.Content.Length <= 1)
        {
            txtContent.text = text.Content[0];
        }
        else
        {
            Debug.Log(text.Content.Length);
            var index = random.Next(0, text.Content.Length);
            Debug.Log(index);
            txtContent.text = text.Content[index];
        }

        if (img.sprite != text.Image)
        {
            img.sprite = text.Image;
            img.preserveAspect = true;
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
        if (leftCharacterImg.sprite != text.LeftCharacter)
        {
            leftCharacterImg.sprite = text.LeftCharacter;
        }
        if (leftCharacterImg.sprite == null && leftCharacterImg.gameObject.activeSelf)
        {
            leftCharacterImg.gameObject.SetActive(false);
        }
        else if (leftCharacterImg.sprite != null && !leftCharacterImg.gameObject.activeSelf)
        {
            leftCharacterImg.gameObject.SetActive(true);
        }
        
        if (rightCharacterImg.sprite != text.RightCharacter)
        {
            rightCharacterImg.sprite = text.RightCharacter;
        }
        if (rightCharacterImg.sprite == null && rightCharacterImg.gameObject.activeSelf)
        {
            rightCharacterImg.gameObject.SetActive(false);
        }
        else if (rightCharacterImg.sprite != null && !rightCharacterImg.gameObject.activeSelf)
        {
            rightCharacterImg.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        random = new Random();
    }
}
