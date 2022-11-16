using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
	//�@�A�C�e���f�[�^�x�[�X
	[SerializeField]
	private ItemDataBase itemDataBase;
	//�@�A�C�e�����Ǘ�
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();


	// Use this for initialization
	void Start()
	{
		
	}

	public void SetNumOfItem(Item item,int num)
    {
		SearchHaveItem(item);
    	//�J�E���g
    	numOfItem[item] = numOfItem[item] + num;
		//�f�o�b�O�p
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

	//�@���O�ŃA�C�e�����擾
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}

	public void SearchHaveItem(Item item)
    {
		//�擾�����A�C�e�����C���x���g���ɂ��邩��������B
		if(numOfItem.ContainsKey(item))
        {
			return;
        }
		numOfItem.Add(item, 0);
    }
}
