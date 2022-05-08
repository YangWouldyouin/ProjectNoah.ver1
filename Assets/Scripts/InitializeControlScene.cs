using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeControlScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;
    
    public Animator controlWorkDoorAnim;
    public GameObject ChangeScene;

    [Header("<AI�ٿ�>")]
    public GameObject chipInsert;
    public GameObject RChip;
    public GameObject WChip;

    //�ݶ��̴�
    BoxCollider chipInsertCol;
    BoxCollider RChipCol;
    BoxCollider WChipCol;



    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");

        if(GameManager.gameManager._gameData.IsAIVSMissionCount >=2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
        }

        if(intialGameData.IsCWDoorOpened_M_C1)
        {
            controlWorkDoorAnim.SetBool("IsDoorOpenStart", true);
            controlWorkDoorAnim.SetBool("IsDoorOpened", true);
            ChangeScene.SetActive(true);
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
    }

}
