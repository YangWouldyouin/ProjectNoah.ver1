using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_EngineDoor : MonoBehaviour
{
    //카드키 찾기
    public GameObject cardPack_WED; //카드팩
    public GameObject engineKey_WED; //엔진실 카드키

    //엔진실 해금
    public GameObject engineDoor_WED; //엔진실문
    public GameObject conduction_WED; // 전도체
    public GameObject rubber_WED; // 고무
    public GameObject brokenPart_WED; // 망가진 부분
    public GameObject insertCardPad_WED; // 카드 끼우는 패드
    public GameObject cabinetDoor_WED; //캐비닛 문
    public GameObject cabinetFirstFloor_WED; // 캐비닛 1층

    //카드키 찾기
    ObjData cardPackData_WED;
    ObjData engineKeyData_WED;

    //엔진실 해금
    ObjData engineDoorData_WED;
    ObjData conductionData_WED;
    ObjData rubberData_WED;
    ObjData brokenPartData_WED;
    ObjData insertCardPadData_WED;
    ObjData cabinetDoorData_WED;
    ObjData cabinetFirstFloorData_WED;


    Outline rubbeOutline_WED;
    Outline cabinetFirstFloorOutline_WED;
    Outline insertCardPadOutline_WED;
    Outline conductionOutline_WED;
    Outline engineKeyOutline_WED;
    Outline brokenPartOutline_WED;


    public Animator engineDoorAnim_WED;
    public Animator canEngineDoorAnim_WED;

    void Start()
    {
        //카드키 찾기
        cardPackData_WED = cardPack_WED.GetComponent<ObjData>();
        engineKeyData_WED = engineKey_WED.GetComponent<ObjData>();

        //엔진실 해금
        engineDoorData_WED = engineDoor_WED.GetComponent<ObjData>();
        conductionData_WED = conduction_WED.GetComponent<ObjData>();
        rubberData_WED = rubber_WED.GetComponent<ObjData>();
        brokenPartData_WED = brokenPart_WED.GetComponent<ObjData>();
        insertCardPadData_WED = insertCardPad_WED.GetComponent<ObjData>();
        cabinetDoorData_WED = cabinetDoor_WED.GetComponent<ObjData>();
        cabinetFirstFloorData_WED = cabinetFirstFloor_WED.GetComponent<ObjData>();

        //아웃라인
        rubbeOutline_WED = rubber_WED.GetComponent<Outline>();
        cabinetFirstFloorOutline_WED = cabinetFirstFloor_WED.GetComponent<Outline>();
        insertCardPadOutline_WED = insertCardPad_WED.GetComponent<Outline>();
        conductionOutline_WED = conduction_WED.GetComponent<Outline>();
        engineKeyOutline_WED = engineKey_WED.GetComponent<Outline>();
        brokenPartOutline_WED = brokenPart_WED.GetComponent<Outline>(); 

        if(GameManager.gameManager.IsEngineDoorFix_M_C2 == false)
        {
            // 엔진실 문에 다가가면 전기 끊어진 소리 재생
            // AI가 문이 고장난 거 같다는 대사 출력
        }
    }

    // Update is called once per frame
    void Update()
    {
        //카드키 찾기
        if (cardPackData_WED.IsDestroy)
        {
            // 카드팩에서 카드키를 벗어나게 한다.
            engineKeyData_WED.GetComponent<Rigidbody>().isKinematic = false; 
            engineKeyData_WED.transform.parent = null;
            Invoke("Disapppear", 3f);
            GameManager.gameManager.IsDisappearPack_M_C2 = true;
        }



        //캐비닛 문열기
        if (cabinetDoorData_WED.IsPushOrPress)
        {
            Invoke("CabinetOpen", 2f);
            GameManager.gameManager.IsOpenCabinetDoor_M_C2 = true;
        }



        // 캐비닛에 상호작용 가능하게
        if (GameManager.gameManager.IsOpenCabinetDoor_M_C2 == true)
        {
            cabinetFirstFloorData_WED.IsNotInteractable = false; // 상호작용 가능하게
            cabinetFirstFloorOutline_WED.OutlineWidth = 8;
        }


        //캐비닛에 관찰하기를 하면 캐비닛 안쪽 물건이 상호작용 가능하다.
        if (cabinetFirstFloorData_WED.IsObserve)
        {
            CameraController.cameraController.currentView = cabinetFirstFloorData_WED.ObserveView;
            rubberData_WED.IsNotInteractable = false;
            rubbeOutline_WED.OutlineWidth = 8;
        }


        // 고무를 물면 고무를 찾은걸로 판단한다. 
        if (rubberData_WED.IsBite)
        {
            cabinetFirstFloorData_WED.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            GameManager.gameManager.IsFindRubbe_M_C2 = true;
        }



        //전도체를 그냥 물면
        if (conductionData_WED.IsBite)
        {
            //망가진 곳에 상호작용 가능
            brokenPartData_WED.IsCenterButtonDisabled = false;
        }


        //고무를 물고 전도체를 물고 망가진 곳에 끼우기를 하면
        if (rubberData_WED.IsBite && conductionData_WED.IsBite && brokenPartData_WED.IsInsert)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            conduction_WED.GetComponent<Rigidbody>().isKinematic = false;
            conduction_WED.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            conduction_WED.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //위치 고정
            conduction_WED.transform.rotation = Quaternion.Euler(90, 90, 0); //각도 고정

            // 망가진 문 부분이랑 끼운 전도체의 상호작용을 삭제한다.
            brokenPartData_WED.IsNotInteractable = true;
            brokenPartOutline_WED.OutlineWidth = 0;

            conductionData_WED.IsNotInteractable = true;
            conductionOutline_WED.OutlineWidth = 0;

            GameManager.gameManager.IsEngineDoorFix_M_C2 = true;
        }

        // 전도체를 그냥 물고 망가진 곳에 끼우면 
        else if (conductionData_WED.IsBite && brokenPartData_WED.IsInsert)
        {
            // 노아 감전 엔딩
            Debug.Log("감전엔딩 출력");
        }


        if (GameManager.gameManager.IsEngineDoorFix_M_C2 == true)
        {
            Debug.Log("문이 고쳐진상태입니다.");
            insertCardPadData_WED.IsNotInteractable = false;
            insertCardPadOutline_WED.OutlineWidth = 8;
        }


        if (insertCardPadData_WED.IsCollision == true)
        {
            /* 특수 상호작용 버튼을 비활성화->오르기로 바꿔주겠다는 것이다. 
            (기본적으로 비활성화 상태라면 인스펙터의 IsCenterButtonDisabled에 체크를 해두자)*/

            insertCardPadData_WED.IsCenterButtonDisabled = false;

        }

        /* IsCenterButtonDisabled => 센터 버튼 비활성화가 트루이면 다시 비활성화 상태로 돌리겠다는 것이다. 
        책상에서 내려왔을 때 상자 위가 아님을 알면 다시 '오르기'를 비활성화로 바꾸기 위해 넣는 코드*/
        else
        {
            insertCardPadData_WED.IsCenterButtonDisabled = true;
        }




        if (engineKeyData_WED.IsBite && insertCardPadData_WED.IsPushOrPress)
        {
            Invoke("DoorOpen", 2f);
            GameManager.gameManager.IsEngineRoomOpen_M_C2 = true;

            // 카드키랑 카드 패드 상호작용을 삭제한다
            insertCardPadData_WED.IsNotInteractable = true;
            insertCardPadOutline_WED.OutlineWidth = 0;

            engineKeyData_WED.IsNotInteractable = true;
            engineKeyOutline_WED.OutlineWidth = 0;
        }

    }

    void Disapppear()
    {
        cardPack_WED.SetActive(false);
        engineKey_WED.SetActive(true);
    }

    void DoorOpen() // 엔진실 열기 
    {
        canEngineDoorAnim_WED.SetBool("canEngineDoorOpen", true);
        canEngineDoorAnim_WED.SetBool("canEngineDoorEnd", true);
    }

    void CabinetOpen()
    {
        engineDoorAnim_WED.SetBool("eCabinetOpen", true);
        engineDoorAnim_WED.SetBool("eCabinetEnd", true);

    }
}
