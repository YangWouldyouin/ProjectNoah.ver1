using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Planet_PortBody_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData Planet_PortBodyData_C;
    Outline Planet_PortBodyLine_C;

    public GameObject PortDoor_C;
    ObjData PortDoorData_C;
    Outline PortDoorLine_C;


    void Start()
    {
        Planet_PortBodyData_C = GetComponent<ObjData>();
        Planet_PortBodyLine_C = GetComponent<Outline>();

        PortDoorData_C = PortDoor_C.GetComponent<ObjData>();
        PortDoorLine_C = PortDoor_C.GetComponent<Outline>();

        //insert02Data = insert02.GetComponent<ObjData>();
        //insert02Line = insert02.GetComponent<Outline>();

        barkButton = Planet_PortBodyData_C.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Planet_PortBodyData_C.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Planet_PortBodyData_C.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Planet_PortBodyData_C.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = Planet_PortBodyData_C.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if(Planet_PortBodyData_C.IsObserve == false)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            PortDoor_C.GetComponent<BoxCollider>().enabled = false;

            PortDoorData_C.IsNotInteractable = true;
            PortDoorLine_C.OutlineWidth = 0f;

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
        Planet_PortBodyData_C.IsBark = true;
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
        Planet_PortBodyData_C.IsObserve = true;
        DisableButton();

        gameObject.GetComponent<BoxCollider>().enabled = false;

        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = Planet_PortBodyData_C.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        //portBodyData.IsNotInteractable = true;
        //portBodyLine.OutlineWidth = 0f;

        PortDoor_C.GetComponent<BoxCollider>().enabled = true;
        PortDoorData_C.IsNotInteractable = false;
        PortDoorLine_C.OutlineWidth = 8f;

        //gameObject.GetComponent<BoxCollider>().enabled = false;

        //insert02Data.IsNotInteractable = false;
        //insert02Line.OutlineWidth = 8f;
    }

    public void OnPushOrPress()
    {
        Planet_PortBodyData_C.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Planet_PortBodyData_C.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Planet_PortBodyData_C.IsSniff = true;
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
