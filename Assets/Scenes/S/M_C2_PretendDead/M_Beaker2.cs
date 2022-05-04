using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker2 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Beaker2, sniffButton_M_Beaker2, biteButton_M_Beaker2,
        pressButton_M_Beaker2, eatButton_M_Beaker2, eatDisableButton_M_Beaker2;


    /*ObjData*/
    ObjData Beaker2Data_M;


    void Start()
    {
        /*ObjData*/
        Beaker2Data_M = GetComponent<ObjData>();

        barkButton_M_Beaker2 = Beaker2Data_M.BarkButton;
        barkButton_M_Beaker2.onClick.AddListener(OnBark);

        sniffButton_M_Beaker2 = Beaker2Data_M.SniffButton;
        sniffButton_M_Beaker2.onClick.AddListener(OnSniff);

        biteButton_M_Beaker2 = Beaker2Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker2 = Beaker2Data_M.PushOrPressButton;
        pressButton_M_Beaker2.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker2 = Beaker2Data_M.CenterButton1;
        eatButton_M_Beaker2.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker2 = Beaker2Data_M.CenterButton1;

    }

    void DisableButton()
    {
        barkButton_M_Beaker2.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker2.transform.gameObject.SetActive(false);
        biteButton_M_Beaker2.transform.gameObject.SetActive(false);
        pressButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        Beaker2Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Beaker2Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Beaker2Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Beaker2Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        Beaker2Data_M.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();
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
