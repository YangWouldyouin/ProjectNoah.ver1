using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet_portDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Planet_portDoorObjData;
    public ObjectData Planet_portDoorData;
    Outline Planet_portDoorLine;

    ObjData Planet_insertObjData;
    public GameObject Planet_insert;
    public ObjectData Planet_insertData;
    Outline Planet_insertLine;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        Planet_portDoorObjData = GetComponent<ObjData>();
        Planet_portDoorLine = GetComponent<Outline>();

        Planet_insertLine = Planet_insert.GetComponent<Outline>();

        barkButton = Planet_portDoorObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Planet_portDoorObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Planet_portDoorObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        //smashButton = portDoorData.SmashButton;
        //smashButton.onClick.AddListener(OnSmash);

        pressButton = Planet_portDoorObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Planet_portDoorObjData.CenterButton1;

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
        Planet_portDoorObjData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Planet_portDoorObjData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Planet_portDoorObjData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        Planet_portDoorObjData.transform.localRotation = Quaternion.Euler(5f, 0f, 90f);

        Planet_portDoorObjData.IsNotInteractable = true;
        Planet_portDoorLine.OutlineWidth = 0f;

        Planet_insertObjData.IsNotInteractable = false;
        Planet_insertLine.OutlineWidth = 8f;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(ChangePressFalse());

        // dialogManager.StartCoroutine(dialogManager.PrintAIDialog(58));
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Planet_portDoorObjData.IsPushOrPress = false;
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
