using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData TabletData_C;
    public ObjectData Tablet_C;

    /* ��ȣ�ۿ� ������Ʈ */
    public GameObject TabletUI_C; // �º� UI
    public GameObject TabletBackBlack_C; // �º� ��Ȱ��ȭ ȭ�� (������Ʈ ���� ȭ��)
    public GameObject TabletBackOn_C; // �º� Ȱ��ȭ ȭ�� (�����ϱ� ȭ��)

/*    public GameObject FullEgPad_C; // ���� �� �����е�
    public GameObject ZeroEgPad_C; // ���� �� �� �����е�

    *//* ������Ʈ ������ *//*
    ObjData FullEgPadData_C; // ���� �� �����е�
    ObjData ZeroEgPadData_C; // ���� �� �� �����е�*/


/*    private float timer = 0f; // �º� ���� Ÿ�̸�
    public float DestroyTime = 5.0f; // �º��� AI�� �����ϱ���� �ɸ��� �ð�*/


    void Start()
    {
        TabletData_C = GetComponent<ObjData>();

        barkButton = TabletData_C.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = TabletData_C.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = TabletData_C.BiteButton;

        pressButton = TabletData_C.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = TabletData_C.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if (Tablet_C.IsObserve == false)
        {
            TabletUI_C.SetActive(false);
            TabletBackBlack_C.SetActive(true);
            TabletBackOn_C.SetActive(false);
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        TabletData_C.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = TabletData_C.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        if (GameManager.gameManager._gameData.IsFullChargeTablet == true) // �º� ���� O
        {
            Invoke("TabletOn", 3f);
            /*
             Ÿ�� ȭ�� ���� > ������� �� > Ÿ�� ������� = true;
            */
        }
        else // �º� ���� X
        {
            // ȭ�� ������ ����
        }
    }

    public void TabletOn()
    {
        TabletUI_C.SetActive(true);
        TabletBackBlack_C.SetActive(false);
        TabletBackOn_C.SetActive(true);
    }


    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }
    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }
}
