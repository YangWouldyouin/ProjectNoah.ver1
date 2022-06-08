using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BeakerAfter : MonoBehaviour
{
    public GameObject StartScreen;
    //public GameObject EndScreen;
    public GameObject DonTClick;

    /*타이머*/
    public InGameTime inGameTime;

    public bool canTpretendDead1 = false;
    public bool StartBlack = false;
    public bool StartOnlyOne = false;

    public GameObject dialog_CS;
    DialogManager dialogManager;


    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog_CS.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //미션 실패
        if (!GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet 
            && canTpretendDead1 == false && inGameTime.IsTimerStarted == false
            && inGameTime.IsBeakerEatAfterStart)
        {
            Debug.Log("미션 실패");
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //반복 방지
            canTpretendDead1 = true;
        }

        //타임 어택 성공시
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet 
            && inGameTime.IsTimerStarted)
        {
            inGameTime.IsTimerStarted = false;
            inGameTime.missionTimer = 0;

            //Debug.Log("노아의 굿엔딩 보기 가능해졌다!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //진짜 튜토리얼 중간 성공
        }

        if (GameManager.gameManager._gameData.IsDrinkBeaker_M_C2 
            && inGameTime.IsBeakerEatAfterStart == false)
        {
            // 2.쓰러진다. 
            Invoke("EatAfter", 3);

            inGameTime.IsBeakerEatAfterStart = true;
        }
    }

    void EatAfter()
    {
        //3.AI가 혼낸다.
        //StartCoroutine(realFakeAI1());

        Invoke("FakeAI1", 3f);

        InteractionButtonController.interactionButtonController.PlayerDie();

        Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");

        DonTClick.SetActive(true);

        /*노아가 혼자서 안움직이게*/
        PlayerScripts.playerscripts.IsBored = true;

        StartBlack = true;

        //여기부터 안됨@@@@@@@@

        //StartCoroutine(SuddenDeath());

        Invoke("SuddenDeath1", 43.5f);
    }

    void SuddenDeath1()
    {
        Debug.Log("노아는 죽엇다");

        //4.꺼지는 화면이 나온다.
        //5. 켜지는 화면이 나온다.
        StartScreen.SetActive(true);
        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();


        Invoke("End", 3f);
    }

    IEnumerator SuddenDeath()
    {

        yield return new WaitForSeconds(40f);
        Debug.Log("노아는 죽엇다");

        //4.꺼지는 화면이 나온다.
        //5. 켜지는 화면이 나온다.
        StartScreen.SetActive(true);
        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();


        Invoke("End", 3f);

    }

    void End()
    {
        Debug.Log("타이머 켜짐");

        StartScreen.SetActive(false);
        DonTClick.SetActive(false);
        //EndScreen.SetActive(false);
        inGameTime.IsAIAwake = false;
        /*노아 다시 움직이게*/
        PlayerScripts.playerscripts.IsBored = false;

        //타이머 시작 5분
        TimerManager.timerManager.TimerStart(300);
    }


    void FakeAI1()
    {
        Debug.Log("AI는 잘 말한다.");

        //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();
    }

    IEnumerator realFakeAI1()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("AI는 잘 말한다.");

        //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();
    }
}
