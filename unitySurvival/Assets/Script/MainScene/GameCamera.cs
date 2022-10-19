using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private GameObject player;        //�v���C���[
    private Vector3 offset;

    void Start()
    {
        //�v���C���[�̌���
        player = GameObject.FindGameObjectWithTag("Player");
        //�J��������v���C���[�܂ł̋���
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(player.transform);
        //�J��������v���C���[�܂ł̋�����ۂ��Ĉړ�����
        this.transform.position = player.transform.position + offset;
    }
    private void Rotation()
    {
        ////�}�E�X���������u��
        //if(Input.GetMouseButtonDown(0))
        //{
        //    newAngle = this.transform.localEulerAngles;
        //}
    }
}
