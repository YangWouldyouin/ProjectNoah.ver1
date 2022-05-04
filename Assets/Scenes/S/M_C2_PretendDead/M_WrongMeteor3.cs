using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_WrongMeteor3 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_WrongMeteor3, sniffButton_M_WrongMeteor3, biteButton_M_WrongMeteor3,
        pressButton_M_WrongMeteor3, noCenterButton_M_WrongMeteor3;

    /*ObjData*/
    ObjData WrongMeteor3Data_T;

    void Start()
    {
        /*ObjData*/
        WrongMeteor3Data_T = GetComponent<ObjData>();

        barkButton_M_WrongMeteor3 = WrongMeteor3Data_T.BarkButton;
        barkButton_M_WrongMeteor3.onClick.AddListener(OnBark);

        sniffButton_M_WrongMeteor3 = WrongMeteor3Data_T.SniffButton;
        sniffButton_M_WrongMeteor3.onClick.AddListener(OnSniff);

        biteButton_M_WrongMeteor3 = WrongMeteor3Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_WrongMeteor3 = WrongMeteor3Data_T.PushOrPressButton;
        pressButton_M_WrongMeteor3.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_WrongMeteor3 = WrongMeteor3Data_T.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_WrongMeteor3.transform.gameObject.SetActive(false);
        sniffButton_M_WrongMeteor3.transform.gameObject.SetActive(false);
        biteButton_M_WrongMeteor3.transform.gameObject.SetActive(false);
        pressButton_M_WrongMeteor3.transform.gameObject.SetActive(false);
        noCenterButton_M_WrongMeteor3.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        WrongMeteor3Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        WrongMeteor3Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        WrongMeteor3Data_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        WrongMeteor3Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnBite()
    {
        throw new System.NotImplementedException();
    }

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {

    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }
}
