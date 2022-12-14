using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove: MonoBehaviour
{
    private GameObject clickedGameObject;//クリックした位置にあるゲームオブジェクト
    private Animator PlayerAnimator;    //アニメーション
    private Vector3 targetPos;          //移動する位置
    private Vector3 moveSpeed;           //移動速度
    private float speed = 2.0f;           //移動スピード
    private float dis;
    private bool isMine = false;        //採掘中か
    private bool isMove = false;        //移動中か

    private NavMeshAgent m_agent;      //ナビメッシュエージェント(Player)

    private CharacterController characterController;    //キャラコン

    // Start is called before the first frame update
    void Start()
    {
        //ナビメッシュエージェントのコンポーネントを取得
        m_agent = GetComponent<NavMeshAgent>();
        //アニメーターの取得
        PlayerAnimator = GetComponent<Animator>();

        characterController = GetComponent<CharacterController>();
        targetPos = transform.position;
        moveSpeed = Vector3.zero;
        clickedGameObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mining"))
        {
            return;
        }
        Vector3 moveDir = ((Vector3.forward * JoyStick_Move.joyStickPosY) 
            + (Vector3.right * JoyStick_Move.joyStickPosX)).normalized;
        //座標更新
        moveSpeed = moveDir * speed * Time.deltaTime;
        this.gameObject.transform.position += moveSpeed;
        if(moveSpeed != Vector3.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        
        // Touch();
        Move();
        Rotation();
        PlayAnimation();
    }
    void Rotation()
    {
        // 回転
        if (moveSpeed.sqrMagnitude > 0.0f)
        {
            isMove = true;
            transform.rotation = Quaternion.LookRotation(moveSpeed.normalized);
        }
        else
        {
            isMove = false;
        }
    }
    //private void Touch()
    //{
        
    //    /*if(EventSystem.current.IsPointerOverGameObject())
    //    {
    //        return;
    //    }*/
    //    if (Application.isEditor)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit hit = new RaycastHit();

    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                clickedGameObject = hit.collider.gameObject;
    //                targetPos = hit.point;
    //            }
    //            Debug.Log(clickedGameObject.tag);
    //        }
    //    }
    //    else
    //    {
    //        if (Input.touchCount > 0)
    //        {
    //            // タッチ情報の取得
    //            Touch touch = Input.GetTouch(0);

    //            if (touch.phase == TouchPhase.Began)
    //            {
    //                Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //                RaycastHit hit = new RaycastHit();
    //                if (Physics.Raycast(ray, out hit))
    //                {
    //                    clickedGameObject = hit.collider.gameObject;
    //                    targetPos = hit.point;
    //                }
    //                Debug.Log(clickedGameObject.tag);
    //            }
    //        }
    //    }


    //}

    //ジョイスティック移動
    private void Move()
    {
        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mining"))
        {
            return;
        }
        Vector3 moveDir = ((Vector3.forward * JoyStick_Move.joyStickPosY)
            + (Vector3.right * JoyStick_Move.joyStickPosX)).normalized;
        //座標更新
        moveSpeed = moveDir * speed * Time.deltaTime;
        this.gameObject.transform.position += moveSpeed;
        if (moveSpeed != Vector3.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    //素材採取時の回転
    public void SetRotationToTarget(Vector3 pos)
    {
        var dir = pos - this.transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    //移動処理
    private void TouchMove()
    {
        if(clickedGameObject == null)
        {
            return;
        }
        if(isMine  == true)
        {
            return;
        }
        if (clickedGameObject.tag == "Materials")
        {
            m_agent.isStopped = false;
            m_agent.SetDestination(clickedGameObject.transform.position);
            dis = (clickedGameObject.transform.position - m_agent.transform.position).sqrMagnitude;
            if(dis <= 5.0f)
            {
                m_agent.isStopped = true;
                isMine = true;
            }
            
        }
        else if(clickedGameObject.tag == "Ground")
        {
            m_agent.isStopped = false;
            m_agent.SetDestination(targetPos);
        }
        else
        {
            return;
        }
        
    }
    //アニメーション
    private void PlayAnimation()
    {
        PlayerAnimator.SetBool("isMoving",isMove);
        //ステート名がMinigで、ループ回数が2より上の時
        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("MinningState"))
        {
            if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2)
            {
                if (isMine) 
                { 
                clickedGameObject.GetComponent<rawMaterials>().SetItemInInventory();
                }
                PlayerAnimator.SetBool("isMining", false);
                isMine = false;
            }
        }
    }

    public void SetIsMinig()
    {
        PlayerAnimator.SetBool("isMining", true);
        isMine = true;
    }
    public void SetClickGameObject(GameObject gameObj)
    {
        clickedGameObject = gameObj;
    }
}
