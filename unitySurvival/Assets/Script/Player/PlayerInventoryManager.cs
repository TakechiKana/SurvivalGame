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
		for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		{
			//　アイテム数初期化
			numOfItem.Add(itemDataBase.GetItemLists()[i], 0);
		}
	}

	public void SetNumOfItem(Item item,int num)
    {
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

	//　名前でアイテムを取得
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
}
