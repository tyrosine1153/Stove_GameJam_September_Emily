using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : Singleton<InventoryManager>
{
    public UnityEvent<Item> ItemAdded = new UnityEvent<Item>();

    public List<Item> Items { get { return items; } }
    private List<Item> items;

    public void AddItem(Item item)
    {
        if (items.Contains(item))
        {
            return;
        }

        items.Add(item);
        ItemAdded.Invoke(item);
    }

    protected override void OnAwake()
    {
        base.OnAwake();

        items = new List<Item>();
    }
}
