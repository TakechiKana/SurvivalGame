using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningButton : MonoBehaviour
{
    //�v���C���[
    private GameObject playerObj;
    //�̌@�\�ȃI�u�W�F�N�g
    private GameObject materialObj;
    //�^�C�}�[
    private float timer = 0.0f;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    private void Update()
    {
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            return;
        }
        timer -= Time.deltaTime;
        this.gameObject.SetActive(false);
    }

    public void PushButton()
    {
        //�̌@���t���O�𗧂Ă�
        playerObj.GetComponent<PlayerMove>().SetIsMinig();
        //�̌@���Ă���Q�[���I�u�W�F�N�g���i�[����
        playerObj.GetComponent<PlayerMove>().SetClickGameObject(materialObj);
        //�̌@�\�G�t�F�N�g���\���ɂ���^�C�}�[�̐ݒ�
        materialObj.GetComponent<rawMaterials>().SetTimerNum();
    }

    public void SetMaterialObject(GameObject gameObject)
    {
        materialObj = gameObject;
    }
}
