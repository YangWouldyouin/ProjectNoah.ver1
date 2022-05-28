using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker2 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_HiBeaker1;
    public GameObject M_RubberForBeaker2;
    public GameObject M_RealAnswerMeteorForBeaker;

    public GameObject M_RealCylinderGlassAnswer;
    public GameObject M_RealcylinderGlassWrong;
    public GameObject M_RealCylinderGlassNoNeed1;
    public GameObject M_RealCylinderGlassNoNeed2;

    public GameObject M_drugInBeaker2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Beaker2, sniffButton_M_Beaker2, biteButton_M_Beaker2,
        pressButton_M_Beaker2, eatButton_M_Beaker2, eatDisableButton_M_Beaker2;


    /*ObjData*/
    ObjData Beaker2Data_M;
    public ObjectData Beaker2ObjData_M;

    public ObjectData RubberForBeaker2Data_M;
    public ObjectData RealAnswerMeteorForBeakerData_M;

    public ObjectData RealCylinderGlassAnswerData_M;
    public ObjectData RealCylinderGlassWrongData_M;
    public ObjectData RealCylinderGlassNoNeed1Data_M;
    public ObjectData RealCylinderGlassNoNeed2Data_M;

    public ObjectData drugInBeaker2Data_M;

    /*Outline*/
    Outline Beaker2Outline_M;
    Outline RealAnswerMeteorForBeakerOutline_M;

    /*��Ŀ �� �ٲٴ� �ڵ�*/
    MeshRenderer ChangeBeaker2;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    AudioSource Beaker_Hit_Sound;
    public AudioClip Beaker_Audio;


    /*Collider*/

    BoxCollider RealBeaker1_Collider;
    BoxCollider RealBeaker2_Collider;

    BoxCollider RealcylinderGlassAnswer_Collider;
    BoxCollider RealcylinderGlassWrong_Collider;
    BoxCollider RealcylinderGlassNoNeed1_Collider;
    BoxCollider RealcylinderGlassNoNeed2_Collider;

    /*Ÿ�̸�*/
    public InGameTime inGameTime;

    public GameObject S_TimerBarFilled;
    public GameObject S_TimerBackground;
    public GameObject S_TimerText;

    public bool IsPretendDeadFail2 = false; //���� �ð� ���� �ȿ� ���� ����
    public bool canTpretendDead2 = false;

    void Start()
    {
        Beaker_Hit_Sound = GetComponent<AudioSource>();

        dialogManager = dialog_CS.GetComponent<DialogManager>();

        //�� �ٲٴ� �ڵ�
        ChangeBeaker2 = M_drugInBeaker2.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker2Data_M = GetComponent<ObjData>();

        /*Outline*/
        Beaker2Outline_M = GetComponent<Outline>();
        RealAnswerMeteorForBeakerOutline_M = M_RealAnswerMeteorForBeaker.GetComponent<Outline>();

        /*Collider*/
        RealBeaker1_Collider = M_HiBeaker1.GetComponent<BoxCollider>();
        RealBeaker2_Collider = GetComponent<BoxCollider>();

        RealcylinderGlassAnswer_Collider = M_RealCylinderGlassAnswer.GetComponent<BoxCollider>();
        RealcylinderGlassWrong_Collider = M_RealcylinderGlassWrong.GetComponent<BoxCollider>();
        RealcylinderGlassNoNeed1_Collider = M_RealCylinderGlassNoNeed1.GetComponent<BoxCollider>();
        RealcylinderGlassNoNeed2_Collider = M_RealCylinderGlassNoNeed2.GetComponent<BoxCollider>();


        /*��ư ����*/
        barkButton_M_Beaker2 = Beaker2Data_M.BarkButton;
        barkButton_M_Beaker2.onClick.AddListener(OnBark);

        sniffButton_M_Beaker2 = Beaker2Data_M.SniffButton;
        sniffButton_M_Beaker2.onClick.AddListener(OnSniff);

        biteButton_M_Beaker2 = Beaker2Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker2 = Beaker2Data_M.PushOrPressButton;
        pressButton_M_Beaker2.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker2 = Beaker2Data_M.CenterButton1;
        eatButton_M_Beaker2.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker2 = Beaker2Data_M.CenterButton1;

        Beaker2ObjData_M.IsCenterButtonDisabled = true;


    }

    void FakeAI2()
    {
        //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ����ô�ϱ� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������

        RealBeaker1_Collider.enabled = false;
        RealBeaker2_Collider.enabled = false;

        RealcylinderGlassAnswer_Collider.enabled = false;
        RealcylinderGlassWrong_Collider.enabled = false;
        RealcylinderGlassNoNeed1_Collider.enabled = false;
        RealcylinderGlassNoNeed2_Collider.enabled = false;

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            RealAnswerMeteorForBeakerData_M.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            RealAnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            Beaker2ObjData_M.IsCenterButtonDisabled = false;

            //���� ���Ѵ�.
            ChangeBeaker2.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            M_RealAnswerMeteorForBeaker.SetActive(false);
        }

        if (IsPretendDeadFail2 == true && canTpretendDead2 == false && !GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("�ð��ȿ� ���� Ǯ�� ����");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTpretendDead2 = true;
        }

        //Ÿ�� ���� ������
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            inGameTime.IsTimerStarted = false;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            Debug.Log("����� �¿��� ���� ����������!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //��¥ Ʃ�丮�� �߰� ����
        }
    }

    void DisableButton()
    {
        barkButton_M_Beaker2.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker2.transform.gameObject.SetActive(false);
        biteButton_M_Beaker2.transform.gameObject.SetActive(false);
        pressButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        Beaker_Hit_Sound.clip = Beaker_Audio;
        Beaker_Hit_Sound.Play();

        /*������ ���� ���� ��� ��Ŀ 2�� �ִ´ٸ�*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ RealAnswerMeteorForBeakerData_M.IsBite)
        {
            M_RealAnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_RealAnswerMeteorForBeaker.transform.parent = null;

            //��� ��Ŀ ������ �̵��Ѵ�.
            M_RealAnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 1.5762f, 683.427f); //��ġ ��
            M_RealAnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

            GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 = true;
        }

        //���� ���� ��Ŀ 2�� �־��� ��
        if (RealCylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker2.SetActive(true);
            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("�߸��� ���� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //�ʿ� ���� ��1�� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //�ʿ� ���� ��2�� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��2�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = true;
        }

    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
        //�������� �ִϸ��̼� ���� ����

        //Invoke(" FakeAI2", 3f);

        StartCoroutine(realFakeAI2());

        //StartCoroutine(PreteadTimer2());

        //Ÿ�̸� ���� 3��
        TimerManager.timerManager.TimerStart(240);
        Invoke("PretendFailCheck", 240f);
    }

    IEnumerator PreteadTimer2()
    {

        yield return new WaitForSeconds(40f);

        //Ÿ�̸� ���� 3��
        TimerManager.timerManager.TimerStart(180);
        Invoke("PretendFailCheck", 180f);

    }

    void PretendFailCheck()
    {
        IsPretendDeadFail2 = true;
    }


    IEnumerator realFakeAI2()
    {

        yield return new WaitForSeconds(3f);
        Debug.Log("AI�� �� ���Ѵ�.");
        //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ����ô�ϱ� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������

        RealBeaker1_Collider.enabled = false;
        RealBeaker2_Collider.enabled = false;

        RealcylinderGlassAnswer_Collider.enabled = false;
        RealcylinderGlassWrong_Collider.enabled = false;
        RealcylinderGlassNoNeed1_Collider.enabled = false;
        RealcylinderGlassNoNeed2_Collider.enabled = false;

    }

    public void OnBite()
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
