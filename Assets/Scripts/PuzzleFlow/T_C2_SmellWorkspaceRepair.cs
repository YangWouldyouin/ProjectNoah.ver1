using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmellWorkspaceRepair : MonoBehaviour
{
    private GameObject nowObject_T_C2_SmellWorkspaceRepair;

    public static bool IsHealthMachineDone = false;

    public GameObject HealthMachine;
    public GameObject HealthMachine_fixPart;

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
                HealthMachineOpen();
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

        if (HealthMachineData.IsPushOrPress)
        {
            if (HealthMachine_fixPartData.IsBite)
            {
                IsHealthMachineDone = true;
            }
        }
    }

    public void HealthMachineOpen()
    {
        //물고 있는 fitPart 물기 해제 -> bool false
        
        //fitPart 위치 HM에 자동 장착
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();

        HealthMachine_fixPartData.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);

        //한 번 물기 하면 더이상 fitPart 상호작용 불가 오브젝트로 변경 -> interaction 스크립트 끄기
        //HM 가운데 버튼 오르기 버튼으로 변경->업데이트
    }
}
