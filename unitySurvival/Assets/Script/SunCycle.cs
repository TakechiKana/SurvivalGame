using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1�t���[����Y���W��60�x��]������
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime);
        float time = 0;
        time+= Time.deltaTime;
        //Debug.Log(time);
    }
}
