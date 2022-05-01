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
    public GameObject Box_Obj;
    public GameObject Noah_Obj;

    public GameObject T_AnalyticalButton;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_MeteorCollectMachine, sniffButton_T_MeteorCollectMachine, biteButton_T_MeteorCollectMachine,
        pressButton_T_MeteorCollectMachine, observeButton_T_MeteorCollectMachine, observeDisableButton_T_MeteorCollectMachine;

    /*ObjData*/
    ObjData meteorCollectMachineData_T;
    ObjData doNormalMeteor1Data_T;
    ObjData doImportantMeteorData_T;
    ObjData doMeteorButtonData_T;
    ObjData Box_ObjData_T;

    /*Outline*/
    Outline meteorCollectMachineOutline_T;
    Outline doNormalMeteor1Outline_T;
    Outline doImportantMeteorOutline_T;
    Outline doMeteorButtonOutline_T;

    /*Collider*/
    BoxCollider IScollectMachineCollider;
    BoxCollider Box_Collider;
    BoxCollider MeteorButton_Collider;
    BoxCollider Noah_Collider;
    BoxCollider AnalyticalButton_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        IScollectMachineCollider = GetComponent<BoxCollider>();
        Box_Collider = Box_Obj.GetComponent<BoxCollider>();
        MeteorButton_Collider = T_DoMeteorButton.GetComponent<BoxCollider>();
        Noah_Collider = Noah_Obj.GetComponent<BoxCollider>();
        AnalyticalButton_Collider = T_AnalyticalButton.GetComponent<BoxCollider>();

        /*ObjData*/
        meteorCollectMachineData_T = GetComponent<ObjData>();
        doNormalMeteor1Data_T = T_DoNormalMeteor1.GetComponent<ObjData>();
        doImportantMeteorData_T = T_DoImportantMeteor.GetComponent<ObjData>();
        doMeteorButtonData_T = T_DoMeteorButton.GetComponent<ObjData>();
        Box_ObjData_T = Box_Obj.GetComponent<ObjData>();

        /*Outline*/
        meteorCollectMachineOutline_T = GetComponent<Outline>();
        doNormalMeteor1Outline_T = T_DoNormalMeteor1.GetComponent<Outline>();
        doImportantMeteorOutline_T = T_DoImportantMeteor.GetComponent<Outline>();
        doMeteorButtonOutline_T = T_DoMeteorButton.GetComponent<Outline>();

        barkButton_T_MeteorCollectMachine = meteorCollectMachineData_T.BarkButton;
        barkButton_T_MeteorCollectMachine.onClick.AddListener(OnBark);

        sniffButton_T_MeteorCollectMachine = meteorCollectMachineData_T.SniffButton;
        sniffButton_T_MeteorCollectMachine.onClick.AddListener(OnSniff);

        biteButton_T_MeteorCollectMachine = meteorCollectMachineData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorCollectMachine = meteorCollectMachineData_T.PushOrPressButton;
        pressButton_T_MeteorCollectMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_MeteorCollectMachine = meteorCollectMachineData_T.CenterButton1;
        observeButton_T_MeteorCollectMachine.onClick.AddListener(OnObserve);

        observeDisableButton_T_MeteorCollectMachine = meteorCollectMachineData_T.CenterButton2;
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

            IScollectMachineCollider.enabled = false; // � ������ �ݶ��̴��� ���ش�.
            Noah_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.
            Debug.Log("false");
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
    }

    public void OnBark()
    {
        meteorCollectMachineData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        meteorCollectMachineData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        meteorCollectMachineData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteorCollectMachineData_T.IsPushOrPress = false;
    }


    public void OnObserve()
    {
        meteorCollectMachineData_T.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteorCollectMachineData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        //�ݶ��̴� ���� ����
        //collectMachineCollider.enabled = false;
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
            CameraController.cameraController.CancelObserve();

            GameManager.gameManager._gameData.IsBiteimportantMeteor_T_C2 = true;

        }

        if (doNormalMeteor1Data_T.IsBite)
        {
            CameraController.cameraController.CancelObserve();

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
