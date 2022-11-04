using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private GameObject inventory;
    private int woodNum = 1;
    [SerializeField]
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("PlayerInventory");
        woodNum = Random.Range(2, 6);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したとき
        if(other.CompareTag("Player"))
        {
            //木の数を増やす
            inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, woodNum);
            //自身を削除
            Destroy(this.gameObject);
        }
    }
}
