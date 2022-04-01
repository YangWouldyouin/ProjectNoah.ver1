using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmellWorkspaceRepair : MonoBehaviour
{
    private GameObject nowObject_T_C2_SmellWorkspaceRepair;

    public static bool IsHealthMachineDone = false;

    public GameObject HealthMachine;
    public GameObject HealthMachine_fixPart;

    public GameObject Report_GUI;
    private bool IsReported = false;

    // Start is called before the first frame update
    void Start()
    {
        //AI: 상태 체크 기계 연결이 되어 있지 않았다 스크립트
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C2_SmellWorkspaceRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C2_SmellWorkspaceRepair != null)
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
        ObjData HealthMachineData = HealthMachine.GetComponent<ObjData>();
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();
        if (HealthMachineData.IsPushOrPress && HealthMachine_fixPartData.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {
        ObjData HealthMachineData = HealthMachine.GetComponent<ObjData>();
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();


        //물고 있는 fitPart 물기 해제 -> bool false
        HealthMachine_fixPartData.IsBite = false;

        HealthMachine_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        HealthMachine_fixPartData.transform.parent = null;

        //fitPart 위치 HM에 자동 장착
        HealthMachine_fixPartData.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        HealthMachine_fixPartData.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        HealthMachine_fixPartData.GetComponent<Interactable>().enabled = false;

        //HM 가운데 버튼 오르기 버튼으로 변경->업데이트
        HealthMachineData.IsCenterButtonDisabled = false;
        //HealthMachineData.IsCenterButtonChanged = true;

        Invoke("Report_Popup", 1f);
    }

    public void Report_Popup()
    {
        if(IsReported)
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
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //cancleCount += 1;
        
        Debug.Log("취소하기");
        IsReported = true;
        Report_GUI.SetActive(false);
    }
}
