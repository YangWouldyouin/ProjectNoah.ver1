using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton4 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton4, sniffButton_M_MeteorBoxButton4, biteButton_M_MeteorBoxButton4,
        pressButton_M_MeteorBoxButton4, noCenterButton_M_MeteorBoxButton4;


    /*ObjData*/
    ObjData MeteorBoxButton4Data_T;


    void Start()
    {
        /*ObjData*/
        MeteorBoxButton4Data_T = GetComponent<ObjData>();

        barkButton_M_MeteorBoxButton4 = MeteorBoxButton4Data_T.BarkButton;
        barkButton_M_MeteorBoxButton4.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton4 = MeteorBoxButton4Data_T.SniffButton;
        sniffButton_M_MeteorBoxButton4.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton4 = MeteorBoxButton4Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton4 = MeteorBoxButton4Data_T.PushOrPressButton;
        pressButton_M_MeteorBoxButton4.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton4 = MeteorBoxButton4Data_T.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        MeteorBoxButton4Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        MeteorBoxButton4Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        MeteorBoxButton4Data_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        MeteorBoxButton4Data_T.IsSniff = true;

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
