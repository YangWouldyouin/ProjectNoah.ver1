using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainComputerUIManager : MonoBehaviour
{
    public GameObject MainMenu_UI; // ���� ȭ��

    /* ����ȭ�� ���*/
    public GameObject Journal_UI; // ���� ���� ���
    public GameObject MeteorList_UI; // ��ǥ ���� ����Ʈ
    public GameObject DogProfile_UI; // ������ ���� ����
    public GameObject Bluetooth_UI; // �������

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

        Journal_UI.SetActive(false);
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
        Journal_UI.SetActive(true);
    }

    public void BackMain_Journal() // �������� ��� -> ����
    {
        MainMenu_UI.SetActive(true);
        Journal_UI.SetActive(false);
    }

    public void ChangeMeteorList() // ���� -> ��ǥ ���� ����Ʈ
    {
        MainMenu_UI.SetActive(false);
        MeteorList_UI.SetActive(true);
    }

    public void BackMain_MeteorList() // ��ǥ ���� ����Ʈ -> ����
    {
        MainMenu_UI.SetActive(true);
        MeteorList_UI.SetActive(false);
    }
    public void ChangeDogProfile() // ���� -> ��ǥ ���� ����Ʈ
    {
        MainMenu_UI.SetActive(false);
        DogProfile_UI.SetActive(true);
    }

    public void BackMain_DogProfile() // ��ǥ ���� ����Ʈ -> ����
    {
        MainMenu_UI.SetActive(true);
        DogProfile_UI.SetActive(false);
    }
    public void ChangeBluetooth() // ���� -> ��ǥ ���� ����Ʈ
    {
        MainMenu_UI.SetActive(false);
        Bluetooth_UI.SetActive(true);
    }

    public void BackMain_Bluetooth() // ��ǥ ���� ����Ʈ -> ����
    {
        MainMenu_UI.SetActive(true);
        Bluetooth_UI.SetActive(false);
    }





    /* �������� */
    public void ChangeProfile() // �������� -> ���� ����� ������
    {
        Journal_UI.SetActive(false);
        Profile_UI.SetActive(true);
    }

    public void BackJournal_Profile() // ���� ����� ������ -> ��������
    {
        Journal_UI.SetActive(true);
        Profile_UI.SetActive(false);
    }

    public void ChangeReport() // �������� -> ���� ����
    {
        Journal_UI.SetActive(false);
        Report_UI.SetActive(true);
    }

    public void BackJournal_Report() // ���� ���� -> ��������
    {
        Journal_UI.SetActive(true);
        Report_UI.SetActive(false);
    }

    public void ChangeRecord() // �������� -> ���� ����
    {
        Journal_UI.SetActive(false);
        Record_UI.SetActive(true);
    }

    public void BackJournal_Record() // ���� ���� -> ��������
    {
        Journal_UI.SetActive(true);
        Record_UI.SetActive(false);
    }
}
