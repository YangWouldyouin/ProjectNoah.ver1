using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot3 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject T_InUnGrownSweetPotato3;
    public GameObject T_InHealthySweetPotato3;
    public GameObject T_InBadSweetPotato3;
    public GameObject T_InSuperDrug3;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_Pot3, sniffButton_T_Pot3, biteButton_T_Pot3, pressButton_T_Pot3, noCenterButton_T_Pot3;

    /*ObjData*/
    ObjData Pot3Data_T;
    public ObjectData realPot3Data_T;
    public ObjectData InHealthySweetPotato3Data_T;
    public ObjectData InBadSweetPotato3Data_T;
    public ObjectData InSuperDrug3Data_T;
    public ObjectData IsFarmButton3Data_T;
    public ObjectData InUnGrownSweetPotato3Data_T;

    public Outline realPot3Outline_T;
    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    PlayerEquipment playerEquipment; // ���� ���� �����͸� �ʱ�ȭ�ϱ� ����
    PortableObjectData portableData; // ���� ��ũ�뿡�� �Ⱥ��̰� �ϱ� ����

    void Start()
    {
        playerEquipment = BaseCanvas._baseCanvas.equipment;
        portableData = BaseCanvas._baseCanvas.workRoomData;

        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot3Data_T = GetComponent<ObjData>();


        barkButton_T_Pot3 = Pot3Data_T.BarkButton;
        barkButton_T_Pot3.onClick.AddListener(OnBark);

        sniffButton_T_Pot3 = Pot3Data_T.SniffButton;
        sniffButton_T_Pot3.onClick.AddListener(OnSniff);

        biteButton_T_Pot3 = Pot3Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot3 = Pot3Data_T.PushOrPressButton;
        pressButton_T_Pot3.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot3 = Pot3Data_T.CenterButton1;


        /*���� ����*/
        realPot3Data_T.IsNotInteractable = true;
        realPot3Outline_T.OutlineWidth = 0;
    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_T_Pot3.transform.gameObject.SetActive(false);
        sniffButton_T_Pot3.transform.gameObject.SetActive(false);
        biteButton_T_Pot3.transform.gameObject.SetActive(false);
        pressButton_T_Pot3.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot3.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        Pot3Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Pot3Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        Pot3Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        /*���ڶ� ������ ������ -> ������ �ڶ���.*/
        if (InUnGrownSweetPotato3Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown3", 2f);
            GameManager.gameManager._gameData.Pot3InPotato = true; // �ɰ� 5�� �� ä��� ���� ����� �߰�����
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*���� ������ ������ -> ������ ������� �ƹ��� ��ȭ�� ����.*/
        if (InBadSweetPotato3Data_T.IsBite)
        {
            Invoke("BadPotatoBye3", 2f);

        }

        /*�ǰ��� ������ �ɰ� �����Ŀ� �������� �Ѹ��� ���ο� ���°� ���� ����*/
        if (InHealthySweetPotato3Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye3", 2f);
        }

        if (GameManager.gameManager._gameData.Pot3InHealthyPotato && InSuperDrug3Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug3", 2f);
        }

    }

    void CanTSeeUnGrown3()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InUnGrownSweetPotato3Data_T.IsBite = false;

        T_InUnGrownSweetPotato3.SetActive(false);

        // ���� ���������� ���ڶ� ���� �����Ƿ� ���� false�� ����
        portableData.IsObjectActiveList[14] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void BadPotatoBye3()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InBadSweetPotato3Data_T.IsBite = false;

        T_InBadSweetPotato3.SetActive(false);

        // ���� ���������� �Ȱǰ��� ���� �����Ƿ�  ���� false�� ����
        portableData.IsObjectActiveList[12] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InBadPotato = true; // ���� ���� ������� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye3()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InHealthySweetPotato3Data_T.IsBite = false;

        T_InHealthySweetPotato3.SetActive(false);

        // ���� ���������� ���� �����Ƿ�  ���� false�� ����
        portableData.IsObjectActiveList[13] = false;

        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InHealthyPotato = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug3()
    {
        // ������ ���� ����߱� ������ ���� ���� ���� ���� �ʱ�ȭ
        playerEquipment.biteObjectName = "";
        InSuperDrug3Data_T.IsBite = false;

        T_InSuperDrug3.SetActive(false);

        // ���� ���������� ���۾�  �����Ƿ�  ���� false�� ����
        portableData.IsObjectActiveList[11] = false;

        Debug.Log("���°� ���� ����");
        GameManager.gameManager._gameData.IsMakeForestEnd = true; // �������� ���ϴ� �ű⶧���� ����
        GameManager.gameManager._gameData.ActiveMissionList[21] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        // ������ ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Pot3Data_T.IsPushOrPress = false;
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
