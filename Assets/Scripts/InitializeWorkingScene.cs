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


    [Header("<죽은 척 하기 완료하면>")]
    public GameObject Beaker1;
    public GameObject Beaker2;
    public GameObject CylinderAnswer;
    public GameObject CylinderWrong;
    public GameObject CylinderNoNeed1;
    public GameObject CylinderNoNeed2;
    public GameObject MeteorBoxButton1;
    public GameObject MeteorBoxButton2;
    public GameObject MeteorBoxButton3;
    public GameObject MeteorBoxButton4;
    public GameObject MeteorBoxButton5;
    public GameObject MeteoritesStorage1;
    public GameObject MeteoritesStorage2;
    public GameObject MeteoritesStorage3;
    public GameObject MeteoritesStorage4;
    public GameObject MeteoritesStorage5;
    public GameObject WrongMeteor1;
    public GameObject WrongMeteor2;
    public GameObject WrongMeteor3;
    public GameObject WrongMeteor4;
    public GameObject AnswerMeteor;

    [Header("<마약탐지>")]
    public GameObject smellRangeArea;
    public GameObject canSmellArea;
    public GameObject drugBag;
    public GameObject drug;
    public GameObject SDrug;
    public GameObject insert01;
    public GameObject insert02;


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

    BoxCollider Beaker1_Collider;
    BoxCollider Beaker2_Collider;
    BoxCollider CylinderAnswer_Collider;
    BoxCollider CylinderWrong_Collider;
    BoxCollider CylinderNoNeed1_Collider;
    BoxCollider CylinderNoNeed2_Collider;
    BoxCollider MeteorBoxButton1_Collider;
    BoxCollider MeteorBoxButton2_Collider;
    BoxCollider MeteorBoxButton3_Collider;
    BoxCollider MeteorBoxButton4_Collider;
    BoxCollider MeteorBoxButton5_Collider;
    BoxCollider MeteoritesStorage1_Collider;
    BoxCollider MeteoritesStorage2_Collider;
    BoxCollider MeteoritesStorage3_Collider;
    BoxCollider MeteoritesStorage4_Collider;
    BoxCollider MeteoritesStorage5_Collider;

    MeshCollider smellRangeAreaCol;
    MeshCollider canSmellAreaCol;
    BoxCollider drugBagCol;
    BoxCollider drugCol;
    BoxCollider SDrugCol;
    BoxCollider insert01Col;
    BoxCollider insert02Col;



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

        /*죽은척하기*/
        Beaker1_Collider = Beaker1.GetComponent<BoxCollider>();
        Beaker2_Collider = Beaker2.GetComponent<BoxCollider>();
        CylinderAnswer_Collider = CylinderAnswer.GetComponent<BoxCollider>();
        CylinderWrong_Collider = CylinderWrong.GetComponent<BoxCollider>();
        CylinderNoNeed1_Collider = CylinderNoNeed1.GetComponent<BoxCollider>();
        CylinderNoNeed2_Collider = CylinderNoNeed2.GetComponent<BoxCollider>();
        MeteorBoxButton1_Collider = MeteorBoxButton1.GetComponent<BoxCollider>();
        MeteorBoxButton2_Collider = MeteorBoxButton2.GetComponent<BoxCollider>();
        MeteorBoxButton3_Collider = MeteorBoxButton3.GetComponent<BoxCollider>();
        MeteorBoxButton4_Collider = MeteorBoxButton4.GetComponent<BoxCollider>();
        MeteorBoxButton5_Collider = MeteorBoxButton5.GetComponent<BoxCollider>();
        MeteoritesStorage1_Collider = MeteoritesStorage1.GetComponent<BoxCollider>();
        MeteoritesStorage2_Collider = MeteoritesStorage2.GetComponent<BoxCollider>();
        MeteoritesStorage3_Collider = MeteoritesStorage3.GetComponent<BoxCollider>();
        MeteoritesStorage4_Collider = MeteoritesStorage4.GetComponent<BoxCollider>();
        MeteoritesStorage5_Collider = MeteoritesStorage5.GetComponent<BoxCollider>();

        //마약 탐지
        smellRangeAreaCol = smellRangeArea.GetComponent<MeshCollider>();
        canSmellAreaCol = canSmellArea.GetComponent<MeshCollider>();
        drugBagCol = drugBag.GetComponent<BoxCollider>();
        drugCol = drug.GetComponent<BoxCollider>();
        SDrugCol = SDrug.GetComponent<BoxCollider>();
        insert01Col = insert01.GetComponent<BoxCollider>();
        insert02Col = insert02.GetComponent<BoxCollider>();


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


        /*엔진실 열기 퍼즐을 완료하면*/
        if(intialGameData.IsCompletePretendDead)
        {
            WrongMeteor1.SetActive(false);
            WrongMeteor2.SetActive(false);
            WrongMeteor3.SetActive(false);
            WrongMeteor4.SetActive(false);
            AnswerMeteor.SetActive(false);

            Beaker1_Collider.enabled = false;
            Beaker2_Collider.enabled = false;
            CylinderAnswer_Collider.enabled = false;
            CylinderNoNeed1_Collider.enabled = false;
            CylinderNoNeed2_Collider.enabled = false;
            MeteorBoxButton1_Collider.enabled = false;
            MeteorBoxButton2_Collider.enabled = false;
            MeteorBoxButton3_Collider.enabled = false;
            MeteorBoxButton4_Collider.enabled = false;
            MeteorBoxButton5_Collider.enabled = false;
            MeteoritesStorage1_Collider.enabled = false;
            MeteoritesStorage2_Collider.enabled = false;
            MeteoritesStorage3_Collider.enabled = false;
            MeteoritesStorage4_Collider.enabled = false;
            MeteoritesStorage5_Collider.enabled = false;
        }

        //마약 탐지 완료하면
        if(intialGameData.IsCheckDrug)
        {
            smellRangeArea.SetActive(false);
            canSmellArea.SetActive(false);
            drugBag.SetActive(false);

            insert01Col.enabled = false;
            drugCol.enabled = false;

            drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
            drug.transform.rotation = Quaternion.Euler(0, 0, 90);
            drug.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(intialGameData.IsFindDrugDone_T_C2)
        {
            insert02Col.enabled = false;
            SDrugCol.enabled = false;

            SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
            SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

}
