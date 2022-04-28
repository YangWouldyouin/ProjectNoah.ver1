using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKeyMachine : MonoBehaviour, IInteraction
{
    /* ������Ʈ�� ��ȣ�ۿ� ��ư�� */
    private Button barkButton_W_LS_CardKeyMachine, sniffButton_W_LS_CardKeyMachine, biteButton_W_LS_CardKeyMachine,
pushButton_W_LS_CardKeyMachine, upButton_W_LS_CardKeyMachine, upDisableButton_W_LS_CardKeyMachine, smashButton_W_LS_CardKeyMachine;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData LivingSpace_CardKeyMachine_W;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ + ������ */
    public GameObject box_WL;
    public GameObject Card_WL;

    ObjData boxData_WL;
    ObjData CardData_WL;



    void Start()
    {
        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        LivingSpace_CardKeyMachine_W = GetComponent<ObjData>();


        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BarkButton;
        barkButton_W_LS_CardKeyMachine.onClick.AddListener(OnBark);

        sniffButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.SniffButton;
        sniffButton_W_LS_CardKeyMachine.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BiteButton;
        biteButton_W_LS_CardKeyMachine.onClick.AddListener(OnBite); // "����"�� �ȵǴ� ������Ʈ

        pushButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.PushOrPressButton;
        pushButton_W_LS_CardKeyMachine.onClick.AddListener(OnPushOrPress);
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   
        barkButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
    }



    void Update()
    { 
    }

    public void OnBark()
    {
        LivingSpace_CardKeyMachine_W.IsBark = true; // ������Ʈ�� ¢�� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��
        InteractionButtonController.interactionButtonController.playerBark(); //�ִϸ��̼� ������
    }

    public void OnInsert()
    {
        LivingSpace_CardKeyMachine_W.IsInsert = true;
        DiableButton();

        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);

        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    public void OnObserve()
    {
        LivingSpace_CardKeyMachine_W.IsObserve = true;
        DiableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject; // ����� �� ������ ������Ʈ ����

        if (boxData_WL.IsUpDown) // ���ڿ� �ö��� ��
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObservePlusView; // ���� �� : ����
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
            InteractionButtonController.interactionButtonController.playerObserve();
            
            if (CardData_WL.IsBite) // ī�带 ������ ��
            { 
                // ����� ��ư Ȱ��ȭ
            }

            else // ī�带 ���� �ʾ��� ��
            { 
                // ����� ��ư ��Ȱ��ȭ
            }
        }
        
        else // ���ڿ� �ȿö��� ��
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObserveView; // ���� �� : �Ʒ���
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
            InteractionButtonController.interactionButtonController.playerObserve();
        }

    }

    public void OnPushOrPress()
    {
        /* �б� & ������ �߿� "������"�� ��!!! */

        LivingSpace_CardKeyMachine_W.IsPushOrPress = true;// ������Ʈ�� ���� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }
    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        LivingSpace_CardKeyMachine_W.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        LivingSpace_CardKeyMachine_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }




    public void OnEat()
    {
    }
    public void OnUp()
    {
    }

    public void OnBite()
    {
    }

    public void OnSmash()
    {
    }
}
