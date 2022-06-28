using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, 
        biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;
    ObjectData healthMachineData;

    public ObjectData healthMachineFixPartData;
    public GameObject healthMachineFixPart_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    Animator reportAnim;
    public GameObject DontMove;

    public CancelInteractions cancelInteractions;

    public InGameTime inGameTime;

    //public bool HealthDataReportbool;
    //public bool MissionScriptCheck =false;

    AudioSource Health_Machine_Sound;
    public AudioClip Health_Machine_cheak;

    GameObject portableGroup; // 다시 포터블 그룹의 자식으로 넣어주기 위함
    PlayerEquipment playerEquipment;

    void Start()
    {
        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineData = Health_MachineData_W.objectDATA;

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_Health_Machine = Health_MachineData_W.BarkButton;
        barkButton_W_Health_Machine.onClick.AddListener(OnBark);

        sniffButton_W_Health_Machine = Health_MachineData_W.SniffButton;
        sniffButton_W_Health_Machine.onClick.AddListener(OnSniff);

        biteButton_W_Health_Machine = Health_MachineData_W.BiteButton;
        biteButton_W_Health_Machine.onClick.AddListener(OnBite);

        pushButton_W_Health_Machine = Health_MachineData_W.PushOrPressButton;
        pushButton_W_Health_Machine.onClick.AddListener(OnPushOrPress);

        upButton_W_Health_Machine = Health_MachineData_W.CenterButton1;
        upButton_W_Health_Machine.onClick.AddListener(OnUp);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        upDisableButton_W_Health_Machine = Health_MachineData_W.CenterDisableButton1;

        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();


        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        playerEquipment = BaseCanvas._baseCanvas.equipment;

        reportAnim = Report_GUI.GetComponent<Animator>();

        Health_Machine_Sound = GetComponent<AudioSource>();

        dialogManager = dialogManager_HM.GetComponent<DialogManager>();
    }

    void Update()
    {
        //if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10 && (inGameTime.days +1) >= 3)
        //{
        //    GameManager.gameManager._gameData.IsAIReportMissionTime = true;
        //    GameManager.gameManager._gameData.IsRM_HealthDataReportbool = false;

        //    if (GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck == false)
        //    {
        //        Debug.Log("상태 체크 정기 업무 시작");
        //        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(62));
        //        GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = true;
        //        //중간데이터보고 임무 시작

        //        GameManager.gameManager._gameData.ActiveMissionList[14] = true;
        //        MissionGenerator.missionGenerator.ActivateMissionList();
        //        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //    }

        //}

        //if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && GameManager.gameManager._gameData.IsRM_HealthDataReportbool == false)
        //{
        //    GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        //    //GameManager.gameManager._gameData.IsRM_HealthDataReportbool = false;

        //    if (GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck == true)
        //    {
        //        Debug.Log("상태 체크 정기 업무 종료");
        //        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
        //        GameManager.gameManager._gameData.IsReportCancleCount += 1;

        //        GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = false;
        //        //중간데이터보고 임무 끝

        //        GameManager.gameManager._gameData.ActiveMissionList[14] = false;
        //        MissionGenerator.missionGenerator.ActivateMissionList();
        //        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //    }

        //}

        if (GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 == true)
        {
            healthMachineData.IsCenterButtonDisabled = false;
        }

    }

    void DiableButton()
    {
        barkButton_W_Health_Machine.transform.gameObject.SetActive(false);
        sniffButton_W_Health_Machine.transform.gameObject.SetActive(false);
        biteButton_W_Health_Machine.transform.gameObject.SetActive(false);
        pushButton_W_Health_Machine.transform.gameObject.SetActive(false);
        upButton_W_Health_Machine.transform.gameObject.SetActive(false);
        upDisableButton_W_Health_Machine.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (healthMachineFixPartData.IsBite) // 부품을 물었으면
        {
            StartCoroutine(HealthMachhineDone());
            //Invoke("HealthMachhineDone", 1.5f);
        }
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        DiableButton();

        if (!healthMachineData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기 변수 true 로 바꿈 */
            healthMachineData.IsUpDown = true;

            /* 실제 노아가 이동할 오르기 위치 좌표에 x, z 값을 넣음 */
            healthMachineRisePos.x = Health_MachineData_W.UpPos.position.x;
            healthMachineRisePos.z = Health_MachineData_W.UpPos.position.z;

            /* 오르기 애니메이션 1/2 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* 오르기 위치 좌표를 보냄 */
            InteractionButtonController.interactionButtonController.risePosition = healthMachineRisePos;
            /* 나머지 오르기 애니메이션 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise2();

            DontMove.SetActive(true);
            cancelInteractions.enabled = false;

            Health_Machine_Sound.clip = Health_Machine_cheak;
            Health_Machine_Sound.Play();

            GameManager.gameManager._gameData.IsHealthMachineUpCheck = true;
            StartCoroutine(Delay5seconds());
        }
    }

    IEnumerator Delay5seconds()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("검사완료"); // 내려오는 애니메이션

        InteractionButtonController.interactionButtonController.PlayerFall1();

        DontMove.SetActive(false);
        cancelInteractions.enabled = true;
        ReportJudgment();
    }

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
        //throw new System.NotImplementedException();
    }


    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    IEnumerator HealthMachhineDone()
    {
        yield return new WaitForSeconds(1.5f);
        healthMachineFixPart_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPart_HM.transform.parent = null;
        healthMachineFixPartData.IsBite = false;

        healthMachineFixPart_HM.transform.position = new Vector3(-258.092f, 0f, 680.078f);
        healthMachineFixPart_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);
        healthMachineFixPart_HM.transform.parent = portableGroup.transform;

        healthMachineFixPartData.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        healthMachineData.IsCenterButtonDisabled = false;
        playerEquipment.biteObjectName = "";

        //W_HM_2
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(6));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");



        MissionGenerator.missionGenerator.DeleteNewMission(13);

        //GameManager.gameManager._gameData.ActiveMissionList[13] = false;
        //MissionGenerator.missionGenerator.ActivateMissionList();

        //냄새로 업무공간 고치기 끝
    }

    public void ReportJudgment()
    {
        if (GameManager.gameManager._gameData.IsAIReportMissionTime == true)
        {
            Debug.Log("보고하기 임무 중");
            Report_GUI.SetActive(true);
            reportAnim.SetBool("ReportOpen", true);
            cancelInteractions.enabled = false;
        }
        else
        {
            if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
            {
                Debug.Log("더미데이터 업로드!");
                //더미데이터 메인컴퓨터에 업로드
                GameManager.gameManager._gameData.IsRealfatigue = GameManager.gameManager._gameData.IsFakefatigue;
                GameManager.gameManager._gameData.IsRealStrength = GameManager.gameManager._gameData.IsFakeStrength;
                GameManager.gameManager._gameData.IsRealThirst = GameManager.gameManager._gameData.IsFakeThirst;
                GameManager.gameManager._gameData.IsRealHunger = GameManager.gameManager._gameData.IsFakeHunger;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                GameManager.gameManager._gameData.IsDummyDataReport = true;
                GameManager.gameManager._gameData.IsHealthMachineUpCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            else
            {
                Debug.Log("노아 상태 업로드!");
                GameManager.gameManager._gameData.IscurrentHealthData = inGameTime.statNum;
                //현재 스탯 상태 메인 컴퓨터에 업로드
            }
        }
    }

    public void Report()
    {
        Debug.Log("보고하기");
        reportAnim.SetBool("Reportclose", true);
        reportAnim.SetBool("ReportOpen", false);
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        GameManager.gameManager._gameData.IsRM_HealthDataReportbool = true;
        GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;
            GameManager.gameManager._gameData.IsDummyDataReport = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //더미데이터 메인컴퓨터에 업로드

            GameManager.gameManager._gameData.IsRealfatigue = GameManager.gameManager._gameData.IsFakefatigue;
            GameManager.gameManager._gameData.IsRealStrength = GameManager.gameManager._gameData.IsFakeStrength;
            GameManager.gameManager._gameData.IsRealThirst = GameManager.gameManager._gameData.IsFakeThirst;
            GameManager.gameManager._gameData.IsRealHunger = GameManager.gameManager._gameData.IsFakeHunger;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            GameManager.gameManager._gameData.IsHealthMachineUpCheck = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));

            //중간데이터보고 임무 끝

            GameManager.gameManager._gameData.ActiveMissionList[14] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else
        {
            //현재 스탯 상태 메인 컴퓨터에 업로드 
            GameManager.gameManager._gameData.IscurrentHealthData = inGameTime.statNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            if (inGameTime.statNum < 3) 
            {
                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //W_HM_5
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(37));

                //중간데이터보고 임무 끝
                GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            else
            {
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //W_HM_3
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));

                //중간데이터보고 임무 끝
                GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
    }

    public void Cancle()
    {
        Debug.Log("취소하기");

        reportAnim.SetBool("ReportClose", true);
        reportAnim.SetBool("ReportOpen", false);
        StartCoroutine(CancelReport());

    }

    IEnumerator CancelReport()
    {

        yield return new WaitForSeconds(0.3f);

        Report_GUI.SetActive(false);

        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = false;
        GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //W_HM_4
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));

        //중간데이터보고 임무 끝
        GameManager.gameManager._gameData.ActiveMissionList[14] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}


