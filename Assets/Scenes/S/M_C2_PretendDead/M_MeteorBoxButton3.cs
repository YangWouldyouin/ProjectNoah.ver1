using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton3 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton3, sniffButton_M_MeteorBoxButton3, biteButton_M_MeteorBoxButton3,
        pressButton_M_MeteorBoxButton3, noCenterButton_M_MeteorBoxButton3;


    /*ObjData*/
    ObjData MeteorBoxButton3Data_T;


    void Start()
    {
        /*ObjData*/
        MeteorBoxButton3Data_T = GetComponent<ObjData>();

        barkButton_M_MeteorBoxButton3 = MeteorBoxButton3Data_T.BarkButton;
        barkButton_M_MeteorBoxButton3.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton3 = MeteorBoxButton3Data_T.SniffButton;
        sniffButton_M_MeteorBoxButton3.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton3 = MeteorBoxButton3Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton3 = MeteorBoxButton3Data_T.PushOrPressButton;
        pressButton_M_MeteorBoxButton3.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton3 = MeteorBoxButton3Data_T.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        MeteorBoxButton3Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        MeteorBoxButton3Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        MeteorBoxButton3Data_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        MeteorBoxButton3Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnBite()
    {
       
    }

    public void OnEat()
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
