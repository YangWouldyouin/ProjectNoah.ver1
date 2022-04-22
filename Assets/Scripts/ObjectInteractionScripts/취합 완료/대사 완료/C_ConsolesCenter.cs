using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour, IInteraction
{
    [Header("< 오브젝트 정보 >")]

    /* 이 오브젝트와 상호작용 하는 변수들 */
    public GameObject box_CC;
    public GameObject envirPipe_CC;
    public GameObject consoleAIResetButton_CC;
    public GameObject consoleCenter_CC;

    /* 이 오브젝트와 상호작용 하는 변수들의 데이터 */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;

    /* 기타 필요한 변수들 */
    Outline consoleAIResetButtonOutline_CC;
    Outline consoleCenterOutline_CC;
    public GameObject consoleDescription_CC;

    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public GameObject fade_CC;
    public Image aiIcon_CC;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    float timer_CC = 0;
    public Button barkButton_C_Console, sniffButton_C_Console, biteButton_C_Console, pressButton_C_Console, observeButton_C_Console;

    public Vector3 consoleRisePos;

    // Start is called before the first frame update
    void Start()
    {
        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_C_Console.onClick.AddListener(OnBark);
        sniffButton_C_Console.onClick.AddListener(OnSniff);
        biteButton_C_Console.onClick.AddListener(OnBiteDestroy);
        pressButton_C_Console.onClick.AddListener(OnPushOrPress);
        observeButton_C_Console.onClick.AddListener(OnObserve);

        consoleCenterData_CC = consoleCenter_CC.GetComponent<ObjData>();
        boxData_CC = box_CC.GetComponent<ObjData>();
        envirPipeData_CC = envirPipe_CC.GetComponent<ObjData>();
        consoleAIResetButtonData_CC = consoleAIResetButton_CC.GetComponent<ObjData>();

        consoleAIResetButtonOutline_CC = consoleAIResetButton_CC.GetComponent<Outline>();
        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

        dialogManager = dialogManager_CC.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // 잠들어 있던 노아가 깨어난다
            StartCoroutine(FadeCoroutine()); //화면이 밝아진다
        }
    }

    IEnumerator NoahWakeUp()
    {
        yield return new WaitForSeconds(2f);
        noahAnim_CC.SetBool("IsWaking", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsWaking2", true);
        yield return new WaitForSeconds(1f);
        noahAnim_CC.SetBool("IsSleeping", false);
    }

    IEnumerator FadeCoroutine()
    {
        Color color = aiIcon_CC.GetComponent<Image>().color;
        color.a = 0f;
        aiIcon_CC.GetComponent<Image>().color = color;

        Color fadeColor = fadeImage_CC.GetComponent<Image>().color;
        fadeColor.a = 1f;
        while (fadeColor.a >= 0)
        {
            fadeColor.a -= 0.01f;
            fadeImage_CC.GetComponent<Image>().color = fadeColor;
            yield return new WaitForSeconds(0.00001f);
        }
        fade_CC.SetActive(false);
    }

    void Update()
    {
        /* 어쩔 수 없는 업데이트문... */
        if(consoleCenterData_CC.IsObserve == false)
        {
            // AI 리셋 버튼 비활성화 (서브 오브젝트)
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            consoleAIResetButtonData_CC.IsNotInteractable = true;
        }
    }

    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        barkButton_C_Console.transform.gameObject.SetActive(false);
        sniffButton_C_Console.transform.gameObject.SetActive(false);
        biteButton_C_Console.transform.gameObject.SetActive(false);
        pressButton_C_Console.transform.gameObject.SetActive(false);
        observeButton_C_Console.transform.gameObject.SetActive(false);
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnObserve()
    {  
        /* 오브젝트의 관찰 변수 true로 바꿈 */
        consoleCenterData_CC.IsObserve = true;
        /* 취소할 때 참고할 오브젝트 저장 */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* 상호작용 버튼을 끔 */
        DiableButton();

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));

        // AI 깨우기 미션 완료 전이면 
        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            /* 임무 리스트에 "AI 깨우기" 미션 추가 */
            GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else 
        {
            /* 임무 리스트에 "AI 깨우기" 미션 삭제 */
            GameManager.gameManager._gameData.ActiveMissionList[0] = false; 
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");         
        }
        /* 임무 리스트 한번 활성화 */
        MissionGenerator.missionGenerator.ActivateMissionList();

        if (boxData_CC.IsUpDown) // 상자에 올라갔으면 
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView; // 관찰 뷰 : 위쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();

            if (envirPipeData_CC.IsBite) // 파이프를 물었으면
            {
                StartCoroutine(PrintConsoleDescriptionAndActivateAIButton());

                if (consoleAIResetButtonData_CC.IsPushOrPress) // AI 리셋 버튼을 눌렀으면
                {
                    // 탑뷰로 돌아감
                    CameraController.cameraController.CancelObserve();

                    // AI 리셋 버튼 비활성화 (서브 오브젝트)
                    consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                    consoleAIResetButtonData_CC.IsNotInteractable = true;

                    // AI 대사 넣기
                    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));

                    /* "AI 깨우기 완료" 게임 중간 저장 */ 
                    GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                    /* 임무 리스트에 "AI 깨우기" 미션 삭제 */
                    GameManager.gameManager._gameData.ActiveMissionList[0] = false;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    /* 임무 리스트 한번 활성화 */
                    MissionGenerator.missionGenerator.ActivateMissionList();
                }
            }
            else // 파이프를 물지 않았으면
            {
                StartCoroutine(PrintConsoleDescription());               
                consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                consoleAIResetButtonData_CC.IsNotInteractable = true;
            }
        }
        else // 상자에 올라가지 않았으면
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = consoleCenterData_CC.ObserveView; // 관찰 뷰 : 아래쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();
        }
    }

    IEnumerator PrintConsoleDescription()
    {
        yield return new WaitForSeconds(2f);
        consoleDescription_CC.SetActive(true);
    }

    IEnumerator PrintConsoleDescriptionAndActivateAIButton()
    {
        yield return new WaitForSeconds(2f);
        consoleDescription_CC.SetActive(true);

        consoleAIResetButtonData_CC.IsNotInteractable = false;
        consoleAIResetButtonOutline_CC.OutlineWidth = 8;
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* "물기" 가 안되는 오브젝트 일 때!! */
    public void OnBiteDestroy() 
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* 밀기&누르기 중 "밀기" 일 때!!! @@  수정 필요 @@
    public void OnPushOrPress()
    {
       오브젝트의 누르기 변수 true로 바꿈 
       consoleCenterData_CC.IsPushOrPress = true;
       상호작용 버튼을 끔 
       DiableButton();
      밀기 취소할 때 쓰기 위해 오브젝트 저장 
      PlayerScripts.playerscripts.currentPushOrPressObj = this.gameObject;
      밀기 함수1 
      InteractionButtonController.interactionButtonController.playerPush1();
      오브젝트 밀기 상세 좌표와 각도 넣어주기 
      this.transform.localPosition = pushPos; 
      this.transform.localEulerAngles = pushRot; 
      밀기 함수2 (애니메이션) 
      InteractionButtonController.interactionButtonController.PlayerPush2();
    } */

    /* 밀기 & 누르기 중에 "누르기"일 때!!! */
    public void OnPushOrPress()
    {
        /* 오브젝트의 누르기 변수 true로 바꿈 */
         consoleCenterData_CC.IsPushOrPress = true;

        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        // InteractionButtonController.interactionButtonController.playerPressHead(); // 머리로 누르는 애니메이션 

        /* 2초 뒤에 Ispushorpress 를 false 로 바꿈 */
        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        consoleCenterData_CC.IsPushOrPress = false;
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnBark()
    {
        /* 오브젝트의 짖기 변수 true로 바꿈 */
        consoleCenterData_CC.IsBark = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnSniff()
    {
        /* 오브젝트의 냄새맡기 변수 true로 바꿈 */
        consoleCenterData_CC.IsSniff = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnUp() // @@ 수정 필요함 @@
    {
        if (!consoleCenterData_CC.IsUpDown)
        {
            /* 상호작용 버튼을 끔 */
            DiableButton();
            /* 점프 좌표를 넣어줌 */
            consoleRisePos.x = this.transform.position.x;
            consoleRisePos.y = this.transform.position.y;
            consoleRisePos.z = this.transform.position.z;

            /* 오르기 취소할 때 참고하기 위해 오브젝트를 저장해둠 */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* 오브젝트의 오르기  변수 true로 바꿈 */
            consoleCenterData_CC.IsUpDown = true;

            /* 오르기 애니메이션 절반만 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* 애니메이션 중간에 점프 좌표로 이동 */
            InteractionButtonController.interactionButtonController.risePosition = consoleRisePos;
            /* 오르기 애니메이션 나머지 실행 */
            InteractionButtonController.interactionButtonController.PlayerRise2();
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnInsert()
    {
        /* 현재 끼우기 오브젝트가 조종석이라는  것을 저장해둠 */
        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;
        /* 오브젝트의 끼우기 변수 true로 바꿈 */
        consoleCenterData_CC.IsInsert = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);
        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        /* 오브젝트의 먹기 변수 true로 바꿈 */
        consoleCenterData_CC.IsEaten = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 먹기 애니메이션 & 오브젝트 사라지게 */
        InteractionButtonController.interactionButtonController.playerEat();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
