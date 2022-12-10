using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInventory: MonoBehaviour
{
    //今手に持っているアイテム
    private Item handItem;
    //手に持つアイテムの切替(設定)
    public void SetHandInItem(Item item)
    {
        handItem = item;
    }
    //手に持っているアイテムの取得
    public Item GetHandInItem()
    {
        return handItem;
    }
}
