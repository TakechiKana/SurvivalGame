using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_HandInventory : MonoBehaviour
{
    //�v���C���[�C���x���g��
    private GameObject playerInventory;
    //���g�̃A�C�e��
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
