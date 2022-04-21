using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugMachine_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData machineData;

    void start()
    {
        machineData = GetComponent<ObjData>();

        barkButton = machineData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = machineData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = machineData.BiteDestroyButton;
        biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = machineData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = machineData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
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
        machineData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        machineData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        machineData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        machineData.IsPushOrPress = false;
    }

    public void OnBiteDestroy()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerBite();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        machineData.IsObserve = true;
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        CameraController.cameraController.currentView = machineData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }
}
