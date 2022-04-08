using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C3_TabletOpen : MonoBehaviour
{
    private GameObject nowObject_M_C3_TabletOpen;

    public GameObject Tablet; // 태블릿
    public GameObject FullEgPad; // 충전 된 충전패드
    public GameObject ZeroEgPad; // 충전 안 된 충전패드
    public GameObject Boxes; // 상자들
    public GameObject NoAI; // 비 AI 전파 감지 구역 기준점

    private float timer = 0f;
    public float DestroyTime = 5.0f;
    private float Charge;

    public static bool IsTabletDestroyed = false;

    public static bool NoBoxes = false; // 상자 무너뜨려 없애기
    public static bool UseTablet = false; // 태블릿 완전 해금
    public Animator BoxDestroyAnimation;
    private bool OpenTablet = false; // 태블릿 잠금화면 해금 여부
    private bool FullEgTablet = false; //태블릿 충전 여부
    private bool NoAIZone = false; // AI 전파 감지 범위 해당 여부


    void Start()
    {
    }

    void Update()
    {
        if(!IsTabletDestroyed)
        {
            GetOutAIZone();
        }

        if(!NoBoxes)
        {
            BoxDestroy();
        }
        else
        {
            FullBetteryTablet();
        }
        //if (NoBoxes == true)
        //{
        //    BoxDestroy();
        //    if (NoAIZone == true)
        //    {
        //        GetOutAIZone();
        //        if (FullEgTablet == true)
        //        {
        //            FullBetteryTablet();
        //            if (OpenTablet == true)
        //            {
        //                OpenLockTablet();
        //                UseTablet = true;
        //            }
        //        }
        //    }
        //}

        //else
        //{
        //    GetOutAIZone();
        //    UseTablet = false;
        //}
    }

    
    public void BoxDestroy()
    {
        ObjData BoxesData = Boxes.GetComponent<ObjData>();
        
        if (BoxesData.IsPushOrPress)
        {
            Invoke("DestroyBoxAnim", 1f);
            Invoke("DestroyBox", 2f);
            NoBoxes = true;
        }
    }

    void DestroyBoxAnim()
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox()
    {
        Boxes.SetActive(false);
    }




    public void GetOutAIZone() // AI전파감지범위 벗어나기
    {
        ObjData TabletData = Tablet.GetComponent<ObjData>();
        ObjData BoxesData = Boxes.GetComponent<ObjData>();
        ObjData NoAIData = NoAI.GetComponent<ObjData>();

        Vector3 TabletPos = Tablet.transform.position; // 태블릿 실시간 위치값

        if (TabletPos.x > 3 && TabletPos.x < 8 && TabletPos.z < -10 && TabletPos.z > -14) // 타블렛이 안전 영역 안에 있으면
        {
            timer = 0f; // 5초 안에 안전 영역으로 다시 돌아오면 타이머를 다시 0으로 돌림
        }
        else // 타블렛이 안전 영역 밖에 있으면
        {
            timer += Time.deltaTime; // 타이머 시작 
            float seconds = Mathf.FloorToInt((timer % 3600) % 60); // 초 단위 체크
            if (seconds >= DestroyTime) // 5초가 지나면
            {
                // AI: 이상 전파가 감지되었습니다. 해당 기기를 폐기합니다
                Destroy(Tablet); // 타블렛 파괴
                IsTabletDestroyed = true; // 반복문에서 빠져나옴
            }
        }
    }




    public void FullBetteryTablet() // 충전O 패드로 태블릿 배터리 충전하기
    {
        ObjData TabletData = Tablet.GetComponent<ObjData>();
        ObjData FullEgPadData = FullEgPad.GetComponent<ObjData>();
        ObjData ZeroEgPadData = ZeroEgPad.GetComponent<ObjData>();

        if (FullEgPadData.IsBite)
        {
            Charge = Vector3.Distance(Tablet.transform.position, FullEgPad.transform.position);

            if (Charge <= 1f) // 태블릿과 충전O패드 사이가 1f 이하 일 시
            {
                FullEgTablet = true;
            }
        }
    }

    public void OpenLockTablet() // 태블릿 잠금화면 해제하기
    {
        ObjData TabletData = Tablet.GetComponent<ObjData>();

        if(!FullEgTablet) // 태블릿 충전이 안됐을 경우
        {
            OpenTablet = false;
        }
        else // 태블릿 충전이 됐을 경우
        {
            if (TabletData.IsObserve)
            {
                //if UI화면 확대뷰에서 알맞은 비밀번호를 클릭했을 시
                {
                    OpenTablet = true;
                }
            }
        }
    }
}
