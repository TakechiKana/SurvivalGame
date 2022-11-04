using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabs : MonoBehaviour
{
    [SerializeField]
    public GameObject treeObj;  //�؂̃v���n�u
    [SerializeField]
    public GameObject rockObj;  //��̃v���n�u
    [SerializeField]
    public GameObject metalObj; //�����̃v���n�u

    private Vector3 rayPos = Vector3.zero;
    private Vector3 createPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //���C�̎n�_�̐ݒ�
        rayPos = new Vector3(0.0f, 20.0f, 0.0f);
        //�؂̐�������
        for(int i = 0;i <= 30;i++)
        {
            createPos.x = Random.Range(-50, 50);    //x���W�ݒ�
            createPos.z = Random.Range(-50, 50);    //y���W�ݒ�
            //���C���΂�
            Ray ray = new Ray(rayPos, createPos);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                //�n�ʂɃq�b�g������
                if(hit.collider.gameObject.tag == "Ground")
                {
                    //�؂̐���
                    Instantiate(treeObj, createPos, Quaternion.identity);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
