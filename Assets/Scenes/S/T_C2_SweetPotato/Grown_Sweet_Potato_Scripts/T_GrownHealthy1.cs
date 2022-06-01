using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_GrownHealthy1 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_GrownHealthy1, sniffButton_T_GrownHealthy1, biteButton_T_GrownHealthy1,
        pressButton_T_GrownHealthy1, eatButton_T_GrownHealthy1; // eatDisableButton_T_HealthySweetPotato1;


    /*ObjData*/
    ObjData GrownHealthy1Data_T;

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
        GrownHealthy1Data_T = GetComponent<ObjData>();

        barkButton_T_GrownHealthy1 = GrownHealthy1Data_T.BarkButton;
        barkButton_T_GrownHealthy1.onClick.AddListener(OnBark);

        sniffButton_T_GrownHealthy1 = GrownHealthy1Data_T.SniffButton;
        sniffButton_T_GrownHealthy1.onClick.AddListener(OnSniff);

        biteButton_T_GrownHealthy1 = GrownHealthy1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_GrownHealthy1 = GrownHealthy1Data_T.PushOrPressButton;
        pressButton_T_GrownHealthy1.onClick.AddListener(OnPushOrPress);

        eatButton_T_GrownHealthy1 = GrownHealthy1Data_T.CenterButton1;
        eatButton_T_GrownHealthy1.onClick.AddListener(OnEat);

        //eatDisableButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_GrownHealthy1.transform.gameObject.SetActive(false);
        sniffButton_T_GrownHealthy1.transform.gameObject.SetActive(false);
        biteButton_T_GrownHealthy1.transform.gameObject.SetActive(false);
        pressButton_T_GrownHealthy1.transform.gameObject.SetActive(false);
        eatButton_T_GrownHealthy1.transform.gameObject.SetActive(false);
        //eatDisableButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //GrownHealthy1Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //GrownHealthy1Data_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        // 스탯 올라가게??
        //스탯 상승
        NoahStatController.noahStatController.IncreaseStatBar(1);

        workRoomData.IsObjectActiveList[21] = false;
        livingRoomData.IsObjectActiveList[21] = false;
        engineRoomData.IsObjectActiveList[21] = false;
        controlRoomData.IsObjectActiveList[21] = false;

        GameManager.gameManager._gameData.sweetPotatoEat[2] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        //GrownHealthy1Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //GrownHealthy1Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        GrownHealthy1Data_T.IsPushOrPress = false;
    }*/

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
