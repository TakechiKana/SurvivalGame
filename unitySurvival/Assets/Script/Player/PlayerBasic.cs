using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerBasic: MonoBehaviour
{
    private GameObject clickedGameObject;//�N���b�N�����ʒu�ɂ���Q�[���I�u�W�F�N�g
    private Animator PlayerAnimator;    //�A�j���[�V����
    private Vector3 targetPos;          //�ړ�����ʒu
    private Vector3 velocity;           //�ړ����x
    private float dis;
    private bool isMine = false;        //�̌@����

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
        velocity = Vector3.zero;
        clickedGameObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
        Move();
        PlayAnimation();
    }
    private void Touch()
    {
        if(isMine)
        {
            return;
        }
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    clickedGameObject = hit.collider.gameObject;
                    targetPos = hit.point;
                }
                Debug.Log(clickedGameObject.tag);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                // �^�b�`���̎擾
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit))
                    {
                        clickedGameObject = hit.collider.gameObject;
                        targetPos = hit.point;
                    }
                    Debug.Log(clickedGameObject.tag);
                }
            }
        }


    }
    //�ړ�����
    private void Move()
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
        PlayerAnimator.SetFloat("MoveSpeed", m_agent.velocity.sqrMagnitude);
        PlayerAnimator.SetBool("isMining", isMine);
        //Debug.Log(isMine);
        //�X�e�[�g����Minig�ŁA���[�v�񐔂�2����̎�
        if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mining"))
        {
            if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2)
            {
                isMine = false;
                Destroy(clickedGameObject);
                clickedGameObject = null;
            }
        }
    }

    public bool GetIsMinig()
    {
        return isMine;
    }
}
