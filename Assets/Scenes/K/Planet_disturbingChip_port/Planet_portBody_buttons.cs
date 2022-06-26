using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_portBody_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton, noCenterButton;

    ObjData Planet_portBodyObjData;
    public ObjectData Planet_portBodyData;
    Outline Planet_portBodyLine;

    public GameObject Planet_portDoor;
    ObjData Planet_portDoorObjData;
    public ObjectData Planet_portDoorData;
    Outline Planet_portDoorLine;

    public ObjectData Planet_portDoorDataOb;
    public ObjectData Planet_portBodyDataOb;




    void Start()
    {
        Planet_portBodyObjData = GetComponent<ObjData>();
        Planet_portBodyLine = GetComponent<Outline>();

        Planet_portDoorObjData = Planet_portDoor.GetComponent<ObjData>();
        Planet_portDoorLine = Planet_portDoor.GetComponent<Outline>();


        barkButton = Planet_portBodyObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Planet_portBodyObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Planet_portBodyObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Planet_portBodyObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Planet_portBodyObjData.CenterButton1;

/*        observeButton = Planet_portBodyObjData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);*/
    }

    void Update()
    {
/*        if(Planet_portBodyDataOb.IsObserve == false)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            Planet_portDoor.GetComponent<BoxCollider>().enabled = false;

            Planet_portDoorDataOb.IsNotInteractable = true;
            Planet_portDoorLine.OutlineWidth = 0f;
        }*/
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
        Planet_portBodyDataOb.IsBark = true;
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
/*        Planet_portBodyDataOb.IsObserve = true;
        DisableButton();

        gameObject.GetComponent<BoxCollider>().enabled = false;

        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = Planet_portBodyObjData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        //portBodyData.IsNotInteractable = true;
        //portBodyLine.OutlineWidth = 0f;

        Planet_portDoor.GetComponent<BoxCollider>().enabled = true;
        Planet_portDoorDataOb.IsNotInteractable = false;
        Planet_portDoorLine.OutlineWidth = 8f;*/

        //gameObject.GetComponent<BoxCollider>().enabled = false;

        //insert02Data.IsNotInteractable = false;
        //insert02Line.OutlineWidth = 8f;
    }

    public void OnPushOrPress()
    {
        Planet_portBodyDataOb.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Planet_portBodyObjData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Planet_portBodyDataOb.IsSniff = true;
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
