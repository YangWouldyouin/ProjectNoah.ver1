using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class T_C2_SmartFarmOpen : MonoBehaviour
{

    private static bool IsSmartFarmOpen_T_C2 = false;
    public bool IsDisappearIron_T_C2 = false;
    private static bool IsRepairCompletion_T_C2 = false;
    private static bool IsLineGone_T_C2 = false;


    private Outline BrokenLine2Outline;
    private Outline InputLiner2Outline;


    // 퍼즐을 완료하면 팜이 열린 상태를 유지한다.

    public GameObject ManagementMachine_T_C2; //본체
    public GameObject IronPlate_T_C2; // 합판
    public GameObject BrokenLine2_T_C2; //망가진 선
    public GameObject FixedLine_T_C2; // 멀쩡한 선

   // 선 끼우는 곳 1,3,4는 나중에 퍼즐 디테일 살리고 싶으면 추가할 것
    public GameObject InputLiner2_T_C2; // 선 끼우는 곳 2


    public GameObject FarmWindow_T_C2; // 스마트 팜 문
    //public GameObject DoorTarget_T_C2; // 스마트 팜이 이동할 위치


    public Transform Target;

    //private Vector3 OriginPosition = new Vector3(-264.83f, 506.4f, 679.771f);
    //private Vector3 LaterPosition = new Vector3(-262.35f, 506.4f, 679.771f);


    void Start()
    {
        BrokenLine2Outline = BrokenLine2_T_C2.GetComponent<Outline>();
        InputLiner2Outline = InputLiner2_T_C2.GetComponent<Outline>();
    }







    // Update is called once per frame
    void Update()
    {
        // nowObject_T_C2_SmartFarmOpen = PlayerScripts.playerscripts.currentObject;


        if (IsSmartFarmOpen_T_C2 == false) // 문이 닫혀있으면(false) WindowOpen을 실행한다.
        {
            WindowOpen();
        }

        if (IsRepairCompletion_T_C2 == false) // 기계가 수리되어 있지 않은 상태라면 수리하는 CanListen 코드를 실행하겠다.
        {
            CanListen();
        }


        if (IsDisappearIron_T_C2 == false) // 판이 파괴되어 있지 않은 상태이면 판을 파괴하는 코드를 실행하겠다. 
        {
            MachinePlateDisapppear();
        }

        if (IsLineGone_T_C2 == false) // 망가진 줄을 빼내야지 새 줄로 넣기 가능하게 하려고... 안그럼 망가진거랑 새거랑 같이 껴지드라 
        {
            BrokenLineBye();
        }


        if (IsSmartFarmOpen_T_C2 == true)
        {
            Vector3 speed = Vector3.zero;
            FarmWindow_T_C2.transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref speed, 0.01f);
        //    //FarmWindow_T_C2.transform.position =  Vector3.Lerp(OriginPosition, LaterPosition, Time.deltaTime * 1);
        //    //FarmWindow_T_C2.transform.position = Vector3.Lerp(transform.position,new Vector3(-282.26f, 526.4f, 699.771f), Time.deltaTime * 0.01f);
        }

    }





    //합판 사라지게 하는 코드
    public void MachinePlateDisapppear()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();



        if (ManagementMachineData.IsObserve) // 스마트팜 관리 기계 자체에 '관찰하기'를 사용하면, 관찰하기 뷰를 실행한다.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }




        if (IronPlateData.IsBite) // 합판에 (관찰하기 상태에서) 물기를 사용하면
        {
            //CameraController.cameraController.CancelObserve(); //관찰하기 뷰를 종료한다. - 관찰하기 뷰 종료하면 유저 입장에서 과정이 늘어서 뺐는데 넣을까?

            // 부모 자식 관계를 해제한다.
            IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
            IronPlate_T_C2.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //위치 고정
            IronPlate_T_C2.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
            IronPlate_T_C2.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정

            Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2을 트루로 바꾸는걸 3초 지연시키겠다.

            //Invoke("Disapppear", 2f); //2초후 사라지기 코드를 실행한다.
            //ManagementMachineData.IsObserve = false;

        }

    }





    //-------------------------------

    void MakeIsDisappearIron_T_C2True()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();

        IronPlateData.IsBite = false; // 체크 되어 있는 물기를 꺼준다.
        IsDisappearIron_T_C2 = true; // IsDisappearIron_T_C2가 트루로 바뀌어 그 상태를 uptate문에 전해준다.
    }







    //-------------------------------
    // 망가진 줄 바이바이 코드
    public void BrokenLineBye()
    {

        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();
        ObjData BrokenLine2_T_C2Data = BrokenLine2_T_C2.GetComponent<ObjData>();

        //--------------------------- 망가진 줄 빼기
        if (ManagementMachineData.IsObserve && BrokenLine2_T_C2Data.IsBite) //관찰하기 뷰를 하고 망가진 2번 줄을 물면 관찰하기를 해제한다.
        {
            //Debug.Log("망가진 줄을 뺐어요");
            ManagementMachineData.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            //Debug.Log("망가진 줄을 빼고 관찰하기를 해제했어요");

            Invoke("BrokenLine2Disapppear", 2f);
            //Debug.Log("망가진 줄을 없애버렸어요");
            IsLineGone_T_C2 = true; // 망가진 줄이 빠졌다는 걸 업데이트에 알린다.
        }
    }








    //-------------------------------
    // 기계 고치기 코드
    public void CanListen()
    {
        ObjData BrokenLine2_T_C2Data = BrokenLine2_T_C2.GetComponent<ObjData>();
        ObjData FixedLine_T_C2Data = FixedLine_T_C2.GetComponent<ObjData>();

        ObjData InputLiner2Data = InputLiner2_T_C2.GetComponent<ObjData>();

        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();




        //------------------------------관찰하기

        if (ManagementMachineData.IsObserve) //관찰하기를 사용하면 관찰하기 뷰가 적용된다.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;


            //Debug.Log("상호작용 가능해요");
            BrokenLine2_T_C2Data.IsNotInteractable = false; // 상호작용 가능하게
            BrokenLine2Outline.OutlineWidth = 8; // 아웃라인도 켜줍니다.
        }

        else if (ManagementMachineData.IsObserve == false) // 관찰하기를 해제하면,
        {
            //Debug.Log("상호작용 불가능해요");
            BrokenLine2_T_C2Data.IsNotInteractable = true; // 상호작용이 불가능해집니다.
            BrokenLine2Outline.OutlineWidth = 0; // 아웃라인도 꺼줍니다.
        }






        //------------------------------- 망가진 선이 사라진게 사실이라면,

        if (IsLineGone_T_C2 == true && ManagementMachineData.IsObserve)
        {
            //Debug.Log("선 끼우는 곳이 활성화 됐어요");
            InputLiner2Data.IsNotInteractable = false; // 새 선을 넣을 수 있게 됩니다.
            InputLiner2Outline.OutlineWidth = 8; // 아웃라인을 켜줍니다.
        }

        else if (IsLineGone_T_C2 == true && ManagementMachineData.IsObserve == false)
        {
            //Debug.Log("선 끼우는 곳이 비활성화 됐어요");
            InputLiner2Data.IsNotInteractable = true; // 관찰하기를 해제한 상태에서 유저가 넣는 것을 막기 위해 - 관찰하기 상태를 해제하면 다시 상호작용이 불가능해집니다.
            InputLiner2Outline.OutlineWidth = 0; // 아웃라인을 꺼줍니다.
        }






        // -----------------------------
        // 아무상태에서나 선 넣는 곳에 누르기를 했을 경우 카메라 뷰를 해제하고 애니메이션만 보여줍니다.
         if (ManagementMachineData.IsObserve && InputLiner2Data.IsPushOrPress)
        {
         ManagementMachineData.IsObserve = false;
         CameraController.cameraController.CancelObserve();
        }





        // ----------------------------
        // 어느 선이든 물고서 관찰하기를 하면
        if (BrokenLine2_T_C2Data.IsBite && ManagementMachineData.IsObserve)
        {
            //Debug.Log("망가진 선을 물고 관찰하기를 했어요");
            ManagementMachineData.IsObserve = true;
        }


        if (FixedLine_T_C2Data.IsBite && ManagementMachineData.IsObserve)
        {
            //Debug.Log("멀쩡한 선을 물고 관찰하기를 했어요");
            ManagementMachineData.IsObserve = true;
        }





        //--------------------------

        if (FixedLine_T_C2Data.IsBite && InputLiner2Data.IsPushOrPress) // 멀쩡한 선에 물기를 하고 선 넣는 곳에 넣기를 하면,
        {

            //Debug.Log("멀쩡한 선을 물고 선을 넣는 곳에 넣기 했어요");

            //부모에서 해제
            FixedLine_T_C2Data.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            FixedLine_T_C2Data.transform.parent = null;

            //멀쩡한 선을 기계에 자동 장착
            FixedLine_T_C2Data.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //위치 값
            FixedLine_T_C2Data.transform.rotation = Quaternion.Euler(0, -90, 90); // 각도 값 

            //Invoke("NoLine", 2f); //선이 사라지는 코드를 2초 후에 실행하겠다.
            //CameraController.cameraController.CancelObserve(); // 관찰하기 뷰 해제

            DialogManager.dialogManager.ResetSystem(); // 이 자리에는 소리 값이 들어갈 예정 - 지금 AI대사 치는 것처럼 기계에 '짖기'를 사용하세요 라는 음성이 들릴 예정이다.
            FixedLine_T_C2Data.IsBite = false; // 물고 있는 상태를 false로 바꿔줘야 확실하게 모계에서 벗어날 수 있다.
            IsRepairCompletion_T_C2 = true;
        }

        //else if (BrokenLine2_T_C2Data.IsBite && InputLiner2Data.IsPushOrPress)
        //{
        //    Debug.Log("고장난 선을 물고 선을 넣는 곳에 넣기 했어요");

        //    //물고 있는 fitPart 물기 해제 -> bool false


        //    BrokenLine2_T_C2Data.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
        //    BrokenLine2_T_C2Data.transform.parent = null;

        //    //멀쩡한 선을 기계에 자동 장착
        //    BrokenLine2_T_C2Data.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //위치 값
        //    BrokenLine2_T_C2Data.transform.rotation = Quaternion.Euler(0, -90, 90); // 각도 값 

        //    //CameraController.cameraController.CancelObserve(); // 관찰하기 뷰 해제

        //    BrokenLine2_T_C2Data.IsBite = false; // 물고 있는 상태를 false로 바꿔줘야 확실하게 모계에서 벗어날 수 있다.
        //}

    }







    //-----------------------------
    // 스마트팜 문 열기 코드
    void BrokenLine2Disapppear()
    {
        BrokenLine2_T_C2.SetActive(false);
    }

    public void WindowOpen() //스마트 팜 문 여는 코드
    {
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();


        if (IsRepairCompletion_T_C2 == true && ManagementMachineData.IsBark) // 수리완료가 사실(True)이면서 기계에 짖기를 사용했다면,
        {
            Debug.Log("스마트팜 기계를 고쳤고 본체기계에 짖기를 했어요");
            //slowmove = GameObject.Find("SmartFarm_Dome_Door").GetComponent<ObjectSlowMove>();
            //slowmove.abc();

            //FarmWindow_T_C2.transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 0.5f);
            //FarmWindow_T_C2.transform.position += new Vector3(-264.83f, 506.4f, 679.771f);
            //FarmWindow_T_C2.transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * 0.5f);

            //FarmWindow_T_C2.transform.Translate(Vector3.right * Time.deltaTime);
            //Invoke("WindowDisapppear", 2f); //2초후 문 사라지기 코드를 실행한다.

            //Vector3 speed = Vector3.zero;
            //FarmWindow_T_C2.transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref speed, 0.01f);

            IsSmartFarmOpen_T_C2 = true; // 항상 팜 문이 열려있는 것이 True가 된다.

        }



    }

    //void WindowDisapppear() // 스마트팜 입구 사라지기
    //{
    //    FarmWindow_T_C2.SetActive(false);
    //}

}

