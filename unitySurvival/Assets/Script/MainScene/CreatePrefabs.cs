using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabs : MonoBehaviour
{
    [SerializeField]
    public GameObject treeObj;  //木のプレハブ
    [SerializeField]
    public GameObject rockObj;  //岩のプレハブ
    [SerializeField]
    public GameObject metalObj; //金属のプレハブ

    private Vector3 rayPos = Vector3.zero;
    private Vector3 createPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //レイの始点の設定
        rayPos = new Vector3(0.0f, 20.0f, 0.0f);
        //木の生成処理
        for(int i = 0;i <= 30;i++)
        {
            createPos.x = Random.Range(-50, 50);    //x座標設定
            createPos.z = Random.Range(-50, 50);    //y座標設定
            //レイを飛ばす
            Ray ray = new Ray(rayPos, createPos);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                //地面にヒットしたら
                if(hit.collider.gameObject.tag == "Ground")
                {
                    //木の生成
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
