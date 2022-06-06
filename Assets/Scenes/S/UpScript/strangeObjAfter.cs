using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeObjAfter : MonoBehaviour
{
    [Header("<�÷��̾��� �ƿ������� ������>")]
    public NoahOutlineController outlineController;
    NoahOutlineController outlineControl;

    /*Ÿ�̸�*/
    public InGameTime inGameTime;

    public bool IsNoSeeFail1 = false; //���� �ð� ���� �ȿ� ���� ����
    public bool canTSee1 = false;
    public bool HideStart = false;

    void Start()
    {
        outlineControl = outlineController.GetComponent<NoahOutlineController>();
    }

    void Update()
    {
        /*�º� �ر� �Ϸ�(�� ������ �� ������ ��ҿ� �׳� �߰��� �Ŷ� AI�� �����ҵ�) && �ð��� �� �����ٸ� && ������Ʈ�� �ݺ� ����  &&AI �ٿ��� ���� ���ߴٸ�*/
        if (GameManager.gameManager._gameData.IsTabletUnlock && inGameTime.IsTimerStarted==false &&inGameTime.IsNoSeeFail1==false && canTSee1 == false && GameManager.gameManager._gameData.IsAIDown == false)
        {
            /*Ÿ�̸Ӱ� ������*/
            inGameTime.IsTimerStarted = false;
            inGameTime.missionTimer = 0;

            /*�ƿ������� ������*/
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;

            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("�ð� �ȿ� ���� Ǯ�� ����");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // AI ���ֱ� 
            canTSee1 = true;
        }

        //Ÿ�� ���� ������
        if (GameManager.gameManager._gameData.IsAIDown)
        {
            Debug.Log("Ÿ�Ӿ��ü���");
            inGameTime.IsNoSeeFail1 = true;

            /*Ÿ�̸Ӱ� ������*/
            inGameTime.IsTimerStarted = false;
            inGameTime.missionTimer = 0;

            /*�ƿ������� ������*/
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;


            //Debug.Log("����� �¿��� ���� ����������!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //��¥ Ʃ�丮�� �߰� ����
        }

        //    if(GameManager.gameManager._gameData.IsHide&& HideStart == false)
        //    {
        //        // 3�а� �÷��̾� �ƿ����� Ȱ��ȭ
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
