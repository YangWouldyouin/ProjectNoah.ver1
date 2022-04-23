using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chair04_Buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, upButton;

    ObjData chair04Data;

    public Vector3 chair04Pos;

    public GameObject SDrug;
    ObjData SDrugData;
    Outline SDrugLine;

    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        //오브젝트
        chair04Data = GetComponent<ObjData>();

        SDrugData = SDrug.GetComponent<ObjData>();
        SDrugLine = SDrug.GetComponent<Outline>();

        //버튼
        barkButton = chair04Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = chair04Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = chair04Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = chair04Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        upButton = chair04Data.CenterButton1;
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
        chair04Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        chair04Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        chair04Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        chair04Data.IsPushOrPress = false;
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
        if (!chair04Data.IsUpDown)
        {
            InteractionButtonController.interactionButtonController.risePosition = chair04Pos;
            InteractionButtonController.interactionButtonController.PlayerRise2();

            SDrugData.IsNotInteractable = false;
            //SDrugLine.OutlineWidth = 8f;
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