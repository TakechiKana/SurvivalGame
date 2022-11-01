using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    //[SerializeField]
    //public Dictionary<Item, int> itemQuantity = new Dictionary<Item, int>();
    private Item item;
    //private ItemDataBase itemDataBase = default;
    
    public int[] itemQuantity = new int[17];
    private void Start()
    {
        for(int i=0;i<17;i++)
        {
            itemQuantity[i] = 0;
        }
    }
    public void SetItemQuantity(int id,int num)
    {
        itemQuantity[id] = num;
    }
    //public void SetItemQuantity(string itemID,int num)
    //{
    //    for(int i = 0;i< itemDataBase.GetItemLists().Count;i++)
    //    {
    //        if (itemDataBase.GetItemLists()[i].GetItemID() == itemID)
    //        {
    //            item = itemDataBase.GetItemLists()[i];
    //            break;
    //        }
    //    }
    //    itemQuantity[item] = num;
    //    Debug.Log(itemQuantity[item]);
    //}
    //public int GetItemQuantity(Item item)
    //{
    //    return itemQuantity[item];
    //}
}
