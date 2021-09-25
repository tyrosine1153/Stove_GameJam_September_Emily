using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologEndingStory : MonoBehaviour
{
    public int StoryType;

    [SerializeField] private StoryScriptableObject story;
    private void Start()
    {
        UIManager.instance.ShowStory(story);
    }

    public void PrologEnd()
    {
        SceneManagerEx.instance.LoadScene(SceneType.LivingRoom);
    }

    public void EndingEnd()
    {
        SceneManagerEx.instance.LoadScene(SceneType.Opening);
    }
}
