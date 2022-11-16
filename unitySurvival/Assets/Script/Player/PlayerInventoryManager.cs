using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
	//　アイテムデータベース
	[SerializeField]
	private ItemDataBase itemDataBase;
	//　アイテム数管理
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();


	// Use this for initialization
	void Start()
	{
		
	}

	public void SetNumOfItem(Item item,int num)
    {
		SearchHaveItem(item);
    	//カウント
    	numOfItem[item] = numOfItem[item] + num;
		//デバッグ用
		Debug.Log(item.GetItemName());
		Debug.Log(numOfItem[item]);
	}

	public int GetNumOfItem(Item item)
    {
		return numOfItem[item];
	}

	public Dictionary<Item,int> GetHavingItem()
    {
		return numOfItem;
    }

	//　名前でアイテムを取得
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}

	public void SearchHaveItem(Item item)
    {
		//取得したアイテムがインベントリにあるか検索する。
		if(numOfItem.ContainsKey(item))
        {
			return;
        }
		numOfItem.Add(item, 0);
    }
}
