using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage5 : MonoBehaviour, IInteraction
{
    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteoritesStorage5, sniffButton_M_MeteoritesStorage5,
        biteButton_M_MeteoritesStorage5, pressButton_M_MeteoritesStorage5, 
        observeButton_M_MeteoritesStorage5, observeDisableButton_M_MeteoritesStorage5;

    /*ObjData*/
    ObjData meteoritesStorage5Data_M;


    void Start()
    {
        /*ObjData*/
        meteoritesStorage5Data_M = GetComponent<ObjData>();


        barkButton_M_MeteoritesStorage5 = meteoritesStorage5Data_M.BarkButton;
        barkButton_M_MeteoritesStorage5.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage5 = meteoritesStorage5Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage5.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage5 = meteoritesStorage5Data_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage5 = meteoritesStorage5Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage5.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage5 = meteoritesStorage5Data_M.CenterButton1;
        observeButton_M_MeteoritesStorage5.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage5= meteoritesStorage5Data_M.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        meteoritesStorage5Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnObserve()
    {
        meteoritesStorage5Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage5Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    public void OnPushOrPress()
    {
        meteoritesStorage5Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage5Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage5Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnBite()
    {
        
    }

    public void OnEat()
    {
       
    }

    public void OnInsert()
    {
       
    }


    public void OnSmash()
    {

    }

    public void OnUp()
    {
        
    }
}