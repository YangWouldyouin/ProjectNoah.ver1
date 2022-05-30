using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadFood3 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogBadFood3, sniffButton_DogBadFood3, biteButton_DogBadFood3,
        pressButton_DogBadFood3, eatButton_DogBadFood3;

    /*ObjData*/
    ObjData DogBadFood3Data;


    void Start()
    {
        /*ObjData*/
        DogBadFood3Data = GetComponent<ObjData>();

        barkButton_DogBadFood3 = DogBadFood3Data.BarkButton;
        barkButton_DogBadFood3.onClick.AddListener(OnBark);

        sniffButton_DogBadFood3 = DogBadFood3Data.SniffButton;
        sniffButton_DogBadFood3.onClick.AddListener(OnSniff);

        biteButton_DogBadFood3 = DogBadFood3Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogBadFood3 = DogBadFood3Data.PushOrPressButton;
        pressButton_DogBadFood3.onClick.AddListener(OnPushOrPress);

        eatButton_DogBadFood3 = DogBadFood3Data.CenterButton1;
        eatButton_DogBadFood3.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogBadFood3.transform.gameObject.SetActive(false);
        sniffButton_DogBadFood3.transform.gameObject.SetActive(false);
        biteButton_DogBadFood3.transform.gameObject.SetActive(false);
        pressButton_DogBadFood3.transform.gameObject.SetActive(false);
        eatButton_DogBadFood3.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.BadFoodEat[1] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //스탯 감소
        NoahStatController.noahStatController.DecreaseStatBar(3);
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
