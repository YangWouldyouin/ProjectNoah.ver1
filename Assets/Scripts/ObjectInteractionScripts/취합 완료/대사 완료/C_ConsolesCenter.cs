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
    public GameObject consoleCenter_CC;

    /* �� ������Ʈ�� ��ȣ�ۿ� �ϴ� �������� ������ */
    ObjData consoleCenterData_CC;
    ObjData boxData_CC;
    ObjData envirPipeData_CC;
    ObjData consoleAIResetButtonData_CC;

    /* ��Ÿ �ʿ��� ������ */
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

        consoleAIResetButtonOutline_CC = consoleAIResetButton_CC.GetComponent<Outline>();
        consoleAIResetButtonOutline_CC.OutlineWidth = 0;

        dialogManager = dialogManager_CC.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
            noahAnim_CC.SetBool("IsSleeping", true);
            StartCoroutine(NoahWakeUp()); // ���� �ִ� ��ư� �����
            StartCoroutine(FadeCoroutine()); //ȭ���� �������
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
        /* ��¿ �� ���� ������Ʈ��... */
        if(consoleCenterData_CC.IsObserve == false)
        {
            // AI ���� ��ư ��Ȱ��ȭ (���� ������Ʈ)
            consoleAIResetButtonOutline_CC.OutlineWidth = 0;
            consoleAIResetButtonData_CC.IsNotInteractable = true;
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

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnObserve()
    {  
        /* ������Ʈ�� ���� ���� true�� �ٲ� */
        consoleCenterData_CC.IsObserve = true;
        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));

        // AI ����� �̼� �Ϸ� ���̸� 
        if (!GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            /* �ӹ� ����Ʈ�� "AI �����" �̼� �߰� */
            GameManager.gameManager._gameData.ActiveMissionList[0] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else 
        {
            /* �ӹ� ����Ʈ�� "AI �����" �̼� ���� */
            GameManager.gameManager._gameData.ActiveMissionList[0] = false; 
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");         
        }
        /* �ӹ� ����Ʈ �ѹ� Ȱ��ȭ */
        MissionGenerator.missionGenerator.ActivateMissionList();

        if (boxData_CC.IsUpDown) // ���ڿ� �ö����� 
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView; // ���� �� : ����
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
            InteractionButtonController.interactionButtonController.playerObserve();

            if (envirPipeData_CC.IsBite) // �������� ��������
            {
                StartCoroutine(PrintConsoleDescriptionAndActivateAIButton());

                if (consoleAIResetButtonData_CC.IsPushOrPress) // AI ���� ��ư�� ��������
                {
                    // ž��� ���ư�
                    CameraController.cameraController.CancelObserve();

                    // AI ���� ��ư ��Ȱ��ȭ (���� ������Ʈ)
                    consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                    consoleAIResetButtonData_CC.IsNotInteractable = true;

                    // AI ��� �ֱ�
                    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));

                    /* "AI ����� �Ϸ�" ���� �߰� ���� */ 
                    GameManager.gameManager._gameData.IsAIAwake_M_C1 = true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                    /* �ӹ� ����Ʈ�� "AI �����" �̼� ���� */
                    GameManager.gameManager._gameData.ActiveMissionList[0] = false;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    /* �ӹ� ����Ʈ �ѹ� Ȱ��ȭ */
                    MissionGenerator.missionGenerator.ActivateMissionList();
                }
            }
            else // �������� ���� �ʾ�����
            {
                StartCoroutine(PrintConsoleDescription());               
                consoleAIResetButtonOutline_CC.OutlineWidth = 0;
                consoleAIResetButtonData_CC.IsNotInteractable = true;
            }
        }
        else // ���ڿ� �ö��� �ʾ�����
        {
            /* ī�޶� ��Ʈ�ѷ��� �� ���� */
            CameraController.cameraController.currentView = consoleCenterData_CC.ObserveView; // ���� �� : �Ʒ���
            /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
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

    /* "����" �� �ȵǴ� ������Ʈ �� ��!! */
    public void OnBiteDestroy() 
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    /* �б�&������ �� "�б�" �� ��!!! @@  ���� �ʿ� @@
    public void OnPushOrPress()
    {
       ������Ʈ�� ������ ���� true�� �ٲ� 
       consoleCenterData_CC.IsPushOrPress = true;
       ��ȣ�ۿ� ��ư�� �� 
       DiableButton();
      �б� ����� �� ���� ���� ������Ʈ ���� 
      PlayerScripts.playerscripts.currentPushOrPressObj = this.gameObject;
      �б� �Լ�1 
      InteractionButtonController.interactionButtonController.playerPush1();
      ������Ʈ �б� �� ��ǥ�� ���� �־��ֱ� 
      this.transform.localPosition = pushPos; 
      this.transform.localEulerAngles = pushRot; 
      �б� �Լ�2 (�ִϸ��̼�) 
      InteractionButtonController.interactionButtonController.PlayerPush2();
    } */

    /* �б� & ������ �߿� "������"�� ��!!! */
    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
         consoleCenterData_CC.IsPushOrPress = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        // InteractionButtonController.interactionButtonController.playerPressHead(); // �Ӹ��� ������ �ִϸ��̼� 

        /* 2�� �ڿ� Ispushorpress �� false �� �ٲ� */
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
        /* ������Ʈ�� ¢�� ���� true�� �ٲ� */
        consoleCenterData_CC.IsBark = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnSniff()
    {
        /* ������Ʈ�� �����ñ� ���� true�� �ٲ� */
        consoleCenterData_CC.IsSniff = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnUp() // @@ ���� �ʿ��� @@
    {
        if (!consoleCenterData_CC.IsUpDown)
        {
            /* ��ȣ�ۿ� ��ư�� �� */
            DiableButton();
            /* ���� ��ǥ�� �־��� */
            consoleRisePos.x = this.transform.position.x;
            consoleRisePos.y = this.transform.position.y;
            consoleRisePos.z = this.transform.position.z;

            /* ������ ����� �� �����ϱ� ���� ������Ʈ�� �����ص� */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* ������Ʈ�� ������  ���� true�� �ٲ� */
            consoleCenterData_CC.IsUpDown = true;

            /* ������ �ִϸ��̼� ���ݸ� ���� */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* �ִϸ��̼� �߰��� ���� ��ǥ�� �̵� */
            InteractionButtonController.interactionButtonController.risePosition = consoleRisePos;
            /* ������ �ִϸ��̼� ������ ���� */
            InteractionButtonController.interactionButtonController.PlayerRise2();
        }
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnInsert()
    {
        /* ���� ����� ������Ʈ�� �������̶��  ���� �����ص� */
        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;
        /* ������Ʈ�� ����� ���� true�� �ٲ� */
        consoleCenterData_CC.IsInsert = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);
        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        /* ������Ʈ�� �Ա� ���� true�� �ٲ� */
        consoleCenterData_CC.IsEaten = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �Ա� �ִϸ��̼� & ������Ʈ ������� */
        InteractionButtonController.interactionButtonController.playerEat();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
