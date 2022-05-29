using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiExDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;


    public ObjectData portDoorData;
    public ObjectData ExDataa;
    ObjData portDoorObjData;
    Outline portDoorLine;

    public GameObject food;
    Outline ExLine;

    void Start()
    {
        portDoorObjData = GetComponent<ObjData>();

        portDoorLine = GetComponent<Outline>();

        ExLine = food.GetComponent<Outline>();

        barkButton = portDoorObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = portDoorObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = portDoorObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        //smashButton = portDoorData.SmashButton;
        //smashButton.onClick.AddListener(OnSmash);

        pressButton = portDoorObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = portDoorObjData.CenterButton1;
        portDoorData.IsNotInteractable = true;
        portDoorLine.OutlineWidth = 0f;
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

        portDoorObjData.transform.localRotation = Quaternion.Euler(-90f, 0f, -330f);

        portDoorData.IsNotInteractable = true;
        portDoorLine.OutlineWidth = 0f;

        ExDataa.IsNotInteractable = false;
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
