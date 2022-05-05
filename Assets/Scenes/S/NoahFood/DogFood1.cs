using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogGoodFood1: MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogFood1, sniffButton_DogFood1, biteButton_DogFood1,
        pressButton_DogFood1, eatButton_DogFood1;

    /*ObjData*/
    ObjData DogFood1Data_T;


    void Start()
    {
        /*ObjData*/
        DogFood1Data_T = GetComponent<ObjData>();

        barkButton_DogFood1 = DogFood1Data_T.BarkButton;
        barkButton_DogFood1.onClick.AddListener(OnBark);

        sniffButton_DogFood1 = DogFood1Data_T.SniffButton;
        sniffButton_DogFood1.onClick.AddListener(OnSniff);

        biteButton_DogFood1 = DogFood1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogFood1 = DogFood1Data_T.PushOrPressButton;
        pressButton_DogFood1.onClick.AddListener(OnPushOrPress);

        eatButton_DogFood1 = DogFood1Data_T.CenterButton1;
        eatButton_DogFood1.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogFood1.transform.gameObject.SetActive(false);
        sniffButton_DogFood1.transform.gameObject.SetActive(false);
        biteButton_DogFood1.transform.gameObject.SetActive(false);
        pressButton_DogFood1.transform.gameObject.SetActive(false);
        eatButton_DogFood1.transform.gameObject.SetActive(false);

    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

    }


    public void OnEat()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        GameManager.gameManager._gameData.FoodEat[0] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //스탯 상승
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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
