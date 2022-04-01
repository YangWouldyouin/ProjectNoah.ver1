using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_SmellWorkspaceRepair : MonoBehaviour
{
    private GameObject nowObject_T_C2_SmellWorkspaceRepair;

    public static bool IsHealthMachineDone = false;

    public GameObject HealthMachine;
    public GameObject HealthMachine_fixPart;

    public GameObject Report_GUI;
    private bool IsReported = false;

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
                Invoke("HealthMachineOpen", 1.5f);
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
        if (HealthMachineData.IsPushOrPress && HealthMachine_fixPartData.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {
        ObjData HealthMachineData = HealthMachine.GetComponent<ObjData>();
        ObjData HealthMachine_fixPartData = HealthMachine_fixPart.GetComponent<ObjData>();


        //���� �ִ� fitPart ���� ���� -> bool false
        HealthMachine_fixPartData.IsBite = false;

        HealthMachine_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        HealthMachine_fixPartData.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        HealthMachine_fixPartData.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        HealthMachine_fixPartData.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        HealthMachine_fixPartData.GetComponent<Interactable>().enabled = false;

        //HM ��� ��ư ������ ��ư���� ����->������Ʈ
        HealthMachineData.IsCenterButtonDisabled = false;
        //HealthMachineData.IsCenterButtonChanged = true;

        Invoke("Report_Popup", 1f);
    }

    public void Report_Popup()
    {
        if(IsReported)
        {
            Report_GUI.SetActive(false);
        }
        else
        {
            Report_GUI.SetActive(true);
        }
    }

    public void Report()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //�����ϱ� ������ �̵�
        //else ���� ������ �̵�
        
        Debug.Log("�����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);
    }

    public void Cancle()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //cancleCount += 1;
        
        Debug.Log("����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);
    }
}
