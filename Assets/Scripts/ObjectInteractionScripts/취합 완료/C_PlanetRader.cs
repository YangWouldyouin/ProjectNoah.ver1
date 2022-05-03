using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pressButton, observeButton;

    BoxCollider raderCollider;



    /* ������Ʈ */
    public GameObject leftButton_PR; // ���� ��ư
    public GameObject rightButton_PR; // ������ ��ư
    public GameObject confirmButton_PR; // Ȯ�ι�ư

    public GameObject ob;

    /* Ȯ�� ���� �� ������ ȭ�� (UI) */
    public Image raderLine_PR; // ���̴� ����

    public Image[] normalPlanet_PR; // �༺
    public Image[] selectPlanet_PR; // ������ �༺
    public Image[] fakePlanet_PR; // ��¥ �༺

    public TMPro.TextMeshProUGUI exploreText;

    public Image[] planetInfo_PR; // �༺ ���� �̹���

    public Button planetReportButton_PR; //�༺ ���� ��ư
    public Button exitButton_PR; // ���� ��ư
    public GameObject interactBtn1;
    /* ������Ʈ ������ */
    ObjData planetRaderData_PR;
    ObjData leftButtonData_PR;
    ObjData rightButtonData_PR;
    ObjData confirmButtonData_PR;

    /* Outline ���� */
    Outline planetRaderOutline_PR;
    Outline leftButtonOutline_PR;
    Outline rightButtonOutline_PR;
    Outline confirmButtonOutline_PR;

    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����
    float timer_PR = 0;
    float exploreTimer = 0;

    public bool PlanetExploration_PR = false; // �༺ Ž�� ����
    
    private bool PlanetExplorationTimeStart_PR = false; // �༺ Ž�� �ҿ� �ð� ���� ����
    public bool FakePlanet_PR = false; // ���� �༺ ����

    private float PlanetDistance_PR; // �༺�� ���̴� ���� �Ÿ�

    private float PlanetExplorationTime_PR = 5.0f; // �༺ Ž�� �ҿ� �ð�

    private float PlanetInfoTime_PR = 3.0f; // �༺ ���� �˾� �ð�

    Vector3 recentAngle;

    void Start()
    {

        raderCollider = GetComponent<BoxCollider>();
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


        leftButtonOutline_PR = leftButton_PR.GetComponent<Outline>();
        rightButtonOutline_PR = rightButton_PR.GetComponent<Outline>();
        confirmButtonOutline_PR = confirmButton_PR.GetComponent<Outline>();
        planetRaderOutline_PR = GetComponent<Outline>();

        //planetReportButton_PR.onClick.AddListener(ReportPlanet);
        //exitButton_PR.onClick.AddListener(ExitPlanetRader);

        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
   
    }






    void ReportPlanet()
    {
        exploreText.text = "A �༺ ���� �Ϸ�";
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);




        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;

        PlanetExplorationTime_PR = 5.0f;

        raderLine_PR.transform.gameObject.SetActive(false);
        // ��� �༺ ��Ȱ��ȭ
        for (int i = 0; i < 6; i++)
        {
            normalPlanet_PR[i].transform.gameObject.SetActive(false);
        }
    }

    void ExitPlanetRader()
    {
        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;
        PlanetExplorationTime_PR = 5.0f;

        exploreText.transform.gameObject.SetActive(false); // Ž�������� ��Ȱ��ȭ
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);
        timer_PR = 0;
        CameraController.cameraController.CancelObserve();
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
        raderCollider.enabled = false;
        /* ������Ʈ�� ���� ���� true�� �ٲ� */
        planetRaderData_PR.IsObserve = true;
        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* ī�޶� ��Ʈ�ѷ��� �� ���� */
        CameraController.cameraController.currentView = planetRaderData_PR.ObserveView; // ���� �� : ����
        /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
        InteractionButtonController.interactionButtonController.playerObserve();
    }




    public void OnBark()
    {     
        planetRaderData_PR.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ������Ʈ�� �����ñ� ���� true�� �ٲ� */
        planetRaderData_PR.IsSniff = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
        planetRaderData_PR.IsPushOrPress = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        /* 2�� �ڿ� Ispushorpress �� false �� �ٲ� */
        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        planetRaderData_PR.IsPushOrPress = false;
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
