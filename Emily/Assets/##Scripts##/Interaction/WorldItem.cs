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

    /// <summary>
    /// 해당 아이템의 상호작용 종류
    /// </summary>
    public WorldItemInteractType interactType;

    /// <summary>
    /// 해당 아이템의 아이디
    /// </summary>
    public string itemId;

    /// <summary>
    /// 해당 아이템의 마킹 여부를 반대로 결정하는 플래그
    /// </summary>
    public bool reverseVisibility = false;

    void Start()
    {
        base.Start();

        var item = ItemManager.instance.GetItemById(itemId);
        if (item != null) {
            item.OnMark.AddListener(OnItemMark);
        }

        UpdateVisibility();
    }

    public override void Interact()
    {
        var item = ItemManager.instance.GetItemById(itemId);
        if (item == null)
        {
            return;
        }

        switch (interactType)
        {
            case WorldItemInteractType.Story:
                if (item.Story) {
                    UIManager.instance.ShowStory(item.Story);
                }
                break;

            case WorldItemInteractType.PickUp:
            {
                InventoryManager.instance.AddItem(item);
                if (item.IsMarked)
                {
                    item.ToggleMark();
                }
            }
                break;

            default:
                break;
        }

        UpdateVisibility();
    }

    protected void HideItem()
    {
        var item = ItemManager.instance.GetItemById(itemId);
        if (item != null) {
            item.ToggleMark();
        }
    }

    protected void UpdateVisibility()
    {
        if (itemId != "") {
            var item = ItemManager.instance.GetItemById(itemId);
            var active = item.visibleWhenStart;

            if (item.IsMarked)
            {
                active = !active;
            }

            if (reverseVisibility)
            {
                active = !active;
            }

            gameObject.SetActive(active);
        }
    }

    private void OnItemMark()
    {
        UpdateVisibility();
    }
}
