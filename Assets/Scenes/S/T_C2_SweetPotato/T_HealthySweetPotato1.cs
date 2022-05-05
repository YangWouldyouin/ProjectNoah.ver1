using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_HealthySweetPotato1 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_HealthySweetPotato1, sniffButton_T_HealthySweetPotato1, biteButton_T_HealthySweetPotato1,
        pressButton_T_HealthySweetPotato1, eatButton_T_HealthySweetPotato1; // eatDisableButton_T_HealthySweetPotato1;


    /*ObjData*/
    ObjData HealthySweetPotato1Data_T;

    void Start()
    {
        /*ObjData*/
        HealthySweetPotato1Data_T = GetComponent<ObjData>();

        barkButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.BarkButton;
        barkButton_T_HealthySweetPotato1.onClick.AddListener(OnBark);

        sniffButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.SniffButton;
        sniffButton_T_HealthySweetPotato1.onClick.AddListener(OnSniff);

        biteButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.PushOrPressButton;
        pressButton_T_HealthySweetPotato1.onClick.AddListener(OnPushOrPress);

        eatButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.CenterButton1;
        eatButton_T_HealthySweetPotato1.onClick.AddListener(OnEat);

        //eatDisableButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
        sniffButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
        biteButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
        pressButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
        eatButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
        //eatDisableButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //HealthySweetPotato1Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //HealthySweetPotato1Data_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        // 스탯이 올라간다.

        GameManager.gameManager._gameData.sweetPotatoEat[1] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        //HealthySweetPotato1Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
       // HealthySweetPotato1Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        HealthySweetPotato1Data_T.IsPushOrPress = false;
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
