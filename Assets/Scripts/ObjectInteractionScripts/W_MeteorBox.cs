using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorBox : MonoBehaviour
{
    public GameObject meteorBoxButton1_MCM; // 운석 보관함
    public GameObject meteorBoxButton2_MCM; // 운석 보관함
    public GameObject meteorBoxButton3_MCM; // 운석 보관함
    public GameObject meteorBoxButton4_MCM; // 운석 보관함
    public GameObject meteorBoxButton5_MCM; // 운석 보관함



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

        //아웃라인
        meteorBoxButton1Outline_MCM = meteorBoxButton1_MCM.GetComponent<Outline>();
        meteorBoxButton2Outline_MCM = meteorBoxButton2_MCM.GetComponent<Outline>();
        meteorBoxButton3Outline_MCM = meteorBoxButton3_MCM.GetComponent<Outline>();
        meteorBoxButton4Outline_MCM = meteorBoxButton4_MCM.GetComponent<Outline>();
        meteorBoxButton5Outline_MCM = meteorBoxButton5_MCM.GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        //만약 운석 5개를 넣은 게 사실이라면 true확인하고
        //전부 상호작용을 켜준다.

        meteorBoxButton1Data_MCM.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton1Outline_MCM.OutlineWidth = 8;
    }
}
