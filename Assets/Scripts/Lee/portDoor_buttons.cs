using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData portDoorData;

    void Start()
    {
        portDoorData = GetComponent<ObjData>();

        barkButton = portDoorData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portDoorData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portDoorData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = portDoorData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        portDoorData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        portDoorData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        portDoorData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        portDoorData.IsPushOrPress = false;
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
