using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1C3_FakeLocation : MonoBehaviour
{
    private GameObject nowObject_T_C1C3_FakeLocation;

    // ������Ʈ
    public GameObject PlanetRader_FL; // �༺�������̴� ���
    public GameObject Planet_1_FL; // �༺ 1
    public GameObject Planet_2_FL; // �༺ 2
    public GameObject Planet_3_FL; // �༺ 3
    public GameObject FakePlanet_1_FL; // ��¥ �༺ 1
    public GameObject FakePlanet_2_FL; // ��¥ �༺ 2
    public GameObject FakePlanet_3_FL; // ��¥ �༺ 3
    public GameObject DisturbanceChip_FL; // ����Ĩ
    public GameObject UnderPlate_FL; // ���̴� �ϴ� ����
    public GameObject PutChip_FL; // Ĩ �ִ� ��

    // ������Ʈ ������
    ObjData PlanetRaderData_FL;
    ObjData Planet_1Data_FL;
    ObjData Planet_2Data_FL;
    ObjData Planet_3Data_FL;
    ObjData FakePlanetData_1_FL;
    ObjData FakePlanetData_2_FL;
    ObjData FakePlanetData_3_FL;
    ObjData DisturbanceChipData_FL;
    ObjData UnderPlateData_FL;
    ObjData PutChipData_FL;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UnderPlateData_FL.IsBite)
        {
            UnderPlate_FL.SetActive(false); // ���� �����
            if (PutChipData_FL.IsPushOrPress)
            {
                Planet_1_FL.SetActive(false); // NomalPlanet ��Ȱ��ȭ
                Planet_1_FL.SetActive(false);
                Planet_1_FL.SetActive(false); 
                FakePlanet_1_FL.SetActive(true); // ��¥ �༺ ǥ��
                FakePlanet_2_FL.SetActive(true);
                FakePlanet_3_FL.SetActive(true);
            }
        }
    }
}
