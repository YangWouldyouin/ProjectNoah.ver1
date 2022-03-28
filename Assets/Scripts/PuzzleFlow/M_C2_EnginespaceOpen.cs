using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_EnginespaceOpen : MonoBehaviour
{

    private static bool IsOpenCabinetDoor_M_C2 = false;
    private static bool IsFindRubbe_M_C2 = false;
    private static bool IsEngineDoorFix_M_C2 = false;
    private static bool IsEngineRoomOpen_M_C2 = false;

    private Outline RubbeOutline;
    private Outline CabinetFirstFloorOutline;
    private Outline CardPadOutline;
    private Outline ConductionOutline;
    private Outline EngineKeyOutline;
    private Outline BrokenPartOutline;



    public GameObject EngineDoor_M_C2;
    public GameObject Conduction_M_C2; // 전도체
    public GameObject Rubbe_M_C2; // 고무
    public GameObject Box2_M_C2;
    public GameObject EngineKey_M_C2;
    public GameObject BrokenPart_M_C2;
    public GameObject CardPad_M_C2;

    public GameObject CabinetDoor_M_C2; //캐비닛 문
    public GameObject CabinetFirstFloor_M_C2; // 캐비닛 1층




    void Start()
    {
        RubbeOutline = Rubbe_M_C2.GetComponent<Outline>();
        CabinetFirstFloorOutline = CabinetFirstFloor_M_C2.GetComponent<Outline>();
        CardPadOutline = CardPad_M_C2.GetComponent<Outline>();
        ConductionOutline = Conduction_M_C2.GetComponent<Outline>(); 
        EngineKeyOutline = EngineKey_M_C2.GetComponent<Outline>();
        BrokenPartOutline = BrokenPart_M_C2.GetComponent<Outline>(); ;


        //엔진실 카드 찾기 퍼즐 완료 확인
        // 엔진실 문에 다가가면 전기 끊어진 소리 재생
        // AI가 문이 고장난 거 같다는 대사 출력
    }

    void Update()
    {
        if(IsOpenCabinetDoor_M_C2 == false)
        {
            ByeCabinetDoor();
        }

        if(IsFindRubbe_M_C2 == false)
        {
            FindRubbe();
        }

        if(IsEngineDoorFix_M_C2 == false)
        {
            CanInsert();
        }

        if(IsEngineRoomOpen_M_C2 == false)
        {
            CanOpen();
        }
    }

    void ByeCabinetDoor()
    {
        ObjData CabineDoortData = CabinetDoor_M_C2.GetComponent<ObjData>();

        if(CabineDoortData.IsPushOrPress)
        {
            Debug.Log("나는 캐비닛 문을 눌럿어요");
            CabineDoortData.transform.position = new Vector3(-259.55f, 541.68f, 688.09f); //위치 고정
            CabineDoortData.transform.rotation = Quaternion.Euler(-90f, -90, -107.177f); //각도 고정
            //CabineDoortData.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정
            IsOpenCabinetDoor_M_C2 = true;
        }


    }

    void FindRubbe()
    {
        ObjData CabinetFirstFloorData = CabinetFirstFloor_M_C2.GetComponent<ObjData>();
        ObjData RubbeData = Rubbe_M_C2.GetComponent<ObjData>();


        if (IsOpenCabinetDoor_M_C2 == true)
        {
            CabinetFirstFloorData.IsNotInteractable = false; // 상호작용 가능하게
            CabinetFirstFloorOutline.OutlineWidth = 8;
        }

        if(CabinetFirstFloorData.IsObserve)
        {
            CameraController.cameraController.currentView = CabinetFirstFloorData.ObserveView;
            RubbeData.IsNotInteractable = false;
            RubbeOutline.OutlineWidth = 8;
        }

        if (RubbeData.IsBite)
        {
            CabinetFirstFloorData.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            IsFindRubbe_M_C2 = true;
        }


    }


    void CanInsert()
    {
        ObjData ConductionData = Conduction_M_C2.GetComponent<ObjData>();
        ObjData BrokenPartData = BrokenPart_M_C2.GetComponent<ObjData>();
        ObjData RubbeData = Rubbe_M_C2.GetComponent<ObjData>();

        if (ConductionData.IsBite)
        {
            BrokenPartData.IsCenterButtonDisabled = false;
        }

        if (ConductionData.IsBite && BrokenPartData.IsInsert)
        {
            // 노아 감전 엔딩
            Debug.Log("감전엔딩 출력");
        }


        if (RubbeData.IsBite && ConductionData.IsBite && BrokenPartData.IsInsert)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            Conduction_M_C2.GetComponent<Rigidbody>().isKinematic = false;
            Conduction_M_C2.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            Conduction_M_C2.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //위치 고정
            Conduction_M_C2.transform.rotation = Quaternion.Euler(90, 90, 0); //각도 고정
            IsEngineDoorFix_M_C2 = true;

            // 망가진 문 부분이랑 끼운 전도체의 상호작용을 삭제한다.
            BrokenPartData.IsNotInteractable = true;
            BrokenPartOutline.OutlineWidth = 0;

            ConductionData.IsNotInteractable = true;
            ConductionOutline.OutlineWidth = 0;
        }

    }



    void CanOpen()
    {
        ObjData CardPadData = CardPad_M_C2.GetComponent<ObjData>();
        ObjData EngineKeyData = EngineKey_M_C2.GetComponent<ObjData>();

        if (IsEngineDoorFix_M_C2 == true)
        {
            CardPadData.IsNotInteractable = false;
            CardPadOutline.OutlineWidth = 8;
        }

        if(EngineKeyData.IsBite && CardPadData.IsPushOrPress)
        {
            Invoke("DoorDisapppear", 4f);
            IsEngineRoomOpen_M_C2 = true;

            // 카드키랑 카드 패드 상호작용을 삭제한다
            CardPadData.IsNotInteractable = true;
            CardPadOutline.OutlineWidth = 0;

            EngineKeyData.IsNotInteractable = true;
            CardPadOutline.OutlineWidth = 0;
        }
    }

    void DoorDisapppear() // 스마트팜 입구 사라지기
    {
        EngineDoor_M_C2.SetActive(false);
    }
}
