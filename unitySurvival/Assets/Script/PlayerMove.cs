using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove : MonoBehaviour
{
    private GameObject clickedGameObject;
    private Animator PlayerAnimator;    //�A�j���[�V����
    private Vector3 targetPos;          //�ړ�����ʒu
    private Vector3 velocity;           //�ړ����x
    private float dis;

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
        var c_pos = Input.mousePosition;
        c_pos.z = 10.0f;
        Vector3 c_pos3D = Camera.main.ScreenToWorldPoint(c_pos);
        //Debug.Log(c_pos3D);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("click");
            //targetPos = c_pos3D;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }
            Debug.Log(clickedGameObject.tag);
        }

        Move();
        PlayAnimation();
    }
    //�ړ�����
    private void Move()
    {
        if(clickedGameObject == null)
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
                clickedGameObject = null;
            }
            
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
    }
}
