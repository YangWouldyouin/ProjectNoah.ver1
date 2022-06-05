using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData portDoorData;
    Outline portDoorLine;

    public GameObject insert01;
    ObjData insert01Data;
    Outline insert01Line;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        portDoorData = GetComponent<ObjData>();
        portDoorLine = GetComponent<Outline>();

        insert01Data = insert01.GetComponent<ObjData>();
        insert01Line = insert01.GetComponent<Outline>();

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

        portDoorData.transform.localRotation = Quaternion.Euler(-10f, 90f, 90f);

        portDoorData.IsNotInteractable = true;
        portDoorLine.OutlineWidth = 0f;

        insert01Data.IsNotInteractable = false;
        insert01Line.OutlineWidth = 8f;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(ChangePressFalse());

        if (GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(58));
        }
        
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
