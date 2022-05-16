using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    public ObjectData hydrantDoorData;
    public ObjectData extingusherData;

    ObjData portDoorData;
    Outline portDoorLine;

    public GameObject extinguisher;
    Outline ExLine;

    void Start()
    {
        portDoorData = GetComponent<ObjData>();
        portDoorLine = GetComponent<Outline>();
        portDoorLine.OutlineWidth = 0;
        hydrantDoorData.IsNotInteractable = true;

        ExLine = extinguisher.GetComponent<Outline>();

        barkButton = portDoorData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portDoorData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portDoorData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        //smashButton = portDoorData.SmashButton;
        //smashButton.onClick.AddListener(OnSmash);

        pressButton = portDoorData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = portDoorData.CenterButton1;

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        //smashButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        portDoorData.transform.localRotation = Quaternion.Euler(-90f, 0f, 40f);

        portDoorData.IsNotInteractable = true;
        portDoorLine.OutlineWidth = 0f;

        extingusherData.IsNotInteractable = false;
        ExLine.OutlineWidth = 8f;

        gameObject.GetComponent<BoxCollider>().enabled = false;
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
        /*if (GameManager.gameManager._gameData.IsAlert)
        {
            Debug.Log("�� �ɷȴ�");
            GameManager.gameManager._gameData.IsAlert = false;

            Destroy(gameObject, 5f);
        }*/

        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        /*portDoorData.IsSmash = true;
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        Invoke();

        InteractionButtonController.interactionButtonController.PlayerSmash2();
        */
    }

}
