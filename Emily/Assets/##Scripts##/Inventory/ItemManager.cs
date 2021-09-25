﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public ItemListScriptableObject[] itemLists;

    private Dictionary<string, Item> items = new Dictionary<string, Item>();

    public Item GetItemById(string id)
    {
        if (!items.ContainsKey(id)) {
            Debug.LogAssertion(string.Format("item id '{0}' is not found", id));
            return null;
        }

        return items[id];
    }

    protected override void OnAwake()
    {
        foreach (var itemList in itemLists)
        {
            foreach (var item in itemList.items)
            {
                if (items.ContainsKey(item.Id))
                {
                    Debug.LogAssertion(string.Format("item id '{0}' is duplicated", item.Id));
                    return;
                }

                items.Add(item.Id, item);
            }
        }
    }
}