using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogGoodFood2: MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_DogGoodFood2, sniffButton_DogGoodFood2, biteButton_DogGoodFood2,
        pressButton_DogGoodFood2, eatButton_DogGoodFood2;

    /*ObjData*/
    ObjData DogGoodFood2Data;

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
        DogGoodFood2Data = GetComponent<ObjData>();

        barkButton_DogGoodFood2 = DogGoodFood2Data.BarkButton;
        barkButton_DogGoodFood2.onClick.AddListener(OnBark);

        sniffButton_DogGoodFood2 = DogGoodFood2Data.SniffButton;
        sniffButton_DogGoodFood2.onClick.AddListener(OnSniff);

        biteButton_DogGoodFood2 = DogGoodFood2Data.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_DogGoodFood2 = DogGoodFood2Data.PushOrPressButton;
        pressButton_DogGoodFood2.onClick.AddListener(OnPushOrPress);

        eatButton_DogGoodFood2 = DogGoodFood2Data.CenterButton1;
        eatButton_DogGoodFood2.onClick.AddListener(OnEat);
    }

    void DisableButton()
    {
        barkButton_DogGoodFood2.transform.gameObject.SetActive(false);
        sniffButton_DogGoodFood2.transform.gameObject.SetActive(false);
        biteButton_DogGoodFood2.transform.gameObject.SetActive(false);
        pressButton_DogGoodFood2.transform.gameObject.SetActive(false);
        eatButton_DogGoodFood2.transform.gameObject.SetActive(false);

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

        GameManager.gameManager._gameData.GoodFoodEat[1] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //스탯 상승
        NoahStatController.noahStatController.IncreaseStatBar(1);
        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[46] = false;
        livingRoomData.IsObjectActiveList[46] = false;
        engineRoomData.IsObjectActiveList[46] = false;
        controlRoomData.IsObjectActiveList[46] = false;

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
