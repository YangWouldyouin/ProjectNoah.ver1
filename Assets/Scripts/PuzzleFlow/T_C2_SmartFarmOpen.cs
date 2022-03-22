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


    // ������ �Ϸ��ϸ� ���� ���� ���¸� �����Ѵ�.

    public GameObject ManagementMachine_T_C2; //��ü
    public GameObject IronPlate_T_C2; // ����
    public GameObject BrokenLine2_T_C2; //������ ��
    public GameObject FixedLine_T_C2; // ������ ��

   // �� ����� �� 1,3,4�� ���߿� ���� ������ �츮�� ������ �߰��� ��
    public GameObject InputLiner2_T_C2; // �� ����� �� 2


    public GameObject FarmWindow_T_C2; // ����Ʈ �� ��
    //public GameObject DoorTarget_T_C2; // ����Ʈ ���� �̵��� ��ġ


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

        if (IsLineGone_T_C2 == false) // ������ ���� �������� �� �ٷ� �ֱ� �����ϰ� �Ϸ���... �ȱ׷� �������Ŷ� ���Ŷ� ���� ������� 
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





    //���� ������� �ϴ� �ڵ�
    public void MachinePlateDisapppear()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();



        if (ManagementMachineData.IsObserve) // ����Ʈ�� ���� ��� ��ü�� '�����ϱ�'�� ����ϸ�, �����ϱ� �並 �����Ѵ�.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;
        }




        if (IronPlateData.IsBite) // ���ǿ� (�����ϱ� ���¿���) ���⸦ ����ϸ�
        {
            //CameraController.cameraController.CancelObserve(); //�����ϱ� �並 �����Ѵ�. - �����ϱ� �� �����ϸ� ���� ���忡�� ������ �þ ���µ� ������?

            // �θ� �ڽ� ���踦 �����Ѵ�.
            IronPlate_T_C2.GetComponent<Rigidbody>().isKinematic = false;
            IronPlate_T_C2.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            IronPlate_T_C2.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //��ġ ����
            IronPlate_T_C2.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
            IronPlate_T_C2.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

            Invoke("MakeIsDisappearIron_T_C2True", 3f); //IsDisappearIron_T_C2�� Ʈ��� �ٲٴ°� 3�� ������Ű�ڴ�.

            //Invoke("Disapppear", 2f); //2���� ������� �ڵ带 �����Ѵ�.
            //ManagementMachineData.IsObserve = false;

        }

    }





    //-------------------------------

    void MakeIsDisappearIron_T_C2True()
    {
        ObjData IronPlateData = IronPlate_T_C2.GetComponent<ObjData>();

        IronPlateData.IsBite = false; // üũ �Ǿ� �ִ� ���⸦ ���ش�.
        IsDisappearIron_T_C2 = true; // IsDisappearIron_T_C2�� Ʈ��� �ٲ�� �� ���¸� uptate���� �����ش�.
    }







    //-------------------------------
    // ������ �� ���̹��� �ڵ�
    public void BrokenLineBye()
    {

        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();
        ObjData BrokenLine2_T_C2Data = BrokenLine2_T_C2.GetComponent<ObjData>();

        //--------------------------- ������ �� ����
        if (ManagementMachineData.IsObserve && BrokenLine2_T_C2Data.IsBite) //�����ϱ� �並 �ϰ� ������ 2�� ���� ���� �����ϱ⸦ �����Ѵ�.
        {
            //Debug.Log("������ ���� �����");
            ManagementMachineData.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            //Debug.Log("������ ���� ���� �����ϱ⸦ �����߾��");

            Invoke("BrokenLine2Disapppear", 2f);
            //Debug.Log("������ ���� ���ֹ��Ⱦ��");
            IsLineGone_T_C2 = true; // ������ ���� �����ٴ� �� ������Ʈ�� �˸���.
        }
    }








    //-------------------------------
    // ��� ��ġ�� �ڵ�
    public void CanListen()
    {
        ObjData BrokenLine2_T_C2Data = BrokenLine2_T_C2.GetComponent<ObjData>();
        ObjData FixedLine_T_C2Data = FixedLine_T_C2.GetComponent<ObjData>();

        ObjData InputLiner2Data = InputLiner2_T_C2.GetComponent<ObjData>();

        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();




        //------------------------------�����ϱ�

        if (ManagementMachineData.IsObserve) //�����ϱ⸦ ����ϸ� �����ϱ� �䰡 ����ȴ�.
        {
            CameraController.cameraController.currentView = ManagementMachineData.ObserveView;


            //Debug.Log("��ȣ�ۿ� �����ؿ�");
            BrokenLine2_T_C2Data.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            BrokenLine2Outline.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.
        }

        else if (ManagementMachineData.IsObserve == false) // �����ϱ⸦ �����ϸ�,
        {
            //Debug.Log("��ȣ�ۿ� �Ұ����ؿ�");
            BrokenLine2_T_C2Data.IsNotInteractable = true; // ��ȣ�ۿ��� �Ұ��������ϴ�.
            BrokenLine2Outline.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.
        }






        //------------------------------- ������ ���� ������� ����̶��,

        if (IsLineGone_T_C2 == true && ManagementMachineData.IsObserve)
        {
            //Debug.Log("�� ����� ���� Ȱ��ȭ �ƾ��");
            InputLiner2Data.IsNotInteractable = false; // �� ���� ���� �� �ְ� �˴ϴ�.
            InputLiner2Outline.OutlineWidth = 8; // �ƿ������� ���ݴϴ�.
        }

        else if (IsLineGone_T_C2 == true && ManagementMachineData.IsObserve == false)
        {
            //Debug.Log("�� ����� ���� ��Ȱ��ȭ �ƾ��");
            InputLiner2Data.IsNotInteractable = true; // �����ϱ⸦ ������ ���¿��� ������ �ִ� ���� ���� ���� - �����ϱ� ���¸� �����ϸ� �ٽ� ��ȣ�ۿ��� �Ұ��������ϴ�.
            InputLiner2Outline.OutlineWidth = 0; // �ƿ������� ���ݴϴ�.
        }






        // -----------------------------
        // �ƹ����¿����� �� �ִ� ���� �����⸦ ���� ��� ī�޶� �並 �����ϰ� �ִϸ��̼Ǹ� �����ݴϴ�.
         if (ManagementMachineData.IsObserve && InputLiner2Data.IsPushOrPress)
        {
         ManagementMachineData.IsObserve = false;
         CameraController.cameraController.CancelObserve();
        }





        // ----------------------------
        // ��� ���̵� ���� �����ϱ⸦ �ϸ�
        if (BrokenLine2_T_C2Data.IsBite && ManagementMachineData.IsObserve)
        {
            //Debug.Log("������ ���� ���� �����ϱ⸦ �߾��");
            ManagementMachineData.IsObserve = true;
        }


        if (FixedLine_T_C2Data.IsBite && ManagementMachineData.IsObserve)
        {
            //Debug.Log("������ ���� ���� �����ϱ⸦ �߾��");
            ManagementMachineData.IsObserve = true;
        }





        //--------------------------

        if (FixedLine_T_C2Data.IsBite && InputLiner2Data.IsPushOrPress) // ������ ���� ���⸦ �ϰ� �� �ִ� ���� �ֱ⸦ �ϸ�,
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







    //-----------------------------
    // ����Ʈ�� �� ���� �ڵ�
    void BrokenLine2Disapppear()
    {
        BrokenLine2_T_C2.SetActive(false);
    }

    public void WindowOpen() //����Ʈ �� �� ���� �ڵ�
    {
        ObjData ManagementMachineData = ManagementMachine_T_C2.GetComponent<ObjData>();


        if (IsRepairCompletion_T_C2 == true && ManagementMachineData.IsBark) // �����Ϸᰡ ���(True)�̸鼭 ��迡 ¢�⸦ ����ߴٸ�,
        {
            Debug.Log("����Ʈ�� ��踦 ���ư� ��ü��迡 ¢�⸦ �߾��");
            //slowmove = GameObject.Find("SmartFarm_Dome_Door").GetComponent<ObjectSlowMove>();
            //slowmove.abc();

            //FarmWindow_T_C2.transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 0.5f);
            //FarmWindow_T_C2.transform.position += new Vector3(-264.83f, 506.4f, 679.771f);
            //FarmWindow_T_C2.transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * 0.5f);

            //FarmWindow_T_C2.transform.Translate(Vector3.right * Time.deltaTime);
            //Invoke("WindowDisapppear", 2f); //2���� �� ������� �ڵ带 �����Ѵ�.

            //Vector3 speed = Vector3.zero;
            //FarmWindow_T_C2.transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref speed, 0.01f);

            IsSmartFarmOpen_T_C2 = true; // �׻� �� ���� �����ִ� ���� True�� �ȴ�.

        }



    }

    //void WindowDisapppear() // ����Ʈ�� �Ա� �������
    //{
    //    FarmWindow_T_C2.SetActive(false);
    //}

}

