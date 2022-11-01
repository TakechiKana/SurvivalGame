using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private GameObject inventory;
    private int woodNum = 1;
    private int arrayNum = 0;
    private ItemDataBase itemDataBase = default;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("PlayerInventory");
        woodNum = Random.Range(2, 6);
        int i = 0;
        for (; ; )
        {
            if (itemDataBase.GetItemLists()[i].GetItemName() == ("木材"))
            {
                arrayNum = i;
                break;
            }
            i++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したとき
        if(other.CompareTag("Player"))
        {
            //木の数を増やす
            inventory.GetComponent<PlayerInventoryManager>().SetItemQuantity(arrayNum, woodNum);
            //自身を削除
            Destroy(this.gameObject);
        }
    }
}
