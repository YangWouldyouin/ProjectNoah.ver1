using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader1 : MonoBehaviour, IInteraction
{
    public ObjectData planetRaderData;
    private Button barkButton, sniffButton, biteButton,
pressButton, observeButton;

    public GameObject CS_GUI;

    /* ������Ʈ ������ */
    ObjData planetRaderData_PR;

    /* Outline ���� */
    Outline planetRaderOutline_PR;


    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����

    void Start()
    {

        planetRaderData_PR = GetComponent<ObjData>();

        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
        barkButton = planetRaderData_PR.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = planetRaderData_PR.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = planetRaderData_PR.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = planetRaderData_PR.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = planetRaderData_PR.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);

        planetRaderOutline_PR = GetComponent<Outline>();

        //planetReportButton_PR.onClick.AddListener(ReportPlanet);
        //exitButton_PR.onClick.AddListener(ExitPlanetRader);
    }

    void Update()
    {
        if (planetRaderData.IsObserve == false)
        {
            CS_GUI.SetActive(false);
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

   public void OnObserve()
    {
        Debug.Log("����");

        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();

        /* ����� �� ������ ������Ʈ ���� */
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* ī�޶� ��Ʈ�ѷ��� �� ���� */
        //CameraController.cameraController.currentView = planetRaderData_PR.ObserveView; // ���� �� : ����
        /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
        //InteractionButtonController.interactionButtonController.playerObserve();

        /* ���������������������������������������� X-1��� ���� ���������������������������������������� */

        Invoke("secondsf", 3f);
    }

    public void secondsf() 
    {
        Debug.Log("�������˾�");
        CS_GUI.SetActive(true);
    }


    public void OnBark()
    {     
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
    }

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }



    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }
}
