using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHardMaterials: MonoBehaviour
{
    private GameObject[] childObjs;
    public int createNum;
    public float time;
    void Start()
    {
        //�q�I�u�W�F�N�g�̔z��
        childObjs = new GameObject[this.transform.childCount];
        //�q�I�u�W�F�N�g��z��Ɋi�[
        for(int i= 0;i<this.transform.childCount;i++)
        {
            childObjs[i] = this.transform.GetChild(i).gameObject;
        }
        CreateHardObjects(createNum);
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0.0f)
        {
            SearchObjectNum();
            time = 60.0f;
        }
    }
    void SearchObjectNum()
    {
        int activeNum = 0;
        for(int i = 0; i<this.transform.childCount;i++)
        {
            if(childObjs[i].activeSelf)
            {
                activeNum += 1;
            }
        }
        if(activeNum < createNum)
        {
            int count1 = createNum - activeNum;
            CreateHardObjects(count1);
        }
    }

    void CreateHardObjects(int count)
    {
        for (int i = 0; i <= count; i++)
        {
            //�����_���ɐ�������
            int rand = Random.Range(0, this.transform.childCount);
            //���łɃA�N�e�B�u��������
            if (childObjs[rand].activeSelf)
            {
                //i���}�C�i�X
                i--;
                //1���[�v�I��
                break;
            }
            //�A�N�e�B�u�ɂ���
            childObjs[rand].SetActive(true);
        }
    }
}

