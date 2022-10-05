using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private GameObject player;        //プレイヤー
    private Vector3 offset;

    void Start()
    {
        //プレイヤーの検索
        player = GameObject.FindGameObjectWithTag("Player");
        //カメラからプレイヤーまでの距離
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(player.transform);
        //カメラからプレイヤーまでの距離を保って移動する
        this.transform.position = player.transform.position + offset;
    }
    private void Rotation()
    {
        ////マウスを押した瞬間
        //if(Input.GetMouseButtonDown(0))
        //{
        //    newAngle = this.transform.localEulerAngles;
        //}
    }
}
