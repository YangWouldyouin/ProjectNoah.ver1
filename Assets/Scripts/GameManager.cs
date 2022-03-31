using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    /* 1회성 임무 ( 한번 끝내면 다시 안함 ) */
    public bool IsAI_M_C1 = false; // 항상 AI 활성화
    public bool IsCockpitDoorOpened_M_C1 = false; // 항상 조종실에서 업무공간 이동 가능

    public bool IsHealthMachineFixedT_C2 = false; // 정기적으로 상태 측정 임무 수행 가능
    public bool IsSmartFarmOpen_T_C2 = false; // 항상 스마트팜 열려있고, 정기적으로 스마트팜 임무 수행 가능



    /* 정기 임무 ( 일정 시간이 지나면 다시 false 로 바뀌어서 다시 해야함 ) */
    public bool IsHealthMachineDone = false;
    public bool IsSmartFarmMissionDone = false;



    public static int Hp = 100;
    public bool isBark = false;



    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        if(IsCockpitDoorOpened_M_C1) // playerpref 에 저장하기 
        {
            // 조종실 - 업무공간 이동 가능
        }

    }


    private void Update()
    {
        if(isBark == true) // 짖으면
        {
            Hp -= 10;
            isBark = false;
        }



        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log("체력: " + Hp);
        //    //Debug.Log("isPush : " + isPush);
        //}
    }
}
