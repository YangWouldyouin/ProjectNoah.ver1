using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C3_SmellEngineRepair : MonoBehaviour
{
    private GameObject nowObject_T_C3_SmellEngineRepair;

    public static bool IsFueltankDone = false;

    public GameObject Fueltank;
    public GameObject Fueltank_fixPart;

    // Start is called before the first frame update
    void Start()
    {
        //AI: ���� üũ ��� ������ �Ǿ� ���� �ʾҴ� ��ũ��Ʈ
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C3_SmellEngineRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C3_SmellEngineRepair != null)
        {
            if (IsFueltankDone)
            {
                Invoke("FueltankDone", 1.5f);
            }
            else
            {
                Fueltank_fixPart_Putting();
            }
        }
    }

    public void Fueltank_fixPart_Putting()
    {
        ObjData FueltankData = Fueltank.GetComponent<ObjData>();
        ObjData Fueltank_fixPartData = Fueltank_fixPart.GetComponent<ObjData>();
        if (FueltankData.IsPushOrPress && Fueltank_fixPartData.IsBite)
        {
            IsFueltankDone = true;
        }
    }

    public void FueltankDone()
    {
        ObjData FueltankData = Fueltank.GetComponent<ObjData>();
        ObjData Fueltank_fixPartData = Fueltank_fixPart.GetComponent<ObjData>();


        //���� �ִ� fitPart ���� ���� -> bool false
        Fueltank_fixPartData.IsBite = false;

        Fueltank_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        Fueltank_fixPartData.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        Fueltank_fixPartData.transform.position = new Vector3(0f, 0f, 0f);
        Fueltank_fixPartData.transform.rotation = Quaternion.Euler(0, 0, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        //gameObject.GetComponent<Interactable>().enabled = false;

        //HM ��� ��ư ������ ��ư���� ����->������Ʈ
        FueltankData.IsCenterButtonDisabled = false;
        //HealthMachineData.IsCenterButtonChanged = true;
    }
}
