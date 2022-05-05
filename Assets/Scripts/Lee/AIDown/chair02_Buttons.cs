using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chair02_Buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, upButton;
    public ObjectData chair02Data;
    ObjData chairData;

    public Vector3 chairRisePos;

    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ
        chairData = GetComponent<ObjData>();

        //��ư
        barkButton = chairData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = chairData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = chairData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = chairData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        upButton = chairData.CenterButton1;
        upButton.onClick.AddListener(OnUp);

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        upButton.transform.gameObject.SetActive(false);
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
        InteractionButtonController.interactionButtonController.playerPressHand();
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
        DisableButton();

        if (!chair02Data.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = gameObject;

            chair02Data.IsUpDown = true;

            chairRisePos.x = chairData.UpPos.position.x;
            chairRisePos.z = chairData.UpPos.position.z;

            InteractionButtonController.interactionButtonController.PlayerRise1();
            InteractionButtonController.interactionButtonController.risePosition = chairRisePos;
            InteractionButtonController.interactionButtonController.PlayerRise2();
        }
    }

    public void OnInsert()
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