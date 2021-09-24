using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private Image imgItem;

    [SerializeField]
    private Button btnItem;

    public void SetItem(Item item)
    {
        this.item = item;
        if (item != null)
        {
            imgItem.sprite = item.Sprite;
            imgItem.color = Color.white;
        }
        else
        {
            imgItem.sprite = null;
            imgItem.color = Color.clear;
        }
    }

    protected void Start()
    {
        if (imgItem == null)
        {
            imgItem = GetComponentInChildren<Image>();
        }

        if (btnItem == null)
        {
            btnItem = GetComponent<Button>();
        }
        btnItem.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (item == null)
        {
            return;
        }

        UIManager.instance.ShowStory(item.Story);
    }
}
