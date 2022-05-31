using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BeakerAfter : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject EndScreen;
    public GameObject DonTClick;

    /*Ÿ�̸�*/
    public InGameTime inGameTime;

    public GameObject S_TimerBarFilled;
    public GameObject S_TimerBackground;
    public GameObject S_TimerText;

    public bool IsFirstStart = false;

    public bool IsPretendDeadFail1 = false; //���� �ð� ���� �ȿ� ���� ����
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
        if (IsPretendDeadFail1 == true && canTpretendDead1 == false && !GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("�ð� �ȿ� ���� Ǯ�� ����");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTpretendDead1 = true;
        }

        //Ÿ�� ���� ������
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            inGameTime.IsTimerStarted = false;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            Debug.Log("����� �¿��� ���� ����������!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //��¥ Ʃ�丮�� �߰� ����
        }

        if (GameManager.gameManager._gameData.IsDrinkBeaker_M_C2 && IsFirstStart == false)
        {
            // 2.��������. 
            Invoke("EatAfter", 3);

            IsFirstStart = true;
        }
    }

    void EatAfter()
    {
        //3.AI�� ȥ����.
        //StartCoroutine(realFakeAI1());

        Invoke("FakeAI1", 3f);

        InteractionButtonController.interactionButtonController.PlayerDie();

        Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");

        DonTClick.SetActive(true);

        /*��ư� ȥ�ڼ� �ȿ����̰�*/
        PlayerScripts.playerscripts.IsBored = true;

        StartBlack = true;

        //������� �ȵ�@@@@@@@@

        //StartCoroutine(SuddenDeath());

        Invoke("SuddenDeath1", 43.5f);
    }

    void SuddenDeath1()
    {
        Debug.Log("��ƴ� �׾���");

        //4.������ ȭ���� ���´�.
        //5. ������ ȭ���� ���´�.
        StartScreen.SetActive(true);
        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();


        Invoke("End", 3f);
    }

    IEnumerator SuddenDeath()
    {

        yield return new WaitForSeconds(40f);
        Debug.Log("��ƴ� �׾���");

        //4.������ ȭ���� ���´�.
        //5. ������ ȭ���� ���´�.
        StartScreen.SetActive(true);
        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();


        Invoke("End", 3f);

    }

    void End()
    {
        Debug.Log("Ÿ�̸� ����");

        StartScreen.SetActive(false);
        DonTClick.SetActive(false);
        //EndScreen.SetActive(false);

        /*��� �ٽ� �����̰�*/
        PlayerScripts.playerscripts.IsBored = false;

        //Ÿ�̸� ���� 3��
        TimerManager.timerManager.TimerStart(300);
        Invoke("PretendFailCheck", 300f);
    }

    void PretendFailCheck()
    {
        IsPretendDeadFail1 = true;
    }

    void FakeAI1()
    {
        Debug.Log("AI�� �� ���Ѵ�.");

        //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    IEnumerator realFakeAI1()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("AI�� �� ���Ѵ�.");

        //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}
