using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Table1 : MonoBehaviour
{
    /*책상에 오르기 스크립트 입니다. 책상에 오르기 전까지 상호작용이 안되는 오브젝트들은 여기에 써주세요*/

    public GameObject workroomTable1_WT;
    public GameObject dontCardPack_WT;



    ObjData workroomTableData1_WT;
    ObjData dontCardPackData_WT;


    Outline dontCardPackOutline_WT;

    void Start()
    {
        workroomTableData1_WT = workroomTable1_WT.GetComponent<ObjData>();
        dontCardPackData_WT = dontCardPack_WT.GetComponent<ObjData>();

        dontCardPackOutline_WT = dontCardPack_WT.GetComponent<Outline>();
    }

    void Update()
    {
        // IsCollision이 켜지면 책상과 노아가 충돌했다는 뜻이다.
        if (workroomTableData1_WT.IsCollision == true)
        {
            /* 특수 상호작용 버튼을 비활성화->오르기로 바꿔주겠다는 것이다. 
            (기본적으로 비활성화 상태라면 인스펙터의 IsCenterButtonDisabled에 체크를 해두자)*/

            workroomTableData1_WT.IsCenterButtonDisabled = false; 

        }

        /* IsCenterButtonDisabled => 센터 버튼 비활성화가 트루이면 다시 비활성화 상태로 돌리겠다는 것이다. 
        책상에서 내려왔을 때 상자 위가 아님을 알면 다시 '오르기'를 비활성화로 바꾸기 위해 넣는 코드*/
        else
        {
            workroomTableData1_WT.IsCenterButtonDisabled = true;
        }

        //--------------------------
        /*가운데 버튼이 오르기 비활성화->활성화로 바뀐 상태라면 가운데버튼을 '관찰하기'로 바꾸는 걸 트루로 하겠다.*/

        if (workroomTableData1_WT.IsUpDown) 
        {
            workroomTableData1_WT.IsCenterButtonChanged = true;
            // 책상 위 물건이 상호작용 가능하게
            dontCardPackData_WT.IsNotInteractable = false; 
            dontCardPackOutline_WT.OutlineWidth = 8;
        }
        else
        {
            // 책상 위 물건이 상호작용 불가능하게
            workroomTableData1_WT.IsCenterButtonChanged = false;
            dontCardPackData_WT.IsNotInteractable = true; 
            dontCardPackOutline_WT.OutlineWidth = 0;
        }

        //--------------------------

        if (workroomTableData1_WT.IsObserve) // 책상에서 '관찰하기'를 사용한게 트루이면 관찰하기 뷰를 실행하겠다.
        {
            CameraController.cameraController.currentView = workroomTableData1_WT.ObserveView;
        }
    }

}




