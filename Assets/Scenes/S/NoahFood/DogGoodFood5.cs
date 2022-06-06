using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogGoodFood5: MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogGoodFood5, sniffButton_DogGoodFood5, biteButton_DogGoodFood5,
        pressButton_DogGoodFood5, eatButton_DogGoodFood5;

    /*ObjData*/
    ObjData DogGoodFood5Data;

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
        DogGoodFood5Data = GetComponent<ObjData>();

        barkButton_DogGoodFood5 = DogGoodFood5Data.BarkButton;
        barkButton_DogGoodFood5.onClick.AddListener(OnBark);

        sniffButton_DogGoodFood5 = DogGoodFood5Data.SniffButton;
        sniffButton_DogGoodFood5.onClick.AddListener(OnSniff);

        biteButton_DogGoodFood5 = DogGoodFood5Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogGoodFood5 = DogGoodFood5Data.PushOrPressButton;
        pressButton_DogGoodFood5.onClick.AddListener(OnPushOrPress);

        eatButton_DogGoodFood5 = DogGoodFood5Data.CenterButton1;
        eatButton_DogGoodFood5.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogGoodFood5.transform.gameObject.SetActive(false);
        sniffButton_DogGoodFood5.transform.gameObject.SetActive(false);
        biteButton_DogGoodFood5.transform.gameObject.SetActive(false);
        pressButton_DogGoodFood5.transform.gameObject.SetActive(false);
        eatButton_DogGoodFood5.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.GoodFoodEat[4] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //스탯 상승
        NoahStatController.noahStatController.IncreaseStat(1);
        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[56] = false;
        livingRoomData.IsObjectActiveList[56] = false;
        engineRoomData.IsObjectActiveList[56] = false;
        controlRoomData.IsObjectActiveList[56] = false;

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
