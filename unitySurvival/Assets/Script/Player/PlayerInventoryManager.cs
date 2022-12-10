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
	//最初にハンマーをセットする
	public Item hammer;


	// Use this for initialization
	void Start()
	{
		numOfItem.Add(hammer, 1);
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
	public bool IsHavingItem(Item item)
	{
		if (numOfItem.ContainsKey(item))
		{
			return true;
		}
		return false;
	}

	public void SearchHaveItem(Item item)
    {
		//取得したアイテムがインベントリにあるか検索する。
		if(IsHavingItem(item))
        {
			return;
        }
		numOfItem.Add(item, 0);
    }
}
