using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKeyMachine : MonoBehaviour, IInteraction
{
    /* ������Ʈ�� ��ȣ�ۿ� ��ư�� */
    private Button barkButton_W_LS_CardKeyMachine, sniffButton_W_LS_CardKeyMachine, biteButton_W_LS_CardKeyMachine,
pushButton_W_LS_CardKeyMachine, observeButton_W_LS_CardKeyMachine, smashButton_W_LS_CardKeyMachine;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData LivingSpace_CardKeyMachine_W;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ + ������ */
    public GameObject box_WL;
    public GameObject CardKey_WL;
    public GameObject LivingDoomDoor_WL;

    ObjData boxData_WL;
    ObjData CardKeyData_WL;
    ObjData LivingDoomDoorData_WL;

    /* ������Ʈ �ƿ����� */
    Outline CardMachineOutline_M; // ī��ӽ�
    Outline LivingCardKeyOutline_M; // ī��Ű


    /* �ִϸ��̼� */
    public Animator HalfLivingDoorAni_M; // ��Ȱ���� �� �ݸ� ������

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        LivingSpace_CardKeyMachine_W = GetComponent<ObjData>();
        boxData_WL = box_WL.GetComponent<ObjData>();
        CardKeyData_WL = CardKey_WL.GetComponent<ObjData>();
        LivingDoomDoorData_WL = LivingDoomDoor_WL.GetComponent<ObjData>();

        CardMachineOutline_M = LivingSpace_CardKeyMachine_W.GetComponent<Outline>(); // ī��ӽ� �ƿ�����
        LivingCardKeyOutline_M = CardKey_WL.GetComponent<Outline>(); // ī��Ű �ƿ�����


        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BarkButton;
        barkButton_W_LS_CardKeyMachine.onClick.AddListener(OnBark);

        sniffButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.SniffButton;
        sniffButton_W_LS_CardKeyMachine.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BiteButton;
        biteButton_W_LS_CardKeyMachine.onClick.AddListener(OnBite); // "����"�� �ȵǴ� ������Ʈ

        pushButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.PushOrPressButton;
        pushButton_W_LS_CardKeyMachine.onClick.AddListener(OnPushOrPress);

        observeButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.CenterButton1;
        observeButton_W_LS_CardKeyMachine.onClick.AddListener(OnObserve);

/*        HalfLivingDoorAni_M.SetBool("HalfOpen", false); // �ִϸ��̼� ��� ����*/
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   
        barkButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        observeButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
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

    public void OnObserve()
    {
        LivingSpace_CardKeyMachine_W.IsObserve = true;
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;// ����� �� ������ ������Ʈ ����
        DiableButton();

        if (boxData_WL.IsUpDown) // ���ڿ� �ö��� ��
        {
            // ī�޶� ��Ʈ�ѷ��� �� ����
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObservePlusView; // ���� �� : ����
            // ���� �ִϸ��̼� &ī�޶� ��ȯ
            InteractionButtonController.interactionButtonController.playerObserve();
        }
        else // ���ڿ� �ö��� �ʾ��� ��
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

        LivingSpace_CardKeyMachine_W.IsPushOrPress = true; // ������Ʈ�� ���� ���� true�� �ٲ�
        DiableButton(); // ��ȣ�ۿ� ��ư�� ��

        /* �ִϸ��̼� */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        if(CardKeyData_WL.IsBite && boxData_WL.IsUpDown) // ī��Ű '����' && �ڽ� '������' ���� ��
        {
            // ������ -> ī��Ű�� ī���迡 ���� �Ϸ�
            // �θ�-�ڽ� ���� ����
            CardKeyData_WL.GetComponent<Rigidbody>().isKinematic = false;
            CardKeyData_WL.transform.parent = null;

            // ī��Ű ��ġ, ���� ��ȯ
            CardKeyData_WL.transform.position = new Vector3(-264.007f, 541.042f, 691.461f); //��ġ
            CardKeyData_WL.transform.rotation = Quaternion.Euler(0, 0, 0); //����

            // ī��Ű, ī���� ��ȣ�ۿ� ����
            CardKeyData_WL.IsNotInteractable = true;
            LivingCardKeyOutline_M.OutlineWidth = 0;

            LivingSpace_CardKeyMachine_W.IsNotInteractable = true;
            CardMachineOutline_M.OutlineWidth = 0;


            // LivingDoomDoor_WL.GetComponent<Animator>().Play("LivingDoorHalfOpen");
            Invoke("LivingDoorHalfOpen", 2f); // �� ������ �ִϸ��̼� ����
            GameManager.gameManager._gameData.IsWLDoorHalfOpened_M_C2 = true; // �׻� ������������ ��Ȱ���� �̵� ����
            GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom = true; // ��Ȱ���� �� �ݸ� ���� �Ϸ�
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            /* ���������������������������������������� Y-3��� ���� ���������������������������������������� */
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(29));
        }
        else
        {
            /* ���������������������������������������� ī��Ű �� ������ �� -> Y-1��� ���� ���������������������������������������� */
            if (CardKeyData_WL.IsBite == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(27));
            }
            /* ���������������������������������������� ���ڿ� �ö��� �ʾ��� �� -> Y-2��� ���� ���������������������������������������� */
            if(boxData_WL.IsUpDown == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(28));
            }
        }
    }
    IEnumerator ChangePressFalse() // 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(2f);
        LivingSpace_CardKeyMachine_W.IsPushOrPress = false;
    }

    void LivingDoorHalfOpen()
    {
        HalfLivingDoorAni_M.SetBool("HalfOpen", true); // ��Ȱ���� �� �ݸ� ������
        HalfLivingDoorAni_M.SetBool("HalfEnd", true);
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
    public void OnInsert()
    {
    }

    public void OnSmash()
    {
    }
}
