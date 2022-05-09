using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadFood4 : MonoBehaviour, IInteraction
{
    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_DogBadFood4, sniffButton_DogBadFood4, biteButton_DogBadFood4,
        pressButton_DogBadFood4, eatButton_DogBadFood4;

    /*ObjData*/
    ObjData DogBadFood4Data;


    void Start()
    {
        /*ObjData*/
        DogBadFood4Data = GetComponent<ObjData>();

        barkButton_DogBadFood4 = DogBadFood4Data.BarkButton;
        barkButton_DogBadFood4.onClick.AddListener(OnBark);

        sniffButton_DogBadFood4 = DogBadFood4Data.SniffButton;
        sniffButton_DogBadFood4.onClick.AddListener(OnSniff);

        biteButton_DogBadFood4 = DogBadFood4Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogBadFood4 = DogBadFood4Data.PushOrPressButton;
        pressButton_DogBadFood4.onClick.AddListener(OnPushOrPress);

        eatButton_DogBadFood4 = DogBadFood4Data.CenterButton1;
        eatButton_DogBadFood4.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogBadFood4.transform.gameObject.SetActive(false);
        sniffButton_DogBadFood4.transform.gameObject.SetActive(false);
        biteButton_DogBadFood4.transform.gameObject.SetActive(false);
        pressButton_DogBadFood4.transform.gameObject.SetActive(false);
        eatButton_DogBadFood4.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.BadFoodEat[3] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //���� ����
        NoahStatController.noahStatController.DecreaseStatBar();
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
