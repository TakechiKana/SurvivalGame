using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick_Move : MonoBehaviour
{
    [SerializeField]
    public GameObject joyStick;     //スティック格納
    private RectTransform joyStickRectTransform;    //ジョイスティックキャンバスのポジション
    [SerializeField]
    public GameObject joyStick_bg;  //ジョイスティック背景
    public int stickRange = 3;      //スティックが動ける範囲
    private int stickMovement = 0;  //実際に動く値

    public static float joyStickPosX;
    public static float joyStickPosY;

    private void Start()
    {
        //初期設定
        Init();
    }

    //初期設定
    private void Init()
    {
        //端末のサイズに合わせた挙動にさせる
        stickMovement = stickRange * (Screen.width + Screen.height) / 100;
        joyStickRectTransform = joyStick.GetComponent<RectTransform>();
        //ジョイスティックの非表示
        JoyStickDisPlay(false);
    }

    //ジョイスティックの表示
    private void JoyStickDisPlay(bool x)
    {
        joyStick_bg.SetActive(x);
        joyStick.SetActive(x);
    }

    //ジョイスティックのポジション初期化
    public void JoyStickPosInit()
    {
        joyStickRectTransform.anchoredPosition = Vector2.zero;
        joyStickPosX = 0.0f;
        joyStickPosY = 0.0f;
    }

    //ジョイスティックの動き
    public void Move(BaseEventData data)
    {
        PointerEventData pointer = data as PointerEventData;

        //ジョイスティックと入力位置の差
        float x = joyStick_bg.transform.position.x - pointer.position.x;
        float y = joyStick_bg.transform.position.y - pointer.position.y;
        //ジョイスティックの円の動き
        float angle = Mathf.Atan2(y, x);
        //動く余裕があるか
        if (Vector2.Distance(joyStick_bg.transform.position, pointer.position) > stickMovement)
        {
            y = stickMovement * Mathf.Sin(angle);
            x = stickMovement * Mathf.Cos(angle);
        }

        joyStickPosX = -x / stickMovement;
        joyStickPosY = -y / stickMovement;

        joyStick.transform.position = new Vector2(joyStick_bg.transform.position.x - x, joyStick_bg.transform.position.y - y);

    }

    //入力中
    public void PointDown(BaseEventData data)
    {
        PointerEventData pointer = data as PointerEventData;
        //ジョイスティック表示
        JoyStickDisPlay(true);
        //ジョイスティック背景をタッチした座標に表示
        joyStick_bg.transform.position = pointer.position;
    }

    //指を離した瞬間
    public void PointerUp(BaseEventData data)
    {
        //ジョイスティック座標初期化
        JoyStickPosInit();
        //ジョイスティック非表示
        JoyStickDisPlay(false);
    }
}

