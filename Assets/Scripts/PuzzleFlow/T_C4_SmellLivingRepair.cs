using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C4_SmellLivingRepair : MonoBehaviour
{
    private GameObject nowObject_T_C4_SmellLivingRepair;

    public static bool IsTrashDoorDone = false;

    public GameObject TrashBT;
    public GameObject TrashBT_fixPart;

    /* Interactable ������Ʈ�� ���� ���� ���� */
    Interactable TrashBT_Interactable;
    Interactable TrashBT_fixPartInteractable;

    // Start is called before the first frame update
    void Start()
    {
        //AI: ��ǰ ���� ��ũ��Ʈ

        /* ������Ʈ ������ �پ��ִ� Interactable ������Ʈ�� ������ */
        TrashBT_Interactable = TrashBT.GetComponent<Interactable>();
        TrashBT_fixPartInteractable = TrashBT_fixPart.GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C4_SmellLivingRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C4_SmellLivingRepair != null)
        {
            if (IsTrashDoorDone)
            {
                Invoke("TrashBTDone", 1.5f);
            }
            else
            {
                TrashBT_fixPart_Putting();
            }
        }
    }

    public void TrashBT_fixPart_Putting()
    {
        ObjData TrashBTData = TrashBT.GetComponent<ObjData>();
        ObjData TrashBT_fixPartData = TrashBT_fixPart.GetComponent<ObjData>();
        if (TrashBTData.IsPushOrPress && TrashBT_fixPartData.IsBite)
        {
            IsTrashDoorDone = true;
        }
    }

    public void TrashBTDone()
    {
        ObjData TrashBTData = TrashBT.GetComponent<ObjData>();
        ObjData TrashBT_fixPartData = TrashBT_fixPart.GetComponent<ObjData>();


        //���� �ִ� fitPart ���� ���� -> bool false
        TrashBT_fixPartData.IsBite = false;

        TrashBT_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        TrashBT_fixPartData.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        TrashBT_fixPartData.transform.position = new Vector3(-27.279f, 1.182999f, 35.614f);
        TrashBT_fixPartData.transform.rotation = Quaternion.Euler(0, -90, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����

        //TrashBT_fixPartData.IsNotInteractable = true; // �ƿ� Interactable ��ũ��Ʈ ��ü�� ������ ���̹Ƿ� �ʿ��� �ּ�ó���� 
        //TrashBTData.IsNotInteractable = true;

        // ���콺 ������ �ƿ������� ����� �ϴ� �Ͱ� ��ȣ�ۿ� ��ư�� ����� �ϴ°� �Ѵ� Interactable  ��ũ��Ʈ���� �ϱ� ������
        // �� ���� ���ķ� �� �̻� ��ȣ�ۿ��� �Ͼ�� �ʴ� ������Ʈ�� ��� Interactable ��ũ��Ʈ ������Ʈ�� �ƿ� �����ϸ�
        // �� �̻� ��ȣ�ۿ� ��ư�� �ܰ����� ������ �ʴ´�.
        Destroy(TrashBT_Interactable);
        Destroy(TrashBT_fixPartInteractable);
    }
}