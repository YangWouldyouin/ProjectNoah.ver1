using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drug_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData drugData;

    void Start()
    {
        drugData = GetComponent<ObjData>();

        barkButton = drugData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        pressButton = drugData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = drugData.CenterButton1;
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
        drugData.IsBark = true;
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
        //throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
    {
        drugData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        drugData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        drugData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    void IInteraction.OnBite()
    {
        //바이트 버튼에 스크립트 넣기
    }

    void IInteraction.OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
