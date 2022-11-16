using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBookButton : MonoBehaviour
{
    [SerializeField]
    public Item item;       //�N���t�g�A�C�e��
    [SerializeField]
    public Item[] useItem;   //�N���t�g�f��
    [SerializeField]
    public int[] useItemNum; //�N���t�g�f�ނ̐�
    //�N���t�g�p����
    private Dictionary<Item, int> numOfCraftItem = new Dictionary<Item, int>();
    GameObject playerInventory; //�C���x���g��
    [SerializeField]
    GameObject errorImage;      //�G���[�摜
    [SerializeField]
    GameObject craftImage;      //�쐬�{�^��

    GameObject errorText;

    float timeLimit = 3.0f;

    private void Start()
    {
        for (int i = 0; i < useItem.Length; i++)
        {
            //�N���t�g�A�C�e���Ǝg�p����������
            numOfCraftItem.Add(useItem[i], useItemNum[i]);
        }
        //�v���C���[�C���x���g�����擾
        playerInventory = GameObject.Find("PlayerInventory");
        //�G���[�摜�̃e�L�X�g�擾
        errorText = errorImage.transform.GetChild(0).gameObject;
    }
    // �{�^���������ꂽ�u�ԂɌĂ΂��
    public void ButtonPush()
    {
        if(HaveThisItem())
        {
            errorImage.SetActive(true);
            errorText.GetComponent<Text>().text = ("�N���t�g�ςł��I");
            return;
        }
        if(IsAbleToCraft())
        {
            //�G���[���o�Ă�����
            if(errorImage.activeSelf)
            {
                //��\��
                errorImage.SetActive(false);
            }
            //�N���t�g�{�^�����o���܂܂Ȃ�
            if(craftImage.activeSelf)
            {
                //��\��
                craftImage.SetActive(false);
                return;
            }
            //�N���t�g�{�^���\��
            craftImage.SetActive(true);
        }
        else
        {
            if(craftImage.activeSelf)
            {
                craftImage.SetActive(false);
            }
            errorText.GetComponent<Text>().text = ("�f�ނ�����܂���I");
            errorImage.SetActive(true);
        }
    }
    void Update()
    {
        IsAbleToCraft();
        ImageControll();
    }
    private bool HaveThisItem()
    {
        if(item.GetKindOfItem() == Item.KindOfItem.Tools)
        {
            if (playerInventory.GetComponent<PlayerInventoryManager>().GetHavingItem().ContainsKey(item))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private void ImageControll()
    {
        if(IsAbleToCraft()==false 
            && craftImage.activeSelf ==true)
        {
            craftImage.SetActive(false);
        }
        if(errorImage.activeSelf)
        {
            timeLimit -= Time.deltaTime;
            if (timeLimit <= 0.0f)
            {
                timeLimit = 5.0f;
                errorImage.SetActive(false);
            }
        }
    }

    private bool IsAbleToCraft()
    {
        for(int i = 0; i < useItem.Length;i++)
        {
            //�f�ނ������Ă��Ȃ�������
            if(!playerInventory.GetComponent<PlayerInventoryManager>().GetHavingItem().ContainsKey(useItem[i]))
            {
                return false;
            }
            //�f�ނ͎����Ă��邪�A��������ĂȂ�������
            if (numOfCraftItem[useItem[i]] 
                > playerInventory.GetComponent<PlayerInventoryManager>().GetNumOfItem(useItem[i]))
            {
                return false;
            }

        }
       return true;
    }
}
