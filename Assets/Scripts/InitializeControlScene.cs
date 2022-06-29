using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeControlScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;
    
    public Animator controlWorkDoorAnim;
    public GameObject ChangeScene;

    [Header("<파이프 찾기>")]
    public GameObject pipe_C;


    [Header("<AI다운>")]
    public GameObject chipInsert;
    public GameObject RChip;
    public GameObject WChip;

    //콜라이더
    BoxCollider chipInsertCol;
    BoxCollider RChipCol;
    BoxCollider WChipCol;

    [Header("<행성탐사>")]
    public GameObject PlanetInsert;
    BoxCollider PlanetInsertCol;



    // Start is called before the first frame update
    void Start()
    {
        chipInsertCol = chipInsert.GetComponent<BoxCollider>();
        RChipCol = RChip.GetComponent<BoxCollider>();
        WChipCol = WChip.GetComponent<BoxCollider>();

        dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");

        if(GameManager.gameManager._gameData.IsAIVSMissionCount >=2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(8));
            //GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.AddNewMission(0);
        }

        if(GameManager.gameManager._gameData.IsPipeFound_M_C1)
        {
            pipe_C.transform.position = new Vector3(-27.07f, 0.05f, -30f);
            pipe_C.transform.eulerAngles = new Vector3(0, -90, 180);
        }

        if(intialGameData.IsCWDoorOpened_M_C1)
        {
            controlWorkDoorAnim.SetBool("IsDoorOpenStart", true);
            controlWorkDoorAnim.SetBool("IsDoorOpened", true);
            ChangeScene.SetActive(true);
        }
        else
        {
            ChangeScene.SetActive(false);
        }

        if(intialGameData.IsAIDown_M_C1C3)
        {
            chipInsertCol.enabled = false;
            RChip.SetActive(true);
            RChipCol.enabled = false;

            RChip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            RChip.transform.position = new Vector3(-7.448f, 34.62f, -1.439f);
            RChip.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if(intialGameData.IsPlanetInsertChip_In)
        {
            PlanetInsertCol.enabled = false;
            WChip.SetActive(true);
            WChipCol.enabled = false;

            WChip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            WChip.transform.position = new Vector3(-36.433f, 0.735f, -33.7f);
            WChip.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

}
