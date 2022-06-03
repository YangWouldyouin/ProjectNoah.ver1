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

    public GameObject S_TimerBarFilled;
    public GameObject S_TimerBackground;
    public GameObject S_TimerText;

    public bool IsNoSeeFail1 = false; //제한 시간 내에 안에 퍼즐 실패
    public bool canTSee1 = false;
    public bool HideStart = false;

    // Start is called before the first frame update
    void Start()
    {
        outlineControl = outlineController.GetComponent<NoahOutlineController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*태블릿 해금 완료(이 시점을 안 넣으면 평소에 그냥 발견한 거랑 AI가 착각할듯) && 시간이 안 끝났다면 && 업데이트문 반복 방지  &&AI 다운이 성공 못했다면*/
        if (GameManager.gameManager._gameData.IsTabletUnlock &&IsNoSeeFail1 == true && canTSee1 == false && GameManager.gameManager._gameData.IsAIDown == false)
        {
            /*타이머가 꺼진다*/
            inGameTime.IsTimerStarted = false;

            /*아웃라인이 꺼진다*/
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            //Debug.Log("시간 안에 퍼즐 풀기 실패");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTSee1 = true;
        }

        //타임 어택 성공시
        if (GameManager.gameManager._gameData.IsAIDown)
        {
            /*타이머가 꺼진다*/
            inGameTime.IsTimerStarted = false;

            /*아웃라인이 꺼진다*/
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            //Debug.Log("노아의 굿엔딩 보기 가능해졌다!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //진짜 튜토리얼 중간 성공
        }

        if(GameManager.gameManager._gameData.IsHide&& HideStart == false)
        {
            // 3분간 플레이어 아웃라인 활성화
            outlineControl.StartOutlineTime(300f);
            TimerManager.timerManager.TimerStart(300f);
            Invoke("FailStrangeObj", 300f);

            HideStart = true;
        }
    }

    void FailStrangeObj()
    {
        IsNoSeeFail1 = true;
    }
}
