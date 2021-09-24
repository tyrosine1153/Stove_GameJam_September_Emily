using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : Interactable
{
    public enum WorldItemInteractType
    {
        Story,
        PickUp
    };

    public WorldItemInteractType interactType;
    public string itemId;
    public StoryScriptableObject story;

    public override void Interact()
    {
        switch (interactType)
        {
            case WorldItemInteractType.Story:
                if (story) {
                    UIManager.instance.ShowStory(story);
                }
                break;

            case WorldItemInteractType.PickUp:
            {
                var item = ItemManager.instance.GetItemById(itemId);
                if (item != null)
                {
                    InventoryManager.instance.AddItem(item);
                }
            }
                break;

            default:
                break;
        }
    }
}
