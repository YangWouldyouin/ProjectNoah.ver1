using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*�������� �ռ�
    �ڽ��� �ö󰡸� �ڽ� �ݶ��̴��� ���ش�. ��ư �ݶ��̴��� ���ش�. -> � ������ ��ư�� ������ 
    -> � �������� �ݶ��̴��� ������. -> � �����⿡ �����ϱ⸦ �ϸ�-> ��ư�� � ������, ����� �ݶ��̴��� ������. ->���� �ٽ� ������ � �ݶ��̴��� ������. */

public class T_MeteorCollectMachine : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject T_DoNormalMeteor1;
    public GameObject T_DoImportantMeteor;
    public GameObject T_DoMeteorButton;
    public GameObject T_Box_Obj;
    public GameObject T_Noah_Obj;

    public GameObject T_AnalyticalButton;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_MeteorCollectMachine, sniffButton_T_MeteorCollectMachine, biteButton_T_MeteorCollectMachine,
        pressButton_T_MeteorCollectMachine, observeButton_T_MeteorCollectMachine, observeDisableButton_T_MeteorCollectMachine;

    /*ObjData*/
    ObjData meteorCollectMachineObjData_T;
    public ObjectData meteorCollectMachineData_T;

    public ObjectData doNormalMeteor1Data_T;
    public ObjectData doImportantMeteorData_T;
    public ObjectData doMeteorButtonData_T;
    public ObjectData Box_ObjData_T;

    /*Outline*/
    Outline meteorCollectMachineOutline_T;
    Outline doNormalMeteor1Outline_T;
    Outline doImportantMeteorOutline_T;
    Outline doMeteorButtonOutline_T;

    /*Collider*/
    BoxCollider IScollectMachine_Collider;
    BoxCollider Box_Collider;
    BoxCollider MeteorButton_Collider;
    BoxCollider Noah_Collider;
    BoxCollider AnalyticalButton_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        IScollectMachine_Collider = GetComponent<BoxCollider>();
        Box_Collider = T_Box_Obj.GetComponent<BoxCollider>();
        MeteorButton_Collider = T_DoMeteorButton.GetComponent<BoxCollider>();
        Noah_Collider = T_Noah_Obj.GetComponent<BoxCollider>();
        AnalyticalButton_Collider = T_AnalyticalButton.GetComponent<BoxCollider>();

        /*ObjData*/
        meteorCollectMachineObjData_T = GetComponent<ObjData>();

        /*Outline*/
        meteorCollectMachineOutline_T = GetComponent<Outline>();
        doNormalMeteor1Outline_T = T_DoNormalMeteor1.GetComponent<Outline>();
        doImportantMeteorOutline_T = T_DoImportantMeteor.GetComponent<Outline>();
        doMeteorButtonOutline_T = T_DoMeteorButton.GetComponent<Outline>();

        barkButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.BarkButton;
        barkButton_T_MeteorCollectMachine.onClick.AddListener(OnBark);

        sniffButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.SniffButton;
        sniffButton_T_MeteorCollectMachine.onClick.AddListener(OnSniff);

        biteButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.PushOrPressButton;
        pressButton_T_MeteorCollectMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.CenterButton1;
        observeButton_T_MeteorCollectMachine.onClick.AddListener(OnObserve);

        observeDisableButton_T_MeteorCollectMachine = meteorCollectMachineObjData_T.CenterButton2;
    }

    void Update()
    {
        //�����ϱ� ���°� �ƴ϶�� �ݶ��̴� ������ ���ش�.
        if(!meteorCollectMachineData_T.IsObserve)
        {
            //Box_Collider.enabled = true;
          
        }

        //� �����⿡ �����ϱ� ���̶��
        if(meteorCollectMachineData_T.IsObserve)
        {
            doMeteorButtonData_T.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            doMeteorButtonOutline_T.OutlineWidth = 0;

            IScollectMachine_Collider.enabled = false; // � ������ �ݶ��̴��� ���ش�.
            Noah_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.
            //Debug.Log("false");
        }

        if(Box_ObjData_T.IsUpDown)
        {
            Box_Collider.enabled = false;
            //collectMachineCollider.enabled = true;
            MeteorButton_Collider.enabled = true;
            AnalyticalButton_Collider.enabled = true;

        }
        else
        {
            Box_Collider.enabled = true;
            //collectMachineCollider.enabled = false;
            MeteorButton_Collider.enabled = false;
            AnalyticalButton_Collider.enabled = false;
        }
    }

    void DisableButton()
    {
        barkButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        biteButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        pressButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        observeButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        observeDisableButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
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

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteorCollectMachineObjData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        //�ݶ��̴� ���� ����
        IScollectMachine_Collider.enabled = false;
        //Box_Collider.enabled = false;
        MeteorButton_Collider.enabled = false;

        doNormalMeteor1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        doNormalMeteor1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        doImportantMeteorData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        doImportantMeteorOutline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        meteorCollectMachineData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
        meteorCollectMachineOutline_T.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

   



        if(doImportantMeteorData_T.IsBite)
        {
            //CameraController.cameraController.CancelObserve();

            GameManager.gameManager._gameData.IsBiteimportantMeteor_T_C2 = true;

        }

        if (doNormalMeteor1Data_T.IsBite)
        {
            //CameraController.cameraController.CancelObserve();

            GameManager.gameManager._gameData.IsBiteNormalMeteor1_T_C2 = true;

        }

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
