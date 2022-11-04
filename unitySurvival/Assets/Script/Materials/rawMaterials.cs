using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rawMaterials: MonoBehaviour
{
    public GameObject createObj;

    private void OnDestroy()
    {
        Vector3 pos = this.transform.position;
        Instantiate(createObj, pos, Quaternion.identity);
    }
}