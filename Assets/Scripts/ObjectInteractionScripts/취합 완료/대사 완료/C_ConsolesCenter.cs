using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_ConsolesCenter : MonoBehaviour, IInteraction
{
    [Header("< ������Ʈ ���� >")]

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� ������ */
    public GameObject box_CC;
    public GameObject envirPipe_CC;
    public GameObject consoleAIResetButton_CC;
    public GameObject consoleUnLockButton_CC;
    public GameObject consoleCenter_CC;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;
    ObjData consoleUnLockButtonData_CC;

    /* ��Ÿ �ʿ��� ������ */
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

    public GameObject planetRader_CC; // �༺ ���� ���̴� ���
    ObjData planetRaderData_CC;

    // Start is called before the first frame update
    void Start()
    {
        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
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
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // ���� �ִ� ��ư� �����
            StartCoroutine(FadeCoroutine()); //ȭ���� �������
        }
    }

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
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
            // ������ : ��;��
        }
        else
        {
            // ������ : �����Y
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
        // ������ ������ �ִϸ��̼� ������
        InteractionButtonController.interactionButtonController.playerPressHand();
        // 1�� �ڿ� Ispushorpress �� false �� �ٲ�
        DiableButton();
    }

    public void OnBark()
    {
        consoleCenterData_CC.IsBark = true;
        // �ִϸ��̼� ������
        InteractionButtonController.interactionButtonController.playerBark();
        // ��ȣ�ۿ� ��ư�� ��
        DiableButton();
    }

    public void OnSniff()
    {
        consoleCenterData_CC.IsSniff = true;
        // �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ���
        InteractionButtonController.interactionButtonController.playerSniff();
        // ��ȣ�ۿ� ��ư�� ��
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
