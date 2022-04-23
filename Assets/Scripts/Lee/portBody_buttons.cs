using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portBody_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData portBodyData;

    void Start()
    {
        portBodyData = GetComponent<ObjData>();

        barkButton = portBodyData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portBodyData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portBodyData.BiteButton;
        //biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = portBodyData.PushOrPressButton;
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
        portBodyData.IsBark = true;
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
        portBodyData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        portBodyData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        portBodyData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    void IInteraction.OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    void IInteraction.OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
