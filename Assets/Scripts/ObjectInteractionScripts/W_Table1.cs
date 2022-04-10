using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Table1 : MonoBehaviour
{
    /*å�� ������ ��ũ��Ʈ �Դϴ�. å�� ������ ������ ��ȣ�ۿ��� �ȵǴ� ������Ʈ���� ���⿡ ���ּ���*/

    public GameObject workroomTable1_WT;
    public GameObject dontCardPack_WT;



    ObjData workroomTableData1_WT;
    ObjData dontCardPackData_WT;


    Outline dontCardPackOutline_WT;

    void Start()
    {
        workroomTableData1_WT = workroomTable1_WT.GetComponent<ObjData>();
        dontCardPackData_WT = dontCardPack_WT.GetComponent<ObjData>();

        dontCardPackOutline_WT = dontCardPack_WT.GetComponent<Outline>();
    }

    void Update()
    {
        // IsCollision�� ������ å��� ��ư� �浹�ߴٴ� ���̴�.
        if (workroomTableData1_WT.IsCollision == true)
        {
            /* Ư�� ��ȣ�ۿ� ��ư�� ��Ȱ��ȭ->������� �ٲ��ְڴٴ� ���̴�. 
            (�⺻������ ��Ȱ��ȭ ���¶�� �ν������� IsCenterButtonDisabled�� üũ�� �ص���)*/

            workroomTableData1_WT.IsCenterButtonDisabled = false; 

        }

        /* IsCenterButtonDisabled => ���� ��ư ��Ȱ��ȭ�� Ʈ���̸� �ٽ� ��Ȱ��ȭ ���·� �����ڴٴ� ���̴�. 
        å�󿡼� �������� �� ���� ���� �ƴ��� �˸� �ٽ� '������'�� ��Ȱ��ȭ�� �ٲٱ� ���� �ִ� �ڵ�*/
        else
        {
            workroomTableData1_WT.IsCenterButtonDisabled = true;
        }

        //--------------------------
        /*��� ��ư�� ������ ��Ȱ��ȭ->Ȱ��ȭ�� �ٲ� ���¶�� �����ư�� '�����ϱ�'�� �ٲٴ� �� Ʈ��� �ϰڴ�.*/

        if (workroomTableData1_WT.IsUpDown) 
        {
            workroomTableData1_WT.IsCenterButtonChanged = true;
            // å�� �� ������ ��ȣ�ۿ� �����ϰ�
            dontCardPackData_WT.IsNotInteractable = false; 
            dontCardPackOutline_WT.OutlineWidth = 8;
        }
        else
        {
            // å�� �� ������ ��ȣ�ۿ� �Ұ����ϰ�
            workroomTableData1_WT.IsCenterButtonChanged = false;
            dontCardPackData_WT.IsNotInteractable = true; 
            dontCardPackOutline_WT.OutlineWidth = 0;
        }

        //--------------------------

        if (workroomTableData1_WT.IsObserve) // å�󿡼� '�����ϱ�'�� ����Ѱ� Ʈ���̸� �����ϱ� �並 �����ϰڴ�.
        {
            CameraController.cameraController.currentView = workroomTableData1_WT.ObserveView;
        }
    }

}




