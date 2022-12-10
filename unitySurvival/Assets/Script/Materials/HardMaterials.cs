using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMaterials : MonoBehaviour
{
    public GameObject playerObj;        //プレイヤー
    public GameObject miningButton;     //採掘可能エフェクト
    public GameObject inventory;        //インベントリ
    private int num = 0;     //ドロップ数
    [SerializeField]
    public int minRange;     //乱数の最小値
    [SerializeField]
    public int maxRange;     //乱数の最大値
    [SerializeField]
    public Item item;       //インベントリに格納するアイテム

    bool isAbleToMinig = false;     //採掘可能か
    float timer = 0.0f;             //採掘ボタンの非表示時間

    private Vector3 effectPos = Vector3.zero;

    private void Start()
    {
        //インベントリオブジェクトの検索
        inventory = GameObject.Find("PlayerInventory");
        //プレイヤー
        playerObj = GameObject.Find("Player");
        //採掘ボタン
        miningButton = GameObject.Find("EffectCanvas").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        //採掘出来るようにする
        MiningProcess();
        //Debug.Log(timer);
        //非表示タイマーの値が0より大きかったら
        if (timer > 0.0f)
        {
            //0になるまで非表示
            miningButton.SetActive(false);
            //タイマー
            timer -= Time.deltaTime;
        }
        //タイマーが0になったら
        if (timer <= 0.0f)
        {
            //0代入
            timer = 0.0f;
        }
    }
    //採取処理
    private void MiningProcess()
    {
        if (!isAbleToMinig)
        {
            //UI非表示
            miningButton.SetActive(false);
            return;
        }
        //マテリアルオブジェクト設定
        miningButton.GetComponent<MiningButton>().SetMaterialObject(this.gameObject);
        //UI表示
        miningButton.SetActive(true);

        Debug.Log(miningButton.activeSelf);
    }

    public void SetTimerNum()
    {
        //タイマーを7sに設定
        timer = 7.0f;
    }

    //採取可能か
    private void OnTriggerEnter(Collider other)
    {
        isAbleToMinig = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isAbleToMinig = false;
    }

    public void SetItemInInventory()
    {
        //アイテムのドロップ数の設定
        num = Random.Range(minRange, maxRange);
        //ドロップアイテムの格納
        inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, num);
    }

}
