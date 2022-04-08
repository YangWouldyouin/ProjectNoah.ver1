using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_HealthMachine : MonoBehaviour
{
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
            if (IsHealthMachineDone)
            {
                Invoke("HealthMachineOpen", 1f);
            }
            else
            {
                HMfixPart_Putting();
            }
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
        //GameManager.gameManager.IsHealthMachineFixedT_C2 = true;
    }
}


