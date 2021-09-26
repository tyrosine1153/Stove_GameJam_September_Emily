using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologEndingStory : MonoBehaviour
{
    public enum StoryType
    {
        Prolog,
        Ending
    }
    public StoryType storyType;
    public int endingType;

    [SerializeField] private StoryScriptableObject currentStory;
    [SerializeField] private StoryScriptableObject[] stories;

    private void Start()
    {
        if (storyType == StoryType.Prolog)
        {
            currentStory = stories[0];
        }
        else if (storyType == StoryType.Ending)
        {
            endingType = (int) SceneManagerEx.instance.UserData;
            currentStory = stories[endingType];
        }

        UIManager.instance.ShowStory(currentStory);
    }

    public void PrologEnd()
    {
        SceneManagerEx.instance.LoadScene(SceneType.LivingRoom);
    }

    public void EndingEnd()
    {
        SceneManagerEx.instance.LoadScene(SceneType.Menu);
    }
}
