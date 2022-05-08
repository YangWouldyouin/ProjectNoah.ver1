using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;

    public ObjectData healthMachineData;
    public ObjectData healthMachineFixPartData;

    public GameObject healthMachineFixPart_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    public GameObject DontMove;

    public CancelInteractions cancelInteractions;

    public InGameTime inGameTime;

    public bool HealthDataReportbool;

    //노아 내려가는 애니메이션 필요
    //노아 스탯 정보/더미데이터 정보 메인컴퓨터로 전송

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsFirstEnterWorking)
        {
            //W_HM_1
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5));
            GameManager.gameManager._gameData.IsFirstEnterWorking = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }


        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();

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
    }

    void Update()
    {
        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10)
        {
            Debug.Log("상태 체크 정기 업무 시작");
            GameManager.gameManager._gameData.IsAIReportMissionTime = true;
            HealthDataReportbool = false;

            //W_HM_여따써줘
        }
        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && HealthDataReportbool == false)
        {
            Debug.Log("상태 체크 정기 업무 종료");
            GameManager.gameManager._gameData.IsAIReportMissionTime = false;
            HealthDataReportbool = false;

            GameManager.gameManager._gameData.IsReportCancleCount += 1;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
        }
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
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
            Invoke("HealthMachhineDone", 1.5f);
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
            StartCoroutine(Delay3seconds());
        }
    }

    IEnumerator Delay3seconds()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("검사완료"); // 내려오는 애니메이션
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

    public void HealthMachhineDone()
    {
        healthMachineFixPart_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPart_HM.transform.parent = null;

        healthMachineFixPart_HM.transform.position = new Vector3(-258.092f, 0f, 680.078f);
        healthMachineFixPart_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        healthMachineFixPartData.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        healthMachineData.IsCenterButtonDisabled = false;

        //W_HM_2
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(6));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void ReportJudgment()
    {
        if (GameManager.gameManager._gameData.IsAIReportMissionTime == true)
        {
            Debug.Log("보고하기 임무 중");
            Report_GUI.SetActive(true);
            cancelInteractions.enabled = false;
        }
        else
        {
            if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
            {
                Debug.Log("더미데이터 업로드!");
                //더미데이터 메인컴퓨터에 업로드
            }
            else
            {
                Debug.Log("노아 상태 업로드!");
                //현재 스탯 상태 메인 컴퓨터에 업로드
            }
        }
    }

    public void Report()
    {
        Debug.Log("보고하기");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        HealthDataReportbool = true;

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;

            //더미데이터 메인컴퓨터에 업로드
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));
        }
        else
        {
            //현재 스탯 상태 메인 컴퓨터에 업로드 

            //if (노아 스탯 < 30) 
            //{
            //    GameManager.gameManager._gameData.IsReportCancleCount += 1;
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //    //W_HM_5
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(37));
            //}
            //else
            //{
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //    //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));
            //}
        }
    }

    public void Cancle()
    {
        Debug.Log("취소하기");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //W_HM_4
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
    }
}
