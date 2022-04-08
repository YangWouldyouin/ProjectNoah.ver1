using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI �ҷ�����

public class T_C1_FindingPlanets : MonoBehaviour
{
    private GameObject nowObject_T_C1_FindingPlanets;
    
    //������Ʈ
    public GameObject planetMachine_PR; // �༺ ���� ���

    public GameObject PlanetInfo_PR; // �༺ ���� �̹���
    public GameObject PlanetRader_PR; // �༺�������̴� ���
    public GameObject LeftButton_PR; // ���� ��ư
    public GameObject RightButton_PR; // ������ ��ư
    public GameObject ConfirmButton_PR; // Ȯ�ι�ư

    // Ȯ�� ���� �� ������ ȭ�� (UI)
    public GameObject RaderLine_PR; // ���̴� ����
    public GameObject Planet_1_PR; // �༺ 1
    public GameObject Planet_2_PR; // �༺ 2
    public GameObject Planet_3_PR; // �༺ 3
    public GameObject FakePlanet_1_FL; // ��¥ �༺ 1
    public GameObject FakePlanet_2_FL; // ��¥ �༺ 2
    public GameObject FakePlanet_3_FL; // ��¥ �༺ 3
    public GameObject PlanetReportButton_PR; //�༺ ���� ��ư
    public GameObject ExitButton_PR; // ���� ��ư

    // ������Ʈ ������
    ObjData PlanetInfoData_PR;

    ObjData planetMachineData_PR;

    ObjData PlanetRaderData_PR;
    ObjData LeftButtonData_PR;
    ObjData RightButtonData_PR;
    ObjData ConfirmButtonData_PR;

    ObjData RanderLineData_PR;
    ObjData Planet_1Data_PR;
    ObjData Planet_2Data_PR;
    ObjData Planet_3Data_PR;
    ObjData FakePlanetData_1_FL;
    ObjData FakePlanetData_2_FL;
    ObjData FakePlanetData_3_FL;
    ObjData ExitButtonData_PR;

    public Image[] normalPlanet;
    public Image[] selectPlanet;
    public Image[] fakePlanet;

    // Outline ����
    Outline consoleAIResetButtonOutline_PR;

    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����
    float timer_PR = 0;

    public bool PlanetExploration_PR = false; // �༺ Ž�� ����
    public bool FakePlanet_PR = false; // ���� �༺ ����
    private bool PlanetExplorationTimeStart_PR = false; // �༺ Ž�� �ҿ� �ð� ���� ����

    private float PlanetDistance_PR; // �༺�� ���̴� ���� �Ÿ�
    private float PlanetExplorationTime_PR = 600.0f; // �༺ Ž�� �ҿ� �ð�
    private float PlanetInfoTime_PR = 3.0f; // �༺ ���� �˾� �ð�


    void Start()
    {
        // PlanetInfo_T_C1.transform.gameObject.SetActive(false); // �̹��� ������ �ʴ� ���� -> true=����
        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
        if(planetMachineData_PR.IsObserve)
        {
            // ��� �༺ Ȱ��ȭ
            for(int i = 0; i<6; i++)
            {
                normalPlanet[i].transform.gameObject.SetActive(true);
            }

            if (PlanetRaderData_PR.IsPushOrPress) // �༺ ���̴� ��Ʈ���ϱ�
            {
                ControlRader();
            }

            // �༺ - ���̴� �� �Ÿ� ����ϱ�
            PlanetDistance_PR = Vector3.Distance(RaderLine_PR.transform.position, Planet_1_PR.transform.position);
            ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.red;

            if (PlanetDistance_PR <= 1.0f) // �༺ ���̴��� �༺ 1 �� �Ÿ��� 1 �̸��� ��,
            {
                // ���� �ڵ� ���� NomalPlanet�� SelectPlanet ������Ʈ�� ����Ǳ�
                //ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.green; // ���������� ��ȯ
            }

            if (ConfirmButtonData_PR.IsPushOrPress) // Ȯ�� ��ư ������ ��
            {
                // ��� ��ȣ�ۿ� ��Ȱ��ȭ
                if (FakePlanet_PR == true) // �༺�� ���� �༺ �� ��
                {
                    // ��� ���� �༺���� ������
                }

                else // �༺�� ��¥ �༺ �� ��
                {
                    PlanetExplorationTimeStart_PR = true; // Ÿ�̸� ��ŸƮ ����
                    if (PlanetExplorationTime_PR <= 0) // �ð��� 0�� ���� ��
                    {
                        // AI�� �༺ ���� + �м� �ϷḦ �˸�

                        //if (PlanetRaderData_PR.IsObserve) // �༺ ���� ���̴� ���� ��
                        //{
                        //    PlanetInfo_PR.SetActive(true); // �༺ ���� �̹��� ����
                        //    if (PlanetInfoTime_PR <= 0)
                        //    {
                        //        PlanetReportButton_PR.SetActive(true);
                        //        if (ExitButtonData_PR.IsClicked)
                        //        {
                        //            // �༺ ���� ���̴� ���������� ������
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }
        else
        {
            // ��� �༺ ��Ȱ��ȭ
            for (int i = 0; i < 6; i++)
            {
                normalPlanet[i].transform.gameObject.SetActive(false);
            }
        }

  
    }

    public void ControlRader()
    {
        if (LeftButtonData_PR.IsPushOrPress)
        {
            RaderLine_PR.transform.rotation = Quaternion.Euler(0,0,5); // �༺ ���̴� �� �������� �̵�
        }
        if (RightButtonData_PR.IsPushOrPress)
        {
            RaderLine_PR.transform.rotation = Quaternion.Euler(0, 0, -5); // �༺ ���̴� �� ���������� �̵�
        }
    }
}
