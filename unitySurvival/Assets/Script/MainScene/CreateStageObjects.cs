using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageObjects: MonoBehaviour
{
    public GameObject[] createPrefabs;     //�Q�[���I�u�W�F�N�g�̔z��
    public int[] num;                      //�������̔z��

    private float radius = 50.0f;    //�͈�(���a)
    private float rayOriginY = 10.0f;//���C�̊�_�̍���

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<createPrefabs.Length;i++)
        {
            for(int j = 0;j<num[i];j++)
            {
                // ���C�̊�_�����߂�
                Vector3 rayOrigin = Random.insideUnitSphere * radius;
                rayOrigin.y = rayOriginY;

                //���C�𔭎˂��ďՓ˂����ꏊ�����߂�
                RaycastHit hit;
                if(Physics.BoxCast(rayOrigin,Vector3.one * 7.0f, -Vector3.up,out hit))
                {
                    if (hit.collider.gameObject.tag == "Ground" && hit.point.y > 1.5f)
                    {
                        //���C�̏Փ˒n�_�Ƀv���n�u�쐬
                        Instantiate(createPrefabs[i], hit.point, Quaternion.identity);
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    //�n�ʂƏՓ˂��Ȃ��������蒼��
                    j--;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
