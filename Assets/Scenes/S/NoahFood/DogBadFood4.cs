using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBadFood4 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogBadFood4, sniffButton_DogBadFood4, biteButton_DogBadFood4,
        pressButton_DogBadFood4, eatButton_DogBadFood4;

    /*ObjData*/
    ObjData DogBadFood4Data;

    PortableObjectData workRoomData;
    PortableObjectData livingRoomData;
    PortableObjectData engineRoomData;
    PortableObjectData controlRoomData;

    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        livingRoomData = BaseCanvas._baseCanvas.livingRoomData;
        engineRoomData = BaseCanvas._baseCanvas.engineRoomData;
        controlRoomData = BaseCanvas._baseCanvas.controlRoomData;

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

        //스탯 감소
        NoahStatController.noahStatController.DecreaseStat(1);
        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[57] = false;
        livingRoomData.IsObjectActiveList[57] = false;
        engineRoomData.IsObjectActiveList[57] = false;
        controlRoomData.IsObjectActiveList[57] = false;
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
