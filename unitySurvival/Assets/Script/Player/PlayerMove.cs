using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove: MonoBehaviour
{
    private GameObject clickedGameObject;//�N���b�N�����ʒu�ɂ���Q�[���I�u�W�F�N�g
    private Animator PlayerAnimator;    //�A�j���[�V����
    private Vector3 targetPos;          //�ړ�����ʒu
    private Vector3 moveSpeed;           //�ړ����x
    private float speed = 2.0f;           //�ړ��X�s�[�h
    private float dis;
    private bool isMine = false;        //�̌@����
    private bool isMove = false;        //�ړ�����

    private NavMeshAgent m_agent;      //�i�r���b�V���G�[�W�F���g(Player)

    private CharacterController characterController;    //�L�����R��

    // Start is called before the first frame update
    void Start()
    {
        //�i�r���b�V���G�[�W�F���g�̃R���|�[�l���g���擾
        m_agent = GetComponent<NavMeshAgent>();
        //�A�j���[�^�[�̎擾
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
        //���W�X�V
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
        // ��]
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
    //            // �^�b�`���̎擾
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

    //�W���C�X�e�B�b�N�ړ�
    private void Move()
    {
        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mining"))
        {
            return;
        }
        Vector3 moveDir = ((Vector3.forward * JoyStick_Move.joyStickPosY)
            + (Vector3.right * JoyStick_Move.joyStickPosX)).normalized;
        //���W�X�V
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

    //�f�ލ̎掞�̉�]
    public void SetRotationToTarget(Vector3 pos)
    {
        var dir = pos - this.transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    //�ړ�����
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
    //�A�j���[�V����
    private void PlayAnimation()
    {
        PlayerAnimator.SetBool("isMoving",isMove);
        //�X�e�[�g����Minig�ŁA���[�v�񐔂�2����̎�
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
