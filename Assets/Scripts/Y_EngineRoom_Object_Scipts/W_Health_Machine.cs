using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;

    public GameObject healthMachineFixPart_HM;
    ObjData healthMachineFixPartData_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Transform healthMachinePos;
    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    public GameObject DontMove;

    public bool AIReprotMissionTime = false;

    public CancelInteractions cancelInteractions;

    //노아 내려가는 애니메이션 필요
    //정기 보고 체크
    //노아 스탯 정보/더미데이터 정보 메인컴퓨터로 전송
    //다이어로그 연결

    // Start is called before the first frame update
    void Start()
    {
        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineFixPartData_HM = healthMachineFixPart_HM.GetComponent<ObjData>();
        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();

        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

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

        AIReprotMissionTime = true;
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

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Health_MachineData_W.IsPushOrPress = false;
    }

    public void OnBark()
    {
        Health_MachineData_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Health_MachineData_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());


        if (healthMachineFixPartData_HM.IsBite) // 부품을 물었으면
        {
            Invoke("HealthMachhineDone", 1.5f);
        }
    }

    public void OnSniff()
    {
        Health_MachineData_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        DiableButton();

        if (!Health_MachineData_W.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기 변수 true 로 바꿈 */
            Health_MachineData_W.IsUpDown = true;

            /* 실제 노아가 이동할 오르기 위치 좌표에 x, z 값을 넣음 */
            healthMachineRisePos.x = healthMachinePos.position.x;
            healthMachineRisePos.z = healthMachinePos.position.z;

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
        healthMachineFixPartData_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPartData_HM.transform.parent = null;

        healthMachineFixPartData_HM.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachineFixPartData_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        healthMachineFixPartData_HM.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        Health_MachineData_W.IsCenterButtonDisabled = false;

        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(7));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void ReportJudgment()
    {
        if (AIReprotMissionTime == true)
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
        AIReprotMissionTime = false;

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            //더미데이터 메인컴퓨터에 업로드
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //확인되었습니다. AI 대사 출력
        }
        else
        {
            //if (노아 스탯 < 30) 
            //{
            //    GameManager.gameManager._gameData.IsReportCancleCount += 1;
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //    //상태 관리 제대로 하지 않으면 임무에서 제외하도록 하겠습니다. AI 대사 출력
            //}
            
            //현재 스탯 상태 메인 컴퓨터에 업로드 
        }
    }

    public void Cancle()
    {
        Debug.Log("취소하기");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //임무에 성실히 임하지 않으면 임무에서 제외하도록 하겠습니다. AI 대사 출력
        AIReprotMissionTime = false;
    }
}
