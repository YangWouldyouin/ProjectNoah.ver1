using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour, IInteraction
{
    [Header("< 오브젝트 정보 >")]

    /* 이 오브젝트와 상호작용 하는 변수들 */
    public GameObject consoleCenter_CC;
    MeshCollider consoleCollider;
    
    /* 이 오브젝트와 상호작용 하는 변수들의 데이터 */
    ObjData consoleCenterObjData_CC;

    public ObjectData consoleCenterData_CC;
    public ObjectData boxData_CC;
    public ObjectData envirPipeData_CC;
    public ObjectData consoleAIResetButtonData_CC;


    /* 기타 필요한 변수들 */
    public Outline consoleAIResetButtonOutline_CC;
    Outline consoleCenterOutline_CC;

    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public GameObject fade_CC;
    public Button aiIcon_CC;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    float timer_CC = 0;
    private  Button barkButton_C_Console, sniffButton_C_Console, biteButton_C_Console, pressButton_C_Console, observeButton_C_Console;

    public Vector3 consoleRisePos;

    /*UI관련*/
    public Canvas MainSystem_GUI;
    public GameObject TrackChangeNotification_GUI;

    // Start is called before the first frame update
    void Start()
    {
        consoleCollider = GetComponent<MeshCollider>();
        consoleCenterObjData_CC = GetComponent<ObjData>();

        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_C_Console = consoleCenterObjData_CC.BarkButton;
        barkButton_C_Console.onClick.AddListener(OnBark);

        sniffButton_C_Console = consoleCenterObjData_CC.SniffButton;
        sniffButton_C_Console.onClick.AddListener(OnSniff);

        biteButton_C_Console = consoleCenterObjData_CC.BiteButton;
        biteButton_C_Console.onClick.AddListener(OnBite);

        pressButton_C_Console = consoleCenterObjData_CC.PushOrPressButton;
        pressButton_C_Console.onClick.AddListener(OnPushOrPress);

        observeButton_C_Console = consoleCenterObjData_CC.CenterButton1;
        observeButton_C_Console.onClick.AddListener(OnObserve);

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
            consoleCollider.enabled = true;
            MainSystem_GUI.gameObject.SetActive(false);
        }

        if(GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet == true)
        {
            TrackChangeNotification_GUI.SetActive(true);
            Invoke("TrackChangeGUI_popUp", 3f);
        }
    }

    public void TrackChangeGUI_popUp()
    {
        TrackChangeNotification_GUI.SetActive(false);
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
        /* 취소할 때 참고할 오브젝트 저장 */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        /* 상호작용 버튼을 끔 */
        DiableButton();

        //// AI 깨우기 미션 완료 전이면 
        //if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        //{
        //    /* 임무 리스트에 "AI 깨우기" 미션 추가 */
        //    GameManager.gameManager._gameData.ActiveMissionList[0] = true;
        //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //}
        //else 
        //{
        //    /* 임무 리스트에 "AI 깨우기" 미션 삭제 */
        //    GameManager.gameManager._gameData.ActiveMissionList[0] = false; 
        //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");         
        //}
        ///* 임무 리스트 한번 활성화 */
        //MissionGenerator.missionGenerator.ActivateMissionList();

        if (boxData_CC.IsUpDown) // 상자에 올라갔으면 
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = consoleCenterObjData_CC.ObservePlusView; // 관찰 뷰 : 위쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();

            StartCoroutine(Delay3Seconds());
        }
        else // 상자에 올라가지 않았으면
        {
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = consoleCenterObjData_CC.ObserveView; // 관찰 뷰 : 아래쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();
        }
    }

    IEnumerator Delay3Seconds()
    {
        yield return new WaitForSeconds(3f);
        MainSystem_GUI.gameObject.SetActive(true);
        consoleCollider.enabled = false;
        if (envirPipeData_CC.IsBite) // 파이프를 물었으면
        {
            consoleAIResetButtonData_CC.IsNotInteractable = false;
            consoleAIResetButtonOutline_CC.OutlineWidth = 8;
        }
        else // 파이프를 물지 않았으면
        {
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            consoleAIResetButtonData_CC.IsNotInteractable = true;
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* "물기" 가 안되는 오브젝트 일 때!! */

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* 밀기 & 누르기 중에 "누르기"일 때!!! */
    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnBark()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnUp() // @@ 수정 필요함 @@
    {

    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnInsert()
    {
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {

    }


    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
