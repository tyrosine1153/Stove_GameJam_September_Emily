using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNPC : WorldNpc
{
    public StoryScriptableObject storyForSelectScene;

    public override void Interact()
    {
        
        if (storyForSelectScene) {
                UIManager.instance.ShowStory(storyForSelectScene, () => SceneManagerEx.instance.LoadScene(SceneType.Ending));
        }
        
    }
}