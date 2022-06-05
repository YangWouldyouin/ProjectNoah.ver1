using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugMachine_buttons : MonoBehaviour, IInteraction
{
    public GameObject insert01;
    public GameObject insert02;

    public ObjectData insertCheck1Data, insertCheck2Data;

    Outline insert01Line;
    Outline insert02Line;
    
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData machineData;
    Outline machineLine;

    AudioSource drugMachine_Sound;
    public AudioClip drugMachine_On;

    BoxCollider insert01Col;
    BoxCollider insert02Col;

    void Start()
    {
        drugMachine_Sound = GetComponent<AudioSource>();

        machineData = GetComponent<ObjData>();
        machineLine = GetComponent<Outline>();

        insert01Line = insert01.GetComponent<Outline>();
        insert02Line = insert02.GetComponent<Outline>();

        insert01Col = insert01.GetComponent<BoxCollider>();
        insert02Col = insert02.GetComponent<BoxCollider>();

        //��ư
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
            insert01Col.enabled = false;
            insert02Col.enabled = false;

            drugMachine_Sound.clip = drugMachine_On;
            drugMachine_Sound.Stop();
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
        /* ������Ʈ�� ���� ���� true�� �ٲ� */

        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();

        /* ����� �� ������ ������Ʈ ���� */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        /* ī�޶� ��Ʈ�ѷ��� �� ���� */
        CameraController.cameraController.currentView = machineData.ObserveView; // ���� �� : ����

        /* ���� �ִϸ��̼� & ī�޶� ��ȯ */
        InteractionButtonController.interactionButtonController.playerObserve();

        insert01Col.enabled = true;
        insert02Col.enabled = true;

        drugMachine_Sound.clip = drugMachine_On;
        drugMachine_Sound.Play();

        //machineData.IsNotInteractable = true;
        //machineLine.OutlineWidth = 0f;
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
