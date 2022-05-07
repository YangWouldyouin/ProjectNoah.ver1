using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_IDCard : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_S_IDCard, sniffButton_S_IDCard, biteButton_S_IDCard,
        pressButton_S_IDCard, noCenterButton_S_IDCard; // eatDisableButton_T_SuperDrug;


    /*ObjData*/
    ObjData IDCardData_S;

    void Start()
    {
        /*ObjData*/
        IDCardData_S = GetComponent<ObjData>();

        barkButton_S_IDCard = IDCardData_S.BarkButton;
        barkButton_S_IDCard.onClick.AddListener(OnBark);

        sniffButton_S_IDCard = IDCardData_S.SniffButton;
        sniffButton_S_IDCard.onClick.AddListener(OnSniff);

        biteButton_S_IDCard = IDCardData_S.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_S_IDCard = IDCardData_S.PushOrPressButton;
        pressButton_S_IDCard.onClick.AddListener(OnPushOrPress);

        noCenterButton_S_IDCard = IDCardData_S.CenterButton1;
        //noCenterButton_T_SuperDrug.onClick.AddListener(OnEat);

        //eatDisableButton_T_SuperDrug = SuperDrugData_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_S_IDCard.transform.gameObject.SetActive(false);
        sniffButton_S_IDCard.transform.gameObject.SetActive(false);
        biteButton_S_IDCard.transform.gameObject.SetActive(false);
        pressButton_S_IDCard.transform.gameObject.SetActive(false);
        noCenterButton_S_IDCard.transform.gameObject.SetActive(false);
        //eatDisableButton_T_SuperDrug.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();
    }

    public void OnSniff()
    {
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
