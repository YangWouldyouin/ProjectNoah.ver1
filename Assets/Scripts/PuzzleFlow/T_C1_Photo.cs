using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1_Photo : MonoBehaviour
{
    private GameObject nowObject_T_C1_Photo;

    // ������Ʈ
    public GameObject Camera_P; // ī�޶�
    public GameObject CameraTakeButton_P; // ī�޶� �Կ� ��ư
    public GameObject SendButton_P; // �����ϱ� ��ư
    public GameObject UniverseImage_P; // ���� ����

    // ������Ʈ ������
    ObjData CameraData_P;
    ObjData CameraTakeButtonData_P;
    ObjData SendButtonData_P;
    ObjData UniverseImageData_P;


    public GameObject Report_GUI;
    private bool IsReported = false;


    // Outline ����
    Outline consoleAIResetButtonOutline_PR;

    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����
    float timer_PR = 0;

    //private float SendButton = 3.0f; // �����ϱ� �˾�

    void Start()
    {
    }

    void Update()
    {
        if(CameraData_P.IsObserve)
        {
            if(CameraTakeButtonData_P.IsPushOrPress)
            {
                // ���� �̹��� �������� UniverseImage_P �� ����
                UniverseImage_P.SetActive(true); // ���� ���� �����ֱ�

                Invoke("Report_Popup", 3f);
            }
        }
    }

    public void Report_Popup()
    {
        if (IsReported)
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
        Debug.Log("�����ϱ�");
        IsReported = true;
        Report_GUI.SetActive(false);

        // if �����ϱ� ������ ��
        // 
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
