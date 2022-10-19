using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    //private NavMeshAgent m_agent;      //�i�r���b�V���G�[�W�F���g(Player)
    private PlayerInventoryManager playerInventory; //�C���x���g��
    private GameObject player;
    private PlayerBasic playerBasic;

    private int rand = 0;           //�؍ނ̓��萔
    private int rand1 = 0;          //��񂲓���m��
//private bool isFlag = false;

    void Start()
    {
        //�i�r���b�V���G�[�W�F���g�̃R���|�[�l���g���擾
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
        //2�ȏ�6�����̖߂�l,�؍ނ̓��萔
        rand = Random.Range(2, 6);
        //1�ȏ�6�����̖߂�l,��񂲂̊m��
        rand1 = Random.Range(1, 6);
        //�C���x���g���ɖ؍ޒǉ�
        playerInventory.SetItemQuantity(Item.ItemID.wood, rand);
        //����rand1��1��������
        if(rand1==1)
        {
            //��񂲂�1�ǉ�
            playerInventory.SetItemQuantity(Item.ItemID.apple, 1);
        }
        //isFlag = false;
    }

}