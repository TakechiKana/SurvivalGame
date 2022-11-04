using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private GameObject inventory;
    private int woodNum = 1;
    [SerializeField]
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("PlayerInventory");
        woodNum = Random.Range(2, 6);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�ƐڐG�����Ƃ�
        if(other.CompareTag("Player"))
        {
            //�؂̐��𑝂₷
            inventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, woodNum);
            //���g���폜
            Destroy(this.gameObject);
        }
    }
}
