using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    private GameObject gameObj; //ƒCƒ“ƒxƒ“ƒgƒŠ
    public GameObject createWood;

    private void OnDestroy()
    {
        Vector3 pos = this.transform.position;
        //pos.y += 10.0f;
        Instantiate(createWood, pos, Quaternion.identity);
    }

    void Start()
    {

    }

    private void Update()
    { 
    }
}