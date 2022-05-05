using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage3 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_IsWrongMeteor2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteoritesStorage3, sniffButton_M_MeteoritesStorage3,
        biteButton_M_MeteoritesStorage3, pressButton_M_MeteoritesStorage3, 
        observeButton_M_MeteoritesStorage3, observeDisableButton_M_MeteoritesStorage3;

    /*ObjData*/
    ObjData meteoritesStorage3Data_M;
    ObjData IsWrongMeteor2Data_M;

    /*Outline*/
    Outline IsWrongMeteor2Outline_M;

    /*Collider*/
    BoxCollider meteoritesStorage3_Collider;
    BoxCollider IsWrongMeteor2_Collider;


    void Start()
    {
        /*ObjData*/
        meteoritesStorage3Data_M = GetComponent<ObjData>();
        IsWrongMeteor2Data_M = M_IsWrongMeteor2.GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor2Outline_M = M_IsWrongMeteor2.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage3_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor2_Collider = M_IsWrongMeteor2.GetComponent<BoxCollider>();

        /*��ư ����*/
        barkButton_M_MeteoritesStorage3 = meteoritesStorage3Data_M.BarkButton;
        barkButton_M_MeteoritesStorage3.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage3 = meteoritesStorage3Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage3.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage3 = meteoritesStorage3Data_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage3 = meteoritesStorage3Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage3.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage3 = meteoritesStorage3Data_M.CenterButton1;
        observeButton_M_MeteoritesStorage3.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage3= meteoritesStorage3Data_M.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        meteoritesStorage3Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnObserve()
    {
        meteoritesStorage3Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage3Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor2Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
        IsWrongMeteor2Outline_M.OutlineWidth = 8;
    }

    public void OnPushOrPress()
    {
        meteoritesStorage3Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage3Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage3Data_M.IsSniff = true;

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
