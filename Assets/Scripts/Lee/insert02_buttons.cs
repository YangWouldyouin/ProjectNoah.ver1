using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert02_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData Insert02Data;

    void Start()
    {
        Insert02Data = GetComponent<ObjData>();

        barkButton = Insert02Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Insert02Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Insert02Data.BiteDestroyButton;
        biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = Insert02Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        Insert02Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Insert02Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Insert02Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Insert02Data.IsPushOrPress = false;
    }

    public void OnBiteDestroy()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerBite();
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
}
