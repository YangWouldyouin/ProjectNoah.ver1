using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugMachine_buttons : MonoBehaviour, IInteraction
{
    public GameObject insert01;
    public GameObject insert02;

    ObjData insert01Data;
    ObjData insert02Data;

    Outline insert01Line;
    Outline insert02Line;
    
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData machineData;
    Outline machineLine;

    void Start()
    {
        machineData = GetComponent<ObjData>();
        machineLine = GetComponent<Outline>();

        insert01Data = insert01.GetComponent<ObjData>();
        insert01Line = insert01.GetComponent<Outline>();

        insert02Data = insert02.GetComponent<ObjData>();
        insert02Line = insert02.GetComponent<Outline>();

        //¹öÆ°
        barkButton = machineData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = machineData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = machineData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = machineData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = machineData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void update()
    {
        if (machineData.IsObserve == false)
        {
            insert01Data.IsNotInteractable = true;
            insert01Line.OutlineWidth = 0f;

            insert02Data.IsNotInteractable = true;
            insert02Line.OutlineWidth = 0f;
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        machineData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        machineData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        machineData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        machineData.IsPushOrPress = false;
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        machineData.IsObserve = true;
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = machineData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        machineData.IsNotInteractable = true;
        machineLine.OutlineWidth = 0f;

        insert01Data.IsNotInteractable = false;
        insert01Line.OutlineWidth = 8f;

        insert02Data.IsNotInteractable = false;
        insert02Line.OutlineWidth = 8f;
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
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
