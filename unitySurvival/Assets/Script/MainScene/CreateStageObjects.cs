using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageObjects: MonoBehaviour
{
    public GameObject[] createPrefabs;     //ゲームオブジェクトの配列
    public int[] num;                      //生成数の配列

    private float radius = 50.0f;    //範囲(半径)
    private float rayOriginY = 10.0f;//レイの基点の高さ

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<createPrefabs.Length;i++)
        {
            for(int j = 0;j<num[i];j++)
            {
                // レイの基点を決める
                Vector3 rayOrigin = Random.insideUnitSphere * radius;
                rayOrigin.y = rayOriginY;

                //レイを発射して衝突した場所を求める
                RaycastHit hit;
                if(Physics.BoxCast(rayOrigin,Vector3.one * 7.0f, -Vector3.up,out hit))
                {
                    if (hit.collider.gameObject.tag == "Ground" && hit.point.y > 1.5f)
                    {
                        //レイの衝突地点にプレハブ作成
                        Instantiate(createPrefabs[i], hit.point, Quaternion.identity);
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    //地面と衝突しなかったらやり直し
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
