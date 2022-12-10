using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningButton : MonoBehaviour
{
    //プレイヤー
    private GameObject playerObj;
    //採掘可能なオブジェクト
    private GameObject materialObj;
    //タイマー
    private float timer = 0.0f;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    private void Update()
    {
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            return;
        }
        timer -= Time.deltaTime;
        this.gameObject.SetActive(false);
    }

    public void PushButton()
    {
        //採掘中フラグを立てる
        playerObj.GetComponent<PlayerMove>().SetIsMinig();
        //採掘しているゲームオブジェクトを格納する
        playerObj.GetComponent<PlayerMove>().SetClickGameObject(materialObj);
        //採掘可能エフェクトを非表示にするタイマーの設定
        materialObj.GetComponent<rawMaterials>().SetTimerNum();
    }

    public void SetMaterialObject(GameObject gameObject)
    {
        materialObj = gameObject;
    }
}
