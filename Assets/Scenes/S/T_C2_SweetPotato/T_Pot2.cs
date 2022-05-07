using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot2 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_InUnGrownSweetPotato2;
    public GameObject T_InHealthySweetPotato2;
    public GameObject T_InBadSweetPotato2;
    public GameObject T_InSuperDrug2;
    public GameObject T_IsGrownHealthy4;
    public GameObject T_IsGrownHealthy5;
    public GameObject T_IsGrownHealthy6;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_Pot2, sniffButton_T_Pot2, biteButton_T_Pot2, pressButton_T_Pot2, noCenterButton_T_Pot2;

    /*ObjData*/
    ObjData Pot2Data_T;
    public ObjectData InHealthySweetPotato2Data_T;
    public ObjectData InBadSweetPotato2Data_T;
    public ObjectData InSuperDrug2Data_T;
    public ObjectData IsFarmButton2Data_T;
    public ObjectData InUnGrownSweetPotato2Data_T;

    /*Collider*/
    BoxCollider Pot2_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot2Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot2_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot2 = Pot2Data_T.BarkButton;
        barkButton_T_Pot2.onClick.AddListener(OnBark);

        sniffButton_T_Pot2 = Pot2Data_T.SniffButton;
        sniffButton_T_Pot2.onClick.AddListener(OnSniff);

        biteButton_T_Pot2 = Pot2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot2 = Pot2Data_T.PushOrPressButton;
        pressButton_T_Pot2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot2 = Pot2Data_T.CenterButton1;
    }

    void Update()
    {
        /*덜자란 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if (GameManager.gameManager._gameData.Pot2InPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato2", 300f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.
        }

        /*상한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if (GameManager.gameManager._gameData.Pot2InBadPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*성숙한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if (GameManager.gameManager._gameData.Pot2InHealthyPotato && IsFarmButton2Data_T.IsPushOrPress)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
    }

    void DisableButton()
    {
        barkButton_T_Pot2.transform.gameObject.SetActive(false);
        sniffButton_T_Pot2.transform.gameObject.SetActive(false);
        biteButton_T_Pot2.transform.gameObject.SetActive(false);
        pressButton_T_Pot2.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot2.transform.gameObject.SetActive(false);
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

        InteractionButtonController.interactionButtonController.playerPressHand();

        /*덜자란 고구마를 심으면 -> 고구마가 자란다.*/
        if (InUnGrownSweetPotato2Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown2", 2f);
            GameManager.gameManager._gameData.Pot2InPotato = true; // 심고 5분 다 채우기 전에 끌까봐 중간저장
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*상한 고구마를 심으면 -> 고구마만 사라지고 아무런 변화가 없다.*/
        if (InBadSweetPotato2Data_T.IsBite)
        {
            Invoke("BadPotatoBye2", 2f);

        }

        /*건강한 고구마를 심고 슈퍼파워 영양제를 뿌리면 새로운 생태계 구축 엔딩*/
        if (InHealthySweetPotato2Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye2", 2f);
        }

        if (GameManager.gameManager._gameData.Pot2InHealthyPotato && InSuperDrug2Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug2", 2f);
        }
    }

    void CanTSeeUnGrown2()
    {
        T_InUnGrownSweetPotato2.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void AppearSweetPotato2()
    {
        T_IsGrownHealthy4.SetActive(true);
        T_IsGrownHealthy5.SetActive(true);
        T_IsGrownHealthy6.SetActive(true);

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot2_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*/
        GameManager.gameManager._gameData.IsCanSeePotato2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void BadPotatoBye2()
    {
        T_InBadSweetPotato2.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InBadPotato = true; // 상한 고구마 사라진거 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye2()
    {
        T_InHealthySweetPotato2.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot2InHealthyPotato = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug2()
    {
        T_InSuperDrug2.SetActive(false);
        Debug.Log("생태계 구축 엔딩");
        GameManager.gameManager._gameData.IsMakeForest = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnBite()
    {
       
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
