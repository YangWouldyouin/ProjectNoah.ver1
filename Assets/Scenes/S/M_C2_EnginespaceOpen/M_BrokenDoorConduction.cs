using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BrokenDoorConduction : MonoBehaviour, IInteraction
{
    //public bool fixEngineDoor = false;

    /*연관있는 오브젝트*/
    public GameObject M_canBrokenArea;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_BrokenDoorConduction, sniffButton_M_BrokenDoorConduction,
        biteButton_M_BrokenDoorConduction, pressButton_M_BrokenDoorConduction, noCenterButton_M_BrokenDoorConduction;

    ObjData brokenDoorConductionData_M;

    void Start()
    {
        brokenDoorConductionData_M = GetComponent<ObjData>();


        barkButton_M_BrokenDoorConduction = brokenDoorConductionData_M.BarkButton;
        barkButton_M_BrokenDoorConduction.onClick.AddListener(OnBark);

        sniffButton_M_BrokenDoorConduction = brokenDoorConductionData_M.SniffButton;
        sniffButton_M_BrokenDoorConduction.onClick.AddListener(OnSniff);

        biteButton_M_BrokenDoorConduction = brokenDoorConductionData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_BrokenDoorConduction = brokenDoorConductionData_M.PushOrPressButton;
        pressButton_M_BrokenDoorConduction.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_BrokenDoorConduction = brokenDoorConductionData_M.CenterButton1;

    }

    void Update()
    {
    }

    void DisableButton()
    {
        barkButton_M_BrokenDoorConduction.transform.gameObject.SetActive(false);
        sniffButton_M_BrokenDoorConduction.transform.gameObject.SetActive(false);
        biteButton_M_BrokenDoorConduction.transform.gameObject.SetActive(false);
        pressButton_M_BrokenDoorConduction.transform.gameObject.SetActive(false);
        noCenterButton_M_BrokenDoorConduction.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        brokenDoorConductionData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
        /* 상호작용 버튼을 끔 *//*
        DisableButton();
        *//*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 *//*
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();*/

    }
    public void OnPushOrPress()
    {
        brokenDoorConductionData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());


    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        brokenDoorConductionData_M.IsPushOrPress = false;
    }


    public void OnSniff()
    {
        brokenDoorConductionData_M.IsSniff = true;

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

    public void OnObserve()
    {
      
    }

    public void OnSmash()
    {

    }

    public void OnUp()
    {
        
    }

}
