using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker1 : MonoBehaviour, IInteraction
{
    public GameObject StartScreen;
    //public GameObject EndScreen;
    public GameObject DonTClick;

    /*�����ִ� ������Ʈ*/
    public GameObject M_HiBeaker2;
    //public GameObject M_RubberForBeaker1;
    public GameObject M_AnswerMeteorForBeaker;

    public GameObject M_cylinderGlassAnswer;
    public GameObject M_cylinderGlassWrong;
    public GameObject M_cylinderGlassNoNeed1;
    public GameObject M_cylinderGlassNoNeed2;

    public GameObject M_drugInBeaker1;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Beaker1, sniffButton_M_Beaker1, biteButton_M_Beaker1,
        pressButton_M_Beaker1, eatButton_M_Beaker1, eatDisableButton_M_Beaker1;

    /*ObjData*/
    ObjData Beaker1Data_M;
    public ObjectData Beaker1ObjData_M;
    public ObjectData AnswerMeteorForBeaker1Data;
    public ObjectData RubberForBeaker1Data_M;

    public ObjectData cylinderGlassAnswerData_M;
    public ObjectData cylinderGlassWrongData_M;
    public ObjectData cylinderGlassNoNeed1Data_M;
    public ObjectData cylinderGlassNoNeed2Data_M;

    public ObjectData drugInBeaker1Data_M;

    /*Outline*/
    Outline Beaker1Outline_M;
    Outline AnswerMeteorForBeakerOutline_M;

   /*��Ŀ �� �ٲٴ� �ڵ�*/
   MeshRenderer ChangeBeaker1;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    AudioSource Beaker_Hit_Sound;
    public AudioClip Beaker_Audio;


    /*Collider*/

    BoxCollider Beaker1_Collider;
    BoxCollider Beaker2_Collider;

    BoxCollider cylinderGlassAnswer_Collider;
    BoxCollider cylinderGlassWrong_Collider;
    BoxCollider cylinderGlassNoNeed1_Collider;
    BoxCollider cylinderGlassNoNeed2_Collider;


    /*Ÿ�̸�*/
    public InGameTime inGameTime;

    public bool IsPretendDeadFail1 = false; //���� �ð� ���� �ȿ� ���� ����
    public bool canTpretendDead1 = false;
    public bool StartBlack = false;
    public bool StartOnlyOne = false;
    public bool startTimer = false;
    public bool IsDeath = false;
    public int i = 0;
    PortableObjectData workRoomData;
    PlayerEquipment equipment;
    GameObject portableGroup;


    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;

        Beaker_Hit_Sound = GetComponent<AudioSource>();

        dialogManager = dialog_CS.GetComponent<DialogManager>();

        //�� �ٲٴ� �ڵ�
        ChangeBeaker1 = M_drugInBeaker1.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker1Data_M = GetComponent<ObjData>();
        /*Outline*/
        Beaker1Outline_M = GetComponent<Outline>();
        AnswerMeteorForBeakerOutline_M = M_AnswerMeteorForBeaker.GetComponent<Outline>();

        /*Collider*/
        Beaker1_Collider = GetComponent<BoxCollider>();
        Beaker2_Collider = M_HiBeaker2.GetComponent<BoxCollider>();

        cylinderGlassAnswer_Collider = M_cylinderGlassAnswer.GetComponent<BoxCollider>();
        cylinderGlassWrong_Collider = M_cylinderGlassWrong.GetComponent<BoxCollider>();
        cylinderGlassNoNeed1_Collider = M_cylinderGlassNoNeed1.GetComponent<BoxCollider>();
        cylinderGlassNoNeed2_Collider = M_cylinderGlassNoNeed2.GetComponent<BoxCollider>();


        /*��ư ����*/
        barkButton_M_Beaker1 = Beaker1Data_M.BarkButton;
        barkButton_M_Beaker1.onClick.AddListener(OnBark);

        sniffButton_M_Beaker1 = Beaker1Data_M.SniffButton;
        sniffButton_M_Beaker1.onClick.AddListener(OnSniff);

        biteButton_M_Beaker1 = Beaker1Data_M.BiteButton;
        biteButton_M_Beaker1.onClick.AddListener(OnBite);

        pressButton_M_Beaker1 = Beaker1Data_M.PushOrPressButton;
        pressButton_M_Beaker1.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker1 = Beaker1Data_M.CenterButton1;
        eatButton_M_Beaker1.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker1 = Beaker1Data_M.CenterDisableButton1;


        Beaker1ObjData_M.IsCenterButtonDisabled = true;
    }

/*    void FakeAI1()
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

        Beaker1_Collider.enabled = false;
        Beaker2_Collider.enabled = false;

        cylinderGlassAnswer_Collider.enabled = false;
        cylinderGlassWrong_Collider.enabled = false;
        cylinderGlassNoNeed1_Collider.enabled = false;
        cylinderGlassNoNeed2_Collider.enabled = false;

    }*/

    void Update()
    {
        //if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        //{
        //    //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
        //    //answerMeteor_MB.SetActive(false);
        //    AnswerMeteorForBeaker1Data.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
        //    AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

        //    //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
        //    Beaker1ObjData_M.IsCenterButtonDisabled = false;

        //    //���� ���Ѵ�.
        //    ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

        //    M_AnswerMeteorForBeaker.SetActive(false);
        //    // ������ ������������ ���׿����̸� �ȵ�
        //    workRoomData.IsObjectActiveList[28] = false;
        //}

/*        if(StartBlack == true && StartOnlyOne == false)
        {
            StartCoroutine(SuddenDeath());
            StartOnlyOne = true;

        }*/


/*        if (IsPretendDeadFail1 == true && canTpretendDead1 == false && !GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("�ð� �ȿ� ���� Ǯ�� ����");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTpretendDead1 = true;
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
        }*/

    }

    void DisableButton()
    {
        barkButton_M_Beaker1.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker1.transform.gameObject.SetActive(false);
        biteButton_M_Beaker1.transform.gameObject.SetActive(false);
        pressButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker1.transform.gameObject.SetActive(false);
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

        /*������ ���� ���� ��� ��Ŀ 1�� �ִ´ٸ�*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ AnswerMeteorForBeaker1Data.IsBite)
        {
            Beaker_Hit_Sound.clip = Beaker_Audio;
            Beaker_Hit_Sound.Play();

            M_AnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_AnswerMeteorForBeaker.transform.parent = null;

            //��� ��Ŀ ������ �̵��Ѵ�.
            M_AnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 1.5762f, 683.427f); //��ġ ��
            M_AnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

            // ���� ���� �ʱ�ȭ
            equipment.biteObjectName = "";
            // �ٽ� ���ͺ� �־���
            M_AnswerMeteorForBeaker.transform.parent = portableGroup.transform;

            GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // ������� �־����� Ȯ��
            if (GameManager.gameManager._gameData.IsAnswerDrugInBeaker1_M_C2)
            {
                M_drugInBeaker1.SetActive(true);
                Debug.Log("���� ����Ǿ����ϴ�.");
                //ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

                GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
                GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
                GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
                GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
                //answerMeteor_MB.SetActive(false);
                AnswerMeteorForBeaker1Data.IsNotInteractable = true;
                AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

                //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
                Beaker1ObjData_M.IsCenterButtonDisabled = false;

                //���� ���Ѵ�.
                ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

                MeshRenderer meteoRenderer = M_AnswerMeteorForBeaker.GetComponent<MeshRenderer>();
                meteoRenderer.enabled = false;
                M_AnswerMeteorForBeaker.SetActive(false);
                // ������ ������������ ���׿����̸� �ȵ�
                workRoomData.IsObjectActiveList[28] = false;


                //�߰��� �κ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                //�Ǹ��� ���ڸ���
                M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                M_cylinderGlassAnswer.transform.parent = null;
                M_cylinderGlassAnswer.transform.position = new Vector3(-247.277f, 1.39397f, 683.715f); //��ġ ��
                M_cylinderGlassAnswer.transform.rotation = Quaternion.Euler(0, 0, 0); //�����̼� ��

                // ���� ���� �ʱ�ȭ
                equipment.biteObjectName = "";
                // �ٽ� ���ͺ� �־���
                M_cylinderGlassAnswer.transform.parent = portableGroup.transform;


                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }

        //���� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker1.SetActive(true);
            // ������ ������������ ��@@@@@@@@@@@@@@@@@

            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;

            GameManager.gameManager._gameData.IsAnswerDrugInBeaker1_M_C2 = true;

            //�߰��� �κ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //�Ǹ��� ���ڸ���
            M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_cylinderGlassAnswer.transform.parent = null;
            M_cylinderGlassAnswer.transform.position = new Vector3(-247.277f, 1.39397f, 683.715f); //��ġ ��
            M_cylinderGlassAnswer.transform.rotation = Quaternion.Euler(0, 0, 0); //�����̼� ��

            // ���� ���� �ʱ�ȭ
            equipment.biteObjectName = "";
            // �ٽ� ���ͺ� �־���
            M_cylinderGlassAnswer.transform.parent = portableGroup.transform;

            // ������ ��Ŀ�� ���������
            if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2)
            {
                //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
                //answerMeteor_MB.SetActive(false);
                AnswerMeteorForBeaker1Data.IsNotInteractable = true;
                AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

                //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
                Beaker1ObjData_M.IsCenterButtonDisabled = false;

                //���� ���Ѵ�.
                ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

                MeshRenderer meteoRenderer = M_AnswerMeteorForBeaker.GetComponent<MeshRenderer>();
                meteoRenderer.enabled = false;
                // ������ ������������ ���׿����̸� �ȵ�
                workRoomData.IsObjectActiveList[28] = false;

                M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                M_cylinderGlassAnswer.transform.parent = null;

                // ���� ���� �ʱ�ȭ
                equipment.biteObjectName = "";
                // �ٽ� ���ͺ� �־���
                M_cylinderGlassAnswer.transform.parent = portableGroup.transform;
                M_cylinderGlassAnswer.SetActive(false);
            }
        }

        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("�߸��� ���� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // ������ ������������ ��@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //�߰��� �κ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //�Ǹ��� ���ڸ���
            M_cylinderGlassWrong.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_cylinderGlassWrong.transform.parent = null;
            M_cylinderGlassWrong.transform.position = new Vector3(-247.277f, 1.39397f, 683.438f); //��ġ ��
            M_cylinderGlassWrong.transform.rotation = Quaternion.Euler(0, 0, 0); //�����̼� ��

            // ���� ���� �ʱ�ȭ
            equipment.biteObjectName = "";
            // �ٽ� ���ͺ� �־���
            M_cylinderGlassWrong.transform.parent = portableGroup.transform;

            //// ���� ���� �ʱ�ȭ
            //equipment.biteObjectName = "";
            //// �ٽ� ���ͺ� �־���
            //M_cylinderGlassWrong.transform.parent = portableGroup.transform;
            //M_cylinderGlassWrong.SetActive(false);
        }

        //�ʿ� ���� ��1�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // ������ ������������ ��@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //�߰��� �κ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //�Ǹ��� ���ڸ���
            M_cylinderGlassNoNeed1.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_cylinderGlassNoNeed1.transform.parent = null;
            M_cylinderGlassNoNeed1.transform.position = new Vector3(-247.277f, 1.39397f, 684.2311f); //��ġ ��
            M_cylinderGlassNoNeed1.transform.rotation = Quaternion.Euler(0, 0, 0); //�����̼� ��

            // ���� ���� �ʱ�ȭ
            equipment.biteObjectName = "";
            // �ٽ� ���ͺ� �־���
            M_cylinderGlassNoNeed1.transform.parent = portableGroup.transform;

            //M_cylinderGlassNoNeed1.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            //M_cylinderGlassNoNeed1.transform.parent = null;

            //// ���� ���� �ʱ�ȭ
            //equipment.biteObjectName = "";
            //// �ٽ� ���ͺ� �־���
            //M_cylinderGlassNoNeed1.transform.parent = portableGroup.transform;
            //M_cylinderGlassNoNeed1.SetActive(false);
        }

        //�ʿ� ���� ��2�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��2�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // ������ ������������ ��@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;

            //�߰��� �κ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //�Ǹ��� ���ڸ���
            M_cylinderGlassNoNeed2.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_cylinderGlassNoNeed2.transform.parent = null;
            M_cylinderGlassNoNeed2.transform.position = new Vector3(-247.277f, 1.39397f, 683.9581f); //��ġ ��
            M_cylinderGlassNoNeed2.transform.rotation = Quaternion.Euler(0, 0, 0); //�����̼� ��

            // ���� ���� �ʱ�ȭ
            equipment.biteObjectName = "";
            // �ٽ� ���ͺ� �־���
            M_cylinderGlassNoNeed2.transform.parent = portableGroup.transform;


            //M_cylinderGlassNoNeed2.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            //M_cylinderGlassNoNeed2.transform.parent = null;

            //// ���� ���� �ʱ�ȭ
            //equipment.biteObjectName = "";
            //// �ٽ� ���ͺ� �־���
            //M_cylinderGlassNoNeed2.transform.parent = portableGroup.transform;
            //M_cylinderGlassNoNeed2.SetActive(false);
        }
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    //���� ��! �ϼ��� ���� �Դ´ٸ�?!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /*1. ��ư� ������ �Դ´�. 2. ��������. 3.AI�� ȥ����. 4. ������ ȭ���� ���´�. 5. ������ ȭ���� ���´�. 6. Ÿ�̸Ӱ� ���۵ȴ�.*/


    public void OnEat()
    {
        DisableButton();
        //1. ��ư� ������ �Դ´�-> ���ķ� M_BeakerAfter �ڵ��
        InteractionButtonController.interactionButtonController.playerEat();
        M_drugInBeaker1.SetActive(false);
        Beaker1ObjData_M.IsEaten = false;

        GameManager.gameManager._gameData.IsDrinkBeaker_M_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ��Ŀ �Ⱥ��̰�
        gameObject.GetComponent<BoxCollider>().enabled =false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(EatAfter());
        StartCoroutine(SuddenDeath());
        StartCoroutine(End());

    }

    IEnumerator EatAfter()
    {
        yield return new WaitForSeconds(3f);
        //3.AI�� ȥ����.
        InteractionButtonController.interactionButtonController.PlayerDie();
        Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
        DonTClick.SetActive(true);
        /*��ư� ȥ�ڼ� �ȿ����̰�*/
        PlayerScripts.playerscripts.IsBored = true;
        StartBlack = true;
        StartCoroutine(realFakeAI1());
        //StartCoroutine(WaitFor40());
    }
    IEnumerator realFakeAI1()
    {
        if(!StartBlack)
        {
            yield return null;
        }
        else
        {
            //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

            GameManager.gameManager._gameData.IsCompletePretendDead = true;
            GameManager.gameManager._gameData.IsStartOrbitChange = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            MissionGenerator.missionGenerator.DeleteNewMission(11);
            StartCoroutine(Delay2Sec());
 

            //StartCoroutine(SuddenDeath());
            //startTimer = true;
            //StartCoroutine(WaitFor40());
        }
    }

    IEnumerator Delay2Sec()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(12);
    }

    IEnumerator WaitFor40()
    {
        if(!startTimer)
        {
            yield return new WaitForSeconds(60f);
        }
        else
        {
            IsDeath = true;
            StartCoroutine(SuddenDeath());
        }
    }

    IEnumerator SuddenDeath()
    {
        yield return new WaitForSeconds(53f);
        Debug.Log("��ƴ� �׾���");
        StartScreen.SetActive(true);



        //4.������ ȭ���� ���´�.
        //5. ������ ȭ���� ���´�.

        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();
        inGameTime.IsBeakerEatAfterStart = true;
        StartCoroutine(End());

    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Ÿ�̸� ����");

        StartScreen.SetActive(false);
        DonTClick.SetActive(false);
        //EndScreen.SetActive(false);
        inGameTime.IsAIAwake = false;
        /*��� �ٽ� �����̰�*/
        PlayerScripts.playerscripts.IsBored = false;

        //Ÿ�̸� ���� 5��
        TimerManager.timerManager.TimerStart(300);
    }

    /* void EatAfter()
     {
         InteractionButtonController.interactionButtonController.PlayerDie();

         Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");

         StartBlack = true;

         //������� �ȵ�@@@@@@@@

         StartCoroutine(SuddenDeath());

         //Invoke("SuddenDeath", 3);
     }

     IEnumerator SuddenDeath()
     {

         yield return new WaitForSeconds(3f);
         Debug.Log("��ƴ� �׾���");

         //5. ������ ȭ���� ���´�.
         StartScreen.SetActive(false);
         EndScreen.SetActive(true);

         InteractionButtonController.interactionButtonController.PlayerAlive();


         Invoke("End",3f);

     }

     void End()
     {
         Debug.Log("Ÿ�̸� ����");

         EndScreen.SetActive(false);

         //Ÿ�̸� ���� 3��
         TimerManager.timerManager.TimerStart(60);
         Invoke("PretendFailCheck", 60f);
     }

 *//*    IEnumerator PreteadTimer1()
     {

         yield return new WaitForSeconds(40f);

         //Ÿ�̸� ���� 3��
         TimerManager.timerManager.TimerStart(8);
         Invoke("PretendFailCheck", 8f);

     }*//*

     void PretendFailCheck()
     {
         IsPretendDeadFail1 = true;
     }

     IEnumerator realFakeAI1()
     {

         yield return new WaitForSeconds(5f);
         Debug.Log("AI�� �� ���Ѵ�.");

         //4.������ ȭ���� ���´�.
         StartScreen.SetActive(true);

         //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
         dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

         GameManager.gameManager._gameData.IsCompletePretendDead = true;
         GameManager.gameManager._gameData.IsStartOrbitChange = true;
         GameManager.gameManager._gameData.ActiveMissionList[11] = false;
         GameManager.gameManager._gameData.ActiveMissionList[12] = true;
         MissionGenerator.missionGenerator.ActivateMissionList();
         SaveSystem.Save(GameManager.gameManager._gameData, "save_001");


         // ����ô�ϱ� �ӹ�����Ʈ �Ϸ� ����������������������������������������������������������������������

         Beaker1_Collider.enabled = false;
         Beaker2_Collider.enabled = false;

         cylinderGlassAnswer_Collider.enabled = false;
         cylinderGlassWrong_Collider.enabled = false;
         cylinderGlassNoNeed1_Collider.enabled = false;
         cylinderGlassNoNeed2_Collider.enabled = false;

         *//*Ÿ�̸� ����*//*
         //StartCoroutine(PreteadTimer1());


     }*/


    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
