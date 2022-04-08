using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindLivingspaceKey : MonoBehaviour
{

    private GameObject nowObject_M_C2_FindLivingspaceKey;

    public GameObject Cabinet;
    public GameObject Card_Key; // 생활공간 카드키
    public GameObject Card_Machine_Living; //생활공간 카드인식기계
    public GameObject livingroomDoor; //생활공간 문
    public GameObject Box; //상자

    public static bool HalfOpenLivingroomDoor = false;
    private bool HasCard_Machine_Living = false;


    //private Vector3 PlayerDoorOpenPosition = new Vector3(-270.42f, 504.13f, 673.509f);
    private Vector3 PlayerOriginPosition = new Vector3(-260.161f, 538.39f, 666.48f);
    private Vector3 PlayerDoorOpenPosition = new Vector3(-259.15f, 537.83f, 694.03f);

    private void Update()
    {

        ObserveCardMachine();

        if (HasCard_Machine_Living)
        {
            PutLivingRoomKey();
        }
        else
        {
            FindCardKey();
        }
    }

    public void ObserveCardMachine()
    {
        ObjData Card_Machine_LivingData = Card_Machine_Living.GetComponent<ObjData>();
        ObjData BoxData = Box.GetComponent<ObjData>();
        if (BoxData.IsUpDown)
        {
            if (Card_Machine_LivingData.IsObserve)
            {
                CameraController.cameraController.currentView = Card_Machine_LivingData.ObservePlusView; // 박스 위 관찰
                Card_Machine_LivingData.IsCenterButtonChanged = true;
            }
            else
            {
                Card_Machine_LivingData.IsCenterButtonChanged = false;
            }
        }
        else
        {
            if (Card_Machine_LivingData.IsObserve)
            {
                CameraController.cameraController.currentView = Card_Machine_LivingData.ObserveView; // 박스 아래서 관찰
                Card_Machine_LivingData.IsCenterButtonChanged = true;
            }
            else
            {
                Card_Machine_LivingData.IsCenterButtonChanged = false;
            }
        }
    }

    void FindCardKey()
    {
        ObjData CabinetData = Cabinet.GetComponent<ObjData>();
        ObjData Card_KeyData = Card_Key.GetComponent<ObjData>();
        
        if (CabinetData.IsObserve)
        {
            CameraController.cameraController.currentView = CabinetData.ObserveView; // 관찰하기
            Card_Key.SetActive(true);
            if(Card_KeyData.IsBite)
            {
                CameraController.cameraController.CancelObserve(); // 탑뷰로 돌아오기
                CabinetData.IsObserve =false;
                HasCard_Machine_Living = true;
            }        
        }

        if(!CabinetData.IsObserve&&!Card_KeyData.IsBite)
        {
            Card_Key.SetActive(false);
        }
    }


    void PutLivingRoomKey() // 생활공간 카드키 카드인식기계에 끼우기
    {
        ObjData Card_KeyData = Card_Key.GetComponent<ObjData>();
        ObjData Card_Machine_LivingData = Card_Machine_Living.GetComponent<ObjData>();
        ObjData BoxData = Box.GetComponent<ObjData>();

        if(Card_KeyData.IsBite)
        {
            if (BoxData.IsUpDown)
            {
                Card_Machine_LivingData.IsCenterButtonChanged = true;
                Card_Machine_LivingData.IsCenterPlusButtonDisabled = false;
                if (Card_Machine_LivingData.IsInsert)
                {
                    
                    Invoke("HalfOpenLivingRoomDoor", 2f); // Invoke : 함수 실행을 지연시킬 수 있다
                }
            }
            else
            {
                Card_Machine_LivingData.IsCenterButtonChanged = false;
                Card_Machine_LivingData.IsCenterPlusButtonDisabled = true;
            }
        }
        else
        {
            Card_Machine_LivingData.IsCenterButtonChanged = false;
            //Card_Machine_LivingData.IsCenterPlusButtonDisabled = true;
        }       
    }
    



    public void HalfOpenLivingRoomDoor() // 생활공간 문 열리는 애니메이션
    {
        livingroomDoor.transform.position = Vector3.Lerp(PlayerOriginPosition, PlayerDoorOpenPosition, Time.deltaTime * 1);

        //if(livingroomDoor.transform.position.x>-261f)
        //{
        //    livingroomDoor.transform.position = PlayerDoorOpenPosition;
        //}
    }

}

