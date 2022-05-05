using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage4 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_IsWrongMeteor3;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteoritesStorage4, sniffButton_M_MeteoritesStorage4,
        biteButton_M_MeteoritesStorage4, pressButton_M_MeteoritesStorage4, 
        observeButton_M_MeteoritesStorage4, observeDisableButton_M_MeteoritesStorage4;

    /*ObjData*/
    ObjData meteoritesStorage4Data_M;
    ObjData IsWrongMeteor3Data_M;


    /*Outline*/
    Outline IsWrongMeteor3Outline_M;

    /*Collider*/
    BoxCollider meteoritesStorage4_Collider;
    BoxCollider IsWrongMeteor3_Collider;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage4Data_M = GetComponent<ObjData>();
        IsWrongMeteor3Data_M = M_IsWrongMeteor3.GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor3Outline_M = M_IsWrongMeteor3.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage4_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor3_Collider = M_IsWrongMeteor3.GetComponent<BoxCollider>();

        /*��ư ����*/
        barkButton_M_MeteoritesStorage4 = meteoritesStorage4Data_M.BarkButton;
        barkButton_M_MeteoritesStorage4.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage4 = meteoritesStorage4Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage4.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage4 = meteoritesStorage4Data_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage4 = meteoritesStorage4Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage4.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage4 = meteoritesStorage4Data_M.CenterButton1;
        observeButton_M_MeteoritesStorage4.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage4= meteoritesStorage4Data_M.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        meteoritesStorage4Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnObserve()
    {
        meteoritesStorage4Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage4Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor3Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
        IsWrongMeteor3Outline_M.OutlineWidth = 8;
    }

    public void OnPushOrPress()
    {
        meteoritesStorage4Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage4Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage4Data_M.IsSniff = true;

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
