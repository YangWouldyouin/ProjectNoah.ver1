using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specificDrug_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData specificDrugData;

    void Start()
    {
        specificDrugData = GetComponent<ObjData>();

        barkButton = specificDrugData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = specificDrugData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = specificDrugData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = specificDrugData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        specificDrugData.IsBark = true;
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
        specificDrugData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        specificDrugData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        specificDrugData.IsSniff = true;
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
