using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private InventorySlot[] Slots;

    // Start is called before the first frame update
    void Start()
    {
        Slots = gameObject.GetComponentsInChildren<InventorySlot>();
        InventoryManager.instance.ItemAdded.AddListener(OnItemAdded);

        foreach (var slot in Slots)
        {
            slot.SetItem(null);
        }
    }

    void OnItemAdded(Item item)
    {
        var items = InventoryManager.instance.Items;
        for (var i = 0; i < items.Count; i++)
        {
            Slots[i].SetItem(items[i]);
        }
    }
}
