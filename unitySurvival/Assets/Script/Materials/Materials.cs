using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials: MonoBehaviour
{
    private GameObject inventory;
    private int num;     //�h���b�v��
    [SerializeField]
    public int minRange;     //�����̍ŏ��l
    [SerializeField]
    public int maxRange;     //�����̍ő�l
    [SerializeField]
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("PlayerInventory");
        num = Random.Range(minRange, maxRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�ƐڐG�����Ƃ�
        if(other.CompareTag("Player"))
        {
            //�؂̐��𑝂₷
            inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, num);
            //���g���폜
            Destroy(this.gameObject);
        }
    }
}
