using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI �ҷ�����

public class T_C1_FindingPlanets : MonoBehaviour
{   
    //������Ʈ
    public GameObject planetRader_PR; // �༺ ���� ���̴� ���
    public GameObject leftButton_PR; // ���� ��ư
    public GameObject rightButton_PR; // ������ ��ư
    public GameObject confirmButton_PR; // Ȯ�ι�ư

    // Ȯ�� ���� �� ������ ȭ�� (UI)
    public Image raderLine_PR; // ���̴� ����

    public Image[] normalPlanet_PR; // �༺
    public Image[] selectPlanet_PR; // ������ �༺
    public Image[] fakePlanet_PR; // ��¥ �༺

    public Image[] planetInfo_PR; // �༺ ���� �̹���

    public Button planetReportButton_PR; //�༺ ���� ��ư
    public Button exitButton_PR; // ���� ��ư

    // ������Ʈ ������
    ObjData planetRaderData_PR;
    ObjData leftButtonData_PR;
    ObjData rightButtonData_PR;
    ObjData confirmButtonData_PR;

    // Outline ����
    Outline leftButtonOutline_PR;
    Outline rightButtonOutline_PR;
    Outline confirmButtonOutline_PR;

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
        planetRaderData_PR = planetRader_PR.GetComponent<ObjData>();
        leftButtonData_PR = leftButton_PR.GetComponent<ObjData>();
        rightButtonData_PR = rightButton_PR.GetComponent<ObjData>();
        confirmButtonData_PR = confirmButton_PR.GetComponent<ObjData>();

        leftButtonOutline_PR.OutlineWidth = 0;
        rightButtonOutline_PR.OutlineWidth = 0;
        confirmButtonOutline_PR.OutlineWidth = 0;

        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
        // �����ϱ� �� ��� UI Ȱ��ȭ
        if (planetRaderData_PR.IsObserve)
        {
            CameraController.cameraController.currentView = planetRaderData_PR.ObserveView;
            timer_PR += Time.deltaTime;
            float seconds = Mathf.FloorToInt((timer_PR % 3600) % 60);
            if(seconds>=2f)
            {
                // ���̴� ���� Ȱ��ȭ
                raderLine_PR.transform.gameObject.SetActive(true);
                // ��� �༺ Ȱ��ȭ
                for (int i = 0; i < 6; i++)
                {
                    normalPlanet_PR[i].transform.gameObject.SetActive(true);
                }

                // ������ ��ư 3�� Ȱ��ȭ
                leftButtonOutline_PR.OutlineWidth = 8;
                rightButtonOutline_PR.OutlineWidth = 8;
                confirmButtonOutline_PR.OutlineWidth = 8;

                leftButtonData_PR.IsNotInteractable = false;
                rightButtonData_PR.IsNotInteractable = false;
                confirmButtonData_PR.IsNotInteractable = false;
            }

            if (leftButtonData_PR.IsPushOrPress)
            {
                raderLine_PR.transform.rotation = Quaternion.Euler(0, 0, 5); // �༺ ���̴� �� �������� �̵�
            }
            if (rightButtonData_PR.IsPushOrPress)
            {
                raderLine_PR.transform.rotation = Quaternion.Euler(0, 0, -5); // �༺ ���̴� �� ���������� �̵�
            }


        }

        //    // �༺ - ���̴� �� �Ÿ� ����ϱ�
        //    PlanetDistance_PR = Vector3.Distance(RaderLine_PR.transform.position, Planet_1_PR.transform.position);
        //    ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.red;

        //    if (PlanetDistance_PR <= 1.0f) // �༺ ���̴��� �༺ 1 �� �Ÿ��� 1 �̸��� ��,
        //    {
        //        // ���� �ڵ� ���� NomalPlanet�� SelectPlanet ������Ʈ�� ����Ǳ�
        //        //ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.green; // ���������� ��ȯ
        //    }

        //    if (ConfirmButtonData_PR.IsPushOrPress) // Ȯ�� ��ư ������ ��
        //    {
        //        // ��� ��ȣ�ۿ� ��Ȱ��ȭ
        //        if (FakePlanet_PR == true) // �༺�� ���� �༺ �� ��
        //        {
        //            // ��� ���� �༺���� ������
        //        }

        //        else // �༺�� ��¥ �༺ �� ��
        //        {
        //            PlanetExplorationTimeStart_PR = true; // Ÿ�̸� ��ŸƮ ����
        //            if (PlanetExplorationTime_PR <= 0) // �ð��� 0�� ���� ��
        //            {
        //                // AI�� �༺ ���� + �м� �ϷḦ �˸�

        //                //if (PlanetRaderData_PR.IsObserve) // �༺ ���� ���̴� ���� ��
        //                //{
        //                //    PlanetInfo_PR.SetActive(true); // �༺ ���� �̹��� ����
        //                //    if (PlanetInfoTime_PR <= 0)
        //                //    {
        //                //        PlanetReportButton_PR.SetActive(true);
        //                //        if (ExitButtonData_PR.IsClicked)
        //                //        {
        //                //            // �༺ ���� ���̴� ���������� ������
        //                //        }
        //                //    }
        //                //}
        //            }
        //        }
        //    }
        //}


        // �����ϱ� ���� �� ��� UI ��Ȱ��ȭ
        else 
        {
            // Ÿ�̸� �ʱ�ȭ
            timer_PR = 0;
            // ���̴� ���� ��Ȱ��ȭ
            raderLine_PR.transform.gameObject.SetActive(false);
            // ��� �༺ ��Ȱ��ȭ
            for (int i = 0; i < 6; i++)
            {
                normalPlanet_PR[i].transform.gameObject.SetActive(false);
            }

            // ������ ��ư 3�� ��Ȱ��ȭ
            leftButtonOutline_PR.OutlineWidth = 0;
            rightButtonOutline_PR.OutlineWidth = 0;
            confirmButtonOutline_PR.OutlineWidth = 0;

            leftButtonData_PR.IsNotInteractable = true;
            rightButtonData_PR.IsNotInteractable = true;
            confirmButtonData_PR.IsNotInteractable = true;
        }
    }
}
