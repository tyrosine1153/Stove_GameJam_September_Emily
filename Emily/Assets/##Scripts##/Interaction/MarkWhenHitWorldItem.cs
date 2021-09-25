using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 다른 아이탬이랑 부딛쳤을 때 타겟 아이템들을 마크한다
/// </summary>
public class MarkWhenHitWorldItem : WorldItem
{
    /// <summary>
    /// 부딛쳤을 때 이벤트를 발생시킬 아이템 아이디
    /// </summary>
    [SerializeField] 
    private string[] itemIdFilter;

    /// <summary>
    /// 부딛쳤을 때 마킹할 아이템 아이디
    /// </summary>
    [SerializeField]
    private string[] targetItemIds;

    /// <summary>
    /// 자기 자신도 마크할지 여부
    /// </summary>
    [SerializeField] 
    private bool markSelf = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var otherItem = collider.GetComponent<WorldItem>();
        if (!itemIdFilter.Contains(otherItem.itemId))
        {
            return;
        }

        foreach (var itemId in targetItemIds)
        {
            var item = ItemManager.instance.GetItemById(itemId);
            if (item != null) 
            {
                item.ToggleMark();
            }
        }

        if (markSelf)
        {
            HideItem();
        }
    }
}
