using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmartFarmOpen : MonoBehaviour
{

    private static bool IsSmartFarmOpen_T_C2 = false;
    public bool IsDisappearIron_T_C2 = false;
    private static bool IsRepairCompletion_T_C2 = false;

    // 퍼즐을 완료하면 팜이 열린 상태를 유지한다.

    public GameObject ManagementMachine_T_C2;
    public GameObject IronPlate_T_C2;
    public GameObject Line1_T_C2;
    public GameObject Line2_T_C2;
    public GameObject Line3_T_C2;
    public GameObject Line4_T_C2;
    public GameObject Speaker_T_C2;
    public GameObject FarmWindow_T_C2;


    void Start()
    {
        
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

    }

    public void MachinePlateDisapppear()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();

        if (ManagementMachineData.IsObserve) //관찰하기를 사용하면 관찰하기 뷰가 적용된다.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }

        if (IronPlateData.IsBite) // 합판에 관찰하기 상태에서 파괴하기를 사용하면
        {


            //CameraController.cameraController.CancelObserve(); //관찰하기 뷰를 종료한다.
            IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
            IronPlate_T_C2.transform.parent = null;
            IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f);
            IronPlate_T_C2.transform.rotation = Quaternion.Euler(11.602f, 90, 90);
            IronPlate_T_C2.transform.localScale= new Vector3(-2.882732f, -115.34f, -93.69196f);
            Invoke("MakeIsDisappearIron_T_C2True", 3f);



            //Invoke("Disapppear", 2f); //2초후 사라지기 코드를 실행한다.
            //ManagementMachineData.IsObserve = false;

        }



    }

    void MakeIsDisappearIron_T_C2True()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        IronPlateData.IsBite = false;
        IsDisappearIron_T_C2 = true;
    }



    public void CanListen()
    {
        ObjData Line1_T_C2Data = Line1_T_C2.GetComponent<ObjData>();
        ObjData Line2_T_C2Data = Line2_T_C2.GetComponent<ObjData>();
        ObjData Line3_T_C2Data = Line3_T_C2.GetComponent<ObjData>();
        ObjData Line4_T_C2Data = Line4_T_C2.GetComponent<ObjData>();

        ObjData SpeakerData = Speaker_T_C2.GetComponent<ObjData>();
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();

        if (ManagementMachineData.IsObserve) //관찰하기를 사용하면 관찰하기 뷰가 적용된다.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }


        //--------------------------- 줄 물기

        if (ManagementMachineData.IsObserve && Line1_T_C2Data.IsBite) //관찰하기 뷰를 하고 1번 줄을 물면 관찰하기를 해제한다.
        {
            CameraController.cameraController.CancelObserve();
        }


        if (ManagementMachineData.IsObserve && Line2_T_C2Data.IsBite) //관찰하기 뷰를 하고 2번 줄을 물면 관찰하기를 해제한다.
        {
            ManagementMachineData.IsObserve = false;
            CameraController.cameraController.CancelObserve();

        }

        if (ManagementMachineData.IsObserve && Line3_T_C2Data.IsBite) //관찰하기 뷰를 하고 3번 줄을 물면 관찰하기를 해제한다.
        {
            CameraController.cameraController.CancelObserve();
        }


        if (ManagementMachineData.IsObserve && Line4_T_C2Data.IsBite) //관찰하기 뷰를 하고 4번 줄을 물면 관찰하기를 해제한다.
        {
            CameraController.cameraController.CancelObserve();
        }

        //--------------------------

        if (Line2_T_C2Data.IsBite && SpeakerData.IsPushOrPress) // 라인2번에 물기를 하고 스피커에 넣기를 하면,
        {
            Invoke("NoLine", 2f); //선이 사라지는 코드를 2초 후에 실행하겠다.
            //CameraController.cameraController.CancelObserve(); // 관찰하기 뷰 해제
            DialogManager.dialogManager.ResetSystem(); // 이 자리에는 소리 값이 들어갈 예정 - 지금 AI대사 치는 것처럼 기계에 '짖기'를 사용하세요 라는 음성이 들릴 예정이다.

            IsRepairCompletion_T_C2 = true;
        }

        else if (Line1_T_C2Data.IsBite && SpeakerData.IsPushOrPress)
        {
            SpeakerData.IsPushOrPress = false;
        }

        else if (Line3_T_C2Data.IsBite && SpeakerData.IsPushOrPress)
        {
            SpeakerData.IsPushOrPress = false;
        }

        else if (Line4_T_C2Data.IsBite && SpeakerData.IsPushOrPress)
        {
            SpeakerData.IsPushOrPress = false;
        }

    }

    public void WindowOpen() //스마트 팜 문 여는 코드
    {
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();


        if (IsRepairCompletion_T_C2 == true && ManagementMachineData.IsBark) // 수리완료가 사실(True)라면,
        {
                Invoke("WindowDisapppear", 2f); //2초후 문 사라지기 코드를 실행한다.

                IsSmartFarmOpen_T_C2 = true; // 항상 팜 문이 열려있는 것이 True가 된다.

        }


       
    }

    void WindowDisapppear() // 스마트팜 입구 사라지기
    {
        FarmWindow_T_C2.SetActive(false);
    }

    void NoLine() // 라인2번 사라지게 하기
    {
        Line2_T_C2.SetActive(false);
    }
}
