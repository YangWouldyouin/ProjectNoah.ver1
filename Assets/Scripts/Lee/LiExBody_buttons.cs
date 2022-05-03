using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiExBody_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData portBodyData;
    Outline portBodyLine;

    public GameObject portDoor;
    ObjData portDoorData;
    Outline portDoorLine;

    /*
    public GameObject insert02;
    ObjData insert02Data;
    Outline insert02Line;
    */


    void Start()
    {
        portBodyData = GetComponent<ObjData>();
        portBodyLine = GetComponent<Outline>();

        portDoorData = portDoor.GetComponent<ObjData>();
        portDoorLine = portDoor.GetComponent<Outline>();

        //insert02Data = insert02.GetComponent<ObjData>();
        //insert02Line = insert02.GetComponent<Outline>();

        barkButton = portBodyData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portBodyData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portBodyData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = portBodyData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = portBodyData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if(portBodyData.IsObserve == false)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;

            portDoorData.IsNotInteractable = true;
            portDoorLine.OutlineWidth = 0f;

            //insert02Data.IsNotInteractable = true;
            //insert02Line.OutlineWidth = 0f;
        }
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
        portBodyData.IsObserve = true;
        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = portBodyData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        portBodyData.IsNotInteractable = true;
        portBodyLine.OutlineWidth = 0f;

        portDoorData.IsNotInteractable = false;
        portDoorLine.OutlineWidth = 8f;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        //insert02Data.IsNotInteractable = false;
        //insert02Line.OutlineWidth = 8f;
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
