using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogGoodFood3: MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogGoodFood3, sniffButton_DogGoodFood3, biteButton_DogGoodFood3,
        pressButton_DogGoodFood3, eatButton_DogGoodFood3;

    /*ObjData*/
    ObjData DogGoodFood3Data;

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
        DogGoodFood3Data = GetComponent<ObjData>();

        barkButton_DogGoodFood3 = DogGoodFood3Data.BarkButton;
        barkButton_DogGoodFood3.onClick.AddListener(OnBark);

        sniffButton_DogGoodFood3 = DogGoodFood3Data.SniffButton;
        sniffButton_DogGoodFood3.onClick.AddListener(OnSniff);

        biteButton_DogGoodFood3 = DogGoodFood3Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogGoodFood3 = DogGoodFood3Data.PushOrPressButton;
        pressButton_DogGoodFood3.onClick.AddListener(OnPushOrPress);

        eatButton_DogGoodFood3 = DogGoodFood3Data.CenterButton1;
        eatButton_DogGoodFood3.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogGoodFood3.transform.gameObject.SetActive(false);
        sniffButton_DogGoodFood3.transform.gameObject.SetActive(false);
        biteButton_DogGoodFood3.transform.gameObject.SetActive(false);
        pressButton_DogGoodFood3.transform.gameObject.SetActive(false);
        eatButton_DogGoodFood3.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.GoodFoodEat[2] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //스탯 상승
        NoahStatController.noahStatController.IncreaseStatBar(1);
        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[47] = false;
        livingRoomData.IsObjectActiveList[47] = false;
        engineRoomData.IsObjectActiveList[47] = false;
        controlRoomData.IsObjectActiveList[47] = false;
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
