using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    private GameObject gameObj; //�C���x���g��
    public GameObject createWood;
    private ItemDataBase itemDataBase = default;
    private int woodID = -1;
    private int appleID = -1;

    ~Tree()
    {
        Vector3 pos = this.transform.position;
        Instantiate(createWood, pos,Quaternion.identity);
    }
    void Start()
    {
        gameObj = GameObject.Find("playerInventory");
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            if(itemDataBase.GetItemLists()[i].GetItemName() == "�؍�")
            {
                woodID = i;
            }
            if(itemDataBase.GetItemLists()[i].GetItemName() == "���")
            {
                appleID = i;
            }
            if(appleID!=-1&&woodID!=-1)
            {
                break;
            }
        }
    }

    private void Update()
    { 
    }
}