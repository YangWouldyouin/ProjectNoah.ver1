using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachine : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject T_IsAnalyticalMachinePlate;
    public GameObject T_IsAnalyticalMachineButton;
    public GameObject Noah_Obj2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_AnalyticalMachine, sniffButton_T_AnalyticalMachine, biteButton_T_AnalyticalMachine, 
        pressButton_T_AnalyticalMachine, observeButton_T_AnalyticalMachine;


    /*ObjData*/
    ObjData analyticalMachineData_T;
    ObjData isAnalyticalMachinePlateData_T;
    ObjData isAnalyticalMachineButtonData_T;

    /*Outline*/
    Outline isAnalyticalMachinePlateOutline_T;
    Outline isAnalyticalMachineButtonOutline_T;

    /*Collider*/
    BoxCollider analyticalMachine_Collider;
    BoxCollider isAnalyticalMachineButton_Collider; //��ư
    BoxCollider Noah_Obj2_Collider; //���

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        analyticalMachine_Collider = GetComponent<BoxCollider>();
        Noah_Obj2_Collider = Noah_Obj2.GetComponent<BoxCollider>();
        isAnalyticalMachineButton_Collider = T_IsAnalyticalMachineButton.GetComponent<BoxCollider>();

        /*ObjData*/
        analyticalMachineData_T = GetComponent<ObjData>();
        isAnalyticalMachinePlateData_T = T_IsAnalyticalMachinePlate.GetComponent<ObjData>();
        isAnalyticalMachineButtonData_T = T_IsAnalyticalMachineButton.GetComponent<ObjData>();

        /*Outline*/
        isAnalyticalMachinePlateOutline_T = T_IsAnalyticalMachinePlate.GetComponent<Outline>();
        isAnalyticalMachineButtonOutline_T = T_IsAnalyticalMachineButton.GetComponent<Outline>();

        barkButton_T_AnalyticalMachine = analyticalMachineData_T.BarkButton;
        barkButton_T_AnalyticalMachine.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachine = analyticalMachineData_T.SniffButton;
        sniffButton_T_AnalyticalMachine.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachine = analyticalMachineData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachine = analyticalMachineData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_AnalyticalMachine = analyticalMachineData_T.CenterButton1;
        observeButton_T_AnalyticalMachine.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        //�����ϱ� ���°� �ƴ϶�� �ݶ��̴� ������ ���ش�.
        if (!analyticalMachineData_T.IsObserve)
        {
            analyticalMachine_Collider.enabled = true;
            Noah_Obj2_Collider.enabled = true;
            isAnalyticalMachineButton_Collider.enabled = true;

            isAnalyticalMachinePlateData_T.IsNotInteractable = true; // ���� ��ȣ�ۿ� �� �����ϰ�
            isAnalyticalMachinePlateOutline_T.OutlineWidth = 0;
        }
    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        observeButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        analyticalMachineData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

 
    public void OnPushOrPress()
    {
        analyticalMachineData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        analyticalMachineData_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        analyticalMachineData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        analyticalMachineData_T.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = analyticalMachineData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        analyticalMachine_Collider.enabled = false;
        Noah_Obj2_Collider.enabled = false;
        isAnalyticalMachineButton_Collider.enabled = false;

        isAnalyticalMachinePlateData_T.IsNotInteractable = false; // ���� ��ȣ�ۿ� �����ϰ�
        isAnalyticalMachinePlateOutline_T.OutlineWidth = 8;

        isAnalyticalMachineButtonData_T.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
        isAnalyticalMachineButtonOutline_T.OutlineWidth = 0;
    }

    public void OnSmash()
    {
       
    }

    public void OnUp()
    {
        
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


}
