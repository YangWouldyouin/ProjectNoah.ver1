using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        if(!GameManager.gameManager.IsSmartFarmOpen_T_C2) // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.
        {
            if (!IsDisappearIron_T_C2) // ���� �ı��Ǿ� ���� ���� �����̸� ���� �ı��ϴ� �ڵ带 �����ϰڴ�. 
            {
                MachinePlateDisapppear();
            }
            else
            {
                if (!IsRepairCompletion_T_C2) // ��谡 �����Ǿ� ���� ���� ���¶�� �����ϴ� CanListen �ڵ带 �����ϰڴ�.
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
    }



    // ��� ��ġ�� �ڵ�
    public void CanListen()
    {
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
                    {
                        //Debug.Log("������ ���� ���� ���� �ִ� ���� �ֱ� �߾��");

                        //�θ𿡼� ����
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
                    }
                }
                else // �ƹ����¿����� �� �ִ� ���� �����⸦ ���� ��� ī�޶� �並 �����ϰ� �ִϸ��̼Ǹ� �����ݴϴ�.
                {
                    if (InputLiner2Data.IsPushOrPress)
                    {
                        ManagementMachineData.IsObserve = false;
                        CameraController.cameraController.CancelObserve();
                    }
                }
            }
            else
            {
                // ������ �� ����
                if (BrokenLine2_T_C2Data.IsBite)
                {
                    //Debug.Log("������ ���� �����");
                    CameraController.cameraController.CancelObserve();
                    //Debug.Log("������ ���� ���� �����ϱ⸦ �����߾��");

                    Invoke("BrokenLine2Disapppear", 4f);
                    //Debug.Log("������ ���� ���ֹ��Ⱦ��");
                    IsLineGone_T_C2 = true; // ������ ���� �����ٴ� �� ������Ʈ�� �˸���.
                }
            } 
        }
        else // �����ϱ⸦ �����ϸ�,
        {
            //Debug.Log("��ȣ�ۿ� �Ұ����ؿ�");
            BrokenLine2_T_C2Data.IsNotInteractable = true; // ��ȣ�ۿ��� �Ұ��������ϴ�.
            BrokenLine2Outline.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            //Debug.Log("�� ����� ���� ��Ȱ��ȭ �ƾ��");
            InputLiner2Data.IsNotInteractable = true; // �����ϱ⸦ ������ ���¿��� ������ �ִ� ���� ���� ���� - �����ϱ� ���¸� �����ϸ� �ٽ� ��ȣ�ۿ��� �Ұ��������ϴ�.
            InputLiner2Outline.OutlineWidth = 0; // �ƿ������� ���ݴϴ�.
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
        BrokenLine2_T_C2.SetActive(false);
    }


    public void WindowOpen() //����Ʈ �� �� ���� �ڵ�
    {
        if (ManagementMachineData.IsBark) // ��迡 ¢�⸦ ����ߴٸ�,
        {
            Invoke("WindowAnim", 2f); //2���� �� ������ �ڵ带 �����Ѵ�.
            GameManager.gameManager.IsSmartFarmOpen_T_C2 = true; // �׻� �� ���� �����ִ� ���� True�� �ȴ�.
        }
    }

    void WindowAnim() // ����Ʈ�� �Ա� ������ �ִϸ��̼�
    {
        smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim.SetBool("FarmDoorStop", true);
    }
}
