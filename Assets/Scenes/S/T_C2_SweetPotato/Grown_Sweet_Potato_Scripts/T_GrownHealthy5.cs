using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_GrownHealthy5 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_GrownHealthy5, sniffButton_T_GrownHealthy5, biteButton_T_GrownHealthy5,
        pressButton_T_GrownHealthy5, eatButton_T_GrownHealthy5; // eatDisableButton_T_HealthySweetPotato1;


    /*ObjData*/
    ObjData GrownHealthy5Data_T;

    void Start()
    {
        /*ObjData*/
        GrownHealthy5Data_T = GetComponent<ObjData>();

        barkButton_T_GrownHealthy5 = GrownHealthy5Data_T.BarkButton;
        barkButton_T_GrownHealthy5.onClick.AddListener(OnBark);

        sniffButton_T_GrownHealthy5 = GrownHealthy5Data_T.SniffButton;
        sniffButton_T_GrownHealthy5.onClick.AddListener(OnSniff);

        biteButton_T_GrownHealthy5 = GrownHealthy5Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_GrownHealthy5 = GrownHealthy5Data_T.PushOrPressButton;
        pressButton_T_GrownHealthy5.onClick.AddListener(OnPushOrPress);

        eatButton_T_GrownHealthy5 = GrownHealthy5Data_T.CenterButton1;
        eatButton_T_GrownHealthy5.onClick.AddListener(OnEat);

        //eatDisableButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_GrownHealthy5.transform.gameObject.SetActive(false);
        sniffButton_T_GrownHealthy5.transform.gameObject.SetActive(false);
        biteButton_T_GrownHealthy5.transform.gameObject.SetActive(false);
        pressButton_T_GrownHealthy5.transform.gameObject.SetActive(false);
        eatButton_T_GrownHealthy5.transform.gameObject.SetActive(false);
        //eatDisableButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        GrownHealthy5Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        GrownHealthy5Data_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();
    }

    public void OnSniff()
    {
        GrownHealthy5Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        GrownHealthy5Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        GrownHealthy5Data_T.IsPushOrPress = false;
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
