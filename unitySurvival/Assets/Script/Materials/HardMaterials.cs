using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMaterials : MonoBehaviour
{
    public GameObject playerObj;        //�v���C���[
    public GameObject miningButton;     //�̌@�\�G�t�F�N�g
    public GameObject inventory;        //�C���x���g��
    private int num = 0;     //�h���b�v��
    [SerializeField]
    public int minRange;     //�����̍ŏ��l
    [SerializeField]
    public int maxRange;     //�����̍ő�l
    [SerializeField]
    public Item item;       //�C���x���g���Ɋi�[����A�C�e��

    bool isAbleToMinig = false;     //�̌@�\��
    float timer = 0.0f;             //�̌@�{�^���̔�\������

    private Vector3 effectPos = Vector3.zero;

    private void Start()
    {
        //�C���x���g���I�u�W�F�N�g�̌���
        inventory = GameObject.Find("PlayerInventory");
        //�v���C���[
        playerObj = GameObject.Find("Player");
        //�̌@�{�^��
        miningButton = GameObject.Find("EffectCanvas").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        //�̌@�o����悤�ɂ���
        MiningProcess();
        //Debug.Log(timer);
        //��\���^�C�}�[�̒l��0���傫��������
        if (timer > 0.0f)
        {
            //0�ɂȂ�܂Ŕ�\��
            miningButton.SetActive(false);
            //�^�C�}�[
            timer -= Time.deltaTime;
        }
        //�^�C�}�[��0�ɂȂ�����
        if (timer <= 0.0f)
        {
            //0���
            timer = 0.0f;
        }
    }
    //�̎揈��
    private void MiningProcess()
    {
        if (!isAbleToMinig)
        {
            //UI��\��
            miningButton.SetActive(false);
            return;
        }
        //�}�e���A���I�u�W�F�N�g�ݒ�
        miningButton.GetComponent<MiningButton>().SetMaterialObject(this.gameObject);
        //UI�\��
        miningButton.SetActive(true);

        Debug.Log(miningButton.activeSelf);
    }

    public void SetTimerNum()
    {
        //�^�C�}�[��7s�ɐݒ�
        timer = 7.0f;
    }

    //�̎�\��
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
        //�A�C�e���̃h���b�v���̐ݒ�
        num = Random.Range(minRange, maxRange);
        //�h���b�v�A�C�e���̊i�[
        inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, num);
    }

}
