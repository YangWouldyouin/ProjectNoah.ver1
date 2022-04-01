using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class W_SmartFarm : MonoBehaviour 
{
    private bool IsDisappearIron_T_C2 = false;
    private bool IsRepairCompletion_T_C2 = false;
    private bool IsLineGone_T_C2 = false;

    public GameObject ManagementMachine_T_C2; //��ü
    public GameObject IronPlate_T_C2; // ����
    public GameObject BrokenLine2_T_C2; //������ ��
    public GameObject FixedLine_T_C2; // ������ ��
    // �� ����� �� 1,3,4�� ���߿� ���� ������ �츮�� ������ �߰��� ��
    public GameObject InputLiner2_T_C2; // �� ����� �� 2

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

    public GameObject managementMachine_SF; //��ü
    public GameObject ironPlate_SF; // ����
    public GameObject brokenLine2_SF; //������ ��
    public GameObject fixedLine_SF; // ������ ��
    // �� ����� �� 1,3,4�� ���߿� ���� ������ �츮�� ������ �߰��� ��
    public GameObject inputLiner2_SF; // �� ����� �� 2

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
        if(!GameManager.gameManager.IsSmartFarmOpen_T_C2) // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.
        {
            if (!IsDisappearIron_T_C2) // ���� �ı��Ǿ� ���� ���� �����̸� ���� �ı��ϴ� �ڵ带 �����ϰڴ�. 
=======
        if (!GameManager.gameManager.IsSmartFarmOpen_T_C2) // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.
        {
            if (!IsDisappearIron_SF) // ���� �ı��Ǿ� ���� ���� �����̸� ���� �ı��ϴ� �ڵ带 �����ϰڴ�. 
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
            {
                MachinePlateDisapppear();
            }
            else
            {
<<<<<<< HEAD
                if (!IsRepairCompletion_T_C2) // ��谡 �����Ǿ� ���� ���� ���¶�� �����ϴ� CanListen �ڵ带 �����ϰڴ�.
=======
                if (!IsRepairCompletion_SF) // ��谡 �����Ǿ� ���� ���� ���¶�� �����ϴ� CanListen �ڵ带 �����ϰڴ�.
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
        else // @@@@@ ���߿� ����Ʈ�� ���� �̼� �߰� @@@@@@
        {
            // if ����Ʈ�� ����̼��ؾ��ϸ� ����̼��� �Ѵ�.
        }
    }

    //���� ������� �ϴ� �ڵ�
    public void MachinePlateDisapppear()
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsObserve) // ����Ʈ�� ���� ��� ��ü�� '�����ϱ�'�� ����ϸ�, �����ϱ� �並 �����Ѵ�.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
            if (IronPlateData.IsBite) // ���ǿ� (�����ϱ� ���¿���) ���⸦ ����ϸ�
            {
                // �θ� �ڽ� ���踦 �����Ѵ�.
                IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
                IronPlate_T_C2.transform.parent = null;

                // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
                IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //��ġ ����
                IronPlate_T_C2.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
                IronPlate_T_C2.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

                Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2�� Ʈ��� �ٲٴ°� 3�� ������Ű�ڴ�.

                //ManagementMachineData.IsObserve = false;
            }
        }
    }
    void MakeIsDisappearIron_T_C2True()
    {
        IronPlateData.IsBite = false; // üũ �Ǿ� �ִ� ���⸦ ���ش�.
        IsDisappearIron_T_C2 = true; // IsDisappearIron_T_C2�� Ʈ��� �ٲ�� �� ���¸� uptate���� �����ش�.
=======
        if(managementMachineData_SF.IsClicked)
        {
            dialogTimer_SF = 0;
            IsDialogPrinted_SF = false;
        }
       
        if (managementMachineData_SF.IsObserve) // ����Ʈ�� ���� ��� ��ü�� '�����ϱ�'�� ����ϸ�, �����ϱ� �並 �����Ѵ�.
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
            if (ironPlateData_SF.IsBite) // ���ǿ� (�����ϱ� ���¿���) ���⸦ ����ϸ�
            {
                // �θ� �ڽ� ���踦 �����Ѵ�.
                ironPlate_SF.GetComponent<Rigidbody>().isKinematic = false;
                ironPlate_SF.transform.parent = null;

                // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
                ironPlate_SF.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //��ġ ����
                ironPlate_SF.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
                ironPlate_SF.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

                Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2�� Ʈ��� �ٲٴ°� 3�� ������Ű�ڴ�.
            }
        }
    }



    void MakeIsDisappearIron_T_C2True()
    {
        ironPlateData_SF.IsBite = false; // üũ �Ǿ� �ִ� ���⸦ ���ش�.
        //ManagementMachineData.IsObserve = false;
        IsDisappearIron_SF = true; // IsDisappearIron_T_C2�� Ʈ��� �ٲ�� �� ���¸� uptate���� �����ش�.
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
    }



    // ��� ��ġ�� �ڵ�
    public void CanListen()
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsObserve) //�����ϱ�
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
            BrokenLine2_T_C2Data.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            BrokenLine2Outline.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

            if(IsLineGone_T_C2) // ������ ���� ������� ����̶��,
            {
                InputLiner2Data.IsNotInteractable = false; // �� ���� ���� �� �ְ� �˴ϴ�.
                InputLiner2Outline.OutlineWidth = 8; // �ƿ������� ���ݴϴ�.
                if (FixedLine_T_C2Data.IsBite)
                {
                    if (InputLiner2Data.IsPushOrPress)// ������ ���� ���⸦ �ϰ� �� �ִ� ���� �ֱ⸦ �ϸ�,
=======
        if (managementMachineData_SF.IsObserve) //�����ϱ�
        {
            managementMachineData_SF.IsNotInteractable = true;
            CameraController.cameraController.currentView = managementMachineData_SF.ObserveView;
            brokenLine2Data_SF.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            brokenLine2Outline_HM.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

            if (IsLineGone_SF) // ������ ���� ������� ����̶��,
            {
                inputLiner2Data_SF.IsNotInteractable = false; // �� ���� ���� �� �ְ� �˴ϴ�.
                inputLiner2Outline_HM.OutlineWidth = 8; // �ƿ������� ���ݴϴ�.
                if (fixedLineData_SF.IsBite)
                {
                    if (inputLiner2Data_SF.IsPushOrPress)// ������ ���� ���⸦ �ϰ� �� �ִ� ���� �ֱ⸦ �ϸ�,
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                    {
                        //Debug.Log("������ ���� ���� ���� �ִ� ���� �ֱ� �߾��");

                        //�θ𿡼� ����
<<<<<<< HEAD
                        FixedLine_T_C2Data.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                        FixedLine_T_C2Data.transform.parent = null;

                        //������ ���� ��迡 �ڵ� ����
                        FixedLine_T_C2Data.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //��ġ ��
                        FixedLine_T_C2Data.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

                        //Invoke("NoLine", 2f); //���� ������� �ڵ带 2�� �Ŀ� �����ϰڴ�.
                        //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����

                        DialogManager.dialogManager.ResetSystem(); // �� �ڸ����� �Ҹ� ���� �� ���� - ���� AI��� ġ�� ��ó�� ��迡 '¢��'�� ����ϼ��� ��� ������ �鸱 �����̴�.
                        FixedLine_T_C2Data.IsBite = false; // ���� �ִ� ���¸� false�� �ٲ���� Ȯ���ϰ� ��迡�� ��� �� �ִ�.
                        IsRepairCompletion_T_C2 = true;
=======
                        fixedLineData_SF.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                        fixedLineData_SF.transform.parent = null;

                        //������ ���� ��迡 �ڵ� ����
                        fixedLineData_SF.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //��ġ ��
                        fixedLineData_SF.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

                        //Invoke("NoLine", 2f); //���� ������� �ڵ带 2�� �Ŀ� �����ϰڴ�.
                        //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����
                        // �� �ڸ����� �Ҹ� ���� �� ���� - ���� AI��� ġ�� ��ó�� ��迡 '¢��'�� ����ϼ��� ��� ������ �鸱 �����̴�.
                        fixedLineData_SF.IsBite = false; // ���� �ִ� ���¸� false�� �ٲ���� Ȯ���ϰ� ��迡�� ��� �� �ִ�.
                        DialogManager.dialogManager.SmartFarmAfterFixSpeaker();
                        IsRepairCompletion_SF = true;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                    }
                }
                else // �ƹ����¿����� �� �ִ� ���� �����⸦ ���� ��� ī�޶� �並 �����ϰ� �ִϸ��̼Ǹ� �����ݴϴ�.
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
                // ������ �� ����
<<<<<<< HEAD
                if (BrokenLine2_T_C2Data.IsBite)
=======
                if (brokenLine2Data_SF.IsBite)
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                {
                    //Debug.Log("������ ���� �����");
                    CameraController.cameraController.CancelObserve();
                    //Debug.Log("������ ���� ���� �����ϱ⸦ �����߾��");

                    Invoke("BrokenLine2Disapppear", 4f);
                    //Debug.Log("������ ���� ���ֹ��Ⱦ��");
<<<<<<< HEAD
                    IsLineGone_T_C2 = true; // ������ ���� �����ٴ� �� ������Ʈ�� �˸���.
                }
            } 
=======
                    IsLineGone_SF = true; // ������ ���� �����ٴ� �� ������Ʈ�� �˸���.
                }
            }
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
        }
        else // �����ϱ⸦ �����ϸ�,
        {
            //Debug.Log("��ȣ�ۿ� �Ұ����ؿ�");
<<<<<<< HEAD
            BrokenLine2_T_C2Data.IsNotInteractable = true; // ��ȣ�ۿ��� �Ұ��������ϴ�.
            BrokenLine2Outline.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            //Debug.Log("�� ����� ���� ��Ȱ��ȭ �ƾ��");
            InputLiner2Data.IsNotInteractable = true; // �����ϱ⸦ ������ ���¿��� ������ �ִ� ���� ���� ���� - �����ϱ� ���¸� �����ϸ� �ٽ� ��ȣ�ۿ��� �Ұ��������ϴ�.
            InputLiner2Outline.OutlineWidth = 0; // �ƿ������� ���ݴϴ�.
=======
            brokenLine2Data_SF.IsNotInteractable = true; // ��ȣ�ۿ��� �Ұ��������ϴ�.
            brokenLine2Outline_HM.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            //Debug.Log("�� ����� ���� ��Ȱ��ȭ �ƾ��");
            inputLiner2Data_SF.IsNotInteractable = true; // �����ϱ⸦ ������ ���¿��� ������ �ִ� ���� ���� ���� - �����ϱ� ���¸� �����ϸ� �ٽ� ��ȣ�ۿ��� �Ұ��������ϴ�.
            inputLiner2Outline_HM.OutlineWidth = 0; // �ƿ������� ���ݴϴ�.
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
        }
        //else if (BrokenLine2_T_C2Data.IsBite && InputLiner2Data.IsPushOrPress)
        //{
        //    Debug.Log("���峭 ���� ���� ���� �ִ� ���� �ֱ� �߾��");

        //    //���� �ִ� fitPart ���� ���� -> bool false


        //    BrokenLine2_T_C2Data.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
        //    BrokenLine2_T_C2Data.transform.parent = null;

        //    //������ ���� ��迡 �ڵ� ����
        //    BrokenLine2_T_C2Data.transform.position = new Vector3(-258.06f, 539.623f, 670.358f); //��ġ ��
        //    BrokenLine2_T_C2Data.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

        //    //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����

        //    BrokenLine2_T_C2Data.IsBite = false; // ���� �ִ� ���¸� false�� �ٲ���� Ȯ���ϰ� ��迡�� ��� �� �ִ�.
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


    public void WindowOpen() //����Ʈ �� �� ���� �ڵ�
    {
<<<<<<< HEAD
        if (ManagementMachineData.IsBark) // ��迡 ¢�⸦ ����ߴٸ�,
        {
            Invoke("WindowAnim", 2f); //2���� �� ������ �ڵ带 �����Ѵ�.
=======
        if (managementMachineData_SF.IsBark) // ��迡 ¢�⸦ ����ߴٸ�,
        {
            Invoke("WindowAnimAndDialog", 2f); //2���� �� ������ & AI �Ϸ� ��縦 �����Ѵ�.       
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
            GameManager.gameManager.IsSmartFarmOpen_T_C2 = true; // �׻� �� ���� �����ִ� ���� True�� �ȴ�.
        }
    }

<<<<<<< HEAD
    void WindowAnim() // ����Ʈ�� �Ա� ������ �ִϸ��̼�
    {
        smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim.SetBool("FarmDoorStop", true);
    }
}
=======
    void WindowAnimAndDialog() // ����Ʈ�� �Ա� ������ �ִϸ��̼� & ���
    {
        smartFarmDoorAnim_HM.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim_HM.SetBool("FarmDoorStop", true);
        DialogManager.dialogManager.SmartFarmOpenEnd();
    }
}

>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
