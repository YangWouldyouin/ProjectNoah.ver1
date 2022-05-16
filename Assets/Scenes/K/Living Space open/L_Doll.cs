using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Doll : MonoBehaviour, IInteraction

{
    /* ������Ʈ�� ��ȣ�ۿ� ��ư�� */
    private Button barkButton_L_Doll, sniffButton_L_Doll, biteButton_L_Doll,
pushButton_L_Doll, upButton_L_Doll, upDisableButton_L_Doll, smashButton_L_Doll, DisableButton;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData DollData_L;

    //public GameObject AllDoll_L;
    //public GameObject HalfDoll_L;
    //public GameObject DestroyDoll_L;

    //ObjData AllDollData_L;
    //ObjData HalfDollData_L;
    //ObjData DestroyDollData_L;

    /* �ִϸ��̼� */
    public Animator LivingDoorAni_L; // ��Ȱ���� �� ������ ������

    public GameObject dialog;
    DialogManager dialogManager;

    AudioSource dollrecordAudio;
    public AudioClip Doll_L_Audio;


    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        DollData_L = GetComponent<ObjData>();

        barkButton_L_Doll = DollData_L.BarkButton; // ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�.
        barkButton_L_Doll.onClick.AddListener(OnBark); // ��ư�� �Լ��� �־��ش�.

        sniffButton_L_Doll = DollData_L.SniffButton;
        sniffButton_L_Doll.onClick.AddListener(OnSniff);

        biteButton_L_Doll = DollData_L.BiteButton; // ����

        smashButton_L_Doll = DollData_L.SmashButton; // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư ������ �߰��Ѵ�.
        smashButton_L_Doll.onClick.AddListener(OnSmash);

        pushButton_L_Doll = DollData_L.PushOrPressButton;
        pushButton_L_Doll.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        DisableButton = DollData_L.CenterButton1;

        // GameManager.gameManager._gameData.IsCompleteOpenLivingRoom = false;
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_L_Doll.transform.gameObject.SetActive(false);
        sniffButton_L_Doll.transform.gameObject.SetActive(false);
        biteButton_L_Doll.transform.gameObject.SetActive(false);
        smashButton_L_Doll.transform.gameObject.SetActive(false);
        pushButton_L_Doll.transform.gameObject.SetActive(false);
        DisableButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {
    }


    /* ��ȣ�ۿ� �Լ� �ۼ� */
    // �ش� ������Ʈ���� ������ ���̴� �͵鸸 �Լ� ������ ä��� �ȴ�.
    public void OnBark() // ¢��
    {
        DollData_L.IsBark = true; // ������Ʈ�� ¢�� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��
        InteractionButtonController.interactionButtonController.playerBark(); //�ִϸ��̼� ������
    }
    public void OnBite()
    {

        // ��Ȱ���� ���� �ݸ� ������ && ������ ������ �ʾ��� ��
        if (GameManager.gameManager._gameData.IsCompleteOpenLivingRoom == false)
        {
            // SwitchDoll();
            // Invoke("SwitchDoll", 1.2f); // ������ �������� �ٲ�
            GameManager.gameManager._gameData.IsLivingRoomDollOut = true; // ��Ȱ���� ���� �����ִ� ���� ����
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("���� ����");

            LivingDoorOpen();
            // Invoke("LivingDoorOpen", 2f); // �� ������ ������ �ִϸ��̼� ����
            GameManager.gameManager._gameData.IsCompleteOpenLivingRoom = true; // ��Ȱ���� �� ���� ���� �Ϸ�
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("�� ������ ������");
        }
    }
    //void SwitchDoll()
    //{
    //    HalfDoll_L.SetActive(false);
    //    AllDoll_L.SetActive(true);
    //}
    void LivingDoorOpen() // �� ������ �ִϸ��̼�
    {
        LivingDoorAni_L.SetBool("HalfOpen", true); // ��Ȱ���� �� ������ ������
        LivingDoorAni_L.SetBool("HalfEnd", true);
    }


    /* ���������������������������������������� ���� ���� ���������������������������������������� */
    public void OnPushOrPress() // �б�, ������
    {
        /* �б� & ������ �߿� "������"�� ��!!! */

        DollData_L.IsPushOrPress = true;// ������Ʈ�� ���� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(1));

        // �ڸ� + ���� ������
        dollrecordAudio.clip = Doll_L_Audio;
        dollrecordAudio.Play();
    }
    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        DollData_L.IsPushOrPress = false;
    }
    /* ���������������������������������������� ���� �� ���������������������������������������� */

    public void OnSniff() // �����ñ�
    {
        DollData_L.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnSmash() // �ı��ϱ�
    {
/*        DollData_L.IsSmash = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        *//* �ı��ϱ� ���� ���� (2�� �����̰� �ִϸ��̼��� �ڿ�������) *//*
        Invoke(" SmashInteraction", 2f);

        *//* ������Ʈ ���� �ִϸ��̼� ���� *//*
        InteractionButtonController.interactionButtonController.PlayerSmash2();*/
    }
    /*    void SmashInteraction() // �ı��ϱ⸦ ���� �� �����ְų� ������ �͵��� ���´� 
    {
        AllDoll_L.SetActive(false);
        DestroyDoll_L.SetActive(true);
    }*/
    public void OnObserve() // �����ϱ�
    {
    }
    public void OnInsert() // �����
    {
    }
    public void OnUp() // ������
    {
    }
    public void OnEat() // �Ա�
    {
    }
}
