using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Pot2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_Pot2, sniffButton_T_Pot2, biteButton_T_Pot2, pressButton_T_Pot2, noCenterButton_T_Pot2;

    /*ObjData*/
    ObjData Pot2Data_T;

    void Start()
    {
        Pot2Data_T = GetComponent<ObjData>();

        barkButton_T_Pot2 = Pot2Data_T.BarkButton;
        barkButton_T_Pot2.onClick.AddListener(OnBark);

        sniffButton_T_Pot2 = Pot2Data_T.SniffButton;
        sniffButton_T_Pot2.onClick.AddListener(OnSniff);

        biteButton_T_Pot2 = Pot2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_Pot2 = Pot2Data_T.PushOrPressButton;
        pressButton_T_Pot2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_Pot2 = Pot2Data_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_Pot2.transform.gameObject.SetActive(false);
        sniffButton_T_Pot2.transform.gameObject.SetActive(false);
        biteButton_T_Pot2.transform.gameObject.SetActive(false);
        pressButton_T_Pot2.transform.gameObject.SetActive(false);
        noCenterButton_T_Pot2.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        Pot2Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Pot2Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        Pot2Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Pot2Data_T.IsPushOrPress = false;
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
