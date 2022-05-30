using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogGoodFood4: MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogGoodFood4, sniffButton_DogGoodFood4, biteButton_DogGoodFood4,
        pressButton_DogGoodFood4, eatButton_DogGoodFood4;

    /*ObjData*/
    ObjData DogGoodFood4Data;


    void Start()
    {
        /*ObjData*/
        DogGoodFood4Data = GetComponent<ObjData>();

        barkButton_DogGoodFood4 = DogGoodFood4Data.BarkButton;
        barkButton_DogGoodFood4.onClick.AddListener(OnBark);

        sniffButton_DogGoodFood4 = DogGoodFood4Data.SniffButton;
        sniffButton_DogGoodFood4.onClick.AddListener(OnSniff);

        biteButton_DogGoodFood4 = DogGoodFood4Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogGoodFood4 = DogGoodFood4Data.PushOrPressButton;
        pressButton_DogGoodFood4.onClick.AddListener(OnPushOrPress);

        eatButton_DogGoodFood4 = DogGoodFood4Data.CenterButton1;
        eatButton_DogGoodFood4.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogGoodFood4.transform.gameObject.SetActive(false);
        sniffButton_DogGoodFood4.transform.gameObject.SetActive(false);
        biteButton_DogGoodFood4.transform.gameObject.SetActive(false);
        pressButton_DogGoodFood4.transform.gameObject.SetActive(false);
        eatButton_DogGoodFood4.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.GoodFoodEat[3] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //스탯 상승
        NoahStatController.noahStatController.IncreaseStatBar(1);
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
