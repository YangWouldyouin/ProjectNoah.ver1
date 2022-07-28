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
        NoahStatController.noahStatController.DecreaseStat(3);

        // 앞으로 모든씬에서 안보임
        workRoomData.IsObjectActiveList[48] = false;
        livingRoomData.IsObjectActiveList[48] = false;
        engineRoomData.IsObjectActiveList[48] = false;
        controlRoomData.IsObjectActiveList[48] = false;

        /* 스팀업적 : 아무거나 먹지 말랬지 완료 */
        SteamStatManager.steamAchieve1Time.Invoke(6, "EGG_WRONG_FOOD");
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
