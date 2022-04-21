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

        biteButton = specificDrugData.BiteDestroyButton;
        //biteButton.onClick.AddListener(OnBiteDestroy);

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

    public void OnBiteDestroy()
    {
        //throw new System.NotImplementedException();
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


}
