using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachinePlate : MonoBehaviour, IInteraction
{
    public GameObject Report_GUI;
    private bool IsReported = false;

    /*연관있는 오브젝트*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    //public GameObject T_AreRubber;

    /*오브젝트의 상호작용 버튼들*/
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
            T_RealNormalMeteor1.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            T_RealNormalMeteor1.transform.parent = null;
            playerEquipment.biteObjectName = "";
            T_RealNormalMeteor1.transform.position = new Vector3(-254.667f, 2.2122f, 690.674f);
            T_RealNormalMeteor1.transform.parent = portableGroup.transform;

            GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // 운석 조각 수집 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧

            /*죽은 척하기 임무시작 가능하다*/
            StartCoroutine(StartPretendDead());
            //Invoke("StartPretendDead", 100);

            Invoke("Report_Popup", 4f);

            //상호작용을 꺼준다.

            RealNormalMeteor1Data_T.IsNotInteractable = true; // 상호작용 불가능하게
            RealNormalMeteor1Outline_T.OutlineWidth = 0;

            GameManager.gameManager._gameData.ActiveMissionList[22] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }


        if(RealimportantMeteorData_T.IsBite)
        {
            /*중요 운석을 넣었는지 확인*/
            GameManager.gameManager._gameData.IsReportImportantMeteor_T_C2 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //C-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(45));

            T_RealImportantMeteor.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            T_RealImportantMeteor.transform.parent = null;

            T_RealImportantMeteor.transform.position = new Vector3(-254.667f, 2.2122f, 690.674f);
            T_RealImportantMeteor.transform.parent = portableGroup.transform;
            playerEquipment.biteObjectName = "";
            Invoke("Report_Popup", 4f);

            //상호작용을 꺼준다.

            RealimportantMeteorData_T.IsNotInteractable = true; // 상호작용 불가능하게
            RealimportantMeteorOutline_T.OutlineWidth = 0;
        }

        
    }

    IEnumerator StartPretendDead()
    {
        yield return new WaitForSeconds(100f);
        GameManager.gameManager._gameData.IsStartPretendDead = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //D-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(55));

        // 죽은척하기 임무리스트 시작 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
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
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //보고하기 데이터 이동
        //else 더미 데이터 이동

        Debug.Log("보고하기");
        IsReported = true;
        Report_GUI.SetActive(false);

        if (GameManager.gameManager._gameData.IsReportImportantMeteor_T_C2 == true)
        {
            GameManager.gameManager._gameData.IsInputImportantMeteorEnd = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("지구귀환엔딩");
        }
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //cancleCount += 1;
        GameManager.gameManager._gameData.IsReportCancleCount += 1;

        Debug.Log("취소하기");
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
