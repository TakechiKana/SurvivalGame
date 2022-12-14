using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum KindOfItem
    {
        Materials,
        Tools,
        Foods,
        Drinks
    }
    //アイテムの種類
    [SerializeField]
    private KindOfItem kindOfItem = default;
    //アイテムのアイコン
    [SerializeField]
    private Sprite itemIcon;
    //アイテムの名前
    [SerializeField]
    private string itemName;
    //アイテムの情報
    [SerializeField]
    private string itemInfo;
    //アイテムの効果
    [SerializeField]
    private string itemEffect;
    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }
    public Sprite GetIcon()
    {
        return itemIcon;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetItemInfo()
    {
        return itemInfo;
    }
    public string GetItemEffect()
    {
        return itemEffect;
    }
}
