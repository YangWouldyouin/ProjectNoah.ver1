using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmartFarmOpen : MonoBehaviour
{

    private static bool IsSmartFarmOpen_T_C2 = false;
    public bool IsDisappearIron_T_C2 = false;
    private static bool IsRepairCompletion_T_C2 = false;

    // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.

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


        if (IsSmartFarmOpen_T_C2 == false) // ���� ����������(false) WindowOpen�� �����Ѵ�.
        {
            WindowOpen();
        }

        if (IsRepairCompletion_T_C2 == false) // ��谡 �����Ǿ� ���� ���� ���¶�� �����ϴ� CanListen �ڵ带 �����ϰڴ�.
        {
            CanListen();
        }


        if (IsDisappearIron_T_C2 == false) // ���� �ı��Ǿ� ���� ���� �����̸� ���� �ı��ϴ� �ڵ带 �����ϰڴ�. 
        {
            MachinePlateDisapppear();
        }

    }

    public void MachinePlateDisapppear()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();

        if (ManagementMachineData.IsObserve) //�����ϱ⸦ ����ϸ� �����ϱ� �䰡 ����ȴ�.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }

        if (IronPlateData.IsBite) // ���ǿ� �����ϱ� ���¿��� �ı��ϱ⸦ ����ϸ�
        {


            //CameraController.cameraController.CancelObserve(); //�����ϱ� �並 �����Ѵ�.
            IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
            IronPlate_T_C2.transform.parent = null;
            IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f);
            IronPlate_T_C2.transform.rotation = Quaternion.Euler(11.602f, 90, 90);
            IronPlate_T_C2.transform.localScale= new Vector3(-2.882732f, -115.34f, -93.69196f);
            Invoke("MakeIsDisappearIron_T_C2True", 3f);



            //Invoke("Disapppear", 2f); //2���� ������� �ڵ带 �����Ѵ�.
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

        if (ManagementMachineData.IsObserve) //�����ϱ⸦ ����ϸ� �����ϱ� �䰡 ����ȴ�.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }


        //--------------------------- �� ����

        if (ManagementMachineData.IsObserve && Line1_T_C2Data.IsBite) //�����ϱ� �並 �ϰ� 1�� ���� ���� �����ϱ⸦ �����Ѵ�.
        {
            CameraController.cameraController.CancelObserve();
        }


        if (ManagementMachineData.IsObserve && Line2_T_C2Data.IsBite) //�����ϱ� �並 �ϰ� 2�� ���� ���� �����ϱ⸦ �����Ѵ�.
        {
            ManagementMachineData.IsObserve = false;
            CameraController.cameraController.CancelObserve();

        }

        if (ManagementMachineData.IsObserve && Line3_T_C2Data.IsBite) //�����ϱ� �並 �ϰ� 3�� ���� ���� �����ϱ⸦ �����Ѵ�.
        {
            CameraController.cameraController.CancelObserve();
        }


        if (ManagementMachineData.IsObserve && Line4_T_C2Data.IsBite) //�����ϱ� �並 �ϰ� 4�� ���� ���� �����ϱ⸦ �����Ѵ�.
        {
            CameraController.cameraController.CancelObserve();
        }

        //--------------------------

        if (Line2_T_C2Data.IsBite && SpeakerData.IsPushOrPress) // ����2���� ���⸦ �ϰ� ����Ŀ�� �ֱ⸦ �ϸ�,
        {
            Invoke("NoLine", 2f); //���� ������� �ڵ带 2�� �Ŀ� �����ϰڴ�.
            //CameraController.cameraController.CancelObserve(); // �����ϱ� �� ����
            DialogManager.dialogManager.ResetSystem(); // �� �ڸ����� �Ҹ� ���� �� ���� - ���� AI��� ġ�� ��ó�� ��迡 '¢��'�� ����ϼ��� ��� ������ �鸱 �����̴�.

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

    public void WindowOpen() //����Ʈ �� �� ���� �ڵ�
    {
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();


        if (IsRepairCompletion_T_C2 == true && ManagementMachineData.IsBark) // �����Ϸᰡ ���(True)���,
        {
                Invoke("WindowDisapppear", 2f); //2���� �� ������� �ڵ带 �����Ѵ�.

                IsSmartFarmOpen_T_C2 = true; // �׻� �� ���� �����ִ� ���� True�� �ȴ�.

        }


       
    }

    void WindowDisapppear() // ����Ʈ�� �Ա� �������
    {
        FarmWindow_T_C2.SetActive(false);
    }

    void NoLine() // ����2�� ������� �ϱ�
    {
        Line2_T_C2.SetActive(false);
    }
}
