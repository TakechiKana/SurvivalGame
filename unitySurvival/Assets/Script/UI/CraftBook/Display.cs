using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Item item;                      //アイテムデータ
    private GameObject[] childObjects;      //子オブジェクトの配列
    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトの取得
        childObjects = new GameObject[this.transform.childCount];
        //親オブジェクトの取得
        GameObject parentButton = transform.parent.gameObject;
        //アイテムデータの取得
        item = parentButton.GetComponent<CraftBookButton>().item;
        //アイテムが設定されていなかったら
        if (item == null)
        {
            //早期リターン
            return;
        }
        //ディスプレイの子オブジェクトに情報を渡す
        // DisplayProcess();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //アイコン
            if (i==0)
            {
                //画像取得
                childObjects[i].GetComponent<Image>().sprite = item.GetIcon();
            }
            //名前
            else if (childObjects[i].name == "ItemName")
            {
                //名前取得
                childObjects[i].GetComponent<Text>().text = item.GetItemName();
            }
            //アイテム説明
            else if (childObjects[i].name == "ItemInfo")
            {
                //説明取得
                childObjects[i].GetComponent<Text>().text = item.GetItemInfo();
            }
            //アイテム効果
            else if (childObjects[i].name == "ItemEffect")
            {
                //効果取得
                childObjects[i].GetComponent<Text>().text = item.GetItemEffect();
            }
            else
            {
                Debug.Log("null");
            }
        }

    }

    void DisplayProcess()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //アイコン
            if (childObjects[i].name == "CraftItemIcon")
            {
                //画像取得
                childObjects[i].GetComponent<Image>().sprite = item.GetIcon();
            }
            //名前
            else if (childObjects[i].name == "ItemName")
            {
                //名前取得
                childObjects[i].GetComponent<Text>().text = item.GetItemName();
            }
            //アイテム説明
            else if(childObjects[i].name == "ItemInfo")
            {
                //説明取得
                childObjects[i].GetComponent<Text>().text = item.GetItemInfo();
            }
            //アイテム効果
            else if (childObjects[i].name == "ItemEffect")
            {
                //効果取得
                childObjects[i].GetComponent<Text>().text = item.GetItemEffect();
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
}
