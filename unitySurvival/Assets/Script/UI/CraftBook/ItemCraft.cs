using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    GameObject playerInventory; //インベントリ
    private GameObject parent;  //親オブジェクト
    private Item item;          //アイテム
    // Start is called before the first frame update
    void Start()
    {
        //インベントリ取得
        playerInventory = GameObject.Find("PlayerInventory");
        //親オブジェクト取得
        parent = transform.parent.gameObject;
        //親オブジェクトのアイテムデータ取得
        item = parent.GetComponent<CraftBookButton>().item;
    }
    public void PushCraftButton()
    {
        //インベントリに追加
        playerInventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, 1);
        this.gameObject.SetActive(false);
    }
}
