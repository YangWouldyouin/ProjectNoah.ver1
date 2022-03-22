using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C3_SmellEngineRepair : MonoBehaviour
{
    private GameObject nowObject_T_C3_SmellEngineRepair;

    public static bool IsFuelabsorberDone = false;

    public GameObject Fuelabsorber_Body;
    public GameObject Fuelabsorber_fixPart;
    public GameObject Fuelabsorber;

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
            if (IsFuelabsorberDone)
            {
                Invoke("FuelabsorberDone", 1.5f);
            }
            else
            {
                Fuelabsorber_fixPart_Putting();
            }
        }
    }

    public void Fuelabsorber_fixPart_Putting()
    {
        ObjData Fuelabsorber_BodyData = Fuelabsorber_Body.GetComponent<ObjData>();
        ObjData Fuelabsorber_fixPartData = Fuelabsorber_fixPart.GetComponent<ObjData>();
        if (Fuelabsorber_BodyData.IsPushOrPress && Fuelabsorber_fixPartData.IsBite)
        {
            IsFuelabsorberDone = true;
        }
    }

    public void FuelabsorberDone()
    {
        ObjData Fuelabsorber_BodyData = Fuelabsorber_Body.GetComponent<ObjData>();
        ObjData Fuelabsorber_fixPartData = Fuelabsorber_fixPart.GetComponent<ObjData>();
        ObjData FuelabsorberData = Fuelabsorber.GetComponent<ObjData>();

        //���� �ִ� fitPart ���� ���� -> bool false
        Fuelabsorber_fixPartData.IsBite = false;

        Fuelabsorber_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        Fuelabsorber_fixPartData.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        Fuelabsorber_fixPartData.transform.position = new Vector3(-1.82f, 0.509f, 0.25f);
        Fuelabsorber_fixPartData.transform.rotation = Quaternion.Euler(0, 90, 90);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        Fuelabsorber_fixPartData.IsNotInteractable = true;
        Fuelabsorber_BodyData.IsNotInteractable = true;
        FuelabsorberData.IsNotInteractable = false;

        //������Ʈ ����
        Fuelabsorber.SetActive(true);
        Fuelabsorber_fixPart.SetActive(false);
        Fuelabsorber_Body.SetActive(false);
    }
}
