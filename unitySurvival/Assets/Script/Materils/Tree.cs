using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    //private NavMeshAgent m_agent;      //ナビメッシュエージェント(Player)
    private PlayerInventoryManager playerInventory; //インベントリ
    private GameObject player;
    private PlayerBasic playerBasic;

    private int rand = 0;           //木材の入手数
    private int rand1 = 0;          //りんご入手確立
//private bool isFlag = false;

    void Start()
    {
        //ナビメッシュエージェントのコンポーネントを取得
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    { 
        float dis = (this.transform.position - player.transform.position).sqrMagnitude;
        if (dis <= 10.0f)
        {
            if(playerBasic.GetIsMinig())
            {
                SetTreeNum();
            }
        }
    }

    void SetTreeNum()
    {
        //2以上6未満の戻り値,木材の入手数
        rand = Random.Range(2, 6);
        //1以上6未満の戻り値,りんごの確率
        rand1 = Random.Range(1, 6);
        //インベントリに木材追加
        playerInventory.SetItemQuantity(Item.ItemID.wood, rand);
        //もしrand1が1だったら
        if(rand1==1)
        {
            //りんごを1追加
            playerInventory.SetItemQuantity(Item.ItemID.apple, 1);
        }
        //isFlag = false;
    }

}