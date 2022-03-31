using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Health_Machine : MonoBehaviour
{
    private bool IsHealthMachineDone = false;

    public GameObject healthMachine_T_C2;
    public GameObject healthMachine_FixPart_T_C2;

    ObjData healthMachineData_T_C2;
    ObjData healthMachine_FixPartData_T_C2;

    Outline healthMachine_FixPartOutline_T_C2;

    private float heathMachineRepairTimer_T_C2 = 0;
    public float heathMachineRepairHintTime = 60f;




    void Start()
    {
        healthMachineData_T_C2 = healthMachine_T_C2.GetComponent<ObjData>();
        healthMachine_FixPartData_T_C2 = healthMachine_FixPart_T_C2.GetComponent<ObjData>();

        healthMachine_FixPartOutline_T_C2 = healthMachine_FixPart_T_C2.GetComponent<Outline>();

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
        heathMachineRepairTimer_T_C2 += Time.deltaTime;
        float maxTimer = Mathf.FloorToInt((heathMachineRepairTimer_T_C2 % 3600) % 60);
        if(maxTimer>= heathMachineRepairHintTime)
        {
           DialogManager.dialogManager.HealthMachineRepairHint(); // ���� �� Ǯ���� ��� heathMachineRepairHintTime ���� 1���� ��Ʈ ����
           heathMachineRepairTimer_T_C2 = 0;
        }

        if (healthMachineData_T_C2.IsPushOrPress && healthMachine_FixPartData_T_C2.IsBite)
        {
            IsHealthMachineDone = true;
        }
    }

    public void HealthMachineOpen()
    {
        
        healthMachine_FixPartData_T_C2.IsBite = false; //���� �ִ� fitPart ���� ���� -> bool false

        healthMachine_FixPartData_T_C2.GetComponent<Rigidbody>().isKinematic = false;
        healthMachine_FixPartData_T_C2.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        healthMachine_FixPartData_T_C2.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachine_FixPartData_T_C2.transform.rotation = Quaternion.Euler(-90, 0, 0);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        healthMachine_FixPartData_T_C2.GetComponent<Interactable>().enabled = false;
        healthMachine_FixPartOutline_T_C2.OutlineWidth = 0; // ���콺 �����ص� �ܰ��� x

        //HM ��� ��ư ������ ��ư���� ����->������Ʈ
        healthMachineData_T_C2.IsCenterButtonDisabled = false;
        DialogManager.dialogManager.HealthMachineEnd();

        // ��ü��� ��ġ�� 1ȸ�� �ӹ��� ���� 
        GameManager.gameManager.IsHealthMachineFixedT_C2 = true;
    }
}


