using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_HealthMachine : MonoBehaviour
{
    public GameObject Report_GUI;
    public bool IsReported = false;

    // @@@@@ 나중에 정기 상태 체크 임무 추가 @@@@@@
    private bool IsHealthMachineDone = false;

    public GameObject healthMachine_HM;
    public GameObject healthMachineFixPart_HM;

    ObjData healthMachineData_HM;
    ObjData healthMachineFixPartData_HM;

    Outline healthMachineFixPartOutline_HM;

    private float heathMachineRepairTimer_HM = 0;
    public float heathMachineRepairHintTime_HM = 60f;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;
    void Start()
    {
        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

        healthMachineData_HM = healthMachine_HM.GetComponent<ObjData>();
        healthMachineFixPartData_HM = healthMachineFixPart_HM.GetComponent<ObjData>();

        healthMachineFixPartOutline_HM = healthMachineFixPart_HM.GetComponent<Outline>();


        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5)); //AI: 상태 체크 기계 연결이 되어 있지 않았다 스크립트 
    }

    void Update()
    {

        // 1회성 임무인 "상태 체크 기계 고치기" 를 안했으면 
        if (!GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2)
        {
            if (healthMachineData_HM.IsClicked)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5)); //AI: 상태 체크 기계 연결이 되어 있지 않았다 스크립트
            }

            if (IsHealthMachineDone)
            {
                Invoke("HealthMachineOpen", 1f);
            }
            else
            {
                HMfixPart_Putting();
            }
        }
        else // 기계를 고친 후 보고하기 정기임무 하기 
        {
            ReportStatMission();
        }
    }

    public void HMfixPart_Putting()
    {
        heathMachineRepairTimer_HM += Time.deltaTime;
        float maxTimer = Mathf.FloorToInt((heathMachineRepairTimer_HM % 3600) % 60);
        if (maxTimer >= heathMachineRepairHintTime_HM)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(6)); // 아직 못 풀었을 경우 heathMachineRepairHintTime 마다 1번씩 힌트 제공
            heathMachineRepairTimer_HM = 0;
        }

        if (healthMachineData_HM.IsPushOrPress && healthMachineFixPartData_HM.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {

        healthMachineFixPartData_HM.IsBite = false; //물고 있는 fitPart 물기 해제 -> bool false

        healthMachineFixPartData_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPartData_HM.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        healthMachineFixPartData_HM.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachineFixPartData_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        healthMachineFixPartData_HM.GetComponent<Interactable>().enabled = false;
        healthMachineFixPartOutline_HM.OutlineWidth = 0; // 마우스 오버해도 외곽선 x

        //HM 가운데 버튼 오르기 버튼으로 변경->업데이트
        healthMachineData_HM.IsCenterButtonDisabled = false;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(7));

        // 생체기계 고치기 1회성 임무가 끝남 
        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    public void Report()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //보고하기 데이터 이동
        //else 더미 데이터 이동

        Debug.Log("보고하기");
        IsReported = true;
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        
        Debug.Log("취소하기");

        //cancleCount += 1; // 어디서 확인하는지??
        GameManager.gameManager._gameData.HealthMachineCancelCount -= 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsReported = true;
    }

    public void ReportStatMission()
    {
        if (!IsReported)
        {
            healthMachineData_HM.IsCenterButtonDisabled = false;
            if (healthMachineData_HM.IsUpDown)
            {
                healthMachineData_HM.IsNotInteractable = true;

                // 올라가는 애니메이션 2.5초간 기다렷다가 보고하기 팝업 뜨게 하ㅁ
                heathMachineRepairTimer_HM += Time.deltaTime;
                float maxTimer = Mathf.FloorToInt((heathMachineRepairTimer_HM % 3600) % 60);
                if (maxTimer >= 2.5f) //
                {
                    Report_GUI.SetActive(true);
                }
            }
        }
        else
        {
            healthMachineData_HM.IsNotInteractable = false;
            heathMachineRepairTimer_HM = 0;
            Report_GUI.SetActive(false);
        }
    }
}


