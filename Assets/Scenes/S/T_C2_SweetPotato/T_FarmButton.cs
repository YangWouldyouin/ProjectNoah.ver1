using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_FarmButton : MonoBehaviour, IInteraction
{
    public bool EatPotato = false;

    /*�����ִ� ������Ʈ*/
    public GameObject Pot1;
    public GameObject Pot2;
    public GameObject Pot3;
    public GameObject T_IsGrownHealthy1;
    public GameObject T_IsGrownHealthy2;
    public GameObject T_IsGrownHealthy3;
    public GameObject T_IsGrownHealthy4;
    public GameObject T_IsGrownHealthy5;
    public GameObject T_IsGrownHealthy6;
    public GameObject T_IsGrownHealthy7;
    public GameObject T_IsGrownHealthy8;
    public GameObject T_IsGrownHealthy9;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_FarmButton, sniffButton_T_FarmButton, biteButton_T_FarmButton, pressButton_T_FarmButton, noCenterButton_T_FarmButton;

    /*ObjData*/
    ObjData FarmButtonData_T;
    public ObjectData HeathlyPotatoEatData_T;
    public ObjectData BadPotatoEatData_T;

    /*Collider*/
    BoxCollider Pot1_Collider;
    BoxCollider Pot2_Collider;
    BoxCollider Pot3_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    PortableObjectData portableData; // ���� ��ũ�뿡�� �Ⱥ��̰� �ϱ� ����

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot1_Collider = Pot1.GetComponent<BoxCollider>();
        Pot2_Collider = Pot2.GetComponent<BoxCollider>();
        Pot3_Collider = Pot3.GetComponent<BoxCollider>();

        FarmButtonData_T = GetComponent<ObjData>();

        barkButton_T_FarmButton = FarmButtonData_T.BarkButton;
        barkButton_T_FarmButton.onClick.AddListener(OnBark);

        sniffButton_T_FarmButton = FarmButtonData_T.SniffButton;
        sniffButton_T_FarmButton.onClick.AddListener(OnSniff);

        biteButton_T_FarmButton = FarmButtonData_T.BiteButton;
        biteButton_T_FarmButton.onClick.AddListener(OnBite);

        pressButton_T_FarmButton = FarmButtonData_T.PushOrPressButton;
        pressButton_T_FarmButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_FarmButton = FarmButtonData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_FarmButton.transform.gameObject.SetActive(false);
        sniffButton_T_FarmButton.transform.gameObject.SetActive(false);
        biteButton_T_FarmButton.transform.gameObject.SetActive(false);
        pressButton_T_FarmButton.transform.gameObject.SetActive(false);
        noCenterButton_T_FarmButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if(HeathlyPotatoEatData_T.IsEaten && GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes == false
            || BadPotatoEatData_T.IsEaten && GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes == false)
        {
            // ����� ���� �ӹ�����Ʈ �Ϸ� ��������������������������������������������������������������������
            MissionGenerator.missionGenerator.DeleteNewMission(18);
            Debug.Log("�Ծ����");
            GameManager.gameManager._gameData.IsFinishedEatingSweetPotatoes = true;
        }

    }

    public void OnBark()
    {
        //FarmButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        //FarmButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //����Ʈ�� ��ġ�� ������ ��ư ������ �� ���ľ��մϴ� ���� �߰� �ϱ�
        if (GameManager.gameManager._gameData.IsCompleteSmartFarmOpen == false)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(75));
        }


        /*�׻� pot �������  ���ڶ� ������ �ɰ�, ���� ������ �ɰ�, ������ ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/

        /*Pot1*/
        GameData gameData = SaveSystem.Load("save_001");
        if (gameData.Pot1InPotato)
        {
            //A-6 �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
            Invoke("AppearSweetPotato1", 3f); //���� Ÿ������ 5�� �ڿ� �̸� ���� ���� ��Ų �������� ������ ���̰� �ȴ�.

            if(!gameData.IsCanSeePotato1&& !gameData.IsCanSeePotato2 && !gameData.IsCanSeePotato3)
            {
                MissionGenerator.missionGenerator.DeleteNewMission(19);
                /*������ ��Ÿ�� ���¸� �����Ѵ�.*/
                GameManager.gameManager._gameData.IsCanSeePotato1 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }

        if (gameData.Pot1InBadPotato)
        {
            //A-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot1InHealthyPotato)
        {
            //A-6��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }


        /*Pot2*/
        if(gameData.Pot2InPotato)
        {
            //A-6 �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato2", 3f); //���� Ÿ������ 5�� �ڿ� �̸� ���� ���� ��Ų �������� ������ ���̰� �ȴ�.

            /*������ ��Ÿ�� ���¸� �����Ѵ�.*/
            GameManager.gameManager._gameData.IsCanSeePotato2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            MissionGenerator.missionGenerator.DeleteNewMission(19);
        }

        if (gameData.Pot2InBadPotato)
        {
            //A-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot2InHealthyPotato)
        {
            //A-6��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*Pot3*/
        if(gameData.Pot3InPotato)
        {
            //A-6 �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato3", 3f); //���� Ÿ������ 5�� �ڿ� �̸� ���� ���� ��Ų �������� ������ ���̰� �ȴ�.

            /*������ ��Ÿ�� ���¸� �����Ѵ�.*/
            GameManager.gameManager._gameData.IsCanSeePotato3 = true;
            //GameManager.gameManager._gameData.ActiveMissionList[19] = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.DeleteNewMission(19);

        }

        if (gameData.Pot3InBadPotato)
        {
            //A-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(gameData.Pot3InHealthyPotato)
        {
            //A-6��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
    }

    void AppearSweetPotato1()
    {
        T_IsGrownHealthy1.SetActive(true);
        T_IsGrownHealthy2.SetActive(true);
        T_IsGrownHealthy3.SetActive(true);

        // ���� ���������� ���� �����Ƿ� ���� true�� ����
        portableData.IsObjectActiveList[21] = true;
        portableData.IsObjectActiveList[22] = true;
        portableData.IsObjectActiveList[23] = true;

        //A-7 �˸� ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*���� �Դ� �� ���� �ȵǰ� + �̹� �� �� ���� ������ �ٽ� �� �ɰ�*/
        Pot1_Collider.enabled = false;

        /*������ ��Ÿ�� ���¸� �����Ѵ�.*//*
        GameManager.gameManager._gameData.IsCanSeePotato1 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // �Ĺ� ��� ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������
    }

    void AppearSweetPotato2()
    {
        T_IsGrownHealthy4.SetActive(true);
        T_IsGrownHealthy5.SetActive(true);
        T_IsGrownHealthy6.SetActive(true);

        // ���� ���������� ���� �����Ƿ� ���� true�� ����
        portableData.IsObjectActiveList[18] = true;
        portableData.IsObjectActiveList[19] = true;
        portableData.IsObjectActiveList[20] = true;

        //A-7 �˸� ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*���� �Դ� �� ���� �ȵǰ� + �̹� �� �� ���� ������ �ٽ� �� �ɰ�*/
        Pot2_Collider.enabled = false;

        /*������ ��Ÿ�� ���¸� �����Ѵ�.*//*
        GameManager.gameManager._gameData.IsCanSeePotato2 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // �Ĺ� ��� ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������
    }

    void AppearSweetPotato3()
    {
        T_IsGrownHealthy7.SetActive(true);
        T_IsGrownHealthy8.SetActive(true);
        T_IsGrownHealthy9.SetActive(true);

        // ���� ���������� ���� �����Ƿ� ���� true�� ����
        portableData.IsObjectActiveList[15] = true;
        portableData.IsObjectActiveList[16] = true;
        portableData.IsObjectActiveList[17] = true;

        //A-7 �˸� ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*���� �Դ� �� ���� �ȵǰ� + �̹� �� �� ���� ������ �ٽ� �� �ɰ�*/
        Pot3_Collider.enabled = false;

        /*������ ��Ÿ�� ���¸� �����Ѵ�.*//*
        GameManager.gameManager._gameData.IsCanSeePotato3 = true;
        GameManager.gameManager._gameData.ActiveMissionList[19] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();*/

        // �Ĺ� ��� ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������
    }

    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
