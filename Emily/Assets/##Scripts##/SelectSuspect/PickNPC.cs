using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNPC : WorldNpc
{
    public StoryScriptableObject storyForSelectScene;

    public SelectSuspect selS;
    public override void Interact()
    {
        
        if (storyForSelectScene) {
            if(selS.isEnd)
            {
                UIManager.instance.ShowStory(storyForSelectScene, () => SceneManagerEx.instance.LoadScene(SceneType.Ending));
            }
            else
            {
                UIManager.instance.ShowStory(storyForSelectScene, () => SetFalse());
            }
        }
        
    }

    void SetFalse()
    {
        selS.isSelect = false;
    }
}