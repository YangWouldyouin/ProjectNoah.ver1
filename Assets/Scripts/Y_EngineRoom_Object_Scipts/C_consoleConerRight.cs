using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_consoleConerRight : MonoBehaviour, IInteraction
{

    private Button barkButton_C_consoleConerRight, sniffButton_C_consoleConerRight, biteButton_C_consoleConerRight, pushButton_C_consoleConerRight, observeButton_C_consoleConerRight;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData ConsoleCenterRObjData_C;
    public ObjectData ConsoleCenterRData_C;

    public GameObject CMS_GUI;

    // Start is called before the first frame update
    void Start()
    {
        ConsoleCenterRObjData_C = GetComponent<ObjData>();

        barkButton_C_consoleConerRight = ConsoleCenterRObjData_C.BarkButton;
        barkButton_C_consoleConerRight.onClick.AddListener(OnBark);

        sniffButton_C_consoleConerRight = ConsoleCenterRObjData_C.SniffButton;
        sniffButton_C_consoleConerRight.onClick.AddListener(OnSniff);

        biteButton_C_consoleConerRight = ConsoleCenterRObjData_C.BiteButton;
        biteButton_C_consoleConerRight.onClick.AddListener(OnBite);

        pushButton_C_consoleConerRight = ConsoleCenterRObjData_C.PushOrPressButton;
        pushButton_C_consoleConerRight.onClick.AddListener(OnPushOrPress);

        observeButton_C_consoleConerRight = ConsoleCenterRObjData_C.CenterButton1;
        observeButton_C_consoleConerRight.onClick.AddListener(OnObserve);
    }

    // Update is called once per frame
    void Update()
    {
        if (ConsoleCenterRObjData_C.IsObserve == false)
        {
            CMS_GUI.SetActive(false);
        }
    }
    void DiableButton()
    {
        barkButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        sniffButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        biteButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        pushButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        observeButton_C_consoleConerRight.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        InteractionButtonController.interactionButtonController.playerBark();
        DiableButton();
    }

    public void OnBite()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        ConsoleCenterRObjData_C.IsObserve = true;


        CMS_GUI.SetActive(true);

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* ī�޶� ��Ʈ�ѷ��� �� ���� */
        CameraController.cameraController.currentView = ConsoleCenterRObjData_C.ObserveView; // ���� �� : ����
        /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
        InteractionButtonController.interactionButtonController.playerObserve();


    }

    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
        ConsoleCenterRObjData_C.IsPushOrPress = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHead(); 

        /* 2�� �ڿ� IsPushOrPress �� false �� �ٲ� */
        StartCoroutine(ChangePressFalse());
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        ConsoleCenterRObjData_C.IsPushOrPress = false;
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

}
