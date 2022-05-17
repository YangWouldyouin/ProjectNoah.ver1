using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainComputerUIManager : MonoBehaviour
{
    public GameObject MainMenu_UI; // ���� ȭ��

    /* ����ȭ�� ���*/
    public GameObject JournalMenu_UI; // ���� ���� ���
    // public GameObject MeteorList_UI; // ��ǥ ���� ����Ʈ
    public GameObject DogProfile_UI; // ������ ���� ����
    public GameObject Wireless_UI; // �������

    /* �������� ���*/
    public GameObject Profile_UI; // ���� ����� ������
    public GameObject Report_UI; // ���� ����
    public GameObject Record_UI; // ���� ����

    public GameObject HighBar_UI;


    void Start()
    {
        MainMenu_UI.transform.SetAsLastSibling(); // MainMenu_UI �� ���� �������� �׸� -> �� �տ� ���̰� ��

        MainMenu_UI.SetActive(true); // ���� �޴��� ���� ���̰�
        HighBar_UI.SetActive(true); // ��ܹ� ��� ����

        JournalMenu_UI.SetActive(false);
        // MeteorList_UI.SetActive(false);
        DogProfile_UI.SetActive(false);
        Wireless_UI.SetActive(false);

        Profile_UI.SetActive(false);
        Report_UI.SetActive(false);
        Record_UI.SetActive(false);

    }

    void Update()
    {
    }


    /* ���� ȭ�� */
    public void ChangeJournal() // ���� -> �������� ���
    {
        MainMenu_UI.SetActive(false);
        JournalMenu_UI.SetActive(true);
    }
    public void BackMain_Journal() // �������� ��� -> ����
    {
        MainMenu_UI.SetActive(true);
        JournalMenu_UI.SetActive(false);
    }


/*    public void ChangeMeteorList() // ���� -> ��ǥ ���� ����Ʈ
    {
        MainMenu_UI.SetActive(false);
        MeteorList_UI.SetActive(true);
    }
    public void BackMain_MeteorList() // ��ǥ ���� ����Ʈ -> ����
    {
        MainMenu_UI.SetActive(true);
        MeteorList_UI.SetActive(false);
    }*/


    public void ChangeDogProfile() // ���� -> ������ ���� ����
    {
        MainMenu_UI.SetActive(false);
        DogProfile_UI.SetActive(true);
    }
    public void BackMain_DogProfile() // ������ ���� ���� -> ����
    {
        MainMenu_UI.SetActive(true);
        DogProfile_UI.SetActive(false);
    }


    public void ChangeBluetooth() // ���� -> �������
    {
        MainMenu_UI.SetActive(false);
        Wireless_UI.SetActive(true);

        if (GameManager.gameManager._gameData.IsWirelessUI_firstEnter == false)
        {
            GameManager.gameManager._gameData.IsWirelessUI_firstEnter = true;
            //���� ��ǻ�Ϳ� �º� ��ȣ ���� ���� ����

            GameManager.gameManager._gameData.ActiveMissionList[28] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }
    public void BackMain_Bluetooth() // ������� -> ����
    {
        MainMenu_UI.SetActive(true);
        Wireless_UI.SetActive(false);
    }





    /* �������� */
    public void ChangeProfile() // �������� -> ���� ����� ������
    {
        JournalMenu_UI.SetActive(false);
        Profile_UI.SetActive(true);
    }
    public void BackJournal_Profile() // ���� ����� ������ -> ��������
    {
        JournalMenu_UI.SetActive(true);
        Profile_UI.SetActive(false);
    }


    public void ChangeReport() // �������� -> ���� ����
    {
        JournalMenu_UI.SetActive(false);
        Report_UI.SetActive(true);
    }
    public void BackJournal_Report() // ���� ���� -> ��������
    {
        JournalMenu_UI.SetActive(true);
        Report_UI.SetActive(false);
    }


    public void ChangeRecord() // �������� -> ���� ����
    {
        JournalMenu_UI.SetActive(false);
        Record_UI.SetActive(true);
    }
    public void BackJournal_Record() // ���� ���� -> ��������
    {
        JournalMenu_UI.SetActive(true);
        Record_UI.SetActive(false);
    }
}
