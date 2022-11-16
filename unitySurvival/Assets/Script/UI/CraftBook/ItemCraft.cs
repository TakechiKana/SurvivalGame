using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    GameObject playerInventory; //�C���x���g��
    private GameObject parent;  //�e�I�u�W�F�N�g
    private Item item;          //�A�C�e��
    // Start is called before the first frame update
    void Start()
    {
        //�C���x���g���擾
        playerInventory = GameObject.Find("PlayerInventory");
        //�e�I�u�W�F�N�g�擾
        parent = transform.parent.gameObject;
        //�e�I�u�W�F�N�g�̃A�C�e���f�[�^�擾
        item = parent.GetComponent<CraftBookButton>().item;
    }
    public void PushCraftButton()
    {
        //�C���x���g���ɒǉ�
        playerInventory.GetComponent<PlayerInventoryManager>().SetNumOfItem(item, 1);
        this.gameObject.SetActive(false);
    }
}
