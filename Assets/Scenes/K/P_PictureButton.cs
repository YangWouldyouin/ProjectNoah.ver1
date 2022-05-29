using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P_PictureButton : MonoBehaviour, IInteraction
{
    private Button barkButton_P_PictureButton, sniffButton_P_PictureButton, biteButton_P_PictureButton,
pushButton_P_PictureButton, noCenterButton_P_PictureButton,smashButton_P_PictureButton;

    ObjData PictureButton_P;
    public ObjectData pictureButtonData;

    // UI ������Ʈ
    public GameObject UniverseImage_P; // ���� ����

    // ������Ʈ ������
    ObjData UniverseImageData_P;

    AudioSource TakePic_Sound_P;
    public AudioClip TakePic_sound;

    public GameObject[] UniverseImageList; // ���� ���� ����Ʈ

    public GameObject Report_GUI_P; // �����ϱ� GUI
    private bool IsReported = false;

    public int ran; // ���� ����

    public GameObject dialog;
    DialogManager dialogManager;

    public InGameTime inGameTime;


    public bool MissionScriptCheck = false;

    /* ���������������������������������������� W-1��� ���� ���������������������������������������� */

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        PictureButton_P = GetComponent<ObjData>();

        TakePic_Sound_P = GetComponent<AudioSource>();

        barkButton_P_PictureButton = PictureButton_P.BarkButton;
        barkButton_P_PictureButton.onClick.AddListener(OnBark);

        sniffButton_P_PictureButton = PictureButton_P.SniffButton;
        sniffButton_P_PictureButton.onClick.AddListener(OnSniff);

        biteButton_P_PictureButton = PictureButton_P.BiteButton;
        biteButton_P_PictureButton.onClick.AddListener(OnBite);

        smashButton_P_PictureButton = PictureButton_P.SmashButton;
        smashButton_P_PictureButton.onClick.AddListener(OnSmash);

        pushButton_P_PictureButton = PictureButton_P.PushOrPressButton;
        pushButton_P_PictureButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_P_PictureButton = PictureButton_P.CenterButton1;
    }

    /* ��ȣ�ۿ� ��ư�� ���� �Լ� */
    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_P_PictureButton.transform.gameObject.SetActive(false);
        sniffButton_P_PictureButton.transform.gameObject.SetActive(false);
        biteButton_P_PictureButton.transform.gameObject.SetActive(false);
        pushButton_P_PictureButton.transform.gameObject.SetActive(false);
        noCenterButton_P_PictureButton.transform.gameObject.SetActive(false);
    }


    /* ���������������������������������������� ���� ���� ���������������������������������������� */
    void Update()
    {
        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10)
        {
            GameManager.gameManager._gameData.IsPhotoTime = true;

            if (MissionScriptCheck == false)
            {
                Debug.Log("������� ���� ����");

                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(46));
                MissionScriptCheck = true;
                //������ ���� �Կ� ���� ����

                GameManager.gameManager._gameData.ActiveMissionList[23] = true;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10)
        {
            GameManager.gameManager._gameData.IsPhotoTime = false;

            if (MissionScriptCheck == true)
            {
                Debug.Log("������� ���� ����");

                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                MissionScriptCheck = false;
                //������ ���� �Կ� ���� ��

                GameManager.gameManager._gameData.ActiveMissionList[23] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
    }


    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnBite()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnPushOrPress()
    {
        if (GameManager.gameManager._gameData.IsPhotoTime == true)
        {
            ran = Random.Range(0, 5); // ���� ����
            GameManager.gameManager._gameData.randomUPic = ran;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("���� ���� ����");

            /* �б� & ������ �߿� "������"�� ��!!! */
            DiableButton();
            InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

            Invoke("RandomUniversePic", 1f); // ���� ���� ���� ���� + �̹��� �����ֱ�

            TakePic_Sound_P.clip = TakePic_sound;
            TakePic_Sound_P.Play(); // ȿ���� ���
            Invoke("Report_Popup", 4f); // �����ϱ� �˾�
        }
    }

    /* UI ��ũ��Ʈ */
    public void RandomUniversePic() // ���� ���� ���� �����ֱ�
    {
        UniverseImage_P = UniverseImageList[ran]; // ���� �̹��� �������� UniverseImage_P �� ����
        // SaveSystem.Save(GameManager.gameManager._gameData, UniverseImageList[ran]);
        UniverseImage_P.SetActive(true); // ���� ���� �����ֱ�
    }

    public void Report_Popup() // �����ϱ� GUI ����
    {
        Report_GUI_P.SetActive(true);
    }



    /* ���������������������������������������� �ؿ� �ΰ� ���� �� ���������������������������������������� */
    public void Report() // �����ϱ� ��ư ������
    {
        Debug.Log("�����ϱ�");
        IsReported = true;

        Report_GUI_P.SetActive(false); // â ����
        UniverseImage_P.SetActive(false);
        /* ���������������������������������������� W-2��� ���� ���������������������������������������� */
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(61));
        //������ ���� �Կ� ���� ��

        GameManager.gameManager._gameData.ActiveMissionList[23] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void Cancel() //ĵ�� ��ư ������
    {
        Debug.Log("����ϱ�");

        GameManager.gameManager._gameData.IsReportCancleCount += 1; // �ӹ� ���� ī��Ʈ �پ���
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsReported = true;
        Debug.Log("�ӹ� ���� ī��Ʈ �پ��� + ����");

        Report_GUI_P.SetActive(false); // â ����
        UniverseImage_P.SetActive(false);

        //������ ���� �Կ� ���� ��

        GameManager.gameManager._gameData.ActiveMissionList[23] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }





    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnObserve()
    {
    }
    public void OnSmash()
    {
    }

    public void OnUp()
    {
    }

}
