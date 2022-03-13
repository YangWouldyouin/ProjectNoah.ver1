using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmellWorkspaceRepair : MonoBehaviour
{
    private GameObject nowObject_T_C2_SmellWorkspaceRepair;

    public static bool IsHealthMachineDone = false;

    public GameObject HealthMachine;
    public GameObject HealthMachine_fixPart;

    // Start is called before the first frame update
    void Start()
    {
        //AI: ���� üũ ��� ������ �Ǿ� ���� �ʾҴ� ��ũ��Ʈ
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C2_SmellWorkspaceRepair = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C2_SmellWorkspaceRepair != null)
        {
            if (IsHealthMachineDone)
            {
                HealthMachineOpen();
            }
            else
            {
                HMfixPart_Putting();
            }
        }
    }

    public void HMfixPart_Putting()
    {
        ObjData HealthMachineData = HealthMachine.GetComponent<ObjData>();
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();

        if (HealthMachineData.IsPushOrPress)
        {
            if (HealthMachine_fixPartData.IsBite)
            {
                IsHealthMachineDone = true;
            }
        }
    }

    public void HealthMachineOpen()
    {
        //���� �ִ� fitPart ���� ���� -> bool false
        
        //fitPart ��ġ HM�� �ڵ� ����
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();

        HealthMachine_fixPartData.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        //HM ��� ��ư ������ ��ư���� ����->������Ʈ
    }
}
