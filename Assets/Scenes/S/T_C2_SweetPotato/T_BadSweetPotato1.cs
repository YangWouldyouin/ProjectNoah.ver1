using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_BadSweetPotato1 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_BadSweetPotato1, sniffButton_T_BadSweetPotato1, biteButton_T_BadSweetPotato1,
        pressButton_T_BadSweetPotato1, eatButton_T_BadSweetPotato1; // eatDisableButton_T_BadSweetPotato1;


    /*ObjData*/
    ObjData BadSweetPotato1Data_T;

    PortableObjectData portableData; // 이후 워크룸에서 안보이게 하기 위해

    void Start()
    {
        portableData = BaseCanvas._baseCanvas.workRoomData;

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

        portableData.IsObjectActiveList[12] = false;

        GameManager.gameManager._gameData.sweetPotatoEat[0] = true;
        // 상한 고구마 섭취 엔딩
        GameManager.gameManager._gameData.IsSuddenDeath = true;
        GameManager.gameManager._gameData.IsEatBadPotato = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        InteractionButtonController.interactionButtonController.PlayerDie();
        NoahStatController.noahStatController.DecreaseStatBar();
    }

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
