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
    public GameObject T_IsGrownHealthy4;
    public GameObject T_IsGrownHealthy5;
    public GameObject T_IsGrownHealthy6;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_Pot2, sniffButton_T_Pot2, biteButton_T_Pot2, pressButton_T_Pot2, noCenterButton_T_Pot2;

    /*ObjData*/
    ObjData Pot2Data_T;
    public ObjectData InHealthySweetPotato2Data_T;
    public ObjectData InBadSweetPotato2Data_T;
    public ObjectData InSuperDrug2Data_T;
    public ObjectData IsFarmButton2Data_T;
    public ObjectData InUnGrownSweetPotato2Data_T;

    /*Collider*/
    BoxCollider Pot2_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot2Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot2_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot2 = Pot2Data_T.BarkButton;
        barkButton_T_Pot2.onClick.AddListener(OnBark);

        sniffButton_T_Pot2 = Pot2Data_T.SniffButton;
        sniffButton_T_Pot2.onClick.AddListener(OnSniff);

        biteButton_T_Pot2 = Pot2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot2 = Pot2Data_T.PushOrPressButton;
        pressButton_T_Pot2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot2 = Pot2Data_T.CenterButton1;
    }

    void Update()
    {
        /*���ڶ� ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot2InPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6 �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato2", 300f); //���� Ÿ������ 5�� �ڿ� �̸� ���� ���� ��Ų �������� ������ ���̰� �ȴ�.
        }

        /*���� ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot2InBadPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*������ ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot2InHealthyPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
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
        T_InUnGrownSweetPotato2.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void AppearSweetPotato2()
    {
        T_IsGrownHealthy4.SetActive(true);
        T_IsGrownHealthy5.SetActive(true);
        T_IsGrownHealthy6.SetActive(true);

        //A-7 �˸� ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*���� �Դ� �� ���� �ȵǰ� + �̹� �� �� ���� ������ �ٽ� �� �ɰ�*/
        Pot2_Collider.enabled = false;

        /*������ ��Ÿ�� ���¸� �����Ѵ�.*/
        GameManager.gameManager._gameData.IsCanSeePotato2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void BadPotatoBye2()
    {
        T_InBadSweetPotato2.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InBadPotato = true; // ���� ���� ������� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye2()
    {
        T_InHealthySweetPotato2.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InHealthyPotato = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug2()
    {
        T_InSuperDrug2.SetActive(false);
        Debug.Log("���°� ���� ����");
        GameManager.gameManager._gameData.IsMakeForest = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
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
