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


    [Header("< ������ �� >")]
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

        AIresetbutton_click_sound.clip = AIresetbutton_Click;
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

        /* "AI ����� �Ϸ�" ���� �߰� ���� */
        GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
        GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        /* �ӹ� ����Ʈ�� "AI �����" �̼� ���� */
        MissionGenerator.missionGenerator.DeleteNewMission(0);
        //StartCoroutine(WaitDeleting());

        // ž��� ���ư������� ��ٷȴٰ� ������ �ִϸ��̼�


        /* �ִϸ��̼� ������ */
        StartCoroutine(DelayPressAnim());

        /* ���������������������������������������� Z-1��� ���� ���������������������������������������� */
        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));
        //StartCoroutine(GoToWork());

        //AIresetbutton_click_sound.clip = Door_open;
        //AIresetbutton_click_sound.Play();


        /* ������ �� Ȱ��ȭ */
        //controlDoorOutline.OutlineWidth = 8;
        //controlDoorData.IsNotInteractable = false;
        //Debug.Log("������ �� Ȱ��ȭ");

        /* ���������������������������������������� Z-2��� ���� ���������������������������������������� */
    }

    IEnumerator WaitDeleting()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(1);
    }

    IEnumerator GoToWork()
    {
        yield return new WaitForSeconds(3f);
        changeScene_CWD.SetActive(true); // �������� �̵�
    }



    IEnumerator DelayPressAnim()
    {
        yield return new WaitForSeconds(2f);
        InteractionButtonController.interactionButtonController.playerPressHead();
        yield return new WaitForSeconds(0.5f);
        AIresetbutton_click_sound.Play();
        StartCoroutine(DelayAIDialog());
        yield return new WaitForSeconds(0.5f);
        cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
        cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);
        AIresetbutton_click_sound.clip = Door_open;
        AIresetbutton_click_sound.Play();
        changeScene_CWD.SetActive(true); // �������� �̵�
    }



    IEnumerator DelayAIDialog()
    {
        yield return new WaitForSeconds(1.5f);
        Color AIColor = aiIcon_AI.GetComponent<Image>().color;
        AIColor.a = 1.0f;
        aiIcon_AI.GetComponent<Image>().color = AIColor;
        aiIcon_AI.interactable = true;
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));
        StartCoroutine(PrintSecondDialog()); // 1��° ��� ���������� ��ٷȴٰ� 2��° ��� ���
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
