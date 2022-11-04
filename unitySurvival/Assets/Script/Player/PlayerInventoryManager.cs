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
		for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		{
			//�@�A�C�e����������
			numOfItem.Add(itemDataBase.GetItemLists()[i], 0);
		}
	}

	public void SetNumOfItem(Item item,int num)
    {
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

	//�@���O�ŃA�C�e�����擾
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
}
