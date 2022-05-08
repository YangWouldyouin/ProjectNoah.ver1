using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1_Photo : MonoBehaviour
{
    private GameObject nowObject_T_C1_Photo;

    // ������Ʈ
    public GameObject TakePicButton_P; // ī�޶� �Կ� ��ư
    public GameObject UniverseImage_P; // ���� ����

    // ������Ʈ ������
    ObjData SendButtonData_P;
    ObjData UniverseImageData_P;

    public GameObject[] UniverseImageList; // ���� ���� ����Ʈ

    public GameObject Report_GUI_P; // �����ϱ� GUI
    private bool IsReported = false;

    public int ran = Random.Range(0, 5);

    public InGameTime inGameTime;
    public DialogManager dialogManager_;
    DialogManager dialogManager;

    // �����ϱ� �� �߰� UI�� �ߴ� ���, 2�ʰ��� ���� �ִ�. �̰��� üũ�ϱ� ���� ����
    float timer_PR = 0;

    // private float SendButton = 3.0f; // �����ϱ� �˾�

    void Start()
    {
    }

    void Update()
    {
        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10)
        {
            Debug.Log("������� ���� ����");
            GameManager.gameManager._gameData.IsPhotoTime = true;

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(46));
        }
        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10)
        {
            Debug.Log("������� ���� ����");
            GameManager.gameManager._gameData.IsPhotoTime = false;

            GameManager.gameManager._gameData.IsReportCancleCount += 1;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
        }
    }

    public void RandomUniversePic()
    {
        UniverseImage_P = UniverseImageList[ran]; // ���� �̹��� �������� UniverseImage_P �� ����
        UniverseImage_P.SetActive(true); // ���� ���� �����ֱ�

        Invoke("Report_Popup", 4f);
    }

    public void Report_Popup()
    {
        if (IsReported)
        {
            Report_GUI_P.SetActive(false);
        }
        else
        {
            Report_GUI_P.SetActive(true);
        }
    }

    public void Report() // �����ϱ� ������
    {
        Debug.Log("�����ϱ�");
        IsReported = true;
        GameManager.gameManager._gameData.IsPhotoMissionFinish = true;

        Report_GUI_P.SetActive(false);
    }

    public void Cancel() //ĵ����ư ������
    {
        Debug.Log("����ϱ�");

        GameManager.gameManager._gameData.IsReportCancleCount -= 1; // �ӹ� ���� ī��Ʈ �پ���
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsReported = true;

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));

        Report_GUI_P.SetActive(false);
    }
}
