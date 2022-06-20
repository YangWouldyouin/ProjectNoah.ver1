using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLivingScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;

    [Header("< 쓰레기 기계 수리 >")]
    public GameObject TDBT_fixPart;
    public GameObject TDBT_fixBody;
    public ObjectData TDBT_fixPartData, TDBT_fixBodyData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;

    [Header("< 문 완전히 수리 >")]
    public GameObject Doll;
    public GameObject LivingroomDoor;
    public Animator doorAnim;



    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        TDBT_BodyOutline = TDBT_fixBody.GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();

        GameData intialGameData = SaveSystem.Load("save_001");

        if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
            GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }

        // 생활공간 냄새기계를 고치면
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

        // 생활공간 문을 완전히 고치면
        if(intialGameData.IsCompleteOpenLivingRoom)
        {
            Doll.transform.position = new Vector3(-33.58f, 0.22f, 33.59f);
            LivingroomDoor.transform.position = new Vector3(-263.12f, -0.67f, 694.04f); // 생활공간 문 완전히 열리기
        }
        else
        {
            LivingroomDoor.transform.position = new Vector3(-260.11f, -0.67f, 694.04f);
        }
    }
}
