using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_FindDrug : MonoBehaviour
{
    private GameObject nowObject_T_C2_FindDrug;

    //필요 오브젝트 봉투, 마약성 약물, 특정 약물, 칩, 폼보드, 쪽지, 메인컴퓨터
    public GameObject drugBag;
    public GameObject drug;
    public GameObject specificDrug;
    //public GameObject drugChip;
    //public GameObject drugBoard;
    public GameObject mainCom;

    //이상한 냄새 감지, 약물 검사, 약물 보고, 해독 방법 찾기, 해독
    public bool IsSmellDrug = false;
    private static bool IsCheckDrug = false;
    public bool IsReportDrug = false;
    public bool IsDetox = false;

    // Start is called before the first frame update
    void Start()
    {
        //5분에 한 번씩 60% 확률로 10초 동안 '이상한 냄새' 맡을 수 있음
        //단, 업무공간 책상 기준 3칸 이내에 위치해야 감지할 수 있음
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C2_FindDrug = PlayerScripts.playerscripts.currentObject;

        /*if (nowObject_T_C2_FindDrug != null)
        {
            if (IsDetox)
            {
                Invoke("noDrug", 2f);
            }

            else
            {
                researchDrug();
            }
        }*/
    }

    /* public void findDrug()
    {
        ObjData drugBagData = drugBag.GetComponent<ObjData>();
        ObjData drugData = drug.GetComponent<ObjData>();

        if (drugBagData.IsBite)
        {
            Invoke("NoBag" , 0f);
        }
    }
    */

    
    public void researchDrug()
    {
        ObjData drugBagData = drugBag.GetComponent<ObjData>();
        ObjData drugData = drug.GetComponent<ObjData>();
        ObjData specificDrugData = specificDrug.GetComponent<ObjData>();

        ObjData mainComData = mainCom.GetComponent<ObjData>();

        if (drugBagData.IsBite) //마약 발견 및 물기
        {
            Invoke("noBag", 2f);
        }

        /*if (mainComData.IsObserve)
        {
            CameraController.cameraController.currentView = mainComData.ObserveView;
        }
        */

        if (drugData.IsBite && mainComData.IsPushOrPress) //마약 체크
        {
            //마약이라는 스크립트 출력
            //기계 내에 마약이 들어가 있다는 안내 필요
            IsCheckDrug = true;
        }

        if (specificDrugData.IsBite && mainComData.IsPushOrPress) //마약 해독
        {
            //해독되었다는 스크립트 출력
            //해독 안내 필요
            IsDetox = true;
        }    
    }

    void noBag() //봉투는 사라지고 마약이 보이도록 한다
    {
        drugBag.SetActive(false);
        drug.SetActive(true);
    }

    void noDrug() //마약과 특정약물 사라지게 하기
    {
        drug.SetActive(false);
        specificDrug.SetActive(false);
    }
}
