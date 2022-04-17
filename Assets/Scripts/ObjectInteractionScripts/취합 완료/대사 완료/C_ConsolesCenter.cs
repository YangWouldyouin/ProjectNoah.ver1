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
    public GameObject consoleUnLockButton_CC;
    public GameObject consoleCenter_CC;

    /* 이 오브젝트와 상호작용 하는 변수들의 데이터 */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;
    ObjData consoleUnLockButtonData_CC;

    /* 기타 필요한 변수들 */
    Outline consoleAIResetButtonOutline_CC;
    Outline consoleUnLockButtonOutline_CC;
    public GameObject consoleDescription_CC;
    public Animator cockpitDoorAnim_CC;
    public Animator noahAnim_CC;

    public Image fadeImage_CC;
    public GameObject fade_CC;
    public Image aiIcon_CC;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    float timer_CC = 0;
    public GameObject interactBtn;
    public Button barkButton_C_Console, sniffButton_C_Console, biteButton_C_Console, pressButton_C_Console, observeButton_C_Console;

    public GameObject planetRader_CC; // 행성 감지 레이더 기계
    ObjData planetRaderData_CC;

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
        consoleUnLockButtonData_CC = consoleUnLockButton_CC.GetComponent<ObjData>();

        consoleAIResetButtonOutline_CC = consoleAIResetButton_CC.GetComponent<Outline>();
        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

        consoleUnLockButtonOutline_CC = consoleUnLockButton_CC.GetComponent<Outline>();
        consoleUnLockButtonOutline_CC.OutlineWidth = 0;

        dialogManager = dialogManager_CC.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            // 플로우차트 처음 시작 때 넣고 싶은 연출들을 넣는다.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // 잠들어 있던 노아가 깨어난다
            StartCoroutine(FadeCoroutine()); //화면이 밝아진다
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





    public void OnObserve()
    {
        if(boxData_CC.IsUpDown)
        {
            // 관찰뷰 : 우;쪽
        }
        else
        {
            // 관찰뷰 : ㅇ래쫃
        }
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView;
        InteractionButtonController.interactionButtonController.playerObserve();
        DiableButton();
        //throw new System.NotImplementedException();
    }

    public void OnBiteDestroy()
    {
        DiableButton();
    }

    public void OnPushOrPress()
    {
        consoleCenterData_CC.IsPushOrPress = true;
        // 손으로 누르는 애니메이션 보여줌
        InteractionButtonController.interactionButtonController.playerPressHand();
        // 1초 뒤에 Ispushorpress 를 false 로 바꿈
        DiableButton();
    }

    public void OnBark()
    {
        consoleCenterData_CC.IsBark = true;
        // 애니메이션 보여줌
        InteractionButtonController.interactionButtonController.playerBark();
        // 상호작용 버튼을 끔
        DiableButton();
    }

    public void OnSniff()
    {
        consoleCenterData_CC.IsSniff = true;
        // 애니메이션 보여주고 냄새 텍스트 띄움
        InteractionButtonController.interactionButtonController.playerSniff();
        // 상호작용 버튼을 끔
        DiableButton();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
 
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    void OpenCockpitDoor()
    {
        cockpitDoorAnim_CC.SetBool("IsDoorOpenStart", true);
        cockpitDoorAnim_CC.SetBool("IsDoorOpened", true);
    }
    void CloseCockpitDoor()
    {
        cockpitDoorAnim_CC.SetBool("IsDoorOpened", false);
        cockpitDoorAnim_CC.SetBool("IsDoorOpenStart", false);
    }
}
