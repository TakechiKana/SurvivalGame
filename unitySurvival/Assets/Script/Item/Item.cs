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
