using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Cabinet3 : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Cabinet3, sniffButton_W_Cabinet3, biteButton_W_Cabinet3,
pushButton_W_Cabinet3, observeButton_W_Cabinet3, smashButton_W_Cabinet3;

    ObjData Cabinet3_W, Card_KeyData_W_C3;

    /* ��� ������Ʈ */
    public GameObject Card_Key_W_C3; // ī��Ű


    /* ������Ʈ �ƿ����� */
    private Outline Cabinet3Outline_M; // ĳ���

    private Outline Card_Key3Outline_M; // ĳ���

    void Start()
    {
        /* ��� ������Ʈ ������ �ҷ����� */
        Cabinet3_W = GetComponent<ObjData>();
        Card_KeyData_W_C3 = Card_Key_W_C3.GetComponent<ObjData>();
        Card_Key3Outline_M = Card_Key_W_C3.GetComponent<Outline>(); // ������Ʈ �ƿ�����

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_W_Cabinet3 = Cabinet3_W.BarkButton;
        barkButton_W_Cabinet3.onClick.AddListener(OnBark); // ��ư�� �Լ��� �־��ش�

        sniffButton_W_Cabinet3 = Cabinet3_W.SniffButton;
        sniffButton_W_Cabinet3.onClick.AddListener(OnSniff);

        biteButton_W_Cabinet3 = Cabinet3_W.BiteButton;
        biteButton_W_Cabinet3.onClick.AddListener(OnBite);

        pushButton_W_Cabinet3 = Cabinet3_W.PushOrPressButton;
        pushButton_W_Cabinet3.onClick.AddListener(OnPushOrPress);

        observeButton_W_Cabinet3 = Cabinet3_W.CenterButton1; // CenterButton1�� '�����ϱ�'��ư ����
        observeButton_W_Cabinet3.onClick.AddListener(OnObserve);

        Card_Key_W_C3.SetActive(false); // ī��Ű �����ϱ� ���� �Ⱥ��̰�
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton()
    {
        barkButton_W_Cabinet3.transform.gameObject.SetActive(false);
        sniffButton_W_Cabinet3.transform.gameObject.SetActive(false);
        biteButton_W_Cabinet3.transform.gameObject.SetActive(false);
        pushButton_W_Cabinet3.transform.gameObject.SetActive(false);
        observeButton_W_Cabinet3.transform.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Cabinet3_W.IsObserve == false && Card_KeyData_W_C3.IsInsert == false) // ĳ��� �����ϱ�, ĳ��� 
        {
            /* ī��Ű ��Ȱ��ȭ */
            Card_Key3Outline_M.OutlineWidth = 0;
            Card_KeyData_W_C3.IsNotInteractable = true;
        }
    }


    public void OnBark()
    {
        Cabinet3_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }


    /* ���������������������������������������� ���� ���� ���������������������������������������� */
    public void OnObserve()
    {
        Cabinet3_W.IsObserve = true;
        DiableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        CameraController.cameraController.currentView = Cabinet3_W.ObserveView; // ���� �� : ����
        InteractionButtonController.interactionButtonController.playerObserve(); // ���� �ִϸ��̼� & ī�޶� ��ȯ


        /* ī��Ű ������Ʈ Ȱ��ȭ */
        Card_Key3Outline_M.OutlineWidth = 8; // ī��Ű �ƿ����� Ȱ��ȭ
        Card_KeyData_W_C3.IsNotInteractable = false;

        Card_Key_W_C3.SetActive(true); // ī��Ű ������Ʈ ���̰�

        GameManager.gameManager._gameData.IsCompleteFindLivingKey = true;
        GameManager.gameManager._gameData.ActiveMissionList[2] = false;
        GameManager.gameManager._gameData.ActiveMissionList[4] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

    }

    public void OnPushOrPress()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        Cabinet3_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }
    public void OnInsert()
    {
    }
    public void OnEat()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }

}