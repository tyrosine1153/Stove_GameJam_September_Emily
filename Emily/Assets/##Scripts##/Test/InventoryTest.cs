using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var item = ItemManager.instance.GetItemById("evidence_1");
            if (item == null)
            {
                return;
            }

            InventoryManager.instance.AddItem(item);
        }
    }
}
