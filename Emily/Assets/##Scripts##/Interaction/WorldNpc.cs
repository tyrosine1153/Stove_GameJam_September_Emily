using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNpc : Interactable
{
    public StoryScriptableObject story;

    public override void Interact() {
        if (story) {
            UIManager.instance.ShowStory(story);
        }
    }
}
