using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_TrashDoor_Button : MonoBehaviour
{

    public GameObject trashDoorButton_TB;
    public GameObject trashDoorButtonFixpart_TB;

    ObjData trashDoorButtonData_TB;
    ObjData trashDoorButtonFixpartData_TB;

    Interactable TrashBT_Interactable;
    Interactable TrashBT_fixPartInteractable;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.gameManager.IsTrashDoorFixed_L_L1)
        {
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
        }

        /* (�ʼ�) �� ������Ʈ�κ��� Objdata ������Ʈ�� �޾ƿͼ� ������ �ִ´�.*/
        trashDoorButtonData_TB = trashDoorButton_TB.GetComponent<ObjData>();
        trashDoorButtonFixpartData_TB = trashDoorButtonFixpart_TB.GetComponent<ObjData>();

        TrashBT_Interactable = trashDoorButton_TB.GetComponent<Interactable>();
        TrashBT_fixPartInteractable = trashDoorButtonFixpart_TB.GetComponent<Interactable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (trashDoorButtonData_TB.IsPushOrPress && trashDoorButtonFixpartData_TB.IsBite)
        {
            Invoke("TrashBTDone", 1.5f);
        }
    }

    public void TrashBTDone()
    {
        trashDoorButtonFixpartData_TB.GetComponent<Rigidbody>().isKinematic = false;
        trashDoorButtonFixpartData_TB.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        trashDoorButtonFixpartData_TB.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
        trashDoorButtonFixpartData_TB.transform.rotation = Quaternion.Euler(0, -90, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����

        //TrashBT_fixPartData.IsNotInteractable = true; // �ƿ� Interactable ��ũ��Ʈ ��ü�� ������ ���̹Ƿ� �ʿ��� �ּ�ó���� 
        //TrashBTData.IsNotInteractable = true;

        //���� �ִ� fitPart ���� ���� -> bool false
        trashDoorButtonFixpartData_TB.IsBite = false;

        // ���콺 ������ �ƿ������� ����� �ϴ� �Ͱ� ��ȣ�ۿ� ��ư�� ����� �ϴ°� �Ѵ� Interactable  ��ũ��Ʈ���� �ϱ� ������
        // �� ���� ���ķ� �� �̻� ��ȣ�ۿ��� �Ͼ�� �ʴ� ������Ʈ�� ��� Interactable ��ũ��Ʈ ������Ʈ�� �ƿ� �����ϸ�
        // �� �̻� ��ȣ�ۿ� ��ư�� �ܰ����� ������ �ʴ´�.
        Destroy(TrashBT_Interactable);
        Destroy(TrashBT_fixPartInteractable);

        GameManager.gameManager.IsTrashDoorFixed_L_L1 = true;
    }
}
