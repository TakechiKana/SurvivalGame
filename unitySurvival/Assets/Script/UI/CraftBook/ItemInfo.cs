using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�e�I�u�W�F�N�g�擾
        GameObject parent = transform.parent.gameObject;
        //�e�I�u�W�F�N�g�̃A�C�e���f�[�^�擾
        Item item = parent.GetComponent<CraftBookButton>().item;
        //�A�C�R���摜�擾
        this.GetComponent<UnityEngine.UI.Text>().text = item.GetItemInfo();
    }
}
