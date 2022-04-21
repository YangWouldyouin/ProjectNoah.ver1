using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugBag_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData drugBagData;

    void Start()
    {
        drugBagData = GetComponent<ObjData>();

        barkButton = drugBagData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugBagData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugBagData.BiteDestroyButton;
        //biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = drugBagData.PushOrPressButton;
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
        drugBagData.IsBark = true;
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
        drugBagData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        drugBagData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        drugBagData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

}
