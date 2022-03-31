using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Health_Machine : MonoBehaviour
{
    private bool IsHealthMachineDone = false;

    public GameObject healthMachine_T_C2;
    public GameObject healthMachine_FixPart_T_C2;

    ObjData healthMachineData_T_C2;
    ObjData healthMachine_FixPartData_T_C2;

    Outline healthMachine_FixPartOutline_T_C2;

    private float heathMachineRepairTimer_T_C2 = 0;
    public float heathMachineRepairHintTime = 60f;




    void Start()
    {
        healthMachineData_T_C2 = healthMachine_T_C2.GetComponent<ObjData>();
        healthMachine_FixPartData_T_C2 = healthMachine_FixPart_T_C2.GetComponent<ObjData>();

        healthMachine_FixPartOutline_T_C2 = healthMachine_FixPart_T_C2.GetComponent<Outline>();

        DialogManager.dialogManager.HealthMachineRepairIntro(); //AI: 상태 체크 기계 연결이 되어 있지 않았다 스크립트
    }

    void Update()
    {
        // 1회성 임무인 "상태 체크 기계 고치기" 를 안했으면 
        if(!GameManager.gameManager.IsHealthMachineFixedT_C2)
        {
            if (IsHealthMachineDone)
            {
                Invoke("HealthMachineOpen", 1.5f);
            }
            else
            {
                HMfixPart_Putting();
            }
        }

    }
    public void HMfixPart_Putting()
    {
        heathMachineRepairTimer_T_C2 += Time.deltaTime;
        float maxTimer = Mathf.FloorToInt((heathMachineRepairTimer_T_C2 % 3600) % 60);
        if(maxTimer>= heathMachineRepairHintTime)
        {
           DialogManager.dialogManager.HealthMachineRepairHint(); // 아직 못 풀었을 경우 heathMachineRepairHintTime 마다 1번씩 힌트 제공
           heathMachineRepairTimer_T_C2 = 0;
        }

        if (healthMachineData_T_C2.IsPushOrPress && healthMachine_FixPartData_T_C2.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {
        
        healthMachine_FixPartData_T_C2.IsBite = false; //물고 있는 fitPart 물기 해제 -> bool false

        healthMachine_FixPartData_T_C2.GetComponent<Rigidbody>().isKinematic = false;
        healthMachine_FixPartData_T_C2.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        healthMachine_FixPartData_T_C2.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachine_FixPartData_T_C2.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        healthMachine_FixPartData_T_C2.GetComponent<Interactable>().enabled = false;
        healthMachine_FixPartOutline_T_C2.OutlineWidth = 0; // 마우스 오버해도 외곽선 x

        //HM 가운데 버튼 오르기 버튼으로 변경->업데이트
        healthMachineData_T_C2.IsCenterButtonDisabled = false;
        DialogManager.dialogManager.HealthMachineEnd();

        // 생체기계 고치기 1회성 임무가 끝남 
        GameManager.gameManager.IsHealthMachineFixedT_C2 = true;
    }
}


