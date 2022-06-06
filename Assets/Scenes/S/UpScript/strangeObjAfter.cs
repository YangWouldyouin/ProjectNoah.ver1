using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeObjAfter : MonoBehaviour
{
    [Header("<플레이어의 아웃라인을 관리함>")]
    public NoahOutlineController outlineController;
    NoahOutlineController outlineControl;

    /*타이머*/
    public InGameTime inGameTime;

    void Start()
    {
        outlineControl = outlineController.GetComponent<NoahOutlineController>();
    }

    void Update()
    {

        //타임 어택 성공시
        if (GameManager.gameManager._gameData.IsAIDown && inGameTime.IsTimerStarted)
        {
            Debug.Log("타임어택성공");
            //inGameTime.IsNoSeeFail1 = true;

            /*타이머가 꺼진다*/
            inGameTime.IsTimerStarted = false;
            inGameTime.missionTimer = 0;

            /*아웃라인이 꺼진다*/
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;


            //Debug.Log("노아의 굿엔딩 보기 가능해졌다!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //진짜 튜토리얼 중간 성공
        }

        //    if(GameManager.gameManager._gameData.IsHide&& HideStart == false)
        //    {
        //        // 3분간 플레이어 아웃라인 활성화
        //        outlineControl.StartOutlineTime(300f);
        //        TimerManager.timerManager.TimerStart(300f);
        //        Invoke("FailStrangeObj", 300f);

        //        HideStart = true;
        //    }
        //}

        //void FailStrangeObj()
        //{
        //    IsNoSeeFail1 = true;
        //}
    }
}
