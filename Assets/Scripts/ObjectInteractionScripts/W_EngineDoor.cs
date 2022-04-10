using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_EngineDoor : MonoBehaviour
{
    //ī��Ű ã��
    public GameObject cardPack_WED; //ī����
    public GameObject engineKey_WED; //������ ī��Ű

    //������ �ر�
    public GameObject engineDoor_WED; //�����ǹ�
    public GameObject conduction_WED; // ����ü
    public GameObject rubber_WED; // ��
    public GameObject brokenPart_WED; // ������ �κ�
    public GameObject insertCardPad_WED; // ī�� ����� �е�
    public GameObject cabinetDoor_WED; //ĳ��� ��
    public GameObject cabinetFirstFloor_WED; // ĳ��� 1��

    //ī��Ű ã��
    ObjData cardPackData_WED;
    ObjData engineKeyData_WED;

    //������ �ر�
    ObjData engineDoorData_WED;
    ObjData conductionData_WED;
    ObjData rubberData_WED;
    ObjData brokenPartData_WED;
    ObjData insertCardPadData_WED;
    ObjData cabinetDoorData_WED;
    ObjData cabinetFirstFloorData_WED;


    Outline rubbeOutline_WED;
    Outline cabinetFirstFloorOutline_WED;
    Outline insertCardPadOutline_WED;
    Outline conductionOutline_WED;
    Outline engineKeyOutline_WED;
    Outline brokenPartOutline_WED;


    public Animator engineDoorAnim_WED;
    public Animator canEngineDoorAnim_WED;

    void Start()
    {
        //ī��Ű ã��
        cardPackData_WED = cardPack_WED.GetComponent<ObjData>();
        engineKeyData_WED = engineKey_WED.GetComponent<ObjData>();

        //������ �ر�
        engineDoorData_WED = engineDoor_WED.GetComponent<ObjData>();
        conductionData_WED = conduction_WED.GetComponent<ObjData>();
        rubberData_WED = rubber_WED.GetComponent<ObjData>();
        brokenPartData_WED = brokenPart_WED.GetComponent<ObjData>();
        insertCardPadData_WED = insertCardPad_WED.GetComponent<ObjData>();
        cabinetDoorData_WED = cabinetDoor_WED.GetComponent<ObjData>();
        cabinetFirstFloorData_WED = cabinetFirstFloor_WED.GetComponent<ObjData>();

        //�ƿ�����
        rubbeOutline_WED = rubber_WED.GetComponent<Outline>();
        cabinetFirstFloorOutline_WED = cabinetFirstFloor_WED.GetComponent<Outline>();
        insertCardPadOutline_WED = insertCardPad_WED.GetComponent<Outline>();
        conductionOutline_WED = conduction_WED.GetComponent<Outline>();
        engineKeyOutline_WED = engineKey_WED.GetComponent<Outline>();
        brokenPartOutline_WED = brokenPart_WED.GetComponent<Outline>(); 

        if(GameManager.gameManager.IsEngineDoorFix_M_C2 == false)
        {
            // ������ ���� �ٰ����� ���� ������ �Ҹ� ���
            // AI�� ���� ���峭 �� ���ٴ� ��� ���
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ī��Ű ã��
        if (cardPackData_WED.IsDestroy)
        {
            // ī���ѿ��� ī��Ű�� ����� �Ѵ�.
            engineKeyData_WED.GetComponent<Rigidbody>().isKinematic = false; 
            engineKeyData_WED.transform.parent = null;
            Invoke("Disapppear", 3f);
            GameManager.gameManager.IsDisappearPack_M_C2 = true;
        }



        //ĳ��� ������
        if (cabinetDoorData_WED.IsPushOrPress)
        {
            Invoke("CabinetOpen", 2f);
            GameManager.gameManager.IsOpenCabinetDoor_M_C2 = true;
        }



        // ĳ��ֿ� ��ȣ�ۿ� �����ϰ�
        if (GameManager.gameManager.IsOpenCabinetDoor_M_C2 == true)
        {
            cabinetFirstFloorData_WED.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            cabinetFirstFloorOutline_WED.OutlineWidth = 8;
        }


        //ĳ��ֿ� �����ϱ⸦ �ϸ� ĳ��� ���� ������ ��ȣ�ۿ� �����ϴ�.
        if (cabinetFirstFloorData_WED.IsObserve)
        {
            CameraController.cameraController.currentView = cabinetFirstFloorData_WED.ObserveView;
            rubberData_WED.IsNotInteractable = false;
            rubbeOutline_WED.OutlineWidth = 8;
        }


        // ���� ���� ���� ã���ɷ� �Ǵ��Ѵ�. 
        if (rubberData_WED.IsBite)
        {
            cabinetFirstFloorData_WED.IsObserve = false;
            CameraController.cameraController.CancelObserve();
            GameManager.gameManager.IsFindRubbe_M_C2 = true;
        }



        //����ü�� �׳� ����
        if (conductionData_WED.IsBite)
        {
            //������ ���� ��ȣ�ۿ� ����
            brokenPartData_WED.IsCenterButtonDisabled = false;
        }


        //���� ���� ����ü�� ���� ������ ���� ����⸦ �ϸ�
        if (rubberData_WED.IsBite && conductionData_WED.IsBite && brokenPartData_WED.IsInsert)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.
            conduction_WED.GetComponent<Rigidbody>().isKinematic = false;
            conduction_WED.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            conduction_WED.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //��ġ ����
            conduction_WED.transform.rotation = Quaternion.Euler(90, 90, 0); //���� ����

            // ������ �� �κ��̶� ���� ����ü�� ��ȣ�ۿ��� �����Ѵ�.
            brokenPartData_WED.IsNotInteractable = true;
            brokenPartOutline_WED.OutlineWidth = 0;

            conductionData_WED.IsNotInteractable = true;
            conductionOutline_WED.OutlineWidth = 0;

            GameManager.gameManager.IsEngineDoorFix_M_C2 = true;
        }

        // ����ü�� �׳� ���� ������ ���� ����� 
        else if (conductionData_WED.IsBite && brokenPartData_WED.IsInsert)
        {
            // ��� ���� ����
            Debug.Log("�������� ���");
        }


        if (GameManager.gameManager.IsEngineDoorFix_M_C2 == true)
        {
            Debug.Log("���� �����������Դϴ�.");
            insertCardPadData_WED.IsNotInteractable = false;
            insertCardPadOutline_WED.OutlineWidth = 8;
        }


        if (insertCardPadData_WED.IsCollision == true)
        {
            /* Ư�� ��ȣ�ۿ� ��ư�� ��Ȱ��ȭ->������� �ٲ��ְڴٴ� ���̴�. 
            (�⺻������ ��Ȱ��ȭ ���¶�� �ν������� IsCenterButtonDisabled�� üũ�� �ص���)*/

            insertCardPadData_WED.IsCenterButtonDisabled = false;

        }

        /* IsCenterButtonDisabled => ���� ��ư ��Ȱ��ȭ�� Ʈ���̸� �ٽ� ��Ȱ��ȭ ���·� �����ڴٴ� ���̴�. 
        å�󿡼� �������� �� ���� ���� �ƴ��� �˸� �ٽ� '������'�� ��Ȱ��ȭ�� �ٲٱ� ���� �ִ� �ڵ�*/
        else
        {
            insertCardPadData_WED.IsCenterButtonDisabled = true;
        }




        if (engineKeyData_WED.IsBite && insertCardPadData_WED.IsPushOrPress)
        {
            Invoke("DoorOpen", 2f);
            GameManager.gameManager.IsEngineRoomOpen_M_C2 = true;

            // ī��Ű�� ī�� �е� ��ȣ�ۿ��� �����Ѵ�
            insertCardPadData_WED.IsNotInteractable = true;
            insertCardPadOutline_WED.OutlineWidth = 0;

            engineKeyData_WED.IsNotInteractable = true;
            engineKeyOutline_WED.OutlineWidth = 0;
        }

    }

    void Disapppear()
    {
        cardPack_WED.SetActive(false);
        engineKey_WED.SetActive(true);
    }

    void DoorOpen() // ������ ���� 
    {
        canEngineDoorAnim_WED.SetBool("canEngineDoorOpen", true);
        canEngineDoorAnim_WED.SetBool("canEngineDoorEnd", true);
    }

    void CabinetOpen()
    {
        engineDoorAnim_WED.SetBool("eCabinetOpen", true);
        engineDoorAnim_WED.SetBool("eCabinetEnd", true);

    }
}
