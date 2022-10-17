using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="CreateItem")]
public class Item : ScriptableObject
{
    public enum KindOfItem
    {
        Materials,
        Tools,
        Foods,
        Drinks
    }
    public enum ItemCodeName
    {
        wood,
        stone,
        metal,
        grass,
        plastic,
        fiber,
        cup,
        hammmer,
        fishingRod,
        waterFilter,
        fire,
        electronicParts,
        apple,
        water,
        seawater,
        fish,
        grilledFish
    }
    //アイテムの種類
    [SerializeField]
    private KindOfItem kindOfItem = default;
    //アイテムコードネーム
    [SerializeField]
    private ItemCodeName itemCodeName = default;
    //アイテムのアイコン
    [SerializeField]
    private Sprite itemIcon;
    //アイテムの名前
    [SerializeField]
    private string itemName;
    //アイテムの情報
    [SerializeField]
    private string itemInfo;
    //アイテムの数の管理
    Dictionary<ItemCodeName, int> itemQuantity = new Dictionary<ItemCodeName, int>();
    void Start()
    {
        //itemQuantity[itemName] = 0;
    }

    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }
    public Sprite GetIcon()
    {
        return itemIcon;
    }
    public ItemCodeName GetItemCodeName()
    {
        return itemCodeName;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetItemInfo()
    {
        return itemInfo;
    }
    public int GetItemQuantity(ItemCodeName codename)
    {
        return itemQuantity[codename];
    }
    public void SetItemQuantity(ItemCodeName codename,int num)
    {
        itemQuantity[codename] += num;
    }
}
