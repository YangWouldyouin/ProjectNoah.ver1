using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_FarmButton : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject Pot1;
    public GameObject Pot2;
    public GameObject Pot3;
    public GameObject T_IsGrownHealthy1;
    public GameObject T_IsGrownHealthy2;
    public GameObject T_IsGrownHealthy3;
    public GameObject T_IsGrownHealthy4;
    public GameObject T_IsGrownHealthy5;
    public GameObject T_IsGrownHealthy6;
    public GameObject T_IsGrownHealthy7;
    public GameObject T_IsGrownHealthy8;
    public GameObject T_IsGrownHealthy9;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_FarmButton, sniffButton_T_FarmButton, biteButton_T_FarmButton, pressButton_T_FarmButton, noCenterButton_T_FarmButton;

    /*ObjData*/
    ObjData FarmButtonData_T;


    /*Collider*/
    BoxCollider Pot1_Collider;
    BoxCollider Pot2_Collider;
    BoxCollider Pot3_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        Pot1_Collider = Pot1.GetComponent<BoxCollider>();
        Pot2_Collider = Pot2.GetComponent<BoxCollider>();
        Pot3_Collider = Pot3.GetComponent<BoxCollider>();

        FarmButtonData_T = GetComponent<ObjData>();

        barkButton_T_FarmButton = FarmButtonData_T.BarkButton;
        barkButton_T_FarmButton.onClick.AddListener(OnBark);

        sniffButton_T_FarmButton = FarmButtonData_T.SniffButton;
        sniffButton_T_FarmButton.onClick.AddListener(OnSniff);

        biteButton_T_FarmButton = FarmButtonData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_FarmButton = FarmButtonData_T.PushOrPressButton;
        pressButton_T_FarmButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_FarmButton = FarmButtonData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_FarmButton.transform.gameObject.SetActive(false);
        sniffButton_T_FarmButton.transform.gameObject.SetActive(false);
        biteButton_T_FarmButton.transform.gameObject.SetActive(false);
        pressButton_T_FarmButton.transform.gameObject.SetActive(false);
        noCenterButton_T_FarmButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //FarmButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        //FarmButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //FarmButtonData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        /*항상 pot 순서대로  덜자란 고구마를 심고, 상한 고구마를 심고, 성숙한 고구마를 심고 && 스마트팜 관리 기계 버튼을 누른다면*/

        /*Pot1*/
        if (GameManager.gameManager._gameData.Pot1InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
            Invoke("AppearSweetPotato1", 60f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.
        }

        if(GameManager.gameManager._gameData.Pot1InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(GameManager.gameManager._gameData.Pot1InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }


        /*Pot2*/
        if(GameManager.gameManager._gameData.Pot2InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato2", 60f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.
        }

        if(GameManager.gameManager._gameData.Pot2InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(GameManager.gameManager._gameData.Pot2InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        /*Pot3*/
        if(GameManager.gameManager._gameData.Pot3InPotato)
        {
            //A-6 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));

            Invoke("AppearSweetPotato3", 60f); //리얼 타임으로 5분 뒤에 미리 땅에 성장 시킨 고구마들이 켜져서 보이게 된다.
        }

        if(GameManager.gameManager._gameData.Pot3InBadPotato)
        {
            //A-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }

        if(GameManager.gameManager._gameData.Pot3InHealthyPotato)
        {
            //A-6대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(18));
        }
    }

    void AppearSweetPotato1()
    {
        T_IsGrownHealthy1.SetActive(true);
        T_IsGrownHealthy2.SetActive(true);
        T_IsGrownHealthy3.SetActive(true);

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot1_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*/
        GameManager.gameManager._gameData.IsCanSeePotato1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
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

    void AppearSweetPotato3()
    {
        T_IsGrownHealthy7.SetActive(true);
        T_IsGrownHealthy8.SetActive(true);
        T_IsGrownHealthy9.SetActive(true);

        //A-7 알림 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(19));

        /*고구마 먹는 거 방해 안되게 + 이미 한 번 심은 땅에는 다시 못 심게*/
        Pot3_Collider.enabled = false;

        /*고구마가 나타난 상태를 저장한다.*/
        GameManager.gameManager._gameData.IsCanSeePotato3 = true;
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
