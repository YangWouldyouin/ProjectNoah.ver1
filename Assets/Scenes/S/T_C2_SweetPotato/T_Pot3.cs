using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot3 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_InUnGrownSweetPotato3;
    public GameObject T_InHealthySweetPotato3;
    public GameObject T_InBadSweetPotato3;
    public GameObject T_InSuperDrug3;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_Pot3, sniffButton_T_Pot3, biteButton_T_Pot3, pressButton_T_Pot3, noCenterButton_T_Pot3;

    /*ObjData*/
    ObjData Pot3Data_T;
    public ObjectData InHealthySweetPotato3Data_T;
    public ObjectData InBadSweetPotato3Data_T;
    public ObjectData InSuperDrug3Data_T;
    public ObjectData IsFarmButton3Data_T;
    public ObjectData InUnGrownSweetPotato3Data_T;


    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot3Data_T = GetComponent<ObjData>();


        barkButton_T_Pot3 = Pot3Data_T.BarkButton;
        barkButton_T_Pot3.onClick.AddListener(OnBark);

        sniffButton_T_Pot3 = Pot3Data_T.SniffButton;
        sniffButton_T_Pot3.onClick.AddListener(OnSniff);

        biteButton_T_Pot3 = Pot3Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot3 = Pot3Data_T.PushOrPressButton;
        pressButton_T_Pot3.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot3 = Pot3Data_T.CenterButton1;
    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_T_Pot3.transform.gameObject.SetActive(false);
        sniffButton_T_Pot3.transform.gameObject.SetActive(false);
        biteButton_T_Pot3.transform.gameObject.SetActive(false);
        pressButton_T_Pot3.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot3.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        Pot3Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Pot3Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        Pot3Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        /*덜자란 고구마를 심으면 -> 고구마가 자란다.*/
        if (InUnGrownSweetPotato3Data_T.IsBite)
        {
            Invoke("CanTSeeUnGrown3", 2f);
            GameManager.gameManager._gameData.Pot3InPotato = true; // 심고 5분 다 채우기 전에 끌까봐 중간저장
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /*상한 고구마를 심으면 -> 고구마만 사라지고 아무런 변화가 없다.*/
        if (InBadSweetPotato3Data_T.IsBite)
        {
            Invoke("BadPotatoBye3", 2f);

        }

        /*건강한 고구마를 심고 슈퍼파워 영양제를 뿌리면 새로운 생태계 구축 엔딩*/
        if (InHealthySweetPotato3Data_T.IsBite)
        {
            Invoke("HealthyPotatoBye3", 2f);
        }

        if (GameManager.gameManager._gameData.Pot3InHealthyPotato && InSuperDrug3Data_T.IsBite)
        {
            Invoke("CanTSeeSuperDrug3", 2f);
        }

    }

    void CanTSeeUnGrown3()
    {
        T_InUnGrownSweetPotato3.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));
    }

    void BadPotatoBye3()
    {
        T_InBadSweetPotato3.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InBadPotato = true; // 상한 고구마 사라진거 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    void HealthyPotatoBye3()
    {
        T_InHealthySweetPotato3.SetActive(false);
        //A-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(17));

        GameManager.gameManager._gameData.Pot3InHealthyPotato = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    void CanTSeeSuperDrug3()
    {
        T_InSuperDrug3.SetActive(false);
        Debug.Log("생태계 구축 엔딩");
        GameManager.gameManager._gameData.IsMakeForestEnd = true; // 엔딩으로 향하는 거기때문에 저장
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Pot3Data_T.IsPushOrPress = false;
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
