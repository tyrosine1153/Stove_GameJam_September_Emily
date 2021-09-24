using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour
{
    public Button btn1;

    void Awake()
    {
        btn1.onClick.AddListener(btn1Click);
    }

    private void btn1Click()
    {
        var item = ItemManager.instance.GetItemById("evidence_1");

        if (item != null)
        {
            InventoryManager.instance.AddItem(item);
        }
    }
}
