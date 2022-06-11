using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeEngineScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;
    PortableObjectData EngineRoomData;

    /* 관련 오브젝트 */

    // 연료 퍼즐
    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorberBody;
    public GameObject FA_fuelabsorber;

    // 태블릿 해금 퍼즐
    public GameObject Tablet_E;
    public GameObject Boxes_E;
    public GameObject Full_Eg_Pad_E;
    public GameObject Zero_Eg_Pad_E;

    public GameObject LoverPic_E;
    public GameObject E_AstronPic_Susan_E;
    public GameObject E_AstronPic_Mike_E;
    public GameObject E_AstronPic_Salvia_E;
    public GameObject E_AstronPic_Trelawny_E;


    /* 관련 오브젝트 콜라이더 */




    // Start is called before the first frame update
    void Start()
    {
        EngineRoomData = BaseCanvas._baseCanvas.engineRoomData;
        dialogManager = dialog.GetComponent<DialogManager>();
        GameData intialGameData = SaveSystem.Load("save_001");

        if (!intialGameData.IsFirstEnterEngine)
        {
            intialGameData.IsFirstEnterEngine = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(11));
            GameManager.gameManager._gameData.ActiveMissionList[16] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
            //냄새로 엔진실 고치기 시작
        }


        if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
            GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }

        /* 연료 퍼즐 */
        if (intialGameData.IsFuelabsorberFixed_E_E1)
        {
            /*연료 부품 안보이게*/
            EngineRoomData.IsObjectActiveList[4] = false;

            /*얘네는 못움직이는 오브젝트들*/
            FA_fuelabsorberBody.SetActive(false);
            FA_fuelabsorber.SetActive(true);
        }

        /* 태블릿 해금 퍼즐 */
        if(intialGameData.IsNoBoxes) // 상자더미
        {
            /*얘네는 못움직이는 오브젝트들*/
            Boxes_E.SetActive(false);
        }
        if(intialGameData.IsFullChargeTablet) // 태블릿 충전
        {
            /*충전 패드, 충전 안되는 패드 안보이게*/
            EngineRoomData.IsObjectActiveList[39] = false;
            EngineRoomData.IsObjectActiveList[40] = false;
        }

        if(intialGameData.IsTabletUnlock) // <최종> 태블릿 잠금화면 해제
        {
            /*사진들 안보이게*/
            EngineRoomData.IsObjectActiveList[41] = false;
            EngineRoomData.IsObjectActiveList[42] = false;
            EngineRoomData.IsObjectActiveList[43] = false;
            EngineRoomData.IsObjectActiveList[44] = false;
            EngineRoomData.IsObjectActiveList[45] = false;
        }
    }

}
