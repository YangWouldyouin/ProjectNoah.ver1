using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot2 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject T_InUnGrownSweetPotato2;
    public GameObject T_InHealthySweetPotato2;
    public GameObject T_InBadSweetPotato2;
    public GameObject T_InSuperDrug2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_Pot2, sniffButton_T_Pot2, biteButton_T_Pot2, pressButton_T_Pot2, noCenterButton_T_Pot2;

    /*ObjData*/
    ObjData Pot2Data_T;
    public ObjectData realPot2Data_T;
    public ObjectData InHealthySweetPotato2Data_T;
    public ObjectData InBadSweetPotato2Data_T;
    public ObjectData InSuperDrug2Data_T;
    public ObjectData IsFarmButton2Data_T;
    public ObjectData InUnGrownSweetPotato2Data_T;

    public Outline realPot2Outline_T;
    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    PlayerEquipment playerEquipment; // ���� ���� �����͸� �ʱ�ȭ�ϱ� ����
    PortableObjectData portableData; // ���� ��ũ�뿡�� �Ⱥ��̰� �ϱ� ����

    void Start()
    {
        playerEquipment = BaseCanvas._baseCanvas.equipment;
        portableData = BaseCanvas._baseCanvas.workRoomData;

        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot2Data_T = GetComponent<ObjData>();

        barkButton_T_Pot2 = Pot2Data_T.BarkButton;
        barkButton_T_Pot2.onClick.AddListener(OnBark);

        sniffButton_T_Pot2 = Pot2Data_T.SniffButton;
        sniffButton_T_Pot2.onClick.AddListener(OnSniff);

        biteButton_T_Pot2 = Pot2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot2 = Pot2Data_T.PushOrPressButton;
        pressButton_T_Pot2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot2 = Pot2Data_T.CenterButton1;

        /*���� ����*/
        realPot2Data_T.IsNotInteractable = true;
        realPot2Outline_T.OutlineWidth = 0;
    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_T_Pot2.transform.gameObject.SetActive(false);
        sniffButton_T_Pot2.transform.gameObject.SetActive(false);
        biteButton_T_Pot2.transform.gameObject.SetActive(false);
        pressButton_T_Pot2.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot2.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        /*���ڶ� ������ ������ -> ������ �ڶ���.*/
        if (InUnGrownSweetPotato2Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown2", 2f);
            GameManager.gameManager._gameData.Pot2InPotato = true; // �ɰ� 5�� �� ä��� ���� ����� �߰�����
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*���� ������ ������ -> ������ ������� �ƹ��� ��ȭ�� ����.*/
        if (InBadSweetPotato2Data_T.IsBite)
        {
            Invoke("BadPotatoBye2", 2f);

        }

        /*�ǰ��� ������ �ɰ� �����Ŀ� �������� �Ѹ��� ���ο� ���°� ���� ����*/
        if (InHealthySweetPotato2Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye2", 2f);
        }

        if (GameManager.gameManager._gameData.Pot2InHealthyPotato && InSuperDrug2Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug2", 2f);
        }
    }

    void CanTSeeUnGrown2()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InUnGrownSweetPotato2Data_T.IsBite = false;

        T_InUnGrownSweetPotato2.SetActive(false);

        // ���� ���������� ���ڶ� ���� �����Ƿ� ���� false�� ����
        portableData.IsObjectActiveList[14] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void BadPotatoBye2()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InBadSweetPotato2Data_T.IsBite = false;

        T_InBadSweetPotato2.SetActive(false);

        // ���� ���������� ���ڶ� ���� �����Ƿ� ���� false�� ����
        portableData.IsObjectActiveList[12] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InBadPotato = true; // ���� ���� ������� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye2()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InHealthySweetPotato2Data_T.IsBite = false;

        T_InHealthySweetPotato2.SetActive(false);

        // ���� ���������� ���ڶ� ���� �����Ƿ� ���� false�� ����
        portableData.IsObjectActiveList[13] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InHealthyPotato = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug2()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InSuperDrug2Data_T.IsBite = false;

        T_InSuperDrug2.SetActive(false);

        // ���� ���������� ���ڶ� ���� �����Ƿ� ���� false�� ����
        portableData.IsObjectActiveList[11] = false;

        Debug.Log("���°� ���� ����");
        GameManager.gameManager._gameData.IsMakeForestEnd = true; // �������� ���ϴ� �ű⶧���� ����
        GameManager.gameManager._gameData.ActiveMissionList[21] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ������ ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������
    }

    public void OnBite()
    {
       
    }

    public void OnEat()
    {
        
    }

    public void OnInsert()
    {
        
    }

    public void OnObserve()
    {
        
    }


    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}
