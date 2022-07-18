using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_AIResetButton : MonoBehaviour, IInteraction
{
    //public Outline controlDoorOutline;
    Outline AIButtonOutline;
    ObjData AIButtonObjData;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    public ObjectData controlDoorData;
    public ObjectData AIButtonData;

    public GameObject dialogManager_AI;
    DialogManager dialogManager;

    public Button aiIcon_AI;

    AudioSource AIresetbutton_click_sound; 
    public AudioClip AIresetbutton_Click;


    [Header("< 조종실 문 >")]
    public GameObject controlDoor;
    public GameObject changeScene_CWD;
    public AudioClip Door_open;
    private Animator cockpitDoorAnim_CWD;


    // Start is called before the first frame update
    void Start()
    {
        cockpitDoorAnim_CWD = controlDoor.GetComponent<Animator>();
        AIresetbutton_click_sound = GetComponent<AudioSource>();

        AIButtonOutline = GetComponent<Outline>();
        AIButtonObjData = GetComponent<ObjData>();
        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton = AIButtonObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = AIButtonObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = AIButtonObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = AIButtonObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = AIButtonObjData.CenterButton1;

        dialogManager = dialogManager_AI.GetComponent<DialogManager>();

        AIresetbutton_click_sound.clip = AIresetbutton_Click;
    }

    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();

        // 탑뷰로 돌아감
        CameraController.cameraController.CancelObserve();

        // AI 리셋 버튼 비활성화 (서브 오브젝트)
        AIButtonOutline.OutlineWidth = 0;
        AIButtonData.IsNotInteractable = true;

        /* "AI 깨우기 완료" 게임 중간 저장 */
        GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
        GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* 임무 리스트에 "AI 깨우기" 미션 삭제 */
        MissionGenerator.missionGenerator.DeleteNewMission(0);
        //StartCoroutine(WaitDeleting());

        // 탑뷰로 돌아갈때까지 기다렸다가 누르는 애니메이션


        /* 애니메이션 보여줌 */
        StartCoroutine(DelayPressAnim());

        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ Z-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));
        //StartCoroutine(GoToWork());

        //AIresetbutton_click_sound.clip = Door_open;
        //AIresetbutton_click_sound.Play();


        /* 조종실 문 활성화 */
        //controlDoorOutline.OutlineWidth = 8;
        //controlDoorData.IsNotInteractable = false;
        //Debug.Log("조종실 문 활성화");

        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ Z-2대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    }

    IEnumerator WaitDeleting()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(1);
    }

    IEnumerator GoToWork()
    {
        yield return new WaitForSeconds(3f);
        changeScene_CWD.SetActive(true); // 업무공간 이동
    }



    IEnumerator DelayPressAnim()
    {
        yield return new WaitForSeconds(2f);
        InteractionButtonController.interactionButtonController.playerPressHead();
        yield return new WaitForSeconds(0.5f);
        AIresetbutton_click_sound.Play();
        StartCoroutine(DelayAIDialog());
        yield return new WaitForSeconds(0.5f);
        cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // 문 열리는 애니메이션
        cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);
        AIresetbutton_click_sound.clip = Door_open;
        AIresetbutton_click_sound.Play();
        changeScene_CWD.SetActive(true); // 업무공간 이동
    }



    IEnumerator DelayAIDialog()
    {
        yield return new WaitForSeconds(1.5f);
        Color AIColor = aiIcon_AI.GetComponent<Image>().color;
        AIColor.a = 1.0f;
        aiIcon_AI.GetComponent<Image>().color = AIColor;
        aiIcon_AI.interactable = true;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));
        StartCoroutine(PrintSecondDialog()); // 1번째 대사 끝날때까지 기다렸다가 2번째 대사 출력
    }

    IEnumerator PrintSecondDialog()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (dialogManager.IsDialogStarted)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(2));
                break;
            }
        }
    }

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }
}
