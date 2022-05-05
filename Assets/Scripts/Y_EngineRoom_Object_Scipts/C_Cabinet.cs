using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cabinet : MonoBehaviour, IInteraction
{

    private Button barkButton_C_Cabinet, sniffButton_C_Cabinet, biteButton_C_Cabinet, pushButton_C_Cabinet, observeButton_C_Cabinet;

    /* �ش� ������Ʈ�� ObjData ���� */
    ObjData CabinetData_C;

    BoxCollider cabinetBoxC;

    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        CabinetData_C = GetComponent<ObjData>();

        barkButton_C_Cabinet = CabinetData_C.BarkButton;
        barkButton_C_Cabinet.onClick.AddListener(OnBark);

        sniffButton_C_Cabinet = CabinetData_C.SniffButton;
        sniffButton_C_Cabinet.onClick.AddListener(OnSniff);

        biteButton_C_Cabinet = CabinetData_C.BiteButton;
        biteButton_C_Cabinet.onClick.AddListener(OnBite);

        pushButton_C_Cabinet = CabinetData_C.PushOrPressButton;
        pushButton_C_Cabinet.onClick.AddListener(OnPushOrPress);

        observeButton_C_Cabinet = CabinetData_C.CenterButton1;
        observeButton_C_Cabinet.onClick.AddListener(OnObserve);

        pipe.SetActive(false);

        cabinetBoxC = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(CabinetData_C.IsObserve == false)
        {
            cabinetBoxC.enabled = true;
        }
    }
    // Update is called once per frame
    void DiableButton()
    {
        barkButton_C_Cabinet.transform.gameObject.SetActive(false);
        sniffButton_C_Cabinet.transform.gameObject.SetActive(false);
        biteButton_C_Cabinet.transform.gameObject.SetActive(false);
        pushButton_C_Cabinet.transform.gameObject.SetActive(false);
        observeButton_C_Cabinet.transform.gameObject.SetActive(false);
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
        CabinetData_C.IsObserve = true;
        pipe.SetActive(true);
        cabinetBoxC.enabled = false;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        /* ī�޶� ��Ʈ�ѷ��� �� ���� */
        CameraController.cameraController.currentView = CabinetData_C.ObserveView; // ���� �� : ����

        /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
        InteractionButtonController.interactionButtonController.playerObserve();

    }

    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
        CabinetData_C.IsPushOrPress = true;

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
        CabinetData_C.IsPushOrPress = false;
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