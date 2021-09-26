using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ws;

public class WorldNpc : Interactable
{
    public StoryScriptableObject story;

    public override void Interact() {
        if (story && !UIManager.instance.IsStoryShowing) {
            if (IsPlayEffect) {
                SoundManager.instance.PlayEffectSound((int)EffectTypeWhenInteract);
            }

            UIManager.instance.ShowStory(story);
        }
    }
}
