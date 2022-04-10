using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorBox : MonoBehaviour
{
    public GameObject meteorBoxButton1_MCM; // � ������
    public GameObject meteorBoxButton2_MCM; // � ������
    public GameObject meteorBoxButton3_MCM; // � ������
    public GameObject meteorBoxButton4_MCM; // � ������
    public GameObject meteorBoxButton5_MCM; // � ������



    ObjData meteorBoxButton1Data_MCM;
    ObjData meteorBoxButton2Data_MCM;
    ObjData meteorBoxButton3Data_MCM;
    ObjData meteorBoxButton4Data_MCM;
    ObjData meteorBoxButton5Data_MCM;


    Outline meteorBoxButton1Outline_MCM;
    Outline meteorBoxButton2Outline_MCM;
    Outline meteorBoxButton3Outline_MCM;
    Outline meteorBoxButton4Outline_MCM;
    Outline meteorBoxButton5Outline_MCM;


    // Start is called before the first frame update
    void Start()
    {
        meteorBoxButton1Data_MCM = meteorBoxButton1_MCM.GetComponent<ObjData>();
        meteorBoxButton2Data_MCM = meteorBoxButton2_MCM.GetComponent<ObjData>();
        meteorBoxButton3Data_MCM = meteorBoxButton3_MCM.GetComponent<ObjData>();
        meteorBoxButton3Data_MCM = meteorBoxButton3_MCM.GetComponent<ObjData>();

        //�ƿ�����
        meteorBoxButton1Outline_MCM = meteorBoxButton1_MCM.GetComponent<Outline>();
        meteorBoxButton2Outline_MCM = meteorBoxButton2_MCM.GetComponent<Outline>();
        meteorBoxButton3Outline_MCM = meteorBoxButton3_MCM.GetComponent<Outline>();
        meteorBoxButton4Outline_MCM = meteorBoxButton4_MCM.GetComponent<Outline>();
        meteorBoxButton5Outline_MCM = meteorBoxButton5_MCM.GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        //���� � 5���� ���� �� ����̶�� trueȮ���ϰ�
        //���� ��ȣ�ۿ��� ���ش�.

        meteorBoxButton1Data_MCM.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton1Outline_MCM.OutlineWidth = 8;
    }
}
