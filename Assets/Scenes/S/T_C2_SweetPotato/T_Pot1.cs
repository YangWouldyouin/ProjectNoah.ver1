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
    public GameObject T_IsGrownHealthy1;
    public GameObject T_IsGrownHealthy2;
    public GameObject T_IsGrownHealthy3;


    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_Pot1, sniffButton_T_Pot1, biteButton_T_Pot1, pressButton_T_Pot1, noCenterButton_T_Pot1;

    /*ObjData*/
    ObjData Pot1Data_T;
    public ObjectData InHealthySweetPotato1Data_T;
    public ObjectData InBadSweetPotato1Data_T;
    public ObjectData InSuperDrug1Data_T;
    public ObjectData IsFarmButton1Data_T;
    public ObjectData InUnGrownSweetPotato1Data_T;

    /*아웃라인*/

    /*Collider*/
    BoxCollider Pot1_Collider;

    void Start()
    {
        /*ObjData*/
        Pot1Data_T = GetComponent<ObjData>();

        /*Collider*/
        Pot1_Collider = GetComponent<BoxCollider>();

        barkButton_T_Pot1 = Pot1Data_T.BarkButton;
        barkButton_T_Pot1.onClick.AddListener(OnBark);

        sniffButton_T_Pot1 = Pot1Data_T.SniffButton;
        sniffButton_T_Pot1.onClick.AddListener(OnSniff);

        biteButton_T_Pot1 = Pot1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot1 = Pot1Data_T.PushOrPressButton;
        pressButton_T_Pot1.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot1 = Pot1Data_T.CenterButton1;
    }

    void Update()
    {
        /*덜자란 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if(GameManager.gameManager._gameData.Pot1InPotato && IsFarmButton1Data_T.IsPushOrPress)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            Invoke("AppearSweetPotato1", 300f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.
        }

        /*상한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if (GameManager.gameManager._gameData.Pot1InBadPotato && IsFarmButton1Data_T.IsPushOrPress)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }

        /*성숙한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/
        if (GameManager.gameManager._gameData.Pot1InHealthyPotato && IsFarmButton1Data_T.IsPushOrPress)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }
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

        InteractionButtonController.interactionButtonController.playerPressHand();

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
        T_InUnGrownSweetPotato1.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
    }

    void AppearSweetPotato1()
    {
        T_IsGrownHealthy1.SetActive(true);
        T_IsGrownHealthy2.SetActive(true);
        T_IsGrownHealthy3.SetActive(true);

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot1_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*/
        GameManager.gameManager._gameData.IsCanSeePotato1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void BadPotatoBye1()
    {
        T_InBadSweetPotato1.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        GameManager.gameManager._gameData.Pot1InBadPotato = true; // 상한 고구마 사라진거 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye1()
    {
        T_InHealthySweetPotato1.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        GameManager.gameManager._gameData.Pot1InHealthyPotato = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug1()
    {
        T_InSuperDrug1.SetActive(false);
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
