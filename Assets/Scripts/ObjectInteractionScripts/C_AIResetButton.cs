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
        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
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

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
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
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnPushOrPress()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        // ž��� ���ư�
        CameraController.cameraController.CancelObserve();
        // AI ���� ��ư ��Ȱ��ȭ (���� ������Ʈ)
        AIButtonOutline.OutlineWidth = 0;
        AIButtonData.IsNotInteractable = true;
        /* �ִϸ��̼� ������ */

        Invoke("DelayAnim", 1.5f);

        /* "AI ����� �Ϸ�" ���� �߰� ���� */
        GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* ���������������������������������������� Z-1��� ���� ���������������������������������������� */

        /* �ӹ� ����Ʈ�� "AI �����" �̼� ���� */
        GameManager.gameManager._gameData.ActiveMissionList[0] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* �ӹ� ����Ʈ �ѹ� Ȱ��ȭ */
        MissionGenerator.missionGenerator.ActivateMissionList();

        /* ������ �� Ȱ��ȭ */
        controlDoorOutline.OutlineWidth = 8;
        controlDoorData.IsNotInteractable = false;
        Debug.Log("������ �� Ȱ��ȭ");

        /* ���������������������������������������� Z-2��� ���� ���������������������������������������� */
    }

    void DelayAnim()
    {
        InteractionButtonController.interactionButtonController.playerPressHead();
        // AI ��� �ֱ�
        StartCoroutine(DelayAIDialog());
    }

    IEnumerator DelayAIDialog()
    {
        yield return new WaitForSeconds(1.5f);
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));
    }

    public void OnSniff()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
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
