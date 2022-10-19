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
    public enum ItemID
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
        campFire,
        electronicParts,
        apple,
        water,
        seawater,
        fish,
        grilledFish
    }
    //�A�C�e���̎��
    [SerializeField]
    private KindOfItem kindOfItem = default;
    //�A�C�e���̃A�C�R��
    [SerializeField]
    private Sprite itemIcon;
    //�A�C�e���̖��O
    [SerializeField]
    private string itemName;
    //�A�C�e���̏��
    [SerializeField]
    private string itemInfo;
    //�A�C�e���̌���
    [SerializeField]
    private string itemEffect;
    //�A�C�e���̌���
    [SerializeField]
    private ItemID itemID;
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
    public ItemID GetItemID()
    {
        return itemID;
    }
}
