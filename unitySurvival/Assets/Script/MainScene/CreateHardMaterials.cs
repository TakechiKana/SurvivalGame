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
        //子オブジェクトの配列
        childObjs = new GameObject[this.transform.childCount];
        //子オブジェクトを配列に格納
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
            //ランダムに生成する
            int rand = Random.Range(0, this.transform.childCount);
            //すでにアクティブだったら
            if (childObjs[rand].activeSelf)
            {
                //iをマイナス
                i--;
                //1ループ終了
                break;
            }
            //アクティブにする
            childObjs[rand].SetActive(true);
        }
    }
}

