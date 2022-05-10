using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_AIResetButton : MonoBehaviour, IInteraction
{
    public Outline controlDoorOutline;
    Outline AIButtonOutline;
    ObjData AIButtonObjData;

    private Button barkButton, sniffButton, biteButton,
    pressButton, noCenterButton;

    public ObjectData controlDoorData;
    public ObjectData AIButtonData;

    public GameObject dialogManager_AI;
    DialogManager dialogManager;


    // Start is called before the first frame update
    void Start()
    {
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
        /* 애니메이션 보여줌 */

        Invoke("DelayAnim", 1.5f);

        /* "AI 깨우기 완료" 게임 중간 저장 */
        GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ Z-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */

        /* 임무 리스트에 "AI 깨우기" 미션 삭제 */
        GameManager.gameManager._gameData.ActiveMissionList[0] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* 임무 리스트 한번 활성화 */
        MissionGenerator.missionGenerator.ActivateMissionList();

        /* 조종실 문 활성화 */
        controlDoorOutline.OutlineWidth = 8;
        controlDoorData.IsNotInteractable = false;
        Debug.Log("조종실 문 활성화");

        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ Z-2대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    }

    void DelayAnim()
    {
        InteractionButtonController.interactionButtonController.playerPressHead();
        // AI 대사 넣기
        StartCoroutine(DelayAIDialog());
    }

    IEnumerator DelayAIDialog()
    {
        yield return new WaitForSeconds(1.5f);
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));
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
