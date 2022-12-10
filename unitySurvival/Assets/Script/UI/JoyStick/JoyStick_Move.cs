using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick_Move : MonoBehaviour
{
    [SerializeField]
    public GameObject joyStick;     //�X�e�B�b�N�i�[
    private RectTransform joyStickRectTransform;    //�W���C�X�e�B�b�N�L�����o�X�̃|�W�V����
    [SerializeField]
    public GameObject joyStick_bg;  //�W���C�X�e�B�b�N�w�i
    public int stickRange = 3;      //�X�e�B�b�N��������͈�
    private int stickMovement = 0;  //���ۂɓ����l

    public static float joyStickPosX;
    public static float joyStickPosY;

    private void Start()
    {
        //�����ݒ�
        Init();
    }

    //�����ݒ�
    private void Init()
    {
        //�[���̃T�C�Y�ɍ��킹�������ɂ�����
        stickMovement = stickRange * (Screen.width + Screen.height) / 100;
        joyStickRectTransform = joyStick.GetComponent<RectTransform>();
        //�W���C�X�e�B�b�N�̔�\��
        JoyStickDisPlay(false);
    }

    //�W���C�X�e�B�b�N�̕\��
    private void JoyStickDisPlay(bool x)
    {
        joyStick_bg.SetActive(x);
        joyStick.SetActive(x);
    }

    //�W���C�X�e�B�b�N�̃|�W�V����������
    public void JoyStickPosInit()
    {
        joyStickRectTransform.anchoredPosition = Vector2.zero;
        joyStickPosX = 0.0f;
        joyStickPosY = 0.0f;
    }

    //�W���C�X�e�B�b�N�̓���
    public void Move(BaseEventData data)
    {
        PointerEventData pointer = data as PointerEventData;

        //�W���C�X�e�B�b�N�Ɠ��͈ʒu�̍�
        float x = joyStick_bg.transform.position.x - pointer.position.x;
        float y = joyStick_bg.transform.position.y - pointer.position.y;
        //�W���C�X�e�B�b�N�̉~�̓���
        float angle = Mathf.Atan2(y, x);
        //�����]�T�����邩
        if (Vector2.Distance(joyStick_bg.transform.position, pointer.position) > stickMovement)
        {
            y = stickMovement * Mathf.Sin(angle);
            x = stickMovement * Mathf.Cos(angle);
        }

        joyStickPosX = -x / stickMovement;
        joyStickPosY = -y / stickMovement;

        joyStick.transform.position = new Vector2(joyStick_bg.transform.position.x - x, joyStick_bg.transform.position.y - y);

    }

    //���͒�
    public void PointDown(BaseEventData data)
    {
        PointerEventData pointer = data as PointerEventData;
        //�W���C�X�e�B�b�N�\��
        JoyStickDisPlay(true);
        //�W���C�X�e�B�b�N�w�i���^�b�`�������W�ɕ\��
        joyStick_bg.transform.position = pointer.position;
    }

    //�w�𗣂����u��
    public void PointerUp(BaseEventData data)
    {
        //�W���C�X�e�B�b�N���W������
        JoyStickPosInit();
        //�W���C�X�e�B�b�N��\��
        JoyStickDisPlay(false);
    }
}

