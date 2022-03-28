using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C2_EnginespaceOpen : MonoBehaviour
{

    private static bool IsOpenCabinetDoor_M_C2 = false;
    private static bool IsFindRubbe_M_C2 = false;
    private static bool IsEngineDoorFix_M_C2 = false;
    private static bool IsEngineRoomOpen_M_C2 = false;

    private Outline RubbeOutline;
    private Outline CabinetFirstFloorOutline;
    private Outline CardPadOutline;
    private Outline ConductionOutline;
    private Outline EngineKeyOutline;
    private Outline BrokenPartOutline;



    public GameObject EngineDoor_M_C2;
    public GameObject Conduction_M_C2; // ����ü
    public GameObject Rubbe_M_C2; // ��
    public GameObject Box2_M_C2;
    public GameObject EngineKey_M_C2;
    public GameObject BrokenPart_M_C2;
    public GameObject CardPad_M_C2;

    public GameObject CabinetDoor_M_C2; //ĳ��� ��
    public GameObject CabinetFirstFloor_M_C2; // ĳ��� 1��




    void Start()
    {
        RubbeOutline = Rubbe_M_C2.GetComponent<Outline>();
        CabinetFirstFloorOutline = CabinetFirstFloor_M_C2.GetComponent<Outline>();
        CardPadOutline = CardPad_M_C2.GetComponent<Outline>();
        ConductionOutline = Conduction_M_C2.GetComponent<Outline>(); 
        EngineKeyOutline = EngineKey_M_C2.GetComponent<Outline>();
        BrokenPartOutline = BrokenPart_M_C2.GetComponent<Outline>(); ;


        //������ ī�� ã�� ���� �Ϸ� Ȯ��
        // ������ ���� �ٰ����� ���� ������ �Ҹ� ���
        // AI�� ���� ���峭 �� ���ٴ� ��� ���
    }

    void Update()
    {
        if(IsOpenCabinetDoor_M_C2 == false)
        {
            ByeCabinetDoor();
        }

        if(IsFindRubbe_M_C2 == false)
        {
            FindRubbe();
        }

        if(IsEngineDoorFix_M_C2 == false)
        {
            CanInsert();
        }

        if(IsEngineRoomOpen_M_C2 == false)
        {
            CanOpen();
        }
    }

    void ByeCabinetDoor()
    {
        ObjData CabineDoortData = CabinetDoor_M_C2.GetComponent<ObjData>();

        if(CabineDoortData.IsPushOrPress)
        {
            Debug.Log("���� ĳ��� ���� �������");
            CabineDoortData.transform.position = new Vector3(-259.55f, 541.68f, 688.09f); //��ġ ����
            CabineDoortData.transform.rotation = Quaternion.Euler(-90f, -90, -107.177f); //���� ����
            //CabineDoortData.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����
            IsOpenCabinetDoor_M_C2 = true;
        }


    }

    void FindRubbe()
    {
        ObjData CabinetFirstFloorData = CabinetFirstFloor_M_C2.GetComponent<ObjData>();
        ObjData RubbeData = Rubbe_M_C2.GetComponent<ObjData>();


        if (IsOpenCabinetDoor_M_C2 == true)
        {
            CabinetFirstFloorData.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            CabinetFirstFloorOutline.OutlineWidth = 8;
        }

        if(CabinetFirstFloorData.IsObserve)
        {
            CameraController.cameraController.currentView = CabinetFirstFloorData.ObserveView;
            RubbeData.IsNotInteractable = false;
            RubbeOutline.OutlineWidth = 8;
        }

        if (RubbeData.IsBite)
        {
            CabinetFirstFloorData.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            IsFindRubbe_M_C2 = true;
        }


    }


    void CanInsert()
    {
        ObjData ConductionData = Conduction_M_C2.GetComponent<ObjData>();
        ObjData BrokenPartData = BrokenPart_M_C2.GetComponent<ObjData>();
        ObjData RubbeData = Rubbe_M_C2.GetComponent<ObjData>();

        if (ConductionData.IsBite)
        {
            BrokenPartData.IsCenterButtonDisabled = false;
        }

        if (ConductionData.IsBite && BrokenPartData.IsInsert)
        {
            // ��� ���� ����
            Debug.Log("�������� ���");
        }


        if (RubbeData.IsBite && ConductionData.IsBite && BrokenPartData.IsInsert)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.
            Conduction_M_C2.GetComponent<Rigidbody>().isKinematic = false;
            Conduction_M_C2.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            Conduction_M_C2.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //��ġ ����
            Conduction_M_C2.transform.rotation = Quaternion.Euler(90, 90, 0); //���� ����
            IsEngineDoorFix_M_C2 = true;

            // ������ �� �κ��̶� ���� ����ü�� ��ȣ�ۿ��� �����Ѵ�.
            BrokenPartData.IsNotInteractable = true;
            BrokenPartOutline.OutlineWidth = 0;

            ConductionData.IsNotInteractable = true;
            ConductionOutline.OutlineWidth = 0;
        }

    }



    void CanOpen()
    {
        ObjData CardPadData = CardPad_M_C2.GetComponent<ObjData>();
        ObjData EngineKeyData = EngineKey_M_C2.GetComponent<ObjData>();

        if (IsEngineDoorFix_M_C2 == true)
        {
            CardPadData.IsNotInteractable = false;
            CardPadOutline.OutlineWidth = 8;
        }

        if(EngineKeyData.IsBite && CardPadData.IsPushOrPress)
        {
            Invoke("DoorDisapppear", 4f);
            IsEngineRoomOpen_M_C2 = true;

            // ī��Ű�� ī�� �е� ��ȣ�ۿ��� �����Ѵ�
            CardPadData.IsNotInteractable = true;
            CardPadOutline.OutlineWidth = 0;

            EngineKeyData.IsNotInteractable = true;
            CardPadOutline.OutlineWidth = 0;
        }
    }

    void DoorDisapppear() // ����Ʈ�� �Ա� �������
    {
        EngineDoor_M_C2.SetActive(false);
    }
}
