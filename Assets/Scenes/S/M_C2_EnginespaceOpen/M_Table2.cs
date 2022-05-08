using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Table2 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public Vector3 Table2RisePos;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Table2, sniffButton_M_Table2,
        biteButton_M_Table2, pressButton_M_Table2, upButton_M_Table2,
        upDisableButton_M_Table2, observeButton_M_Table2;

    /*ObjData*/
    ObjData table2ObjData_M;
    public ObjectData table2Data_M;
    public ObjectData superDrugData_M;
    public ObjectData smartFormLine2Data_M;
    public ObjectData brokenDoorConduction_M;


    /*Outline*/
    public Outline superDrugOutline_M;
    public Outline smartFormLine2Outline_M;
    public Outline brokenDoorConductionOutline_M;

    /*Collider*/
    BoxCollider Table2_Collider;

    void Start()
    {
        /*ObjData*/
        table2ObjData_M = GetComponent<ObjData>();

        /*Collider*/
        Table2_Collider = GetComponent<BoxCollider>();

        /*��ư ����*/
        barkButton_M_Table2 = table2ObjData_M.BarkButton;
        barkButton_M_Table2.onClick.AddListener(OnBark);

        sniffButton_M_Table2 = table2ObjData_M.SniffButton;
        sniffButton_M_Table2.onClick.AddListener(OnSniff);

        biteButton_M_Table2 = table2ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Table2 = table2ObjData_M.PushOrPressButton;
        pressButton_M_Table2.onClick.AddListener(OnPushOrPress);

        upButton_M_Table2 = table2ObjData_M.CenterButton1;
        upButton_M_Table2.onClick.AddListener(OnUp);

        observeButton_M_Table2 = table2ObjData_M.CenterButton2;
        observeButton_M_Table2.onClick.AddListener(OnObserve);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        upDisableButton_M_Table2 = table2ObjData_M.CenterDisableButton1;
    }

    void Update()
    {
        if(table2Data_M.IsClicked)
        {
            //B-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }

        /*����� ���̰� å�� �ö� ���̰� �Ǵ��� Ȯ��*/
        if (table2Data_M.IsCollision)
        {
            table2Data_M.IsCenterButtonDisabled = false;
        }

        else if (table2Data_M.IsUpDown)
        {
            table2Data_M.IsCenterButtonDisabled = false;
        }

        else
        {
            table2Data_M.IsCenterButtonDisabled = true;
        }


        if(table2Data_M.IsUpDown==false)
        {
            table2Data_M.IsCenterButtonChanged = false;

            //B-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�

            /*            canPackData_M.IsNotInteractable = true;
                        canPackOutline_M.OutlineWidth = 0;*/
        }

        else
        {
            table2Data_M.IsCenterButtonChanged = true;

            superDrugData_M.IsNotInteractable = false;
            superDrugOutline_M.OutlineWidth = 8;

            smartFormLine2Data_M.IsNotInteractable = false;
            smartFormLine2Outline_M.OutlineWidth = 8;

            brokenDoorConduction_M.IsNotInteractable = false;
            brokenDoorConductionOutline_M.OutlineWidth = 8;
        }

        if(table2Data_M.IsObserve)
        {
            Table2_Collider.enabled = false;
        }

        else
        {
            Table2_Collider.enabled = true;
        }

        if(superDrugData_M.IsBite)
        {
            superDrugData_M.IsNotInteractable = false;
            superDrugOutline_M.OutlineWidth = 8;
        }

        if (smartFormLine2Data_M.IsBite)
        {
            smartFormLine2Data_M.IsNotInteractable = false;
            smartFormLine2Outline_M.OutlineWidth = 8;
        }


        if (brokenDoorConduction_M.IsBite)
        {
            brokenDoorConduction_M.IsNotInteractable = false;
            brokenDoorConductionOutline_M.OutlineWidth = 8;
        }
    }


    void DisableButton()
    {
        barkButton_M_Table2.transform.gameObject.SetActive(false);
        sniffButton_M_Table2.transform.gameObject.SetActive(false);
        biteButton_M_Table2.transform.gameObject.SetActive(false);
        pressButton_M_Table2.transform.gameObject.SetActive(false);
        observeButton_M_Table2.transform.gameObject.SetActive(false);
        upButton_M_Table2.transform.gameObject.SetActive(false);
        upDisableButton_M_Table2.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }



    public void OnBite()
    {
      
    }


    public void OnUp()
    {
        DisableButton();

        table2Data_M.IsCenterButtonChanged = true;

        //Invoke("changeObserve", 3f);

        table2Data_M.IsObserve = false; //�� �����⸸ �޴µ� �����ϱⰡ �˾Ƽ� üũ �Ǳ淡 �־��ذ�


        if (!table2Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = false;

            /* ������ ����� �� �����ϱ� ���� ������Ʈ ���� */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* ������Ʈ�� ������ ���� true �� �ٲ� */
            table2Data_M.IsUpDown = true;

            /* ���� ��ư� �̵��� ������ ��ġ ��ǥ�� x, z ���� ���� */
            Table2RisePos.x = table2ObjData_M.UpPos.position.x;
            Table2RisePos.z = table2ObjData_M.UpPos.position.z;

            /* ������ �ִϸ��̼� 1/2 ���� */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* ������ ��ġ ��ǥ�� ���� */
            InteractionButtonController.interactionButtonController.risePosition = Table2RisePos;
            /* ������ ������ �ִϸ��̼� ���� */
            InteractionButtonController.interactionButtonController.PlayerRise2();


        }



/*        if (!table1Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = true;
            //Invoke("changeObserve",2f);
        }

        else
        {
            table1Data_M.IsCenterButtonChanged = false;
        }
*/
    }

    void changeObserve()
    {
        table2Data_M.IsCenterButtonChanged = true;
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = table2ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

    }


    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }

}