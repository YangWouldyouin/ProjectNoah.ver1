using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnExBody_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    public ObjectData portBodyData;
    public ObjectData portDoorData;

    ObjData portBodyObjData;

    Outline portBodyLine;
    Outline portDoorLine;

    public GameObject portDoor;



    /*
    public GameObject insert02;
    ObjData insert02Data;
    Outline insert02Line;
    */


    void Start()
    {
        portBodyObjData = GetComponent<ObjData>();
        portBodyLine = GetComponent<Outline>();

        portDoorLine = portDoor.GetComponent<Outline>();

        //insert02Data = insert02.GetComponent<ObjData>();
        //insert02Line = insert02.GetComponent<Outline>();

        barkButton = portBodyObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portBodyObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portBodyObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = portBodyObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = portBodyObjData.CenterButton1;
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
        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = portBodyObjData.ObserveView;
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
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
