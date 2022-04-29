using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_FindLivingspaceKey : MonoBehaviour
{

    private GameObject nowObject_M_C2_FindLivingspaceKey;

    public GameObject Cabinet_FLS; // 캐비닛
    public GameObject Card_Key_FLS; // 생활공간 카드키
    public GameObject Card_Machine_Living_FLS; //생활공간 카드인식기계
    public GameObject livingroomDoor_FLS; //생활공간 문
    public GameObject Box_FLS; //상자

    ObjData CabinetData_FLS;
    ObjData Card_KeyData_FLS;
    ObjData Card_Machine_LivingData_FLS;
    ObjData livingroomDoorData_FLS;
    ObjData BoxData_FLS;

    public static bool HalfOpenLivingroomDoor = false;
    private bool HasCard_Machine_Living = false;


    //private Vector3 PlayerDoorOpenPosition = new Vector3(-270.42f, 504.13f, 673.509f);
    private Vector3 PlayerOriginPosition = new Vector3(-260.161f, 538.39f, 666.48f);
    private Vector3 PlayerDoorOpenPosition = new Vector3(-259.15f, 537.83f, 694.03f);

    private void Update()
    {

        //ObserveCardMachine();

        if (HasCard_Machine_Living)
        {
            PutLivingRoomKey();
        }
/*        else
        {
            FindCardKey();
        }*/
    }

/*    public void ObserveCardMachine()
    {

        if (BoxData_FLS.IsUpDown)
        {
            if (Card_Machine_LivingData_FLS.IsObserve)
            {
                CameraController.cameraController.currentView = Card_Machine_LivingData_FLS.ObservePlusView; // 박스 위 관찰
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = true;
            }
            else
            {
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = false;
            }
        }
        else
        {
            if (Card_Machine_LivingData_FLS.IsObserve)
            {
                CameraController.cameraController.currentView = Card_Machine_LivingData_FLS.ObserveView; // 박스 아래서 관찰
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = true;
            }
            else
            {
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = false;
            }
        }
    }*/

    /*    void FindCardKey()
        {   
            if (CabinetData_FLS.IsObserve)
            {
                CameraController.cameraController.currentView = CabinetData_FLS.ObserveView; // 관찰하기
                Card_Key_FLS.SetActive(true);
                if(Card_KeyData_FLS.IsBite)
                {
                    CameraController.cameraController.CancelObserve(); // 탑뷰로 돌아오기
                    CabinetData_FLS.IsObserve =false;
                    HasCard_Machine_Living = true;
                }        
            }

            if(!CabinetData_FLS.IsObserve&&!Card_KeyData_FLS.IsBite)
            {
                Card_Key_FLS.SetActive(false);
            }
        }*/


    void PutLivingRoomKey() // 생활공간 카드키 카드인식기계에 끼우기
    {
        if(Card_KeyData_FLS.IsBite)
        {
            if (BoxData_FLS.IsUpDown)
            {
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = true;
                Card_Machine_LivingData_FLS.IsCenterPlusButtonDisabled = false;
                if (Card_Machine_LivingData_FLS.IsInsert)
                {
                    
                    Invoke("HalfOpenLivingRoomDoor", 2f); // Invoke : 함수 실행을 지연시킬 수 있다
                }
            }
            else
            {
                Card_Machine_LivingData_FLS.IsCenterButtonChanged = false;
                Card_Machine_LivingData_FLS.IsCenterPlusButtonDisabled = true;
            }
        }
        else
        {
            Card_Machine_LivingData_FLS.IsCenterButtonChanged = false;
            //Card_Machine_LivingData.IsCenterPlusButtonDisabled = true;
        }       
    }
    



    public void HalfOpenLivingRoomDoor() // 생활공간 문 열리는 애니메이션
    {
        livingroomDoor_FLS.transform.position = Vector3.Lerp(PlayerOriginPosition, PlayerDoorOpenPosition, Time.deltaTime * 1);

        //if(livingroomDoor.transform.position.x>-261f)
        //{
        //    livingroomDoor.transform.position = PlayerDoorOpenPosition;
        //}
    }

}


