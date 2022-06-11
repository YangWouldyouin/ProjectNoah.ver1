using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeEngineScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;
    PortableObjectData EngineRoomData;

    /* ���� ������Ʈ */

    // ���� ����
    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorberBody;
    public GameObject FA_fuelabsorber;

    // �º� �ر� ����
    public GameObject Tablet_E;
    public GameObject Boxes_E;
    public GameObject Full_Eg_Pad_E;
    public GameObject Zero_Eg_Pad_E;

    public GameObject LoverPic_E;
    public GameObject E_AstronPic_Susan_E;
    public GameObject E_AstronPic_Mike_E;
    public GameObject E_AstronPic_Salvia_E;
    public GameObject E_AstronPic_Trelawny_E;


    /* ���� ������Ʈ �ݶ��̴� */




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
            //������ ������ ��ġ�� ����
        }


        if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
            GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }

        /* ���� ���� */
        if (intialGameData.IsFuelabsorberFixed_E_E1)
        {
            /*���� ��ǰ �Ⱥ��̰�*/
            EngineRoomData.IsObjectActiveList[4] = false;

            /*��״� �������̴� ������Ʈ��*/
            FA_fuelabsorberBody.SetActive(false);
            FA_fuelabsorber.SetActive(true);
        }

        /* �º� �ر� ���� */
        if(intialGameData.IsNoBoxes) // ���ڴ���
        {
            /*��״� �������̴� ������Ʈ��*/
            Boxes_E.SetActive(false);
        }
        if(intialGameData.IsFullChargeTablet) // �º� ����
        {
            /*���� �е�, ���� �ȵǴ� �е� �Ⱥ��̰�*/
            EngineRoomData.IsObjectActiveList[39] = false;
            EngineRoomData.IsObjectActiveList[40] = false;
        }

        if(intialGameData.IsTabletUnlock) // <����> �º� ���ȭ�� ����
        {
            /*������ �Ⱥ��̰�*/
            EngineRoomData.IsObjectActiveList[41] = false;
            EngineRoomData.IsObjectActiveList[42] = false;
            EngineRoomData.IsObjectActiveList[43] = false;
            EngineRoomData.IsObjectActiveList[44] = false;
            EngineRoomData.IsObjectActiveList[45] = false;
        }
    }

}
