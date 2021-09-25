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
        // 대충 씬 넘기는 내용
        SceneManager.LoadScene(0);
    }

    public void EndingEnd()
    {
        // 대충 끝내고 메인으로 가는 내용
        SceneManager.LoadScene(0);
    }
}
