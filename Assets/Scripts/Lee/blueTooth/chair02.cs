using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chair02 : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, upButton;

    ObjData chair01Data;

    public Vector3 chair01Pos;


    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        //오브젝트
        chair01Data = GetComponent<ObjData>();


        //버튼
        barkButton = chair01Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = chair01Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = chair01Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = chair01Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        upButton = chair01Data.CenterButton1;
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
        chair01Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        chair01Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        chair01Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        chair01Data.IsPushOrPress = false;
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
        if (!chair01Data.IsUpDown)
        {
            InteractionButtonController.interactionButtonController.risePosition = chair01Pos;
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
