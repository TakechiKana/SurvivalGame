using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInventory: MonoBehaviour
{
    //����Ɏ����Ă���A�C�e��
    private Item handItem;
    //��Ɏ��A�C�e���̐ؑ�(�ݒ�)
    public void SetHandInItem(Item item)
    {
        handItem = item;
    }
    //��Ɏ����Ă���A�C�e���̎擾
    public Item GetHandInItem()
    {
        return handItem;
    }
}
