using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainCom_workRoom : MonoBehaviour, IInteraction
{
    public GameObject comUI;
    //public bool Isclosed = false;
    
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData mainComData;
    public ObjectData mainComputerData, chair01Data, chair02Data;

    AudioSource On_Computer_Power_Sound;
    public AudioClip On_Computer;

    void Start()
    {
        On_Computer_Power_Sound = GetComponent<AudioSource>();

        mainComData = GetComponent<ObjData>();

        barkButton = mainComData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = mainComData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = mainComData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = mainComData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = mainComData.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if(!mainComputerData.IsObserve)
        {
            comUI.SetActive(false);
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
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
        DisableButton();

        if (chair01Data.IsUpDown || chair02Data.IsUpDown)
        {
            PlayerScripts.playerscripts.currentObserveObj = gameObject;
            CameraController.cameraController.currentView = mainComData.ObserveView;
            InteractionButtonController.interactionButtonController.playerObserve();

            //UI ����
            Invoke("ShowUI", 3f);
            On_Computer_Power_Sound.clip = On_Computer;
            On_Computer_Power_Sound.Play();

        }

        else
        {
            PlayerScripts.playerscripts.currentObserveObj = gameObject;
            CameraController.cameraController.currentView = mainComData.ObservePlusView;
            InteractionButtonController.interactionButtonController.playerObserve();
        }

        /*
         Ÿ���� ȭ�� ���� > �������� �� > Ÿ���� �������� = true;
         */
    }

    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void ShowUI()
    {
        comUI.SetActive(true);
    }


    /*public void UploadClear()
    {
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn && GameManager.gameManager._gameData.Is_Tablet_WirelessOn)
        {
            Debug.Log("���ε��ߵ�!!");
            GameManager.gameManager._gameData.IsComTabletUploadClear = true;
        }
    }*/
}
