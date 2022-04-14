using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader : MonoBehaviour
{
    /* ������Ʈ */
    public GameObject planetRader_PR; // �༺ ���� ���̴� ���
    public GameObject leftButton_PR; // ���� ��ư
    public GameObject rightButton_PR; // ������ ��ư
    public GameObject confirmButton_PR; // Ȯ�ι�ư

    /* Ȯ�� ���� �� ������ ȭ�� (UI) */
    public Image raderLine_PR; // ���̴� ����

    public Image[] normalPlanet_PR; // �༺
    public Image[] selectPlanet_PR; // ������ �༺
    public Image[] fakePlanet_PR; // ��¥ �༺

    public TMPro.TextMeshProUGUI exploreText;

    public Image[] planetInfo_PR; // �༺ ���� �̹���

    public Button planetReportButton_PR; //�༺ ���� ��ư
    public Button exitButton_PR; // ���� ��ư

    /* ������Ʈ ������ */
    ObjData planetRaderData_PR;
    ObjData leftButtonData_PR;
    ObjData rightButtonData_PR;
    ObjData confirmButtonData_PR;

    /* Outline ���� */
    Outline planetRaderOutline_PR;
    Outline leftButtonOutline_PR;
    Outline rightButtonOutline_PR;
    Outline confirmButtonOutline_PR;

    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����
    float timer_PR = 0;
    float exploreTimer = 0;

    public bool PlanetExploration_PR = false; // �༺ Ž�� ����
    
    private bool PlanetExplorationTimeStart_PR = false; // �༺ Ž�� �ҿ� �ð� ���� ����
    public bool FakePlanet_PR = false; // ���� �༺ ����

    private float PlanetDistance_PR; // �༺�� ���̴� ���� �Ÿ�

    private float PlanetExplorationTime_PR = 5.0f; // �༺ Ž�� �ҿ� �ð�

    private float PlanetInfoTime_PR = 3.0f; // �༺ ���� �˾� �ð�

    Vector3 recentAngle;
    void Start()
    {
        planetRaderData_PR = planetRader_PR.GetComponent<ObjData>();
        leftButtonData_PR = leftButton_PR.GetComponent<ObjData>();
        rightButtonData_PR = rightButton_PR.GetComponent<ObjData>();
        confirmButtonData_PR = confirmButton_PR.GetComponent<ObjData>();

        leftButtonOutline_PR = leftButton_PR.GetComponent<Outline>();
        rightButtonOutline_PR = rightButton_PR.GetComponent<Outline>();
        confirmButtonOutline_PR = confirmButton_PR.GetComponent<Outline>();
        planetRaderOutline_PR = planetRader_PR.GetComponent<Outline>();

        planetReportButton_PR.onClick.AddListener(ReportPlanet);
        exitButton_PR.onClick.AddListener(ExitPlanetRader);

        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
        if (PlanetExplorationTimeStart_PR)
        {
            PlanetExplorationTime_PR -= Time.deltaTime;
            exploreTimer = Mathf.FloorToInt((PlanetExplorationTime_PR % 3600) % 60);
        }

        // �����ϱ� �� ��� UI Ȱ��ȭ
        if (planetRaderData_PR.IsObserve)
        {
            CameraController.cameraController.currentView = planetRaderData_PR.ObserveView;
            timer_PR += Time.deltaTime;
            float seconds = Mathf.FloorToInt((timer_PR % 3600) % 60);

            // ������ ��ư 3�� Ȱ��ȭ
            leftButtonOutline_PR.OutlineWidth = 8;
            rightButtonOutline_PR.OutlineWidth = 8;
            confirmButtonOutline_PR.OutlineWidth = 8;

            leftButtonData_PR.IsNotInteractable = false;
            rightButtonData_PR.IsNotInteractable = false;
            confirmButtonData_PR.IsNotInteractable = false;

            // �༺ ���̴� ��� ��Ȱ��ȭ
            planetRaderOutline_PR.OutlineWidth = 0;
            planetRaderData_PR.IsNotInteractable = true;

            if (seconds >= 2f)
            {
                if(!PlanetExploration_PR) // �༺ Ž�� ���̸�
                {
                    // ���̴� ���� Ȱ��ȭ
                    raderLine_PR.transform.gameObject.SetActive(true);
                    // ��� �༺ Ȱ��ȭ
                    for (int i = 0; i < 6; i++)
                    {
                        normalPlanet_PR[i].transform.gameObject.SetActive(true);
                    }

                    if (confirmButtonData_PR.IsPushOrPress) // Ȯ�� ��ư ������ ��
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (PlanetRaderTrigger.planetRaderTrigger.IsPlanetSelected[k])
                            {
                                exploreText.text = "Ž��������";
                                exploreText.transform.gameObject.SetActive(true);

                                for (int i = 0; i < 6; i++)
                                {
                                    normalPlanet_PR[i].transform.gameObject.SetActive(false);
                                    selectPlanet_PR[i].transform.gameObject.SetActive(false);
                                }
                                raderLine_PR.transform.gameObject.SetActive(false);


                                if (FakePlanet_PR) // �༺�� ���� �༺ �� ��
                                {
                                    // ��� ���� �༺���� ������
                                }
                                else // �༺�� ��¥ �༺ �� ��
                                {
                                    PlanetExploration_PR = true; // �༺ Ž�� ����
                                    PlanetExplorationTimeStart_PR = true; // Ÿ�̸� ��ŸƮ ����
                                }
                                break;
                            }
                        }


                    }
                }
                else
                {
                    if (exploreTimer <= 0)
                    {
                        exploreText.text = "Ž��Ϸ�";
                        planetReportButton_PR.transform.gameObject.SetActive(true);
                        exitButton_PR.transform.gameObject.SetActive(true);
                    }
                    else
                    {
                        exploreText.text = "Ž��������";
                    }
                    exploreText.transform.gameObject.SetActive(true); // Ž�������� Ȱ��ȭ                  
                }
            }
        }
        else // �����ϱ� ���� �� ��� UI ��Ȱ��ȭ
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
            exploreText.transform.gameObject.SetActive(false); // Ž�������� ��Ȱ��ȭ
            // ������ ��ư 3�� ��Ȱ��ȭ
            leftButtonOutline_PR.OutlineWidth = 0;
            rightButtonOutline_PR.OutlineWidth = 0;
            confirmButtonOutline_PR.OutlineWidth = 0;

            leftButtonData_PR.IsNotInteractable = true;
            rightButtonData_PR.IsNotInteractable = true;
            confirmButtonData_PR.IsNotInteractable = true;

            planetReportButton_PR.transform.gameObject.SetActive(false);
            exitButton_PR.transform.gameObject.SetActive(false);

            // �༺ ���̴� ��� Ȱ��ȭ
            planetRaderOutline_PR.OutlineWidth = 8;
            planetRaderData_PR.IsNotInteractable = false;
        }
    }






    void ReportPlanet()
    {
        exploreText.text = "A �༺ ���� �Ϸ�";
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);




        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;

        PlanetExplorationTime_PR = 5.0f;

        raderLine_PR.transform.gameObject.SetActive(false);
        // ��� �༺ ��Ȱ��ȭ
        for (int i = 0; i < 6; i++)
        {
            normalPlanet_PR[i].transform.gameObject.SetActive(false);
        }






    }





    void ExitPlanetRader()
    {
        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;
        PlanetExplorationTime_PR = 5.0f;

        exploreText.transform.gameObject.SetActive(false); // Ž�������� ��Ȱ��ȭ
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);
        timer_PR = 0;
        CameraController.cameraController.CancelObserve();
    }
}
