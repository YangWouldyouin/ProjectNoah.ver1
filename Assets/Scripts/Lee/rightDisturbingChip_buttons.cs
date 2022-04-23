using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightDisturbingChip_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData disturbingChipData;

    void Start()
    {
        disturbingChipData = GetComponent<ObjData>();

        barkButton = disturbingChipData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = disturbingChipData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = disturbingChipData.BiteButton;
        //biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = disturbingChipData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        disturbingChipData.IsBark = true;
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
        disturbingChipData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        disturbingChipData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        disturbingChipData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    void IInteraction.OnBite()
    {
        //버튼에 삽입하기
    }

    void IInteraction.OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
