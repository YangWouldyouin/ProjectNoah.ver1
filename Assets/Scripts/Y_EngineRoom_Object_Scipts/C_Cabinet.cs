using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cabinet : MonoBehaviour, IInteraction
{

    private Button barkButton_C_Cabinet, sniffButton_C_Cabinet, biteButton_C_Cabinet, pushButton_C_Cabinet, observeButton_C_Cabinet;

    /* �ش� ������Ʈ�� ObjData ���� */
    public ObjectData cabinetData;

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

        if(!GameManager.gameManager._gameData.IsPipeFound_M_C1)
        {
            pipe.SetActive(false);
        }
        
        cabinetBoxC = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(cabinetData.IsObserve == false)
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
        cabinetBoxC.enabled = false;
        pipe.SetActive(true);
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
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHead(); 
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
