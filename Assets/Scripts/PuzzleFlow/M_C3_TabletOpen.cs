using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_C3_TabletOpen : MonoBehaviour
{
    // 오브젝트
    public GameObject Tablet_TO; // 태블릿
    public GameObject FullEgPad_TO; // 충전 된 충전패드
    //public GameObject ZeroEgPad_TO; // 충전 안 된 충전패드
    public GameObject Boxes_TO; // 상자들

    // 오브젝트 데이터
    ObjData TabletData_TO; // 태블릿
    ObjData FullEgPadData_TO; // 충전 된 충전패드
    //ObjData ZeroEgPadData_TO; // 충전 안 된 충전패드
    ObjData BoxesData_TO; // 상자들


    private float timer = 0f; // 태블릿 감지 타이머
    public float DestroyTime = 5.0f; // 태블릿을 AI가 감지하기까지 걸리는 시간
    private float Charge;

    public static bool IsTabletDestroyed = false; // 태블릿 AI에게 들켜 없어졌는가

    public static bool NoBoxes = false; // 상자 무너뜨려 없애기
    public static bool UseTablet = false; // 태블릿 완전 해금

    public Animator BoxDestroyAnimation; // 박스 무너지는 애니메이션

    private bool OpenTablet = false; // 태블릿 잠금화면 해금 여부
    private bool FullEgTablet = false; //태블릿 충전 여부
    private bool NoAIZone = false; // AI 전파 감지 범위 해당 여부

    void Update()
    {
        GetOutAIZone(); // 태블릿이 AI전파감지범위 벗어나는가 안벗어나는가

        if (!IsTabletDestroyed) // 태블릿이 AI전파감지범위 벗어나 파괴되지 않았을 때,
        {
            if (BoxesData_TO.IsPushOrPress) // 박스 오브젝트 '누르기' 했을 시
            {
                Invoke("DestroyBoxAnim", 1f); // 1초 뒤 박스 무너지는 애니메이션 실행
                Invoke("DestroyBox", 2f); // 2초 뒤 박스 오브젝트 비활성화
                NoBoxes = true;

                if (FullEgPadData_TO.IsBite) // 충전된 충전패드를 물었을 때,
                {
                    Charge = Vector3.Distance(Tablet_TO.transform.position, FullEgPad_TO.transform.position);

                    if (Charge <= 1f) // 태블릿과 충전O패드 사이가 1f 이하 일 시
                    {
                        FullEgTablet = true; // 태블랫 충전 됨

                        if (TabletData_TO.IsObserve) // 태블릿 관찰하기
                        {
                            //if UI화면 확대뷰에서 알맞은 비밀번호를 클릭했을 시
                            {
                                OpenTablet = true;
                            }
                        }

                    }
                }
                else // 태블릿 충전 못했을 시
                {
                    FullEgTablet = false;
                    OpenTablet = false;
                }
            }
        }
    }



    void DestroyBoxAnim() // 박스 무너지는 애니메이션
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // 박스 오브젝트 비활성화
    {
        Boxes_TO.SetActive(false);
    }


    public void GetOutAIZone() // AI전파감지범위 벗어나기
    {
        Vector3 TabletPos = Tablet_TO.transform.position; // 태블릿 실시간 위치값

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
                Destroy(Tablet_TO); // 타블렛 파괴
                IsTabletDestroyed = true; // 반복문에서 빠져나옴
            }
        }
    }

}
