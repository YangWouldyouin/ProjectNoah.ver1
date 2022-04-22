using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_EngineDoor : MonoBehaviour
{
    private bool IsEngineDoorFix_M_C2 = false;

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
    Outline cabinetDoorOutline_WED;


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
        cabinetDoorOutline_WED = cabinetDoor_WED.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameManager._gameData.IsWEDoorOpened_M_C2)
        {
            //if () // 엔진실 문을 클릭하면 
            //{
            //    // 엔진실 문에 다가가면 전기 끊어진 소리 재생
            //    // AI가 문이 고장난 거 같다는 대사 출력
            //}


            // 10.상자를 다시 끌고  InsertCardPad 앞으로 다가온다. 상자 위로 올라가서 아까 물고온 카드를 '넣기' 한다.
            // (인설트 책상이나 카드 패드랑 노아가 성공적으로 부딪혔으면 콘솔창에 '나는 부딪혔어' 디버그가 뜰거야)
            if (engineKeyData_WED.IsBite && insertCardPadData_WED.IsPushOrPress)
            {
                Invoke("DoorOpen", 2f);

                // 카드키랑 카드 패드 상호작용을 삭제한다
                insertCardPadData_WED.IsNotInteractable = true;
                insertCardPadOutline_WED.OutlineWidth = 0;

                engineKeyData_WED.IsNotInteractable = true;
                engineKeyOutline_WED.OutlineWidth = 0;

                /* 엔진실 열기 완료 */
                GameManager.gameManager._gameData.IsWEDoorOpened_M_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }



            // 5. 책상으로 다가가 카드팩을 파괴하기 한다. ( 카드키 찾기 )
            if (cardPackData_WED.IsSmash)
            {

                Invoke("Disapppear", 3f);
                engineKeyData_WED.IsNotInteractable = false;
                engineKeyOutline_WED.OutlineWidth = 8;
            }




            /* 고무 찾기 */
            // 2. 캐비닛에 관찰하기를 하면 캐비닛 안쪽 물건이 상호작용 가능하다.
            if (cabinetFirstFloorData_WED.IsObserve)
            {
                CameraController.cameraController.currentView = cabinetFirstFloorData_WED.ObserveView;
                rubberData_WED.IsNotInteractable = false;
                rubbeOutline_WED.OutlineWidth = 8;

                // 3. 캐비닛 안에 있는 고무를 문다.
                if (rubberData_WED.IsBite)
                {
                    CameraController.cameraController.CancelObserve();
                    cabinetFirstFloorData_WED.IsObserve = false;
                    
                }
            }
            else // 관찰하기 해제 시 고무 다시 비활성화 
            {
                rubberData_WED.IsNotInteractable = true;
                rubbeOutline_WED.OutlineWidth = 0;
            }
            // 1. 엔진실 문 왼쪽 캐비닛 중에 제일 키가 작은 캐비닛을 누르기로 연다.( 캐비닛 문열기 )
            if (cabinetDoorData_WED.IsPushOrPress)
            {
                Invoke("CabinetOpen", 2f);
            }





            /* 기계 수리하기 */
            //전도체를 그냥 물면
            if (conductionData_WED.IsBite)
            {
                //망가진 곳에 상호작용 가능
                brokenPartData_WED.IsCenterButtonDisabled = false;

                // 고무를 물고 전도체를 물고 망가진 곳에 끼우기를 하면
                if (conductionData_WED.IsBite)
                {
                    if(brokenPartData_WED.IsPushOrPress)
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

                        IsEngineDoorFix_M_C2 = true;
                    }
                }
                else // 전도체를 그냥 물고 망가진 곳에 끼우면
                {
                    if (brokenPartData_WED.IsPushOrPress)
                    {
                        {
                            // 노아 감전 엔딩
                            Debug.Log("감전엔딩 출력");
                        }
                    }
                }
            }


            if (IsEngineDoorFix_M_C2)
            {
                Debug.Log("문이 고쳐진상태입니다.");
                //AI가 문이 고쳐졌다는 걸 알려준다.
                //문은 고쳐졌지만 카드 끼기에는 높이가 부족하다는 사실을 알려준다.

                //노아의 높이가 충분하면 상호작용 가능
                if (insertCardPadData_WED.IsCollision == true)
                {

                    insertCardPadData_WED.IsNotInteractable = false;
                    insertCardPadOutline_WED.OutlineWidth = 8;

                }
                else
                {
                    Debug.Log("문은 고쳐졌지만 카드끼기에는 높이가 부족하다 ");
                    insertCardPadData_WED.IsNotInteractable = true;
                    insertCardPadOutline_WED.OutlineWidth = 0;
                }
            }
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

        // 캐비닛 문 비활성화
        cabinetDoorData_WED.IsNotInteractable = true;
        cabinetDoorOutline_WED.OutlineWidth = 0;

        // 캐비닛에 상호작용 가능하게
        cabinetFirstFloorData_WED.IsNotInteractable = false;
        cabinetFirstFloorOutline_WED.OutlineWidth = 8;
    }
}


//// 4. 고무를 물고 전도체를 물고 망가진 곳에 끼우기를 하면
//if (rubberData_WED.IsBite && conductionData_WED.IsBite && brokenPartData_WED.IsPushOrPress)
//{
//    // 끼우기 성공
//    // 부모 자식 관계를 해제한다.
//    conduction_WED.GetComponent<Rigidbody>().isKinematic = false;
//    conduction_WED.transform.parent = null;

//    // 해당 위치, 각도, 크기로 바꾸겠다.
//    conduction_WED.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //위치 고정
//    conduction_WED.transform.rotation = Quaternion.Euler(90, 90, 0); //각도 고정

//    // 망가진 문 부분이랑 끼운 전도체의 상호작용을 삭제한다.
//    brokenPartData_WED.IsNotInteractable = true;
//    brokenPartOutline_WED.OutlineWidth = 0;

//    conductionData_WED.IsNotInteractable = true;
//    conductionOutline_WED.OutlineWidth = 0;

//    GameManager.gameManager.IsEngineDoorFix_M_C2 = true;
//}

//// 전도체를 그냥 물고 망가진 곳에 끼우면 
//else if (conductionData_WED.IsBite && brokenPartData_WED.IsPushOrPress)
//{
//    // 노아 감전 엔딩
//    Debug.Log("감전엔딩 출력");
//}