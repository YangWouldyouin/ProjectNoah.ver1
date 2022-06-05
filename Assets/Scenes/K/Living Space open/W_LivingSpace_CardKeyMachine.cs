using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKeyMachine : MonoBehaviour, IInteraction
{
    /* ������Ʈ�� ��ȣ�ۿ� ��ư�� */
    private Button barkButton_W_LS_CardKeyMachine, sniffButton_W_LS_CardKeyMachine, biteButton_W_LS_CardKeyMachine,
pushButton_W_LS_CardKeyMachine, observeButton_W_LS_CardKeyMachine, smashButton_W_LS_CardKeyMachine, DisableobserveButton_W_LS_CardKeyMachine;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData LivingSpace_CardKeyMachine_W;
    public ObjectData LivingSpace_CardKeyMachineData_W;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ + ������ */
    public GameObject box_WL;
    public GameObject CardKey_WL;
    public GameObject LivingDoomDoor_WL;

    public ObjectData boxData_WL;
    public ObjectData CardKeyData_WL;
    public ObjectData LivingDoomDoorData_WL;

    /* ������Ʈ �ƿ����� */
    Outline CardMachineOutline_M; // ī��ӽ�
    Outline LivingCardKeyOutline_M; // ī��Ű


    /* �ִϸ��̼� */
    public Animator HalfLivingDoorAni_M; // ��Ȱ���� �� �ݸ� ������

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    /* ����� */
    AudioSource LivingSpace_CardKeyMachine;
    public AudioClip LivingDoor_Halfopen;
    public AudioClip CardKey_Sound;

    public GameObject goToLivingRoom;

    void Start()
    {
        LivingSpace_CardKeyMachine = GetComponent<AudioSource>();

        /* �ش� ������Ʈ�� ObjData�� �����´�. */
        LivingSpace_CardKeyMachine_W = GetComponent<ObjData>();
/*        boxData_WL = box_WL.GetComponent<ObjData>();
        CardKeyData_WL = CardKey_WL.GetComponent<ObjData>();
        LivingDoomDoorData_WL = LivingDoomDoor_WL.GetComponent<ObjData>();*/

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

        DisableobserveButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.CenterButton2;

        /*        HalfLivingDoorAni_M.SetBool("HalfOpen", false); // �ִϸ��̼� ��� ����*/

        /*�������*/
        LivingSpace_CardKeyMachineData_W.IsObserve = false;
        LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = false;
        LivingSpace_CardKeyMachineData_W.IsNotInteractable = false;
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton() // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.
    {   
        barkButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        observeButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        DisableobserveButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
    }



    void Update()
    {
        if (LivingSpace_CardKeyMachineData_W.IsObserve)
        {
            LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = true;
        }

        else
        {
            LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = false;
        }

        if (LivingSpace_CardKeyMachineData_W.IsObserve)
        {
            LivingSpace_CardKeyMachineData_W.IsNotInteractable = false;
            CardMachineOutline_M.OutlineWidth = 8;
        }

        if (GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom == true)
        {
            LivingSpace_CardKeyMachineData_W.IsNotInteractable = true;
            CardMachineOutline_M.OutlineWidth = 0;
        }
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
            Debug.Log("��");
            // ī�޶� ��Ʈ�ѷ��� �� ����
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObservePlusView; // ���� �� : ����
            // ���� �ִϸ��̼� &ī�޶� ��ȯ
            InteractionButtonController.interactionButtonController.playerObserve();
        }

        if(!boxData_WL.IsUpDown) // ���ڿ� �ö��� �ʾ��� ��
        {
            Debug.Log("�Ʒ�");
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
        InteractionButtonController.interactionButtonController.playerPressHead(); // ������ ������ �ִϸ��̼�
                                                                                   //StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        if (CardKeyData_WL.IsBite && boxData_WL.IsUpDown && LivingSpace_CardKeyMachineData_W.IsObserve) // ī��Ű '����' && �ڽ� '������' ���� ��
        {
            Debug.Log("ī��Ű �����Կ�");
            // ������ -> ī��Ű�� ī���迡 ���� �Ϸ�
            // �θ�-�ڽ� ���� ����
            CardKey_WL.GetComponent<Rigidbody>().isKinematic = false;
            CardKey_WL.transform.parent = null;

            // ī��Ű ��ġ, ���� ��ȯ
            CardKey_WL.transform.position = new Vector3(-264.18f, 2.94f, 691.467f); //��ġ
            CardKey_WL.transform.rotation = Quaternion.Euler(0, 0, 90); //����

            LivingSpace_CardKeyMachine.clip = CardKey_Sound;
            LivingSpace_CardKeyMachine.Play();

            // ī��Ű, ī���� ��ȣ�ۿ� ����
            CardKeyData_WL.IsNotInteractable = true;
            LivingCardKeyOutline_M.OutlineWidth = 0;

            LivingSpace_CardKeyMachineData_W.IsNotInteractable = true;
            CardMachineOutline_M.OutlineWidth = 0;

            Debug.Log("��Ȱ���� �� ������ �ִϸ��̼�");

            // LivingDoomDoor_WL.GetComponent<Animator>().Play("LivingDoorHalfOpen");
            StartCoroutine(LivingDoorHalfOpen1());
            //Invoke("LivingDoorHalfOpen", 2f); // �� ������ �ִϸ��̼� ����

            LivingSpace_CardKeyMachine.clip = LivingDoor_Halfopen;
            LivingSpace_CardKeyMachine.Play();

            GameManager.gameManager._gameData.IsWLDoorHalfOpened_M_C2 = true; // �׻� ������������ ��Ȱ���� �̵� ����
            GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom = true; // ��Ȱ���� �� �ݸ� ���� �Ϸ�

            /* ���������������������������������������� ���� �� ���������������������������������������� */

            GameManager.gameManager._gameData.ActiveMissionList[4] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Debug.Log("��Ȱ���� �� ���� ����");

            /* ���������������������������������������� Y-3��� ���� ���������������������������������������� */
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(29));

            if (GameManager.gameManager._gameData.IsWEDoorOpened_M_C2)
            {
                GameManager.gameManager._gameData.IsAllDoorOpened = true;
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(12));
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else
        {
            /* ���������������������������������������� ī��Ű �� ������ �� -> Y-1��� ���� ���������������������������������������� */
            if (CardKeyData_WL.IsBite == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(27));
            }
            /* ���������������������������������������� ���ڿ� �ö��� �ʾ��� �� -> Y-2��� ���� ���������������������������������������� */
            if (boxData_WL.IsUpDown == false)
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


    IEnumerator LivingDoorHalfOpen1()
    {
        yield return new WaitForSeconds(2f);
        goToLivingRoom.SetActive(true);
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
