using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class W_SmartFarm : MonoBehaviour 
{
    private bool IsDisappearIron_T_C2 = false;
    private bool IsRepairCompletion_T_C2 = false;
    private bool IsLineGone_T_C2 = false;

    public GameObject ManagementMachine_T_C2; //본체
    public GameObject IronPlate_T_C2; // 합판
    public GameObject BrokenLine2_T_C2; //망가진 선
    public GameObject FixedLine_T_C2; // 멀쩡한 선
    // 선 끼우는 곳 1,3,4는 나중에 퍼즐 디테일 살리고 싶으면 추가할 것
    public GameObject InputLiner2_T_C2; // 선 끼우는 곳 2

    ObjData IronPlateData;
    ObjData ManagementMachineData;
    ObjData BrokenLine2_T_C2Data;
    ObjData FixedLine_T_C2Data;
    ObjData InputLiner2Data;

    public Animator smartFarmDoorAnim;

    private Outline BrokenLine2Outline;
    private Outline InputLiner2Outline;

    void Start()
    {
        IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();
        BrokenLine2_T_C2Data = BrokenLine2_T_C2.GetComponent<ObjData>();
        FixedLine_T_C2Data = FixedLine_T_C2.GetComponent<ObjData>();
        InputLiner2Data = InputLiner2_T_C2.GetComponent<ObjData>();

        BrokenLine2Outline = BrokenLine2_T_C2.GetComponent<Outline>();
        InputLiner2Outline = InputLiner2_T_C2.GetComponent<Outline>();
=======
public class W_SmartFarm : MonoBehaviour
{
    private bool IsDisappearIron_SF = false;
    private bool IsRepairCompletion_SF = false;
    private bool IsLineGone_SF = false;

    public GameObject managementMachine_SF; //본체
    public GameObject ironPlate_SF; // 합판
    public GameObject brokenLine2_SF; //망가진 선
    public GameObject fixedLine_SF; // 멀쩡한 선
    // 선 끼우는 곳 1,3,4는 나중에 퍼즐 디테일 살리고 싶으면 추가할 것
    public GameObject inputLiner2_SF; // 선 끼우는 곳 2

    ObjData ironPlateData_SF;
    ObjData managementMachineData_SF;
    ObjData brokenLine2Data_SF;
    ObjData fixedLineData_SF;
    ObjData inputLiner2Data_SF;

    public Animator smartFarmDoorAnim_HM;

    private Outline brokenLine2Outline_HM;
    private Outline inputLiner2Outline_HM;

    private float dialogTimer_SF = 0f;
    private bool IsDialogPrinted_SF = true; 

    void Start()
    {
        ironPlateData_SF = ironPlate_SF.GetComponent<ObjData>();
        managementMachineData_SF = managementMachine_SF.GetComponent<ObjData>();
        brokenLine2Data_SF = brokenLine2_SF.GetComponent<ObjData>();
        fixedLineData_SF = fixedLine_SF.GetComponent<ObjData>();
        inputLiner2Data_SF = inputLiner2_SF.GetComponent<ObjData>();

        brokenLine2Outline_HM = brokenLine2_SF.GetComponent<Outline>();
        inputLiner2Outline_HM = inputLiner2_SF.GetComponent<Outline>();
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
    }

    void Update()
    {
<<<<<<< HEAD
        if(!GameManager.gameManager.IsSmartFarmOpen_T_C2) // 퍼즐을 완료하면 팜이 열린 상태를 유지한다.
        {
            if (!IsDisappearIron_T_C2) // 판이 파괴되어 있지 않은 상태이면 판을 파괴하는 코드를 실행하겠다. 
=======
        if (!GameManager.gameManager.IsSmartFarmOpen_T_C2) // 퍼즐을 완료하면 팜이 열린 상태를 유지한다.
        {
            if (!IsDisappearIron_SF) // 판이 파괴되어 있지 않은 상태이면 판을 파괴하는 코드를 실행하겠다. 
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
            {
                MachinePlateDisapppear();
            }
            else
            {
<<<<<<< HEAD
                if (!IsRepairCompletion_T_C2) // 기계가 수리되어 있지 않은 상태라면 수리하는 CanListen 코드를 실행하겠다.
=======
                if (!IsRepairCompletion_SF) // 기계가 수리되어 있지 않은 상태라면 수리하는 CanListen 코드를 실행하겠다.
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                {
                    CanListen();
                }
                else
                {
                    WindowOpen();
                }
            }
        }
        else // @@@@@ 나중에 스마트팜 정기 미션 추가 @@@@@@
        {
            // if 스마트팜 정기미션해야하면 정기미션을 한다.
        }
    }

    //합판 사라지게 하는 코드
    public void MachinePlateDisapppear()
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsObserve) // 스마트팜 관리 기계 자체에 '관찰하기'를 사용하면, 관찰하기 뷰를 실행한다.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
            if (IronPlateData.IsBite) // 합판에 (관찰하기 상태에서) 물기를 사용하면
            {
                // 부모 자식 관계를 해제한다.
                IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
                IronPlate_T_C2.transform.parent = null;

                // 해당 위치, 각도, 크기로 바꾸겠다.
                IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //위치 고정
                IronPlate_T_C2.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
                IronPlate_T_C2.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정

                Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2을 트루로 바꾸는걸 3초 지연시키겠다.

                //ManagementMachineData.IsObserve = false;
            }
        }
    }
    void MakeIsDisappearIron_T_C2True()
    {
        IronPlateData.IsBite = false; // 체크 되어 있는 물기를 꺼준다.
        IsDisappearIron_T_C2 = true; // IsDisappearIron_T_C2가 트루로 바뀌어 그 상태를 uptate문에 전해준다.
=======
        if(managementMachineData_SF.IsClicked)
        {
            dialogTimer_SF = 0;
            IsDialogPrinted_SF = false;
        }
       
        if (managementMachineData_SF.IsObserve) // 스마트팜 관리 기계 자체에 '관찰하기'를 사용하면, 관찰하기 뷰를 실행한다.
        {
            managementMachineData_SF.IsNotInteractable = true;
            CameraController.cameraController.currentView = managementMachineData_SF.ObserveView;
            
            dialogTimer_SF += Time.deltaTime;
            float timer = Mathf.FloorToInt((dialogTimer_SF % 3600) % 60); ;
            if (timer >= 3f)
            {
                if (!IsDialogPrinted_SF)
                {
                    DialogManager.dialogManager.SmartFarmObserve();
                    IsDialogPrinted_SF = true;
                }
            }
            if (ironPlateData_SF.IsBite) // 합판에 (관찰하기 상태에서) 물기를 사용하면
            {
                // 부모 자식 관계를 해제한다.
                ironPlate_SF.GetComponent<Rigidbody>().isKinematic = false;
                ironPlate_SF.transform.parent = null;

                // 해당 위치, 각도, 크기로 바꾸겠다.
                ironPlate_SF.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //위치 고정
                ironPlate_SF.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
                ironPlate_SF.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정

                Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2을 트루로 바꾸는걸 3초 지연시키겠다.
            }
        }
    }



    void MakeIsDisappearIron_T_C2True()
    {
        ironPlateData_SF.IsBite = false; // 체크 되어 있는 물기를 꺼준다.
        //ManagementMachineData.IsObserve = false;
        IsDisappearIron_SF = true; // IsDisappearIron_T_C2가 트루로 바뀌어 그 상태를 uptate문에 전해준다.
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
    }



    // 기계 고치기 코드
    public void CanListen()
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsObserve) //관찰하기
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
            BrokenLine2_T_C2Data.IsNotInteractable = false; // 상호작용 가능하게
            BrokenLine2Outline.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            if(IsLineGone_T_C2) // 망가진 선이 사라진게 사실이라면,
            {
                InputLiner2Data.IsNotInteractable = false; // 새 선을 넣을 수 있게 됩니다.
                InputLiner2Outline.OutlineWidth = 8; // 아웃라인을 켜줍니다.
                if (FixedLine_T_C2Data.IsBite)
                {
                    if (InputLiner2Data.IsPushOrPress)// 멀쩡한 선에 물기를 하고 선 넣는 곳에 넣기를 하면,
=======
        if (managementMachineData_SF.IsObserve) //관찰하기
        {
            managementMachineData_SF.IsNotInteractable = true;
            CameraController.cameraController.currentView = managementMachineData_SF.ObserveView;
            brokenLine2Data_SF.IsNotInteractable = false; // 상호작용 가능하게
            brokenLine2Outline_HM.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            if (IsLineGone_SF) // 망가진 선이 사라진게 사실이라면,
            {
                inputLiner2Data_SF.IsNotInteractable = false; // 새 선을 넣을 수 있게 됩니다.
                inputLiner2Outline_HM.OutlineWidth = 8; // 아웃라인을 켜줍니다.
                if (fixedLineData_SF.IsBite)
                {
                    if (inputLiner2Data_SF.IsPushOrPress)// 멀쩡한 선에 물기를 하고 선 넣는 곳에 넣기를 하면,
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                    {
                        //Debug.Log("멀쩡한 선을 물고 선을 넣는 곳에 넣기 했어요");

                        //부모에서 해제
<<<<<<< HEAD
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
=======
                        fixedLineData_SF.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                        fixedLineData_SF.transform.parent = null;

                        //멀쩡한 선을 기계에 자동 장착
                        fixedLineData_SF.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //위치 값
                        fixedLineData_SF.transform.rotation = Quaternion.Euler(0, -90, 90); // 각도 값 

                        //Invoke("NoLine", 2f); //선이 사라지는 코드를 2초 후에 실행하겠다.
                        //CameraController.cameraController.CancelObserve(); // 관찰하기 뷰 해제
                        // 이 자리에는 소리 값이 들어갈 예정 - 지금 AI대사 치는 것처럼 기계에 '짖기'를 사용하세요 라는 음성이 들릴 예정이다.
                        fixedLineData_SF.IsBite = false; // 물고 있는 상태를 false로 바꿔줘야 확실하게 모계에서 벗어날 수 있다.
                        DialogManager.dialogManager.SmartFarmAfterFixSpeaker();
                        IsRepairCompletion_SF = true;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                    }
                }
                else // 아무상태에서나 선 넣는 곳에 누르기를 했을 경우 카메라 뷰를 해제하고 애니메이션만 보여줍니다.
                {
<<<<<<< HEAD
                    if (InputLiner2Data.IsPushOrPress)
                    {
                        ManagementMachineData.IsObserve = false;
=======
                    if (inputLiner2Data_SF.IsPushOrPress)
                    {
                        managementMachineData_SF.IsObserve = false;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                        CameraController.cameraController.CancelObserve();
                    }
                }
            }
            else
            {
                // 망가진 줄 빼기
<<<<<<< HEAD
                if (BrokenLine2_T_C2Data.IsBite)
=======
                if (brokenLine2Data_SF.IsBite)
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                {
                    //Debug.Log("망가진 줄을 뺐어요");
                    CameraController.cameraController.CancelObserve();
                    //Debug.Log("망가진 줄을 빼고 관찰하기를 해제했어요");

                    Invoke("BrokenLine2Disapppear", 4f);
                    //Debug.Log("망가진 줄을 없애버렸어요");
<<<<<<< HEAD
                    IsLineGone_T_C2 = true; // 망가진 줄이 빠졌다는 걸 업데이트에 알린다.
                }
            } 
=======
                    IsLineGone_SF = true; // 망가진 줄이 빠졌다는 걸 업데이트에 알린다.
                }
            }
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
        }
        else // 관찰하기를 해제하면,
        {
            //Debug.Log("상호작용 불가능해요");
<<<<<<< HEAD
            BrokenLine2_T_C2Data.IsNotInteractable = true; // 상호작용이 불가능해집니다.
            BrokenLine2Outline.OutlineWidth = 0; // 아웃라인도 꺼줍니다.

            //Debug.Log("선 끼우는 곳이 비활성화 됐어요");
            InputLiner2Data.IsNotInteractable = true; // 관찰하기를 해제한 상태에서 유저가 넣는 것을 막기 위해 - 관찰하기 상태를 해제하면 다시 상호작용이 불가능해집니다.
            InputLiner2Outline.OutlineWidth = 0; // 아웃라인을 꺼줍니다.
=======
            brokenLine2Data_SF.IsNotInteractable = true; // 상호작용이 불가능해집니다.
            brokenLine2Outline_HM.OutlineWidth = 0; // 아웃라인도 꺼줍니다.

            //Debug.Log("선 끼우는 곳이 비활성화 됐어요");
            inputLiner2Data_SF.IsNotInteractable = true; // 관찰하기를 해제한 상태에서 유저가 넣는 것을 막기 위해 - 관찰하기 상태를 해제하면 다시 상호작용이 불가능해집니다.
            inputLiner2Outline_HM.OutlineWidth = 0; // 아웃라인을 꺼줍니다.
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
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
    void BrokenLine2Disapppear()
    {
<<<<<<< HEAD
        BrokenLine2_T_C2.SetActive(false);
=======
        brokenLine2_SF.SetActive(false);
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
    }


    public void WindowOpen() //스마트 팜 문 여는 코드
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsBark) // 기계에 짖기를 사용했다면,
        {
            Invoke("WindowAnim", 2f); //2초후 문 열리기 코드를 실행한다.
=======
        if (managementMachineData_SF.IsBark) // 기계에 짖기를 사용했다면,
        {
            Invoke("WindowAnimAndDialog", 2f); //2초후 문 열리기 & AI 완료 대사를 실행한다.       
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
            GameManager.gameManager.IsSmartFarmOpen_T_C2 = true; // 항상 팜 문이 열려있는 것이 True가 된다.
        }
    }

<<<<<<< HEAD
    void WindowAnim() // 스마트팜 입구 열리는 애니메이션
    {
        smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim.SetBool("FarmDoorStop", true);
    }
}
=======
    void WindowAnimAndDialog() // 스마트팜 입구 열리는 애니메이션 & 대사
    {
        smartFarmDoorAnim_HM.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim_HM.SetBool("FarmDoorStop", true);
        DialogManager.dialogManager.SmartFarmOpenEnd();
    }
}

>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
