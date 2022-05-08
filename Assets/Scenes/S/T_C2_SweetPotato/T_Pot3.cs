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
    public GameObject T_IsGrownHealthy7;
    public GameObject T_IsGrownHealthy8;
    public GameObject T_IsGrownHealthy9;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_Pot3, sniffButton_T_Pot3, biteButton_T_Pot3, pressButton_T_Pot3, noCenterButton_T_Pot3;

    /*ObjData*/
    ObjData Pot3Data_T;
    public ObjectData InHealthySweetPotato3Data_T;
    public ObjectData InBadSweetPotato3Data_T;
    public ObjectData InSuperDrug3Data_T;
    public ObjectData IsFarmButton3Data_T;
    public ObjectData InUnGrownSweetPotato3Data_T;

    /*Collider*/
    BoxCollider Pot3_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot3Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot3_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot3 = Pot3Data_T.BarkButton;
        barkButton_T_Pot3.onClick.AddListener(OnBark);

        sniffButton_T_Pot3 = Pot3Data_T.SniffButton;
        sniffButton_T_Pot3.onClick.AddListener(OnSniff);

        biteButton_T_Pot3 = Pot3Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot3 = Pot3Data_T.PushOrPressButton;
        pressButton_T_Pot3.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot3 = Pot3Data_T.CenterButton1;
    }

    void Update()
    {
        /*���ڶ� ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot3InPotato && IsFarmButton3Data_T.IsPushOrPress)
        {
            //A-6 �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato3", 10f); //���� Ÿ������ 5�� �ڿ� �̸� ���� ���� ��Ų �������� ������ ���̰� �ȴ�.
        }

        /*���� ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot3InBadPotato && IsFarmButton3Data_T.IsPushOrPress)
        {
            //A-6 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*������ ������ �ɰ� && ����Ʈ�� ���� ��� ��ư�� �����ٸ�*/
        if (GameManager.gameManager._gameData.Pot3InHealthyPotato && IsFarmButton3Data_T.IsPushOrPress)
        {
            //A-6��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
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
        T_InUnGrownSweetPotato3.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void AppearSweetPotato3()
    {
        T_IsGrownHealthy7.SetActive(true);
        T_IsGrownHealthy8.SetActive(true);
        T_IsGrownHealthy9.SetActive(true);

        //A-7 �˸� ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*���� �Դ� �� ���� �ȵǰ� + �̹� �� �� ���� ������ �ٽ� �� �ɰ�*/
        Pot3_Collider.enabled = false;

        /*������ ��Ÿ�� ���¸� �����Ѵ�.*/
        GameManager.gameManager._gameData.IsCanSeePotato3 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void BadPotatoBye3()
    {
        T_InBadSweetPotato3.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InBadPotato = true; // ���� ���� ������� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye3()
    {
        T_InHealthySweetPotato3.SetActive(false);
        //A-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InHealthyPotato = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug3()
    {
        T_InSuperDrug3.SetActive(false);
        Debug.Log("���°� ���� ����");
        GameManager.gameManager._gameData.IsMakeForest = true; // �������� ���ϴ� �ű⶧���� ����
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
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
