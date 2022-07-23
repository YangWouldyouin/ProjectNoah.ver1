using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert01 : MonoBehaviour, IInteraction
{

    /*    [Header("<�÷��̾��� �ƿ������� ������>")]
        public NoahOutlineController outlineController;
        NoahOutlineController outlineControl;*/

    //AI ����
    public Button aiIcon_AI;

    //Ÿ�̸�
    public InGameTime inGameTime;


    //���� �ֵ�
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData insertData;
    Outline insertLine;

    public ObjectData RChipData;
    public ObjectData WChipData;

    public GameObject RChip01;
    ObjData RChip01Data;
    Outline RChip01Line;

    /*
    public GameObject RChip02;
    ObjData RChip02Data;
    Outline RChip02Line;
    */

    public GameObject WChip01;
    ObjData WChip01Data;
    Outline WChip01Line;

    /*
    public GameObject WChip02;
    ObjData WChip02Data;
    Outline WChip02Line;
    */

    public GameObject dialog;
    DialogManager dialogManager;

    GameObject portableGroup;
    PlayerEquipment playerEquipmentStrange;
    PortableObjectData controlData;
    void Start()
    {
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        playerEquipmentStrange = BaseCanvas._baseCanvas.equipment;
        controlData = BaseCanvas._baseCanvas.controlRoomData;

        dialogManager = dialog.GetComponent<DialogManager>();

        insertData = GetComponent<ObjData>();
        insertLine = GetComponent<Outline>();

        RChip01Data = RChip01.GetComponent<ObjData>();
        RChip01Line = RChip01.GetComponent<Outline>();

        //RChip02Data = RChip02.GetComponent<ObjData>();
        //RChip02Line = RChip02.GetComponent<Outline>();

        WChip01Data = WChip01.GetComponent<ObjData>();
        WChip01Line = WChip01.GetComponent<Outline>();

        //WChip02Data = WChip02.GetComponent<ObjData>();
        //WChip02Line = WChip02.GetComponent<Outline>();

        barkButton = insertData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = insertData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = insertData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = insertData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = insertData.CenterButton1;
        noCenterButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        //�̼� �Ϸ� ���� && Ÿ�̸� ���� && �̼� ������
        if (inGameTime.IsGoToEarthMissionClear == false && inGameTime.IsGoToEarthMissionStart)
        {

            StartCoroutine(failMission());
            /*Color AIColor = aiIcon_AI.GetComponent<Image>().color;
            AIColor.a = 1.0f;
            aiIcon_AI.GetComponent<Image>().color = AIColor;
            aiIcon_AI.interactable = true;*/
        }

        //�˵����� �����ϸ� �׸��� Update�� �ݺ� ���Ƽ� ���߿� ���� �ʱ�ȭ �����ұ�� �����ϳ��� �������� �ɾ ���̻� �ȵ���
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet 
            && GameManager.gameManager._gameData.IsAIAfterMissionComplete == false)
        {
            inGameTime.IsGoToEarthMissionClear = true;
            GameManager.gameManager._gameData.IsAIAfterMissionComplete = true;
        }

            // �̼� �Ϸ��� && Ÿ�̸� ������ ����
        if (inGameTime.IsGoToEarthMissionClear && inGameTime.IsTimerStarted)
        {
            Debug.Log("�̼� ����");
            //inGameTime.IsNoahOutlineTurnOn = false;
            //inGameTime.IsTimerStarted = false;
            //inGameTime.missionTimer = 0;
        }
    }


    IEnumerator failMission()
    {


        if(inGameTime.IsTimerStarted == false)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("�̼� ����");
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else
        {
            yield return null;
        }
    }
    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        insertData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        insertData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        insertData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (RChipData.IsBite)
        {
            Debug.Log("AI���");

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(59));

            GameManager.gameManager._gameData.IsAIDown = true;
            GameManager.gameManager._gameData.IsAIDown_M_C1C3 = true;
            GameManager.gameManager._gameData.IsStartOrbitChange = true;
            //GameManager.gameManager._gameData.ActiveMissionList[9] = false;
            //GameManager.gameManager._gameData.ActiveMissionList[12] = true;
            //MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.DeleteNewMission(9);
            StartCoroutine(Delay2Sec());

            inGameTime.IsGoToEarthMissionClear1 = true;
            inGameTime.IsTimerStarted = false;

            Invoke("AIDown", 20f);

            Invoke("NoChip", 0.5f);

            //AI �ٿ� �� �˵� ���� �̼� ����
            StartCoroutine(NewTimerStart());
            //Invoke("NewTimerStart", 2f);
        }

        /*if (WChipData.IsBite)
        {
            Debug.Log("AI�����");

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(60));

            Invoke("NoChip", 0.5f);
        }*/
    }

    IEnumerator Delay2Sec()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(12);
    }
    public void AIDown()
    {
        Color AIColor = aiIcon_AI.GetComponent<Image>().color;
        AIColor.a = 0.5f;
        aiIcon_AI.GetComponent<Image>().color = AIColor;
        aiIcon_AI.interactable = false;
        // AI ��� �ȳ���
        inGameTime.IsAIAwake = false;
        //GameManager.gameManager._gameData.IsAIAwake_M_C1 = false;
    }



   IEnumerator NewTimerStart()
    {
        yield return new WaitForSeconds(2f);
        /* AI�� �ٿ�ǰ� ���� �̼� ���� : ���� �ð� 5��*/
        TimerManager.timerManager.TimerStart(300);
        //outlineControl.StartOutlineTime(300f);
        inGameTime.IsGoToEarthMissionStart = true;
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    void NoChip() // Ĩ �ȾƼ� ��Ȱ��ȭ
    {
        Debug.Log("Ĩ �Ⱦ���");

        if (RChipData.IsBite)
        {
            RChipData.IsBite = false;

            RChip01Data.GetComponent<Rigidbody>().isKinematic = false;
            RChip01Data.transform.parent = null;
            RChip01Data.transform.parent = portableGroup.transform;
            playerEquipmentStrange.biteObjectName = "";

            RChip01Data.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            RChip01Data.transform.position = new Vector3(-37.901f, 0.853f, -30.362f);
            RChip01Data.transform.rotation = Quaternion.Euler(-90, 0, 0);

            RChip01Data.IsNotInteractable = false;
            RChip01Line.OutlineWidth = 0;

            insertData.IsNotInteractable = false;
            insertLine.OutlineWidth = 0;

        }

        /*if (WChipData.IsBite)
        {
            WChipData.IsBite = false;

            WChip01Data.GetComponent<Rigidbody>().isKinematic = false;
            WChip01Data.transform.parent = null;
            RChip01Data.transform.parent = portableGroup.transform;
            playerEquipmentStrange.biteObjectName = "";

            WChip01Data.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            WChip01Data.transform.position = new Vector3(-37.901f, 0.853f, -30.362f);
            WChip01Data.transform.rotation = Quaternion.Euler(-90, 0, 0);

            WChip01Data.IsNotInteractable = false;
            WChip01Line.OutlineWidth = 0;

            insertData.IsNotInteractable = false;
            insertLine.OutlineWidth = 0;
        }*/
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

}
