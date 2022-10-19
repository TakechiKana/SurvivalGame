using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    public Dictionary<Item.ItemID, int> itemQuantity = new Dictionary<Item.ItemID, int>();
    public void SetItemQuantity(Item.ItemID itemID,int num)
    {
        itemQuantity[itemID] = num;
        Debug.Log(itemQuantity[itemID]);
    }
    public int GetItemQuantity(Item.ItemID itemID)
    {
        return itemQuantity[itemID];
    }
}
