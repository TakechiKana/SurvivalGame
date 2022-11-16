using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBookButton : MonoBehaviour
{
    [SerializeField]
    public Item item;       //クラフトアイテム
    [SerializeField]
    public Item[] useItem;   //クラフト素材
    [SerializeField]
    public int[] useItemNum; //クラフト素材の数
    //クラフト用辞書
    private Dictionary<Item, int> numOfCraftItem = new Dictionary<Item, int>();
    GameObject playerInventory; //インベントリ
    [SerializeField]
    GameObject errorImage;      //エラー画像
    [SerializeField]
    GameObject craftImage;      //作成ボタン

    GameObject errorText;

    float timeLimit = 3.0f;

    private void Start()
    {
        for (int i = 0; i < useItem.Length; i++)
        {
            //クラフトアイテムと使用数を辞書化
            numOfCraftItem.Add(useItem[i], useItemNum[i]);
        }
        //プレイヤーインベントリを取得
        playerInventory = GameObject.Find("PlayerInventory");
        //エラー画像のテキスト取得
        errorText = errorImage.transform.GetChild(0).gameObject;
    }
    // ボタンが押された瞬間に呼ばれる
    public void ButtonPush()
    {
        if(HaveThisItem())
        {
            errorImage.SetActive(true);
            errorText.GetComponent<Text>().text = ("クラフト済です！");
            return;
        }
        if(IsAbleToCraft())
        {
            //エラーが出ていたら
            if(errorImage.activeSelf)
            {
                //非表示
                errorImage.SetActive(false);
            }
            //クラフトボタンが出たままなら
            if(craftImage.activeSelf)
            {
                //非表示
                craftImage.SetActive(false);
                return;
            }
            //クラフトボタン表示
            craftImage.SetActive(true);
        }
        else
        {
            if(craftImage.activeSelf)
            {
                craftImage.SetActive(false);
            }
            errorText.GetComponent<Text>().text = ("素材が足りません！");
            errorImage.SetActive(true);
        }
    }
    void Update()
    {
        IsAbleToCraft();
        ImageControll();
    }
    private bool HaveThisItem()
    {
        if(item.GetKindOfItem() == Item.KindOfItem.Tools)
        {
            if (playerInventory.GetComponent<PlayerInventoryManager>().GetHavingItem().ContainsKey(item))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private void ImageControll()
    {
        if(IsAbleToCraft()==false 
            && craftImage.activeSelf ==true)
        {
            craftImage.SetActive(false);
        }
        if(errorImage.activeSelf)
        {
            timeLimit -= Time.deltaTime;
            if (timeLimit <= 0.0f)
            {
                timeLimit = 5.0f;
                errorImage.SetActive(false);
            }
        }
    }

    private bool IsAbleToCraft()
    {
        for(int i = 0; i < useItem.Length;i++)
        {
            //素材を持っていなかったら
            if(!playerInventory.GetComponent<PlayerInventoryManager>().GetHavingItem().ContainsKey(useItem[i]))
            {
                return false;
            }
            //素材は持っているが、数が足りてなかったら
            if (numOfCraftItem[useItem[i]] 
                > playerInventory.GetComponent<PlayerInventoryManager>().GetNumOfItem(useItem[i]))
            {
                return false;
            }

        }
       return true;
    }
}
