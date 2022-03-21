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
    public static bool IsSmellDrug = false;
    private static bool IsCheckDrug = false;
    public static bool IsReportDrug = false;
    public static bool IsDetox = false;

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

        if (nowObject_T_C2_FindDrug != null)
        {
            if (IsDetox)
            {
                Invoke("noDrug", 2f);
            }

            else
            {
                researchDrug();
            }
        }

        //냄새 범위 내에 있으면 마약 찾기 로직 실행


        //약물 획득 시, '갸웃' 애니메이션
        //약물 메인 컴에 제출하면 성분 분석 가능
        //초록불 뜨며 물약과 관련된 이야기가 화면에 나옴

        //레비젼에 보고할 경우
        //메인 컴퓨터에서 칩 가져가기

        //레비젼에 보고하지 않을 경우
        //폼보드의 쪽지 중, 해당 약물의 화학식이 있는 폼보드가 있음
        //특정 약물을 넣으면 해독됨 > 다른 실험하던 약물을 넣었더니 해독된 사례 o
        //단, 그 특정 약물은 육안으로 구분 불가, 후각으로 가능 > 달콤한 냄새
        //미완성 약물 중, 해당 특정 약물 후각으로 찾기 = 각 약물 앞에 가서 냄새맡기 사용해 유일하게 달콤한 냄새 나는 특정 약물 찾기
        //특정 약물과 마약성 약물을 약물제조기계에 넣고 해독시킴

        //클리어 조건
        //연구 결과 칩을 조종실 메인 컴퓨터로 전송 (임무 컴플리트 지점)
        //약물제조기계에 마약성 약물과 특정 약물 넣고 제조해 해독
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
