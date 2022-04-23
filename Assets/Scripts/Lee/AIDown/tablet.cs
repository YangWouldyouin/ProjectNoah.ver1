using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData tabletData;


    void Start()
    {
        tabletData = GetComponent<ObjData>();

        barkButton = tabletData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = tabletData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = tabletData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        pressButton = tabletData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = tabletData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        tabletData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
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
        tabletData.IsObserve = true;
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = tabletData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        /*
         타블렛 화면 진입 > 블루투스 온 > 타블렛 블루투스 = true;
         */
    }

    public void OnPushOrPress()
    {
        tabletData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        tabletData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }
}
