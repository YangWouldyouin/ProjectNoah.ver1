using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report_PopupScript : MonoBehaviour
{
    public GameObject Report_GUI;
    public int cancleCount = 0;//��ü �Լ��� �����ϱ�

    public void Report()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        //�����ϱ� ������ �̵�
        //else ���� ������ �̵�
        Debug.Log("�����ϱ�");
        Report_GUI.SetActive(false);
    }

    public void Cancle()
    {
        //if ���� ������ �ٿ� ������ �Ϸ���� �ʾҴٸ�
        cancleCount += 1;

        Report_GUI.SetActive(false);
    }
}
