using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeWorkingScene : MonoBehaviour
{
    public GameObject ChangeScene;


    [Header("<스마트팜 오픈>")]
    public GameObject FixedLine2; //고쳐진 줄
    public GameObject LineHome2; // 라인 홈
    public GameObject IronPlateDoor; // 스마트팜 합판 
    public GameObject TroubleLine; // 망가진 선
    public Animator smartFarmDoorAnim;



    [Header("<엔진실 카드키 찾기>")]
    public GameObject CardPack; //카드팩
    public GameObject EngineCardKey; // 엔진실 카드 키



    [Header("<엔진실 문 열기 완료>")]
    public Animator engineDoorAnim; // 문열리는 애니메이션
    public GameObject BrokenArea; // 망가진 구역
    public GameObject Conduction; // 전도체
    public GameObject EngineDoor; // 엔진실 문
    public GameObject InsertCardPad; // 카드 패드

    [Header("<운석 수집 완료>")]
    public Animator meteorBoxAnim; //  수집기 문열리는 애니메이션
    public Animator analyticalMachineAnim; // 분석기 문열리는 애니메이션
    public GameObject ImportantMeteor; // 중요 운석
    public GameObject NormalMeteor1; // 평범한 운석1



    /*Object Data*/
    public ObjectData MeteorButtonData_Save;
    public ObjectData MeteorCollectMachineData_Save;
    public ObjectData AnalyticalMachineData_Save;
    public ObjectData AnalyticalMachineButtonData_Save;

    /*Outline*/
    public Outline MeteorButtonOutline_Save;
    public Outline MeteorCollectMachineOutline_Save;
    public Outline AnalyticalMachineOutline_Save;
    public Outline AnalyticalMachineButtonOutline_Save;

    /*BoxCollider*/
    BoxCollider LineHome2_Collider;
    BoxCollider IronPlateDoor_Collider;

    BoxCollider BrokenArea_Collider;
    BoxCollider EngineDoor_Collider;
    BoxCollider InsertCardPad_Collider;



    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");


        /*스마트팜 오픈*/
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        /*엔진실 오픈*/
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();




        /*스마트팜 오픈 퍼즐을 완료 하면*/
        if (intialGameData.IsCompleteSmartFarmOpen)
        {
            LineHome2_Collider.enabled = false;
            IronPlateDoor_Collider.enabled = false;
            TroubleLine.SetActive(false);
            FixedLine2.SetActive(false);
            smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
            smartFarmDoorAnim.SetBool("FarmDoorStop", true);
        }
         

        /*엔진실 카드 키 찾기 퍼즐을 완료하면*/
        if (intialGameData.IsCompleteFindEngineKey)
        {
            CardPack.SetActive(false);
            EngineCardKey.SetActive(true);

        }
         

        /*엔진실 열기 퍼즐을 완료하면*/
        if (intialGameData.IsCompleteOpenEngineRoom)
        {
            engineDoorAnim.SetBool("canEngineDoorOpen", true);
            engineDoorAnim.SetBool("canEngineDoorEnd", true);
            ChangeScene.SetActive(true);

            EngineCardKey.SetActive(false);
            Conduction.SetActive(false);

            BrokenArea_Collider.enabled = false;
            EngineDoor_Collider.enabled = false;
            InsertCardPad_Collider.enabled = false;
        }


        /*운석 수집 퍼즐을 완료하면*/
        if(intialGameData.IsInputNormalMeteor1_T_C2)
        {
            meteorBoxAnim.SetBool("isMeteorBoxClose", false);
            meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", false);
            meteorBoxAnim.SetBool("isMeteorBoxOpen", true);
            meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", true);


            analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineClose", false);
            analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", false);

            NormalMeteor1.SetActive(false);

            MeteorButtonData_Save.IsNotInteractable = true;
            MeteorButtonOutline_Save.OutlineWidth = 0;

            MeteorCollectMachineData_Save.IsNotInteractable = false;
            MeteorCollectMachineOutline_Save.OutlineWidth = 8;

            AnalyticalMachineButtonData_Save.IsNotInteractable = true;
            AnalyticalMachineButtonOutline_Save.OutlineWidth = 0;

            AnalyticalMachineData_Save.IsNotInteractable = false;
            AnalyticalMachineOutline_Save.OutlineWidth = 8;

        }
    }

}
