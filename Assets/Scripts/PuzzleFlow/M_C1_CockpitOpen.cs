using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_C1_CockpitOpen : MonoBehaviour
{
    /* 이번 플로우차트에서 저장되는 설정들 */
    // 이름 짓기 규칙 : 앞에 Is, Has, Can, Should 중 하나를 붙이고 한 단어의 첫 글자는 대문자로, 마지막에 플로우차트 넘버링
    // 이번 플로우차트를 깨야 설정들이 True로 바뀌면서 풀리는 것이므로, 초기에는 모두 false 값을 넣는다. 
    public static bool IsAI_M_C1 = false; // true 가 되면 앞으로 AI 계속 활성화됨
    public static bool IsCockpitDoorOpen_M_C1 = false; // true 가 되면 앞으로 조종실 문 계속 열려있음


    /* 이번 플로우차트에서 쓰이는 상호작용 오브젝트 목록 */
    // 움직일 수 있는 오브젝트와 못 움직이는 오브젝트 모두 넣는다.
    // 이름 짓기 규칙 : 오브젝트 이름 + 플로우차트 넘버링
    //public GameObject consoleCenter_M_C1;
    public GameObject box_M_C1;
    public GameObject envirPipe_M_C1;
    //public GameObject consoleAIResetButton_M_C1;

    // 플로우차트 하나를 크게 n 개로 나눌 수 있으면 오브젝트들도 엔터로 구분한다.
    public GameObject cockpitDoor_M_C1;


    /* 기타 필요한 변수들이 있으면 만든다. */
    public Animator noahAnim_M_C1; //
    public Animator cockpitDoorAnimM_C1;

    public Image fadeImage_M_C1;
    public GameObject fade_M_C1;
    public Image aiIcon_M_C1;

    /* 끼우기 관련 변수들 */
    public GameObject insertArea_M_C1;
    public GameObject cockpitDoorInsertAnswer_M_C1;
    public Button insertAnswerButton;
    public bool IsInsertAreaClicked = false;

    private Outline resetButtonOutline;

    private void Start()
    {
        // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
        noahAnim_M_C1.SetBool("IsSleeping", true);
        StartCoroutine(NoahWakeUp()); // 잠들어 있던 노아가 깨어난다
        StartCoroutine(FadeCoroutine()); //화면이 밝아진다


        //resetButtonOutline = consoleAIResetButton_M_C1.GetComponent<Outline>();



    }
    private void Awake()
    {
        insertAnswerButton.onClick.AddListener(ClickInsertArea);
    }




    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim_M_C1.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim_M_C1.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim_M_C1.SetBool("IsSleeping", false);
    }

    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon_M_C1.GetComponent<Image>().color;
        color.a = 0f;
        aiIcon_M_C1.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage_M_C1.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a >= 0)
        {
            fadeColor.a -= 0.01f;
            fadeImage_M_C1.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.00001f);
        }
        fade_M_C1.SetActive(false);
    }

    private void Update()
    {
        // 이 플로우차트는 크게 2 퍼즐로 나눌 수 있다. 
        // 1) <조종석> 에서 AI 활성화시키기
        // 2) <조종실 문> 을 열기

        // 1)AI 가 먼저 활성화 되어야 2) 조종실 문을 열 수 있으므로 

        if (IsAI_M_C1) // if 문에서 현재 AI 가 활성화되었는지 확인하고 
        {
            //OpenCockpitDoor();// 활성화 되었으면 조종실 문 여는 함수를 실행시킨다.
        }
        else // AI 가 활성화되기 전이면
        {
            openDoor();
            //ResetAI(); // 계속해서 AI 활성화 시키는 함수를 실행시킨다. 
        }
    }

    void ClickInsertArea()
    {
        IsInsertAreaClicked = true;
        Invoke("UnclickInsertArea", 2f);
    }

    void UnclickInsertArea()
    {
        IsInsertAreaClicked = false;
    }

    void openDoor()
    {
        ObjData cockpitDoorData_M_C1 = cockpitDoor_M_C1.GetComponent<ObjData>();
        ObjData boxData_M_C1 = box_M_C1.GetComponent<ObjData>();      
        ObjData cockpitDoorInsertAnswerData_M_C1 = cockpitDoorInsertAnswer_M_C1.GetComponent<ObjData>();
        BoxCollider cockpitDoorCollider = cockpitDoor_M_C1.GetComponent<BoxCollider>();
        if (cockpitDoorData_M_C1.IsInsert)        
        {
            insertArea_M_C1.SetActive(true); // 끼우기 영역을 켠다. 
            cockpitDoorInsertAnswer_M_C1.SetActive(true); // 정답 영역을 켠다. 
            //cockpitDoorCollider.enabled = false;
            if(IsInsertAreaClicked && InsertDetect.insertDetect.Isdetected)
            {
                cockpitDoorAnimM_C1.SetBool("IsOpening", true);
                cockpitDoorAnimM_C1.SetBool("Open", true);
            }
        }

        //if(boxData_M_C1.IsUpDown)
        //{
        //    cockpitDoorAnimM_C1.SetBool("IsOpening", true);
        //    cockpitDoorAnimM_C1.SetBool("Open", true);
        //}
    }

    void EnableCockpitDoor()
    {
        ObjData boxData_M_C1 = box_M_C1.GetComponent<ObjData>();
        ObjData cockpitDoorData_M_C1 = cockpitDoor_M_C1.GetComponent<ObjData>();
        
        if (boxData_M_C1.IsUpDown)
        {
            cockpitDoorData_M_C1.IsNotInteractable = false;
            resetButtonOutline.OutlineWidth = 8;
        }
    }


    /* 플로우차트를 크게 n개로 나눌 수 있으면 나눠서 함수를 만든다. */
    // 1) <조종석> 의 AI 를 활성화 시키는 퍼즐
    public void ResetAI()
    {
        /* 함수 첫 시작에서 앞에서 정했던 이번 플로우차트에서 쓰이는 오브젝트들의 각각의 데이터가 저장되어있는 ObjData 컴포넌트를 모두 불러온다. */
        // 이름 짓기 규칙 : 오브젝트 이름 + Data + 플로우차트 넘버링
        //ObjData consoleCenteData_M_C1 = consoleCenter_M_C1.GetComponent<ObjData>();
        ObjData boxData_M_C1 = box_M_C1.GetComponent<ObjData>();
        ObjData envirPipeData_M_C1 = envirPipe_M_C1.GetComponent<ObjData>();
        //ObjData consoleAIResetButtonData_M_C1 = consoleAIResetButton_M_C1.GetComponent<ObjData>();



        /* 플로우차트를 보고 직접 쳐보고 실행해보면서 if 문을 짠다. */
        // 첫번째 if 문에 퍼즐 가장 마지막 단계를 넣고 마지막 if 문에 퍼즐 첫 번째 단계를 넣는다. 

        // 예를 들어 조종석 AI 활성화 퍼즐의 경우, <재가동 버튼> 의 "밀기" 버튼을 누르는 것이 
        //마지막 단계이므로 눌러졌는지 확인하는 ConsoleLeftAIResetButtoneData.IsPushOrPress를 첫 번쨰 if 문에 넣었다. */
        //if (consoleAIResetButtonData_M_C1.IsPushOrPress)
        //{
        //    CameraController.cameraController.CancelObserve();
        //    DialogManager.dialogManager.ResetSystem(); // AI 1 번째 대사 묶음 출력
        //    //CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // 앞으로 볼 일 없으므로 초기화

        //    IsAI_M_C1 = true; // 앞으로 게임이 꺼져도 AI 가 계속 활성화된다. 

        //    /* 나중에 추가할 목록들 */
        //    // <시스템 재가동 버튼> 상호작용 비활성화(이후에 누르는 일 없도록)
        //    // return true; // 엔딩 수집 페이지 갱신, 게임 세이브 분기점
        //}

        /* <박스> "오르기" && <조종석> "관찰하기" && <파이프> "물기" 전부 true 이면 */
        //if (consoleCenteData_M_C1.IsObserve && boxData_M_C1.IsUpDown && envirPipeData_M_C1.IsBite)
        //{
        //    // <조종석> 의 "관찰하기" 뷰를 ObservePlusView 로 넣는다. 
        //    CameraController.cameraController.currentView = consoleCenteData_M_C1.ObservePlusView; //관찰 뷰 : < 시스템 재가동 버튼> 이 보이는 위치
        //    consoleCenteData_M_C1.IsExtraDescriptionActive = true; // 버튼 추가 설명을 활성화한다. 
        //}
        //else
        //{// 박스 없이 그냥 <조종석> 을 "관찷하기" 했으므로 관찰하기 뷰를 일반 뷰인 ObserveView 로 넣는다
        //    CameraController.cameraController.currentView = consoleCenteData_M_C1.ObserveView; // 관찰 뷰 : 안 보이는 위치
        //}
    }



    // 2) <조종실 문> 을 여는 퍼즐
    //public void OpenCockpitDoor()
    //{
    //    ObjData cockpitDoorData_M_C1 = cockpitDoor_M_C1.GetComponent<ObjData>();
    //    ObjData envirPipeData_M_C1 = envirPipe_M_C1.GetComponent<ObjData>();



    //    if (cockpitDoorData_M_C1.IsInsert)
    //    {
    //        // 문여는 애니메이션
    //        // 
    //        IsCockpitDoorOpen_M_C1 = true; // 문 해금
    //    }
    //    if (envirPipeData_M_C1.IsBite)
    //    {
    //        cockpitDoorData_M_C1.IsCenterButtonDisabled = false; // 끼우기 버튼이 활성화된다. 
    //    }
    //    if (envirPipeData_M_C1.IsBite == false)
    //    {
    //        cockpitDoorData_M_C1.IsCenterButtonDisabled = true; // 끼우기 버튼 비활성화
    //    }


    //}
}

        //if (PlayerScripts.playerscripts.currentObject.name == "DoorLocked")
        //{
        //    DialogManager.dialogManager.DoorLock();
        //    PlayerScripts.playerscripts.currentObject = null;
        //}