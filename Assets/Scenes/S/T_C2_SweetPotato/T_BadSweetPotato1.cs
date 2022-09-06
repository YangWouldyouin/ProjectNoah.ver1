using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_BadSweetPotato1 : MonoBehaviour, IInteraction
{
    public GameObject Dontclick;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_BadSweetPotato1, sniffButton_T_BadSweetPotato1, biteButton_T_BadSweetPotato1,
        pressButton_T_BadSweetPotato1, eatButton_T_BadSweetPotato1; // eatDisableButton_T_BadSweetPotato1;


    /*ObjData*/
    ObjData BadSweetPotato1Data_T;

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
        BadSweetPotato1Data_T = GetComponent<ObjData>();

        barkButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.BarkButton;
        barkButton_T_BadSweetPotato1.onClick.AddListener(OnBark);

        sniffButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.SniffButton;
        sniffButton_T_BadSweetPotato1.onClick.AddListener(OnSniff);

        biteButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.PushOrPressButton;
        pressButton_T_BadSweetPotato1.onClick.AddListener(OnPushOrPress);

        eatButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.CenterButton1;
        eatButton_T_BadSweetPotato1.onClick.AddListener(OnEat);

        //eatDisableButton_T_BadSweetPotato1 = BadSweetPotato1Data_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
        sniffButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
        biteButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
        pressButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
        eatButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
        //eatDisableButton_T_BadSweetPotato1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //BadSweetPotato1Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //BadSweetPotato1Data_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        workRoomData.IsObjectActiveList[12] = false;
        livingRoomData.IsObjectActiveList[12] = false;
        engineRoomData.IsObjectActiveList[12] = false;
        controlRoomData.IsObjectActiveList[12] = false;

        GameManager.gameManager._gameData.sweetPotatoEat[0] = true;
        // 상한 고구마 섭취 엔딩
        
        Invoke("EatAfter", 3f);

        BadSweetPotato1Data_T.IsEaten = false;
    }

    public void EatAfter()
    {
        /* 스팀업적 : 예상치 못한 사고:돌연사 완료 */
        //SteamStatManager.steamAchieve1Time.Invoke(2, "END_SUDDEN_DEATH");

        GameManager.gameManager._gameData.IsEatBadPotato = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //InteractionButtonController.interactionButtonController.PlayerDie();

        //Dontclick.SetActive(true);

        //StartCoroutine(SuddenDeath());
        //Invoke("SuddenDeath", 3f);
    }

    //IEnumerator SuddenDeath()
    //{

    //    yield return new WaitForSeconds(3f);
    //    Debug.Log("노아는 죽엇다");

    //    GameManager.gameManager._gameData.IsSuddenDeath = true;

    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    Dontclick.SetActive(false);

    //    InteractionButtonController.interactionButtonController.PlayerAlive();


    //}

    //public void SuddenDeath()
    //{
    //    GameManager.gameManager._gameData.IsSuddenDeath = true;
    //    GameManager.gameManager._gameData.IsEatBadPotato = true;
    //    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    NoahStatController.noahStatController.DecreaseStatBar();
    //    Dontclick.SetActive(false);

    //    InteractionButtonController.interactionButtonController.PlayerAlive();
    //}

    public void OnSniff()
    {
        //BadSweetPotato1Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //BadSweetPotato1Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        BadSweetPotato1Data_T.IsPushOrPress = false;
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
