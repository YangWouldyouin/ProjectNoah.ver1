using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeObj : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, smashButton, noCenterButton;

    public ObjectData strangeData;
    ObjData objData;

    public ParticleSystem smoke;
    public Outline playerLine;

    public DialogManager dialog;
    DialogManager dialogManager;

    [Header("<플레이어의 아웃라인을 관리함>")]
    public NoahOutlineController outlineController;
    NoahOutlineController outlineControl;

    [Header("<물기 강제 해제로 인해 셀프로 물기 초기화를 하기 위한 변수들>")]
    public GameObject portableGroup; // 다시 포터블 그룹의 자식으로 넣어주기 위함
    public PlayerEquipment playerEquipmentStrange; // 물기 정보 데이터를 초기화하기 위함
    [Header("<업무공간 내의 이동가능한 오브젝트 관리를 위한 변수>")]
    public PortableObjectData workRoomExtinguisherData;

    /*타이머*/
    public InGameTime inGameTime;

    public GameObject S_TimerBarFilled;
    public GameObject S_TimerBackground;
    public GameObject S_TimerText;

    public bool IsNoSeeFail1 = false; //제한 시간 내에 안에 퍼즐 실패
    public bool canTSee1 = false;

    void Start()
    {
        outlineControl = outlineController.GetComponent<NoahOutlineController>();
        dialogManager = dialog.GetComponent<DialogManager>();

        objData = GetComponent<ObjData>();

        barkButton = objData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = objData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = objData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        pressButton = objData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        smashButton = objData.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        noCenterButton = objData.CenterButton1;
    }


    void Update()
    {
        //strangeObjAfter 스크립트로 옮겨감
        /*if (IsNoSeeFail1 == true && canTSee1 == false && GameManager.gameManager._gameData.IsAIDown == false)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("시간 안에 퍼즐 풀기 실패");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTSee1 = true;
        }

        //타임 어택 성공시
        if (GameManager.gameManager._gameData.IsAIDown)
        {
            *//*타이머가 꺼진다*//*
            inGameTime.IsTimerStarted = false;

            *//*아웃라인이 꺼진다*//*
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.outlineTimer = 0;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            Debug.Log("노아의 굿엔딩 보기 가능해졌다!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //진짜 튜토리얼 중간 성공
        }*/
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        smashButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        GameManager.gameManager._gameData.IsFindStrangeObj = true;
        GameManager.gameManager._gameData.ActiveMissionList[27] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        //����Ʈ ��ư�� ��ũ��Ʈ �ֱ�
    }

    public void OnSmash()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        Invoke("ObjSmoke", 3f);

        InteractionButtonController.interactionButtonController.PlayerSmash2();

        StartCoroutine(DelayFor2Seconds());

        Destroy(smoke, 6f);

        GameManager.gameManager._gameData.IsKnowUsingSObj = true;
        GameManager.gameManager._gameData.ActiveMissionList[27] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //��ư� ������ �ʾ� ��Ȳ�ϴ� AI ���

        CameraController.cameraController.CancelObserve();
    }

    void ObjSmoke()
    {
        // 수상한 물건을 플레이어로부터 분리함
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;
        this.transform.parent = portableGroup.transform; // 플레이어로부터 분리한뒤 다시 포터블 그룹에 넣어줌

        // 강제로 물기 취소했기 때문에 물기 관련 변수 직접 초기화
        playerEquipmentStrange.biteObjectName = ""; 
        strangeData.IsBite = false;

        smoke.transform.localScale = new Vector3(1f, 1f, 1f);
        smoke.transform.position = gameObject.transform.position;
        smoke.Play();

        gameObject.SetActive(false);
        // 이제 업무공간에 수상한 물건이 없어졌으므로 직접 false로 변경
        workRoomExtinguisherData.IsObjectActiveList[10] = false;

        GameManager.gameManager._gameData.IsHide = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

/*        // 3분간 플레이어 아웃라인 활성화
        outlineControl.StartOutlineTime(10f);
        TimerManager.timerManager.TimerStart(10f);
        Invoke("FailStrangeObj", 10f);*/
    }

/*    void FailStrangeObj()
    {
        IsNoSeeFail1 = true;
    }*/

    IEnumerator DelayFor2Seconds()
    {
        // 수상한 물건 파괴하기 시 애니메이션이 나오고 나서 첫 대사를 나오게 하기 위해 1.5초 딜레이함
        // (이상하게 2초로 하면 대사 안나와서 걍 1.5초로 해야함)
        yield return new WaitForSeconds(1f);
        if (!GameManager.gameManager._gameData.IsFirstUsingStrangeObj)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(51));
            GameManager.gameManager._gameData.IsFirstUsingStrangeObj = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(53));
        }
    }

    //void CantHide()
    //{
    //    Debug.Log("이제 못 숨음");

    //    playerLine.OutlineWidth = 0f;

    //    GameManager.gameManager._gameData.IsHide = false;
    //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

    //    //Destroy(gameObject, 0.5f);

    //    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(52));
    //}
}
