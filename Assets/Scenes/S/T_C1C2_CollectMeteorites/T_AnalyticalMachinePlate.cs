using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachinePlate : MonoBehaviour, IInteraction
{
    public GameObject Report_GUI;
    private bool IsReported = false;

    /*�����ִ� ������Ʈ*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    //public GameObject T_AreRubber;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_AnalyticalMachineButton, sniffButton_T_AnalyticalMachineButton, biteButton_T_AnalyticalMachineButton,
        pressButton_T_AnalyticalMachineButton, noCenterButton_T_AnalyticalMachineButton;

    /*ObjData*/
    ObjData analyticalMachinePlateObjData_T;

    public ObjectData RealNormalMeteor1Data_T;
    public ObjectData RealimportantMeteorData_T;
    //public ObjectData areRubberData_T;

    /*Outline*/
    Outline RealNormalMeteor1Outline_T;
    Outline RealimportantMeteorOutline_T;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    PlayerEquipment playerEquipment;

    GameObject portableGroup;

    // Start is called before the first frame update
    void Start()
    {
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        playerEquipment = BaseCanvas._baseCanvas.equipment;
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        /*ObjData*/
        analyticalMachinePlateObjData_T = GetComponent<ObjData>();

        /*Outline*/
        RealNormalMeteor1Outline_T = T_RealNormalMeteor1.GetComponent<Outline>();
        RealimportantMeteorOutline_T = T_RealImportantMeteor.GetComponent<Outline>();


        barkButton_T_AnalyticalMachineButton = analyticalMachinePlateObjData_T.BarkButton;
        barkButton_T_AnalyticalMachineButton.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachineButton = analyticalMachinePlateObjData_T.SniffButton;
        sniffButton_T_AnalyticalMachineButton.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachineButton = analyticalMachinePlateObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachineButton = analyticalMachinePlateObjData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachineButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_AnalyticalMachineButton = analyticalMachinePlateObjData_T.CenterButton1;
    }

    void Update()
    {
/*        if(GameManager.gameManager._gameData.IsStartPretendDead)
        {

        }*/
    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        noCenterButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        if(RealNormalMeteor1Data_T.IsBite)
        {
            T_RealNormalMeteor1.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            T_RealNormalMeteor1.transform.parent = null;
            playerEquipment.biteObjectName = "";
            T_RealNormalMeteor1.transform.position = new Vector3(-254.667f, 2.2122f, 690.674f);
            T_RealNormalMeteor1.transform.parent = portableGroup.transform;

            GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // � ���� ���� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������

            /*���� ô�ϱ� �ӹ����� �����ϴ�*/
            StartCoroutine(StartPretendDead());
            //Invoke("StartPretendDead", 100);

            Invoke("Report_Popup", 4f);

            //��ȣ�ۿ��� ���ش�.

            RealNormalMeteor1Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            RealNormalMeteor1Outline_T.OutlineWidth = 0;

            GameManager.gameManager._gameData.ActiveMissionList[22] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }


        if(RealimportantMeteorData_T.IsBite)
        {
            /*�߿� ��� �־����� Ȯ��*/
            GameManager.gameManager._gameData.IsReportImportantMeteor_T_C2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //C-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(45));

            T_RealImportantMeteor.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            T_RealImportantMeteor.transform.parent = null;

            T_RealImportantMeteor.transform.position = new Vector3(-254.667f, 2.2122f, 690.674f);
            T_RealImportantMeteor.transform.parent = portableGroup.transform;
            playerEquipment.biteObjectName = "";
            Invoke("Report_Popup", 4f);

            //��ȣ�ۿ��� ���ش�.

            RealimportantMeteorData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            RealimportantMeteorOutline_T.OutlineWidth = 0;
        }

        
    }

    IEnumerator StartPretendDead()
    {
        yield return new WaitForSeconds(100f);
        GameManager.gameManager._gameData.IsStartPretendDead = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //D-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(55));

        // ����ô�ϱ� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
        GameManager.gameManager._gameData.ActiveMissionList[11] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void Report_Popup()
    {
        if (IsReported)
        {
            Report_GUI.SetActive(false);
        }
        else
        {
            Report_GUI.SetActive(true);
        }
    }

    public void Report()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //�����ϱ� ������ �̵�
        //else ���� ������ �̵�

        Debug.Log("�����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);

        if (GameManager.gameManager._gameData.IsReportImportantMeteor_T_C2 == true)
        {
            GameManager.gameManager._gameData.IsInputImportantMeteorEnd = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("������ȯ����");
        }
    }

    public void Cancle()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //cancleCount += 1;
        GameManager.gameManager._gameData.IsReportCancleCount += 1;

        Debug.Log("����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);
    }
    public void OnBite()
    {
       
    }

    public void OnEat()
    {
       
    }

    public void OnInsert()
    {
        
    }

    public void OnObserve()
    {
        
    }

    public void OnSmash()
    {

    }

    public void OnUp()
    {
      
    }
}
