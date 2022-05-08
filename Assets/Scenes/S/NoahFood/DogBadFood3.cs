using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadFood2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogBadFood2, sniffButton_DogBadFood2, biteButton_DogBadFood2,
        pressButton_DogBadFood2, eatButton_DogBadFood2;

    /*ObjData*/
    ObjData DogBadFood2Data;


    void Start()
    {
        /*ObjData*/
        DogBadFood2Data = GetComponent<ObjData>();

        barkButton_DogBadFood2 = DogBadFood2Data.BarkButton;
        barkButton_DogBadFood2.onClick.AddListener(OnBark);

        sniffButton_DogBadFood2 = DogBadFood2Data.SniffButton;
        sniffButton_DogBadFood2.onClick.AddListener(OnSniff);

        biteButton_DogBadFood2 = DogBadFood2Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogBadFood2 = DogBadFood2Data.PushOrPressButton;
        pressButton_DogBadFood2.onClick.AddListener(OnPushOrPress);

        eatButton_DogBadFood2 = DogBadFood2Data.CenterButton1;
        eatButton_DogBadFood2.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogBadFood2.transform.gameObject.SetActive(false);
        sniffButton_DogBadFood2.transform.gameObject.SetActive(false);
        biteButton_DogBadFood2.transform.gameObject.SetActive(false);
        pressButton_DogBadFood2.transform.gameObject.SetActive(false);
        eatButton_DogBadFood2.transform.gameObject.SetActive(false);

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
