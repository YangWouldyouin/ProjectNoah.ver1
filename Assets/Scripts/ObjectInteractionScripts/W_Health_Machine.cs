using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Health_Machine : MonoBehaviour
{
    private bool IsHealthMachineDone = false;

    public GameObject healthMachine_HM;
    public GameObject healthMachineFixPart_HM;

    ObjData healthMachineData_HM;
    ObjData healthMachineFixPartData_HM;

    Outline healthMachineFixPartOutline_HM;

    private float heathMachineRepairTimer_HM = 0;
    public float heathMachineRepairHintTime_HM = 60f;




    void Start()
    {
        healthMachineData_HM = healthMachine_HM.GetComponent<ObjData>();
        healthMachineFixPartData_HM = healthMachineFixPart_HM.GetComponent<ObjData>();

        healthMachineFixPartOutline_HM = healthMachineFixPart_HM.GetComponent<Outline>();

        DialogManager.dialogManager.HealthMachineRepairIntro(); //AI: ���� üũ ��� ������ �Ǿ� ���� �ʾҴ� ��ũ��Ʈ
    }

    void Update()
    {
        // 1ȸ�� �ӹ��� "���� üũ ��� ��ġ��" �� �������� 
        if(!GameManager.gameManager.IsHealthMachineFixedT_C2)
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
        heathMachineRepairTimer_HM += Time.deltaTime;
        float maxTimer = Mathf.FloorToInt((heathMachineRepairTimer_HM % 3600) % 60);
        if(maxTimer>= heathMachineRepairHintTime_HM)
        {
           DialogManager.dialogManager.HealthMachineRepairHint(); // ���� �� Ǯ���� ��� heathMachineRepairHintTime ���� 1���� ��Ʈ ����
           heathMachineRepairTimer_HM = 0;
        }

        if (healthMachineData_HM.IsPushOrPress && healthMachineFixPartData_HM.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {
        
        healthMachineFixPartData_HM.IsBite = false; //���� �ִ� fitPart ���� ���� -> bool false

        healthMachineFixPartData_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPartData_HM.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        healthMachineFixPartData_HM.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachineFixPartData_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        healthMachineFixPartData_HM.GetComponent<Interactable>().enabled = false;
        healthMachineFixPartOutline_HM.OutlineWidth = 0; // ���콺 �����ص� �ܰ��� x

        //HM ��� ��ư ������ ��ư���� ����->������Ʈ
        healthMachineData_HM.IsCenterButtonDisabled = false;
        DialogManager.dialogManager.HealthMachineEnd();

        // ��ü��� ��ġ�� 1ȸ�� �ӹ��� ���� 
        GameManager.gameManager.IsHealthMachineFixedT_C2 = true;
    }
}


