using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_EngineDoor : MonoBehaviour
{
    private bool IsEngineDoorFix_M_C2 = false;

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
    Outline cabinetDoorOutline_WED;


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
        cabinetDoorOutline_WED = cabinetDoor_WED.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameManager._gameData.IsWEDoorOpened_M_C2)
        {
            //if () // ������ ���� Ŭ���ϸ� 
            //{
            //    // ������ ���� �ٰ����� ���� ������ �Ҹ� ���
            //    // AI�� ���� ���峭 �� ���ٴ� ��� ���
            //}


            // 10.���ڸ� �ٽ� ����  InsertCardPad ������ �ٰ��´�. ���� ���� �ö󰡼� �Ʊ� ����� ī�带 '�ֱ�' �Ѵ�.
            // (�μ�Ʈ å���̳� ī�� �е�� ��ư� ���������� �ε������� �ܼ�â�� '���� �ε�����' ����װ� ��ž�)
            if (engineKeyData_WED.IsBite && insertCardPadData_WED.IsPushOrPress)
            {
                Invoke("DoorOpen", 2f);

                // ī��Ű�� ī�� �е� ��ȣ�ۿ��� �����Ѵ�
                insertCardPadData_WED.IsNotInteractable = true;
                insertCardPadOutline_WED.OutlineWidth = 0;

                engineKeyData_WED.IsNotInteractable = true;
                engineKeyOutline_WED.OutlineWidth = 0;

                /* ������ ���� �Ϸ� */
                GameManager.gameManager._gameData.IsWEDoorOpened_M_C2 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }



            // 5. å������ �ٰ��� ī������ �ı��ϱ� �Ѵ�. ( ī��Ű ã�� )
            if (cardPackData_WED.IsSmash)
            {

                Invoke("Disapppear", 3f);
                engineKeyData_WED.IsNotInteractable = false;
                engineKeyOutline_WED.OutlineWidth = 8;
            }




            /* �� ã�� */
            // 2. ĳ��ֿ� �����ϱ⸦ �ϸ� ĳ��� ���� ������ ��ȣ�ۿ� �����ϴ�.
            if (cabinetFirstFloorData_WED.IsObserve)
            {
                CameraController.cameraController.currentView = cabinetFirstFloorData_WED.ObserveView;
                rubberData_WED.IsNotInteractable = false;
                rubbeOutline_WED.OutlineWidth = 8;

                // 3. ĳ��� �ȿ� �ִ� ���� ����.
                if (rubberData_WED.IsBite)
                {
                    CameraController.cameraController.CancelObserve();
                    cabinetFirstFloorData_WED.IsObserve = false;
                    
                }
            }
            else // �����ϱ� ���� �� �� �ٽ� ��Ȱ��ȭ 
            {
                rubberData_WED.IsNotInteractable = true;
                rubbeOutline_WED.OutlineWidth = 0;
            }
            // 1. ������ �� ���� ĳ��� �߿� ���� Ű�� ���� ĳ����� ������� ����.( ĳ��� ������ )
            if (cabinetDoorData_WED.IsPushOrPress)
            {
                Invoke("CabinetOpen", 2f);
            }





            /* ��� �����ϱ� */
            //����ü�� �׳� ����
            if (conductionData_WED.IsBite)
            {
                //������ ���� ��ȣ�ۿ� ����
                brokenPartData_WED.IsCenterButtonDisabled = false;

                // ���� ���� ����ü�� ���� ������ ���� ����⸦ �ϸ�
                if (conductionData_WED.IsBite)
                {
                    if(brokenPartData_WED.IsPushOrPress)
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

                        IsEngineDoorFix_M_C2 = true;
                    }
                }
                else // ����ü�� �׳� ���� ������ ���� �����
                {
                    if (brokenPartData_WED.IsPushOrPress)
                    {
                        {
                            // ��� ���� ����
                            Debug.Log("�������� ���");
                        }
                    }
                }
            }


            if (IsEngineDoorFix_M_C2)
            {
                Debug.Log("���� �����������Դϴ�.");
                //AI�� ���� �������ٴ� �� �˷��ش�.
                //���� ���������� ī�� ���⿡�� ���̰� �����ϴٴ� ����� �˷��ش�.

                //����� ���̰� ����ϸ� ��ȣ�ۿ� ����
                if (insertCardPadData_WED.IsCollision == true)
                {

                    insertCardPadData_WED.IsNotInteractable = false;
                    insertCardPadOutline_WED.OutlineWidth = 8;

                }
                else
                {
                    Debug.Log("���� ���������� ī�峢�⿡�� ���̰� �����ϴ� ");
                    insertCardPadData_WED.IsNotInteractable = true;
                    insertCardPadOutline_WED.OutlineWidth = 0;
                }
            }
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

        // ĳ��� �� ��Ȱ��ȭ
        cabinetDoorData_WED.IsNotInteractable = true;
        cabinetDoorOutline_WED.OutlineWidth = 0;

        // ĳ��ֿ� ��ȣ�ۿ� �����ϰ�
        cabinetFirstFloorData_WED.IsNotInteractable = false;
        cabinetFirstFloorOutline_WED.OutlineWidth = 8;
    }
}


//// 4. ���� ���� ����ü�� ���� ������ ���� ����⸦ �ϸ�
//if (rubberData_WED.IsBite && conductionData_WED.IsBite && brokenPartData_WED.IsPushOrPress)
//{
//    // ����� ����
//    // �θ� �ڽ� ���踦 �����Ѵ�.
//    conduction_WED.GetComponent<Rigidbody>().isKinematic = false;
//    conduction_WED.transform.parent = null;

//    // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
//    conduction_WED.transform.position = new Vector3(-262.629f, 541.395f, 688.343f); //��ġ ����
//    conduction_WED.transform.rotation = Quaternion.Euler(90, 90, 0); //���� ����

//    // ������ �� �κ��̶� ���� ����ü�� ��ȣ�ۿ��� �����Ѵ�.
//    brokenPartData_WED.IsNotInteractable = true;
//    brokenPartOutline_WED.OutlineWidth = 0;

//    conductionData_WED.IsNotInteractable = true;
//    conductionOutline_WED.OutlineWidth = 0;

//    GameManager.gameManager.IsEngineDoorFix_M_C2 = true;
//}

//// ����ü�� �׳� ���� ������ ���� ����� 
//else if (conductionData_WED.IsBite && brokenPartData_WED.IsPushOrPress)
//{
//    // ��� ���� ����
//    Debug.Log("�������� ���");
//}