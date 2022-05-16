using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleListUIManager : MonoBehaviour
{
    public Sprite Finish_puzzle;

    [Header("<퍼즐 이미지>")]
    public Image Puzzle1;
    public Image Puzzle2;
    public Image Puzzle3;
    public Image Puzzle4;
    public Image Puzzle5;
    public Image Puzzle6;
    public Image Puzzle7;
    public Image Puzzle8;
    public Image Puzzle9;
    public Image Puzzle10;

    public Image Puzzle11;
    public Image Puzzle12;
    public Image Puzzle13;
    public Image Puzzle14;
    public Image Puzzle15;
    public Image Puzzle16;
    public Image Puzzle17;
    public Image Puzzle18;
    public Image Puzzle19;
    public Image Puzzle20;

    public Image Puzzle21;
    public Image Puzzle22;
    public Image Puzzle23;
    public Image Puzzle24;
    public Image Puzzle25;
    public Image Puzzle26;

    [Header("<퍼즐 텍스트>")]
    public Text Puzzle1t;
    public Text Puzzle2t;
    public Text Puzzle3t;
    public Text Puzzle4t;
    public Text Puzzle5t;
    public Text Puzzle6t;
    public Text Puzzle7t;
    public Text Puzzle8t;
    public Text Puzzle9t;
    public Text Puzzle10t;

    public Text Puzzle11t;
    public Text Puzzle12t;
    public Text Puzzle13t;
    public Text Puzzle14t;
    public Text Puzzle15t;
    public Text Puzzle16t;
    public Text Puzzle17t;
    public Text Puzzle18t;
    public Text Puzzle19t;
    public Text Puzzle20t;

    public Text Puzzle21t;
    public Text Puzzle22t;
    public Text Puzzle23t;
    public Text Puzzle24t;
    public Text Puzzle25t;
    public Text Puzzle26t;

    // Start is called before the first frame update
    void Start()
    {
        Puzzle1 = Puzzle1.GetComponent<Image>();
        Puzzle2 = Puzzle2.GetComponent<Image>();
        Puzzle3 = Puzzle3.GetComponent<Image>();
        Puzzle4 = Puzzle4.GetComponent<Image>();
        Puzzle5 = Puzzle5.GetComponent<Image>();
        Puzzle6 = Puzzle6.GetComponent<Image>();
        Puzzle7 = Puzzle7.GetComponent<Image>();
        Puzzle8 = Puzzle8.GetComponent<Image>();
        Puzzle9 = Puzzle9.GetComponent<Image>();
        Puzzle10 = Puzzle10.GetComponent<Image>();

        Puzzle11 = Puzzle11.GetComponent<Image>();
        Puzzle12 = Puzzle12.GetComponent<Image>();
        Puzzle13 = Puzzle13.GetComponent<Image>();
        Puzzle14 = Puzzle14.GetComponent<Image>();
        Puzzle15 = Puzzle15.GetComponent<Image>();
        Puzzle16 = Puzzle16.GetComponent<Image>();
        Puzzle17 = Puzzle17.GetComponent<Image>();
        Puzzle18 = Puzzle18.GetComponent<Image>();
        Puzzle19 = Puzzle19.GetComponent<Image>();
        Puzzle20 = Puzzle20.GetComponent<Image>();

        Puzzle21 = Puzzle21.GetComponent<Image>();
        Puzzle22 = Puzzle22.GetComponent<Image>();
        Puzzle23 = Puzzle23.GetComponent<Image>();
        Puzzle24 = Puzzle24.GetComponent<Image>();
        Puzzle25 = Puzzle25.GetComponent<Image>();
        Puzzle26 = Puzzle26.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.IsTutorialClear0)
        {
            Puzzle1.sprite = Finish_puzzle;
            Puzzle1t.text = "항해 준비 완료";
        }
        if (GameManager.gameManager._gameData.IsCWDoorOpened_M_C10)
        {
            Puzzle2.sprite = Finish_puzzle;
            Puzzle2t.text = "업무공간 해금";
        }
        //if (GameManager.gameManager._gameData.IsDisqualifiedEnd)
        //{
        //    Puzzle3.sprite = Finish_puzzle;
        //    Puzzle3t.text = "행성 목적지 정하기";
        //}
        if (GameManager.gameManager._gameData.IsPhotoMissionFinish0)
        {
            Puzzle4.sprite = Finish_puzzle;
            Puzzle4t.text = "선전용 우주선 사진 찍기";
        }
        if (GameManager.gameManager._gameData.IsCompleteFindLivingKey0)
        {
            Puzzle5.sprite = Finish_puzzle;
            Puzzle5t.text = "생활공간 카드키 획득";
        }
        if (GameManager.gameManager._gameData.IsCompleteFindEngineKey0)
        {
            Puzzle6.sprite = Finish_puzzle;
            Puzzle6t.text = "엔진실 카드키 획득";
        }
        if (GameManager.gameManager._gameData.IsSmartFarmOpen_T_C20)
        {
            Puzzle7.sprite = Finish_puzzle;
            Puzzle7t.text = "엔진실 카드키 획득";
        }
        if (GameManager.gameManager._gameData.IsHealthMachineFixed_T_C20)
        {
            Puzzle8.sprite = Finish_puzzle;
            Puzzle8t.text = "업무공간 고치기";
        }
        if (GameManager.gameManager._gameData.IsDummyDataReport0)
        {
            Puzzle9.sprite = Finish_puzzle;
            Puzzle9t.text = "더미데이터 보고";
        }
        if (GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C20)
        {
            Puzzle10.sprite = Finish_puzzle;
            Puzzle10t.text = "운석 수집 성공";
        }
        if (GameManager.gameManager._gameData.IsCompletePretendDead0)
        {
            Puzzle11.sprite = Finish_puzzle;
            Puzzle11t.text = "죽은 척 하기";
        }
        if (GameManager.gameManager._gameData.IsKnowUsingSObj0)
        {
            Puzzle12.sprite = Finish_puzzle;
            Puzzle12t.text = "이상한 물건 발견";
        }
        if (GameManager.gameManager._gameData.IsFindDrugDone_T_C20)
        {
            Puzzle13.sprite = Finish_puzzle;
            Puzzle13t.text = "마약 탐지 성공";
        }
        if (GameManager.gameManager._gameData.IsCompleteOpenEngineRoom0)
        {
            Puzzle14.sprite = Finish_puzzle;
            Puzzle14t.text = "앤진실 해금";
        }
        if (GameManager.gameManager._gameData.IsCompleteOpenLivingRoom0)
        {
            Puzzle15.sprite = Finish_puzzle;
            Puzzle15t.text = "생활공간 해금";
        }
        if (GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E10)
        {
            Puzzle16.sprite = Finish_puzzle;
            Puzzle16t.text = "엔진실 고치기";
        }
        if (GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L10)
        {
            Puzzle17.sprite = Finish_puzzle;
            Puzzle17t.text = "생활공간 고치기";
        }
        if (GameManager.gameManager._gameData.IsTabletUnlock0)
        {
            Puzzle18.sprite = Finish_puzzle;
            Puzzle18t.text = "태블릿 해금";
        }
        if (GameManager.gameManager._gameData.IsAIVSMissionFinish0)
        {
            Puzzle19.sprite = Finish_puzzle;
            Puzzle19t.text = "상반된 일지 해금";
        }
        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet0)
        {
            Puzzle20.sprite = Finish_puzzle;
            Puzzle20t.text = "더미데이터 다운";
        }
        if (GameManager.gameManager._gameData.IsTabletDestory0)
        {
            Puzzle21.sprite = Finish_puzzle;
            Puzzle21t.text = "태블릿 발각";
        }
        //if (GameManager.gameManager._gameData.IsTabletDestory)
        //{
        //    Puzzle22.sprite = Finish_puzzle;
        //    Puzzle22t.text = "거짓 목적지 정하기";
        //}
        if (GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet0)
        {
            Puzzle23.sprite = Finish_puzzle;
            Puzzle23t.text = "거짓 궤도 좌표 해금";
        }
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet0)
        {
            Puzzle25.sprite = Finish_puzzle;
            Puzzle25t.text = "거짓 궤도 좌표 다운로드";
        }
        if (GameManager.gameManager._gameData.IsAIDown_M_C1C30)
        {
            Puzzle24.sprite = Finish_puzzle;
            Puzzle24t.text = "AI 다운시키기";
        }
        if (GameManager.gameManager._gameData.IsRevisioncomplaint0)
        {
            Puzzle26.sprite = Finish_puzzle;
            Puzzle26t.text = "고발하기";
        }
    }
}
