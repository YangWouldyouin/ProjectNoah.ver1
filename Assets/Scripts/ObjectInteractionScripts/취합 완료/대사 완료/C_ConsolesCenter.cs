using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour, IInteraction
{
    [Header("< ������Ʈ ���� >")]

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ */
    public GameObject consoleCenter_CC;
    MeshCollider consoleCollider;
    
    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenterObjData_CC;

    public ObjectData consoleCenterData_CC;
    public ObjectData boxData_CC;
    public ObjectData envirPipeData_CC;
    public ObjectData consoleAIResetButtonData_CC;
    public ObjectData PictureButtonData_CC;


    /* ��Ÿ �ʿ��� ������ */
    public Outline consoleAIResetButtonOutline_CC;
    Outline consoleCenterOutline_CC;

    public Outline PictureButtonOutline_CC;
    Outline PictureOutline_CC;

    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public Button aiIcon_CC;

    public GameObject dontClick;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    float timer_CC = 0;
    private  Button barkButton_C_Console, sniffButton_C_Console, biteButton_C_Console, pressButton_C_Console, observeButton_C_Console;

    public Vector3 consoleRisePos;

    /*UI����*/
    public Canvas MainSystem_GUI;
    public GameObject TrackChangeNotification_GUI;

    //��Ʈ����
    public GameObject portDoor;
    ObjData portDoorData;
    Outline portDoorLine;
    public ObjectData portDoorDataOb;
    BoxCollider portDoorCol;

    GameData initialData;

    // Start is called before the first frame update
    void Start()
    {
        initialData =  SaveSystem.Load("save_001");
        consoleCollider = GetComponent<MeshCollider>();
        consoleCenterObjData_CC = GetComponent<ObjData>();

        consoleAIResetButtonOutline_CC.OutlineWidth = 0;
        PictureButtonOutline_CC.OutlineWidth = 0;

        portDoorCol = portDoor.GetComponent<BoxCollider>();

        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
        barkButton_C_Console = consoleCenterObjData_CC.BarkButton;
        barkButton_C_Console.onClick.AddListener(OnBark);

        sniffButton_C_Console = consoleCenterObjData_CC.SniffButton;
        sniffButton_C_Console.onClick.AddListener(OnSniff);

        biteButton_C_Console = consoleCenterObjData_CC.BiteButton;
        biteButton_C_Console.onClick.AddListener(OnBite);

        pressButton_C_Console = consoleCenterObjData_CC.PushOrPressButton;
        pressButton_C_Console.onClick.AddListener(OnPushOrPress);

        observeButton_C_Console = consoleCenterObjData_CC.CenterButton1;
        observeButton_C_Console.onClick.AddListener(OnObserve);

        dialogManager = dialogManager_CC.GetComponent<DialogManager>();

        if (!initialData.IsAIAwake_M_C1)
        {
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // ���� �ִ� ��ư� �����
            StartCoroutine(FadeCoroutine()); //ȭ���� �������
            Invoke("dontClickoff", 5f);
            aiIcon_CC.interactable = false;
        }
        else
        {
            dontClick.SetActive(false);
            fadeImage_CC.gameObject.SetActive(false);
            Color normalColor = aiIcon_CC.GetComponent<Image>().color;
            normalColor.a = 1.0f;
            aiIcon_CC.GetComponent<Image>().color = normalColor;
            aiIcon_CC.interactable = true;
        }
    }

    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim_CC.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsSleeping", false);
    }

    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon_CC.GetComponent<Image>().color;
        color.a = 0.5f;
        aiIcon_CC.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage_CC.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a >= 0)
        {
            fadeColor.a -= 0.01f;
            fadeImage_CC.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.0001f);
        }
        fadeImage_CC.gameObject.SetActive(false);
    }

    public void dontClickoff()
    {
        dontClick.SetActive(false);
    }

    void Update()
    {
        /* ��¿ �� ���� ������Ʈ��... */
        if(consoleCenterData_CC.IsObserve == false)
        {
            // AI ���� ��ư ��Ȱ��ȭ (���� ������Ʈ)
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            consoleAIResetButtonData_CC.IsNotInteractable = true;
            consoleCollider.enabled = true;
            MainSystem_GUI.gameObject.SetActive(false);

            portDoorCol.enabled = false;
            portDoorDataOb.IsNotInteractable = true;

            //Debug.Log("�ʰ� ������?");
        }



        else
        {
            consoleCollider.enabled = false;


            portDoorCol.enabled = true;
            portDoorDataOb.IsNotInteractable = false;
        }
        //if(GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet == true)
        //{
        //    TrackChangeNotification_GUI.SetActive(true);
        //    Invoke("TrackChangeGUI_popUp", 3f);
        //}
    }

    //public void TrackChangeGUI_popUp()
    //{
    //    TrackChangeNotification_GUI.SetActive(false);
    //}

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
    void DiableButton()
    {
        barkButton_C_Console.transform.gameObject.SetActive(false);
        sniffButton_C_Console.transform.gameObject.SetActive(false);
        biteButton_C_Console.transform.gameObject.SetActive(false);
        pressButton_C_Console.transform.gameObject.SetActive(false);
        observeButton_C_Console.transform.gameObject.SetActive(false);
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnObserve()
    {
        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        ////// AI ����� �̼� �Ϸ� ���̸� 
        //if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        //{
        //    /* �ӹ� ����Ʈ�� "AI �����" �̼� �߰� */
        //    MissionGenerator.missionGenerator.AddNewMission(0);
        //    //GameManager.gameManager._gameData.ActiveMissionList[0] = true;
        //    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //}
        //else
        //{
        //    /* �ӹ� ����Ʈ�� "AI �����" �̼� ���� */
        //    GameManager.gameManager._gameData.ActiveMissionList[3] = false;
        //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //}
        ///* �ӹ� ����Ʈ �ѹ� Ȱ��ȭ */
        //MissionGenerator.missionGenerator.ActivateMissionList();

        if (boxData_CC.IsUpDown) // ���ڿ� �ö����� 
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = consoleCenterObjData_CC.ObservePlusView; // ���� �� : ����
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
            InteractionButtonController.interactionButtonController.playerObserve();

            StartCoroutine(Delay3Seconds());
        }


        else // ���ڿ� �ö��� �ʾ�����
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = consoleCenterObjData_CC.ObserveView; // ���� �� : �Ʒ���
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
            InteractionButtonController.interactionButtonController.playerObserve();

        }
    }

    IEnumerator Delay3Seconds()
    {
        yield return new WaitForSeconds(3f);

        // ���� ��ǻ�� UI AI Ȱ��ȭ ������ ��
        GameData gameData = SaveSystem.Load("save_001");
        if(gameData.IsAIAwake_M_C1)
        {
            MainSystem_GUI.gameObject.SetActive(true);
        }
        
        consoleCollider.enabled = false;
        if (envirPipeData_CC.IsBite) // �������� ��������
        {
            consoleAIResetButtonData_CC.IsNotInteractable = false;
            consoleAIResetButtonOutline_CC.OutlineWidth = 8;
            PictureButtonData_CC.IsNotInteractable = false;
            PictureButtonOutline_CC.OutlineWidth = 8;

        }
        else // �������� ���� �ʾ�����
        {
            if (!gameData.IsAIAwake_M_C1||GameManager.gameManager._gameData.IsPhotoTime)
            {
                StartCoroutine(turnOffHint());
            }

            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            consoleAIResetButtonData_CC.IsNotInteractable = true;
            PictureButtonData_CC.IsNotInteractable = true;
            PictureButtonOutline_CC.OutlineWidth = 0;
        }
    }

    IEnumerator turnOffHint()
    {
        TMPro.TextMeshProUGUI objectText = BaseCanvas._baseCanvas.statText;
        objectText.text = "��ư�� ���� �ʽ��ϴ�.";
        GameObject hintPanel = BaseCanvas._baseCanvas.statPanel;
        hintPanel.SetActive(true);

        yield return new WaitForSeconds(3f);
        hintPanel.SetActive(false);
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* "����" �� �ȵǴ� ������Ʈ �� ��!! */

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* �б� & ������ �߿� "������"�� ��!!! */
    public void OnPushOrPress()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnBark()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnSniff()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnUp() // @@ ���� �ʿ��� @@
    {

    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnInsert()
    {
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {

    }


    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
