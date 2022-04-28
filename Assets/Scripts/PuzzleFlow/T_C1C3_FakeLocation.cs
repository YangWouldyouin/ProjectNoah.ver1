using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1C3_FakeLocation : MonoBehaviour
{
    private GameObject nowObject_T_C1C3_FakeLocation;

    // 오브젝트
    public GameObject PlanetRader_FL; // 행성감지레이더 기계
    public GameObject Planet_1_FL; // 행성 1
    public GameObject Planet_2_FL; // 행성 2
    public GameObject Planet_3_FL; // 행성 3
    public GameObject FakePlanet_1_FL; // 가짜 행성 1
    public GameObject FakePlanet_2_FL; // 가짜 행성 2
    public GameObject FakePlanet_3_FL; // 가짜 행성 3
    public GameObject DisturbanceChip_FL; // 교란칩
    public GameObject UnderPlate_FL; // 레이더 하단 합판
    public GameObject PutChip_FL; // 칩 넣는 곳

    // 오브젝트 데이터
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
            UnderPlate_FL.SetActive(false); // 합판 사라짐
            if (PutChipData_FL.IsPushOrPress)
            {
                Planet_1_FL.SetActive(false); // NomalPlanet 비활성화
                Planet_1_FL.SetActive(false);
                Planet_1_FL.SetActive(false); 
                FakePlanet_1_FL.SetActive(true); // 가짜 행성 표시
                FakePlanet_2_FL.SetActive(true);
                FakePlanet_3_FL.SetActive(true);
            }
        }
    }
}
