using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData tabletObjectData;

    [SerializeField] ObjectData tabletData;

    public GameObject TabletUI;
    public GameObject TabletBackBlack;
    public GameObject TabletBackOn;

    void Start()
    {
        tabletObjectData = GetComponent<ObjData>();

        barkButton = tabletObjectData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = tabletObjectData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = tabletObjectData.BiteButton;

        pressButton = tabletObjectData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = tabletObjectData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if(tabletData.IsObserve == false)
        {
            TabletUI.SetActive(false);
            TabletBackBlack.SetActive(true);
            TabletBackOn.SetActive(false);
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
        tabletData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();
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
        tabletData.IsObserve = true;
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = tabletObjectData.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        Invoke("TabletOn", 2.5f);
        /*
         타블렛 화면 진입 > 블루투스 온 > 타블렛 블루투스 = true;
        */
    }

    public void TabletOn()
    {
        TabletUI.SetActive(true);
        TabletBackBlack.SetActive(false);
        TabletBackOn.SetActive(true);
    }

    public void OnPushOrPress()
    {
        tabletData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        tabletData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }
}
