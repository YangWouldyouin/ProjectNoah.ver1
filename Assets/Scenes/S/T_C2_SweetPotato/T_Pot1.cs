using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot1 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject T_InUnGrownSweetPotato1;
    public GameObject T_InHealthySweetPotato1;
    public GameObject T_InBadSweetPotato1;
    public GameObject T_InSuperDrug1;


    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_Pot1, sniffButton_T_Pot1, biteButton_T_Pot1, pressButton_T_Pot1, noCenterButton_T_Pot1;

    /*ObjData*/
    ObjData Pot1Data_T;
    public ObjectData InHealthySweetPotato1Data_T;
    public ObjectData InBadSweetPotato1Data_T;
    public ObjectData InSuperDrug1Data_T;
    public ObjectData IsFarmButton1Data_T;
    public ObjectData InUnGrownSweetPotato1Data_T;

    /*�ƿ�����*/

    /*Collider*/
    BoxCollider Pot1_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        Pot1Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot1_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot1 = Pot1Data_T.BarkButton;
        barkButton_T_Pot1.onClick.AddListener(OnBark);

        sniffButton_T_Pot1 = Pot1Data_T.SniffButton;
        sniffButton_T_Pot1.onClick.AddListener(OnSniff);

        biteButton_T_Pot1 = Pot1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot1 = Pot1Data_T.PushOrPressButton;
        pressButton_T_Pot1.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot1 = Pot1Data_T.CenterButton1;
    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_T_Pot1.transform.gameObject.SetActive(false);
        sniffButton_T_Pot1.transform.gameObject.SetActive(false);
        biteButton_T_Pot1.transform.gameObject.SetActive(false);
        pressButton_T_Pot1.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot1.transform.gameObject.SetActive(false);
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
        if(InUnGrownSweetPotato1Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown1", 2f);
            GameManager.gameManager._gameData.Pot1InPotato = true; // �ɰ� 5�� �� ä��� ���� ����� �߰�����
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*���� ������ ������ -> ������ ������� �ƹ��� ��ȭ�� ����.*/
        if (InBadSweetPotato1Data_T.IsBite)
        {
            Invoke("BadPotatoBye1", 2f);

        }

        /*�ǰ��� ������ �ɰ� �����Ŀ� �������� �Ѹ��� ���ο� ���°� ���� ����*/
        if(InHealthySweetPotato1Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye1", 2f);
        }

        if(GameManager.gameManager._gameData.Pot1InHealthyPotato && InSuperDrug1Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug1", 2f);
        }


    }

    void CanTSeeUnGrown1()
    {
        T_InUnGrownSweetPotato1.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }


    void BadPotatoBye1()
    {
        T_InBadSweetPotato1.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot1InBadPotato = true; // ���� ���� ������� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye1()
    {
        T_InHealthySweetPotato1.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot1InHealthyPotato = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug1()
    {
        T_InSuperDrug1.SetActive(false);
        Debug.Log("���°� ���� ����");
        GameManager.gameManager._gameData.IsMakeForestEnd = true; // �������� ���ϴ� �ű⶧���� ����
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
