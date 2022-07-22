using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLivingScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;

    [Header("< ������ ��� ���� >")]
    public GameObject TDBT_fixPart;
    public GameObject TDBT_fixBody;
    public ObjectData TDBT_fixPartData, TDBT_fixBodyData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;

    [Header("< �� ������ ���� >")]
    public GameObject Doll;
    public GameObject LivingroomDoor;
    public Animator doorAnim;
    public void FirstEnter()
    {
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(10));
        //GameManager.gameManager._gameData.ActiveMissionList[15] = true;

        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //MissionGenerator.missionGenerator.ActivateMissionList();
        MissionGenerator.missionGenerator.AddNewMission(15);
        GameManager.gameManager._gameData.IsFirstEnterLiving = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        TDBT_BodyOutline = TDBT_fixBody.GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();

        GameData intialGameData = SaveSystem.Load("save_001");

        if (!intialGameData.IsFirstEnterLiving)
        {
            // ��Ȱ���� �̼� ���� ����
            GameManager.gameManager._gameData.ActiveMissionList[2] = false; // ��Ȱ���� ī��Ű Ž��
            GameManager.gameManager._gameData.ActiveMissionList[4] = false; // ��Ȱ���� ����

            // ��Ȱ���� �ر� ���� ���� ���� true��
            GameManager.gameManager._gameData.IsWLDoorHalfOpened_M_C2 = true; // �׻� ������������ ��Ȱ���� �̵� ����. ��, ���� �ݸ� ����ä��
            GameManager.gameManager._gameData.IsCompleteFindLivingKey = true;
            GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //������ ��Ȱ���� ��ġ�� ����
            Invoke("FirstEnter", 4f);
        }


        if (intialGameData.IsAIVSMissionCount >= 3 && !intialGameData.IsFirstNoticeEnd && !GameManager.gameManager._gameData.IsTabletDestory)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
            //GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.AddNewMission(8);
        }

        // ��Ȱ���� ������踦 ��ġ��
        if (intialGameData.IsTrashDoorBTFixed_L_L1)
        {
            TDBT_fixPart.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
            TDBT_fixPart.transform.rotation = Quaternion.Euler(0, -90, 0);
            TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

            TDBT_fixPartData.IsNotInteractable = true;
            TDBT_fixBodyData.IsNotInteractable = true;

            TDBT_BodyOutline.OutlineWidth = 0;
            TDBT_fixPartOutline.OutlineWidth = 0;
        }
        else
        {
            TDBT_fixPartData.IsNotInteractable = false;
            TDBT_fixBodyData.IsNotInteractable = false;
            TDBT_BodyOutline.OutlineWidth = 8;
            TDBT_fixPartOutline.OutlineWidth = 8;
        }

        // ��Ȱ���� ���� ������ ��ġ��
        if(intialGameData.IsCompleteOpenLivingRoom)
        {
            Doll.transform.position = new Vector3(-33.58f, 0.22f, 33.59f);
            LivingroomDoor.transform.position = new Vector3(-263.12f, -0.67f, 694.04f); // ��Ȱ���� �� ������ ������
        }
        else
        {
            LivingroomDoor.transform.position = new Vector3(-260.11f, -0.67f, 694.04f);
        }
    }
}
