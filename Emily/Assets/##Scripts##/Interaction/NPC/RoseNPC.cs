using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 수사반장
///
/// 특정한 증거 개수를 모았을 때 선택 씬으로 이동 시킨다
/// </summary>
public class RoseNPC : WorldNpc
{
    public int EvidenceCount = 4;

    /// <summary>
    /// 씬으로 이동하기 전에 진행될 대화
    /// </summary>
    public StoryScriptableObject storyForSelectScene;

    public override void Interact()
    {
        if (InventoryManager.instance.Items.Count < EvidenceCount)
        {
            if (story && !UIManager.instance.IsStoryShowing)
            {
                UIManager.instance.ShowStory(story);
            }
        }
        else
        {
            if (storyForSelectScene) {
                UIManager.instance.ShowStory(storyForSelectScene, () => SceneManagerEx.instance.LoadScene(SceneType.LastChoose));
            }
        }
    }
}
