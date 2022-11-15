using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクト取得
        GameObject parent = transform.parent.gameObject;
        //親オブジェクトのアイテムデータ取得
        Item item = parent.GetComponent<CraftBookButton>().item;
        //アイコン画像取得
        this.GetComponent<UnityEngine.UI.Text>().text = item.GetItemInfo();
    }
}
