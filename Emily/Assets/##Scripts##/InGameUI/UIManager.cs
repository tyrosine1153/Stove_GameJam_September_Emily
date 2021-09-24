using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoryManager))]
public class UIManager : Singleton<UIManager>
{
    private StoryManager storyManager;

    public void ShowStory(StoryScriptableObject story)
    {
        storyManager.ShowStory(story);
    }

    public void ShowNextText(bool disableIfDone = true)
    {
        storyManager.ShowNextText(disableIfDone);
    }

    public void SetUI(StoryPanel panel)
    {
        storyManager.SetUI(panel);
    }

    protected override void OnAwake()
    {
        storyManager = GetComponent<StoryManager>();
    }
}
