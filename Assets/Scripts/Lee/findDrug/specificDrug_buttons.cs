using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specificDrug_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;
    public ObjectData specificDrugData; 
    ObjData specificDrugObjData;

    void Start()
    {
        specificDrugObjData = GetComponent<ObjData>();

        barkButton = specificDrugObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = specificDrugObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = specificDrugObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = specificDrugObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = specificDrugObjData.CenterButton1;
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        //바이트 버튼에 스크립트 넣기
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }


}
