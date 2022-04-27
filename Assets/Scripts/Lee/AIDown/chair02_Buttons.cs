using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chair02_Buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, upButton;

    ObjData chairData;

    public Transform chairPos;
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
        chairData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        chairData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        chairData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        chairData.IsPushOrPress = false;
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

        if (!chairData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = gameObject;

            chairData.IsUpDown = true;

            chairRisePos.x = chairPos.position.x;
            chairRisePos.z = chairPos.position.z;

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