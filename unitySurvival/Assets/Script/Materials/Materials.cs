using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials: MonoBehaviour
{
    private GameObject inventory;
    private int num;     //ドロップ数
    [SerializeField]
    public int minRange;     //乱数の最小値
    [SerializeField]
    public int maxRange;     //乱数の最大値
    [SerializeField]
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("PlayerInventory");
        num = Random.Range(minRange, maxRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したとき
        if(other.CompareTag("Player"))
        {
            //木の数を増やす
            inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, num);
            //自身を削除
            Destroy(this.gameObject);
        }
    }
}
