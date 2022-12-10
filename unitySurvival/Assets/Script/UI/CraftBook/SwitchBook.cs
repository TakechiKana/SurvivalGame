using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchBook : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField]
    GameObject bg_Image;
    private Animator Animator;    //�A�j���[�V����
    private void Start()
    {
        //�A�j���[�^�[�̎擾
        Animator = bg_Image.GetComponent<Animator>();
    }
    public void PushButton()
    {
        if(isOpen)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
        Animator.SetBool("IsOpen", isOpen);
        //Debug.Log("push");
    }
}
