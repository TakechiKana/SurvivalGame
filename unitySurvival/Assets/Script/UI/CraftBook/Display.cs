using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Item item;                      //�A�C�e���f�[�^
    private GameObject[] childObjects;      //�q�I�u�W�F�N�g�̔z��
    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�̎擾
        childObjects = new GameObject[this.transform.childCount];
        //�e�I�u�W�F�N�g�̎擾
        GameObject parentButton = transform.parent.gameObject;
        //�A�C�e���f�[�^�̎擾
        item = parentButton.GetComponent<CraftBookButton>().item;
        //�A�C�e�����ݒ肳��Ă��Ȃ�������
        if (item == null)
        {
            //�������^�[��
            return;
        }
        //�f�B�X�v���C�̎q�I�u�W�F�N�g�ɏ���n��
        // DisplayProcess();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //�A�C�R��
            if (i==0)
            {
                //�摜�擾
                childObjects[i].GetComponent<Image>().sprite = item.GetIcon();
            }
            //���O
            else if (childObjects[i].name == "ItemName")
            {
                //���O�擾
                childObjects[i].GetComponent<Text>().text = item.GetItemName();
            }
            //�A�C�e������
            else if (childObjects[i].name == "ItemInfo")
            {
                //�����擾
                childObjects[i].GetComponent<Text>().text = item.GetItemInfo();
            }
            //�A�C�e������
            else if (childObjects[i].name == "ItemEffect")
            {
                //���ʎ擾
                childObjects[i].GetComponent<Text>().text = item.GetItemEffect();
            }
            else
            {
                Debug.Log("null");
            }
        }

    }

    void DisplayProcess()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //�A�C�R��
            if (childObjects[i].name == "CraftItemIcon")
            {
                //�摜�擾
                childObjects[i].GetComponent<Image>().sprite = item.GetIcon();
            }
            //���O
            else if (childObjects[i].name == "ItemName")
            {
                //���O�擾
                childObjects[i].GetComponent<Text>().text = item.GetItemName();
            }
            //�A�C�e������
            else if(childObjects[i].name == "ItemInfo")
            {
                //�����擾
                childObjects[i].GetComponent<Text>().text = item.GetItemInfo();
            }
            //�A�C�e������
            else if (childObjects[i].name == "ItemEffect")
            {
                //���ʎ擾
                childObjects[i].GetComponent<Text>().text = item.GetItemEffect();
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
}
