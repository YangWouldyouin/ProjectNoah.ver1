using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton, DiableButton;

    PlayerEquipment equipment;
    GameObject portableGroup;

    ObjData TabletData_C;
    public ObjectData Tablet_C;

    /* ��ȣ�ۿ� ������Ʈ */
    public GameObject TabletUI_C; // �º� UI
    public GameObject TabletBackBlack_C; // �º� ��Ȱ��ȭ ȭ�� (������Ʈ ���� ȭ��)
    public GameObject TabletBackOn_C; // �º� Ȱ��ȭ ȭ�� (�����ϱ� ȭ��)
    public GameObject TabletBatteryUI_C; // ���� �� 0% ȭ��
    public GameObject TabletDeleteUI_C; // AI �߰� �� ������ ���� ȭ��

    public GameObject LoverPic_C; // ���� ����
    public GameObject FullEgPad_C; // ���� �� �����е�
    // public GameObject ZeroEgPad_C; // ���� �� �� �����е�

    /* ������Ʈ ������ */
    public ObjectData LoverPicData_C;
    public ObjectData FullEgPadData_C; // ���� �� �����е�
    // ObjData ZeroEgPadData_C; // ���� �� �� �����е�


    /*    private float timer = 0f; // �º� ���� Ÿ�̸�
        public float DestroyTime = 5.0f; // �º��� AI�� �����ϱ���� �ɸ��� �ð�*/


    void Start()
    {
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
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

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        DiableButton = TabletData_C.CenterButton1;

        // ���࿡ ���� �Ϸ� ������ ���̸� �º� ȭ���� �Ѱڴ� �߰��ؾ���
        //intialGameData GameManager.gameManager._gameData.IsFullChargeTablet == true
        // GameManager.gameManager._gameData.IsTabletUnlock = false;

        Tablet_C.IsObserve = false;
    }

    void Update()
    {
        if (Tablet_C.IsObserve == false)
        {
            TabletUI_C.SetActive(false);
            TabletBackBlack_C.SetActive(true);
            TabletBackOn_C.SetActive(false);
            TabletBatteryUI_C.SetActive(false);
            TabletDeleteUI_C.SetActive(false);
        }
        if(GameManager.gameManager._gameData.IsFullChargeTablet == false)
        {
            FullEgPad_C.gameObject.SetActive(true);
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        DiableButton.transform.gameObject.SetActive(false);
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
        GameData intialGameData = SaveSystem.Load("save_001");
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = TabletData_C.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

/*        if (intialGameData.IsFullChargeTablet) // �º� ���� O
        {
            Invoke("TabletOn", 3f);
            *//*
             Ÿ�� ȭ�� ���� > ������� �� > Ÿ�� ������� = true;
            *//*
        }*/

        if (intialGameData.IsTabletDestory)
        {
            Invoke("TabletDelete", 3f); 
        }
        else
        {
            if (intialGameData.IsFullChargeTablet)
            {
                Invoke("TabletOn", 3f);

                //Ÿ�� ȭ�� ���� > ������� �� > Ÿ�� ������� = true;
            }
            else // �º� ���� X
            {
                Invoke("TabletOff", 3f);
                // ȭ�� ������ ����
            }
        }


        if (LoverPicData_C.IsBite)
        {
            GameManager.gameManager._gameData.IsTabletUnlock = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //Invoke("TabletLockOff", 1f);
            Debug.Log("�º� �������");
        }
        /*else
        {
            GameManager.gameManager._gameData.IsTabletUnlock = false;
            // SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }*/
    }

    public void TabletOn()
    {
        TabletUI_C.SetActive(true);
        TabletBackBlack_C.SetActive(false);
        TabletBackOn_C.SetActive(true);
        TabletBatteryUI_C.SetActive(false);
        TabletDeleteUI_C.SetActive(false);
        Debug.Log("ȭ������");
    }

    public void TabletOff()
    {
        TabletBatteryUI_C.SetActive(true);
    }

    public void TabletDelete()
    {
        TabletDeleteUI_C.SetActive(true);
    }

    public void TabletLockOff()
    {
        GameManager.gameManager._gameData.IsTabletUnlock = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    public void OnPushOrPress()
    {
        /* �б� & ������ �߿� "������"�� ��!!! */
        FullEgPadData_C.IsPushOrPress = true;// ������Ʈ�� ���� ���� true�� �ٲ�
        DisableButton(); // ��ȣ�ۿ� ��ư�� ��

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        // ����� ����
        // �θ� �ڽ� ���踦 �����Ѵ�.
        FullEgPad_C.GetComponent<Rigidbody>().isKinematic = false;
        FullEgPad_C.transform.parent = null;

        FullEgPad_C.SetActive(false);
        FullEgPad_C.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";

        Debug.Log("�����Ϸ�");
        GameManager.gameManager._gameData.IsFullChargeTablet = true; // �º� ���� ��
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        Debug.Log("�������̺� �Ϸ�");
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FullEgPadData_C.IsPushOrPress = false;

        // FullEgPad_C.gameObject.SetActive(false);
        //Debug.Log("�����е� ��Ȱ��ȭ");

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
