using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot1 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_InUnGrownSweetPotato1;
    public GameObject T_InHealthySweetPotato1;
    public GameObject T_InBadSweetPotato1;
    public GameObject T_InSuperDrug1;


    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_Pot1, sniffButton_T_Pot1, biteButton_T_Pot1, pressButton_T_Pot1, noCenterButton_T_Pot1;

    /*ObjData*/
    ObjData Pot1Data_T;
    public ObjectData realPot1Data_T;

    public ObjectData InHealthySweetPotato1Data_T;
    public ObjectData InBadSweetPotato1Data_T;
    public ObjectData InSuperDrug1Data_T;
    public ObjectData IsFarmButton1Data_T;
    public ObjectData InUnGrownSweetPotato1Data_T;

    /*아웃라인*/
    public Outline realPot1Outline_T;

    /*Collider*/
    BoxCollider Pot1_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    PlayerEquipment playerEquipment; // 물기 정보 데이터를 초기화하기 위함
    PortableObjectData portableData; // 이후 워크룸에서 안보이게 하기 위해

    void Start()
    {
        playerEquipment = BaseCanvas._baseCanvas.equipment;
        portableData = BaseCanvas._baseCanvas.workRoomData;

        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        Pot1Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot1_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot1 = Pot1Data_T.BarkButton;
        barkButton_T_Pot1.onClick.AddListener(OnBark);

        sniffButton_T_Pot1 = Pot1Data_T.SniffButton;
        sniffButton_T_Pot1.onClick.AddListener(OnSniff);

        biteButton_T_Pot1 = Pot1Data_T.BiteButton;
        biteButton_T_Pot1.onClick.AddListener(OnBite);

        pressButton_T_Pot1 = Pot1Data_T.PushOrPressButton;
        pressButton_T_Pot1.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot1 = Pot1Data_T.CenterButton1;

        /*선언 시작*/
        realPot1Data_T.IsNotInteractable = true;
        realPot1Outline_T.OutlineWidth = 0;
    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_T_Pot1.transform.gameObject.SetActive(false);
        sniffButton_T_Pot1.transform.gameObject.SetActive(false);
        biteButton_T_Pot1.transform.gameObject.SetActive(false);
        pressButton_T_Pot1.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        /*덜자란 고구마를 심으면 -> 고구마가 자란다.*/
        if(InUnGrownSweetPotato1Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown1", 2f);
            GameManager.gameManager._gameData.Pot1InPotato = true; // 심고 5분 다 채우기 전에 끌까봐 중간저장
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*상한 고구마를 심으면 -> 고구마만 사라지고 아무런 변화가 없다.*/
        if (InBadSweetPotato1Data_T.IsBite)
        {
            Invoke("BadPotatoBye1", 2f);
        }

        /*건강한 고구마를 심고 슈퍼파워 영양제를 뿌리면 새로운 생태계 구축 엔딩*/
        if(InHealthySweetPotato1Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye1", 2f);
        }

        if(GameManager.gameManager._gameData.Pot1InHealthyPotato && InSuperDrug1Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug1", 2f);
        }
    }

    void CanTSeeUnGrown1()
    {
        // 강제로 물기 취소했기 때문에 물기 관련 변수 직접 초기화
        playerEquipment.biteObjectName = "";
        InUnGrownSweetPotato1Data_T.IsBite = false;

        // 앞으로 안보이게 끄기
        T_InUnGrownSweetPotato1.SetActive(false);

        // 이제 업무공간에 덜자란 고구마 없으므로 직접 false로 변경
        portableData.IsObjectActiveList[14] = false;

        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

    }


    void BadPotatoBye1()
    {
        // 강제로 물기 취소했기 때문에 물기 관련 변수 직접 초기화
        playerEquipment.biteObjectName = "";
        InBadSweetPotato1Data_T.IsBite = false;

        T_InBadSweetPotato1.SetActive(false);

        // 이제 업무공간에 안건강한 고구마 없으므로  직접 false로 변경
        portableData.IsObjectActiveList[12] = false;

        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot1InBadPotato = true; // 상한 고구마 사라진거 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye1()
    {
        // 강제로 물기 취소했기 때문에 물기 관련 변수 직접 초기화
        playerEquipment.biteObjectName = "";
        InHealthySweetPotato1Data_T.IsBite = false;

        T_InHealthySweetPotato1.SetActive(false);

        // 이제 업무공간에 고구마 없으므로  직접 false로 변경
        portableData.IsObjectActiveList[13] = false;

        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot1InHealthyPotato = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug1()
    {
        // 강제로 물기 취소했기 때문에 물기 관련 변수 직접 초기화
        playerEquipment.biteObjectName = "";
        InSuperDrug1Data_T.IsBite = false;

        T_InSuperDrug1.SetActive(false);

        // 이제 업무공간에 슈퍼약  없으므로  직접 false로 변경
        portableData.IsObjectActiveList[11] = false;

        Debug.Log("생태계 구축 엔딩");
        GameManager.gameManager._gameData.IsMakeForestEnd = true; // 엔딩으로 향하는 거기때문에 저장
        GameManager.gameManager._gameData.ActiveMissionList[21] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 영양제 투약 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
