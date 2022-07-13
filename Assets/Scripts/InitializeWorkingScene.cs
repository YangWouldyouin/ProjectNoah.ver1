using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InitializeWorkingScene : MonoBehaviour
{
    GameData intialGameData;
    public GameObject dialog;
    DialogManager dialogManager;
    PortableObjectData workRoomData;

    [Header("<상태체크기계 고치기>")]
    public ObjectData HealthMachineData;
    public GameObject HealthMachineFixData;
    public ObjectData healthMachineFixPartData;

    [Header("<스마트팜 오픈>")]
    public GameObject FixedLine2; //고쳐진 줄
    public GameObject LineHome2; // 라인 홈
    public GameObject IronPlateDoor; // 스마트팜 합판 
    public GameObject TroubleLine; // 망가진 선
    public Animator smartFarmDoorAnim;
    public NavMeshObstacle smartFarmOpen;



    [Header("<엔진실 카드키 찾기>")]
    public GameObject CardPack; //카드팩
    public GameObject EngineCardKey; // 엔진실 카드 키



    [Header("<엔진실 문 열기 완료>")]
    public Animator engineDoorAnim; // 문열리는 애니메이션
    public GameObject BrokenArea; // 망가진 구역
    public GameObject Conduction; // 전도체
    public GameObject EngineDoor; // 엔진실 문
    public GameObject InsertCardPad; // 카드 패드
    public GameObject GoToEngineRoom;


    [Header("<생활공간 문 반만 열기 완료>")]
    public GameObject LivingSpaceDoor; //생활공간 문
    public GameObject goToLIving; // 생활공간해금
    public GameObject CardKey_WL; // 생활공간 카드키
    public GameObject LivingSpace_CardKeyMachine_W; // 생활공간 카드키 기계
    public Animator HalfLivingDoorAni_M; // 생활공간 문 반만 열리기
    BoxCollider CardKey_WL_Collider;
    BoxCollider LivingSpace_CardKeyMachine_W_Collider;


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


    [Header("<책상1오르기>")]
    public GameObject PackOnTable1;
    public GameObject Beaker1OnTable1;
    public GameObject Beaker2OnTable1;
    public GameObject cylinder1OnTable1;
    public GameObject cylinder2OnTable1;
    public GameObject cylinder3OnTable1;
    public GameObject cylinder4OnTable1;

    [Header("<책상2오르기>")]
    public GameObject SuperDrugOnTable2;
    public GameObject NoahFoodOnTable2;
    public GameObject Line2OnTable2;
    public GameObject ConductionOnTable2;


    [Header("<추가적인것>")]
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

    BoxCollider HealthMachineFixData_Collider;

    //책상오르기 콜라이더
    BoxCollider PackOnTable1_Collider;
    BoxCollider Beaker1OnTable1_Collider;
    BoxCollider Beaker2OnTable1_Collider;
    BoxCollider cylinder1OnTable1_Collider;
    BoxCollider cylinder2OnTable1_Collider;
    BoxCollider cylinder3OnTable1_Collider;
    BoxCollider cylinder4OnTable1_Collider;

    BoxCollider SuperDrugOnTable2_Collider;
    BoxCollider NoahFoodOnTable2_Collider;
    BoxCollider Line2OnTable2_Collider;
    BoxCollider ConductionOnTable2_Collider;


    // Start is called before the first frame update
    void Start()
    {
        intialGameData = SaveSystem.Load("save_001");

        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        dialogManager = dialog.GetComponent<DialogManager>();

        /* 업무공간 처음 들어왔을때 대사 & 미션 */
        if (!intialGameData.IsFirstEnterWorking && !intialGameData.IsHealthMachineFixed_T_C2)
        {
            Invoke("FirstEnter", 4f);
        }

        /*상태체크기계고치기*/
        HealthMachineFixData_Collider = HealthMachineFixData.GetComponent<BoxCollider>();

        /*스마트팜 오픈*/
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        /*엔진실 오픈*/
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();

        /* 생활공간 오픈 */
        CardKey_WL_Collider = CardKey_WL.GetComponent<BoxCollider>();
        LivingSpace_CardKeyMachine_W_Collider = CardKey_WL.GetComponent<BoxCollider>();

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

        //책상 1 오르기
        PackOnTable1_Collider = PackOnTable1.GetComponent<BoxCollider>();
        Beaker1OnTable1_Collider = Beaker1OnTable1.GetComponent<BoxCollider>();
        Beaker2OnTable1_Collider = Beaker2OnTable1.GetComponent<BoxCollider>();
        cylinder1OnTable1_Collider = cylinder1OnTable1.GetComponent<BoxCollider>();
        cylinder2OnTable1_Collider = cylinder2OnTable1.GetComponent<BoxCollider>();
        cylinder3OnTable1_Collider = cylinder3OnTable1.GetComponent<BoxCollider>();
        cylinder4OnTable1_Collider = cylinder4OnTable1.GetComponent<BoxCollider>();


        //책상 2 오르기
        SuperDrugOnTable2_Collider = SuperDrugOnTable2.GetComponent<BoxCollider>();
        NoahFoodOnTable2_Collider = NoahFoodOnTable2.GetComponent<BoxCollider>();
        Line2OnTable2_Collider = Line2OnTable2.GetComponent<BoxCollider>();
        ConductionOnTable2_Collider = ConductionOnTable2.GetComponent<BoxCollider>();

        if (intialGameData.IsAIVSMissionCount >= 3 && !intialGameData.IsFirstNoticeEnd)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(54));
            //GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.AddNewMission(8);
        }
   
        FixHealthMachine(); /*상태체크기계 고치기*/

        OpenSmartFarm(); /*스마트팜 오픈 퍼즐을 완료 하면*/

        /*엔진실 문을 수리하면*/
        if (intialGameData.IsEngineDoorFix_M_C2)
        {
            /*전도체 안보이게*/
            workRoomData.IsObjectActiveList[33] = false;
        }


        /*엔진실 카드 키 찾기 퍼즐을 완료하면*/
        if (intialGameData.IsCompleteFindEngineKey)
        {
            /*카드팩, 카드키 안보이게*/
            workRoomData.IsObjectActiveList[31] = false;

        }
      
        OpenEngineRoom(); /*엔진실 열기 퍼즐을 완료하면*/

        HalfLivingDoor(); /* 생활공간 문 반 열기 퍼즐 완료 시 */


        // 생활공간 문을 완전히 고치면
        if (intialGameData.IsCompleteOpenLivingRoom)
        {
            LivingSpaceDoor.transform.position = new Vector3(-263.12f, -0.67f, 694.04f);
        }


        ColectMeteorite();  /*운석 수집 퍼즐을 완료하면*/

        PretendDead(); /*죽은척하기 퍼즐을 완료하면*/

        DetectDrug(); //마약 탐지 완료하면


        if (intialGameData.IsFindDrugDone_T_C2)
        {
            insert02Col.enabled = false;
            SDrugCol.enabled = false;

            SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
            SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        UpTable1(); //책상1 오르기를 완료하면

        UpTable2(); //책상2 오르기를 완료하면


        if(intialGameData.IsCanSeePotato1)
        {
            CanSeeSweetPotato1();
        }

        if (intialGameData.IsCanSeePotato2)
        {
            CanSeeSweetPotato2();
        }

        if (intialGameData.IsCanSeePotato3)
        {
            CanSeeSweetPotato3();
        }
    }



    void FirstEnter()
    {
        //W_HM_1
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5));

        //GameManager.gameManager._gameData.ActiveMissionList[4] = true; // 생활공간 진입
        //GameManager.gameManager._gameData.ActiveMissionList[5] = true; // 엔진실 진입
        //GameManager.gameManager._gameData.ActiveMissionList[13] = true;  //냄새로 업무공간 고치기 시작
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        MissionGenerator.missionGenerator.AddNewMission(4);
        StartCoroutine(AddSecondMission());
        StartCoroutine(AddThirdMission());
    }

    IEnumerator AddSecondMission()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(5);
    }
    IEnumerator AddThirdMission()
    {
        yield return new WaitForSeconds(4f);
        MissionGenerator.missionGenerator.AddNewMission(13);
        GameManager.gameManager._gameData.IsFirstEnterWorking = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void FixHealthMachine()
    {
        if (intialGameData.IsHealthMachineFixed_T_C2)
        {
            HealthMachineFixData.GetComponent<Rigidbody>().isKinematic = false;
            HealthMachineFixData.transform.parent = null;
            healthMachineFixPartData.IsBite = false;

            HealthMachineFixData.transform.position = new Vector3(-258.092f, 0f, 680.078f);
            HealthMachineFixData.transform.rotation = Quaternion.Euler(-90, 0, 0);

            HealthMachineFixData_Collider.enabled = false;

            HealthMachineData.IsCenterButtonDisabled = false;
        }
    }

    void OpenSmartFarm()
    {
        if (intialGameData.IsCompleteSmartFarmOpen)
        {
            /*망가진 전선 안보이게*/
            workRoomData.IsObjectActiveList[34] = false;

            /*고쳐진 전선 위치 고정*/
            FixedLine2.transform.position = new Vector3(-258.06f, 0.674f, 670.384f); //위치 값
            FixedLine2.transform.rotation = Quaternion.Euler(0, -90, 90); // 각도 값 

            smartFarmOpen.enabled = false;
            LineHome2_Collider.enabled = false;
            IronPlateDoor_Collider.enabled = false;
            workRoomData.IsObjectActiveList[34] = false;

            smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
            smartFarmDoorAnim.SetBool("FarmDoorStop", true);
        }
        else
        {
            smartFarmOpen.enabled = true;
        }
    }

    void OpenEngineRoom()
    {
        if (intialGameData.IsCompleteOpenEngineRoom)
        {

            /*전도체 안보이게*/
            workRoomData.IsObjectActiveList[33] = false;

            /*카드 안보이게*/
            workRoomData.IsObjectActiveList[32] = false;

            engineDoorAnim.SetBool("canEngineDoorOpen", true);
            engineDoorAnim.SetBool("canEngineDoorEnd", true);
            GoToEngineRoom.SetActive(true);

            //중복임
/*            EngineCardKey.SetActive(false);
            Conduction.SetActive(false);*/

            BrokenArea_Collider.enabled = false;
            EngineDoor_Collider.enabled = false;
            InsertCardPad_Collider.enabled = false;
        }
    }

    void HalfLivingDoor()
    {
        if (intialGameData.IsWLDoorHalfOpened_M_C2)
        {
            HalfLivingDoorAni_M.SetBool("HalfOpen", true); // 생활공간 문 반만 열리기
            HalfLivingDoorAni_M.SetBool("HalfEnd", true);
            goToLIving.SetActive(true);

            CardKey_WL.transform.position = new Vector3(-264.18f, 2.94f, 691.467f); //위치
            CardKey_WL.transform.rotation = Quaternion.Euler(0, 0, 90); //각도

            CardKey_WL_Collider.enabled = false;
            LivingSpace_CardKeyMachine_W_Collider.enabled = false;
        }
    }

    void ColectMeteorite()
    {
        if (intialGameData.IsInputNormalMeteor1_T_C2)
        {
            meteorBoxAnim.SetBool("isMeteorBoxClose", false);
            meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", false);
            meteorBoxAnim.SetBool("isMeteorBoxOpen", true);
            meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", true);


            analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineClose", false);
            analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", false);

            /*일반 운석 안보이게*/
            workRoomData.IsObjectActiveList[30] = false;

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

    void PretendDead()
    {
        if (intialGameData.IsCompletePretendDead)
        {
            /*운석 보관함에 있던 운석들 안보이게*/
            workRoomData.IsObjectActiveList[31] = false;
            workRoomData.IsObjectActiveList[24] = false;
            workRoomData.IsObjectActiveList[25] = false;
            workRoomData.IsObjectActiveList[26] = false;
            workRoomData.IsObjectActiveList[27] = false;
            workRoomData.IsObjectActiveList[28] = false;

            Beaker1_Collider.enabled = false;
            Beaker2_Collider.enabled = false;
            CylinderAnswer_Collider.enabled = false;
            CylinderWrong_Collider.enabled = false;
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
    }

    void DetectDrug()
    {
        if (intialGameData.IsCheckDrug)
        {
            /*얘네는 못움직이는 오브젝트들*/
            smellRangeArea.SetActive(false);
            canSmellArea.SetActive(false);

            /*drugBag 안보이게*/
            workRoomData.IsObjectActiveList[37] = false;

            insert01Col.enabled = false;
            drugCol.enabled = false;

            drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
            drug.transform.rotation = Quaternion.Euler(0, 0, 90);
            drug.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void UpTable1()
    {
        if (intialGameData.IsUpTable1)
        {
            /*책상 위에 올라가면 책상 위 오브젝트랑 상호작용 가능하도록*/
            PackOnTable1_Collider.enabled = true;
            Beaker1OnTable1_Collider.enabled = true;
            Beaker2OnTable1_Collider.enabled = true;
            cylinder1OnTable1_Collider.enabled = true;
            cylinder2OnTable1_Collider.enabled = true;
            cylinder3OnTable1_Collider.enabled = true;
            cylinder4OnTable1_Collider.enabled = true;
        }
    }

    void UpTable2()
    {
        if (intialGameData.IsUpTable1)
        {
            /*책상 위에 올라가면 책상 위 오브젝트랑 상호작용 가능하도록*/
            SuperDrugOnTable2_Collider.enabled = true;
            NoahFoodOnTable2_Collider.enabled = true;
            Line2OnTable2_Collider.enabled = true;
            ConductionOnTable2_Collider.enabled = true;
        }
    }

    void CanSeeSweetPotato1()
    {
        if (intialGameData.IsCanSeePotato1)
        {
            /*고구마들 보이게~*/
            workRoomData.IsObjectActiveList[21] = true;
            workRoomData.IsObjectActiveList[22] = true;
            workRoomData.IsObjectActiveList[23] = true;
        }
    }

    void CanSeeSweetPotato2()
    {
        if (intialGameData.IsCanSeePotato2)
        {
            /*고구마들 보이게~*/
            workRoomData.IsObjectActiveList[18] = true;
            workRoomData.IsObjectActiveList[19] = true;
            workRoomData.IsObjectActiveList[20] = true;
        }
    }

    void CanSeeSweetPotato3()
    {
        if (intialGameData.IsCanSeePotato3)
        {
            /*고구마들 보이게~*/
            workRoomData.IsObjectActiveList[15] = true;
            workRoomData.IsObjectActiveList[16] = true;
            workRoomData.IsObjectActiveList[17] = true;
        }
    }
}
