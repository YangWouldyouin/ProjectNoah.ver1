using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeEngineScene : MonoBehaviour
{
    public GameObject dialog;
    DialogManager dialogManager;

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
        dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");

        if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2 && !GameManager.gameManager._gameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
        }

        /* 연료 퍼즐 */
        if (intialGameData.IsFuelabsorberFixed_E_E1)
        {
            FA_fuelabsorberfixPart.SetActive(false);
            FA_fuelabsorberBody.SetActive(false);
            FA_fuelabsorber.SetActive(true);
        }

        /* 태블릿 해금 퍼즐 */
        if(intialGameData.IsNoBoxes) // 상자더미
        {
            Boxes_E.SetActive(false);
        }
        if(intialGameData.IsFullChargeTablet) // 태블릿 충전
        {
            Full_Eg_Pad_E.SetActive(false);
            Zero_Eg_Pad_E.SetActive(false);
        }
        if(intialGameData.IsTabletUnlock) // <최종> 태블릿 잠금화면 해제
        {
            LoverPic_E.SetActive(false);
            E_AstronPic_Susan_E.SetActive(false);
            E_AstronPic_Mike_E.SetActive(false);
            E_AstronPic_Salvia_E.SetActive(false);
            E_AstronPic_Trelawny_E.SetActive(false);
        }
    }

}
