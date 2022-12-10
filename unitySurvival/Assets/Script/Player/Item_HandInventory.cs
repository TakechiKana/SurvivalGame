using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_HandInventory : MonoBehaviour
{
    //プレイヤーインベントリ
    private GameObject playerInventory;
    //自身のアイテム
    public Item item;
    void Start()
    {
        playerInventory = GameObject.Find("PlayerInventory");
    }
    private void Update()
    {
        if(playerInventory.GetComponent<PlayerInventoryManager>().IsHavingItem(item))
        {
            this.GetComponent<Image>().sprite = item.GetIcon();
        }
    }


    public void PushIcon()
    {
        playerInventory.GetComponent<HandInventory>().SetHandInItem(item);
    }
}
