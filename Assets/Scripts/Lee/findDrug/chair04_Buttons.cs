using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chair04_Buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, upButton;
    public ObjectData chair04Data, specificDrugData;
    ObjData chairData;

    public Vector3 chairRisePos;

    public GameObject SDrug;
    Outline SDrugLine;

    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        //오브젝트
        chairData = GetComponent<ObjData>();

        SDrugLine = SDrug.GetComponent<Outline>();

        //버튼
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

        if (!chair04Data.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = gameObject;

            chair04Data.IsUpDown = true;

            chairRisePos.x = chairData.UpPos.position.x;
            chairRisePos.z = chairData.UpPos.position.z;

            InteractionButtonController.interactionButtonController.PlayerRise1();
            InteractionButtonController.interactionButtonController.risePosition = chairRisePos;
            InteractionButtonController.interactionButtonController.PlayerRise2();

            specificDrugData.IsNotInteractable = false;
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