using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Table1 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public Vector3 Table1RisePos;
    public GameObject PackOnTable1;
    public GameObject Beaker1OnTable1;
    public GameObject Beaker2OnTable1;
    public GameObject cylinder1OnTable1;
    public GameObject cylinder2OnTable1;
    public GameObject cylinder3OnTable1;
    public GameObject cylinder4OnTable1;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Table1, sniffButton_M_Table1,
        biteButton_M_Table1, pressButton_M_Table1, upButton_M_Table1,
        upDisableButton_M_Table1, observeButton_M_Table1;

    /*ObjData*/
    ObjData table1ObjData_M;
    public ObjectData table1Data_M;
    public ObjectData canPackData_M;

    /*Outline*/
    public Outline canPackOutline_M;

    /*Collider*/
    BoxCollider Table1_Collider;
    BoxCollider PackOnTable1_Collider;
    BoxCollider Beaker1OnTable1_Collider;
    BoxCollider Beaker2OnTable1_Collider;
    BoxCollider cylinder1OnTable1_Collider;
    BoxCollider cylinder2OnTable1_Collider;
    BoxCollider cylinder3OnTable1_Collider;
    BoxCollider cylinder4OnTable1_Collider;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        table1ObjData_M = GetComponent<ObjData>();

        /*Collider*/
        Table1_Collider = GetComponent<BoxCollider>();
        PackOnTable1_Collider = PackOnTable1.GetComponent<BoxCollider>();
        Beaker1OnTable1_Collider = Beaker1OnTable1.GetComponent<BoxCollider>();
        Beaker2OnTable1_Collider = Beaker2OnTable1.GetComponent<BoxCollider>();
        cylinder1OnTable1_Collider = cylinder1OnTable1.GetComponent<BoxCollider>();
        cylinder2OnTable1_Collider = cylinder2OnTable1.GetComponent<BoxCollider>();
        cylinder3OnTable1_Collider = cylinder3OnTable1.GetComponent<BoxCollider>();
        cylinder4OnTable1_Collider = cylinder4OnTable1.GetComponent<BoxCollider>();

        /*��ư ����*/
        barkButton_M_Table1 = table1ObjData_M.BarkButton;
        barkButton_M_Table1.onClick.AddListener(OnBark);

        sniffButton_M_Table1 = table1ObjData_M.SniffButton;
        sniffButton_M_Table1.onClick.AddListener(OnSniff);

        biteButton_M_Table1 = table1ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Table1 = table1ObjData_M.PushOrPressButton;
        pressButton_M_Table1.onClick.AddListener(OnPushOrPress);

        upButton_M_Table1 = table1ObjData_M.CenterButton1;
        upButton_M_Table1.onClick.AddListener(OnUp);

        observeButton_M_Table1 = table1ObjData_M.CenterButton2;
        observeButton_M_Table1.onClick.AddListener(OnObserve);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        upDisableButton_M_Table1 = table1ObjData_M.CenterDisableButton1;


        /*�������*/

        table1Data_M.IsUpDown = false;
        table1Data_M.IsObserve = false;
        table1Data_M.IsCollision = false;

        PackOnTable1_Collider.enabled = false;
        Beaker1OnTable1_Collider.enabled = false;
        Beaker2OnTable1_Collider.enabled = false;
        cylinder1OnTable1_Collider.enabled = false;
        cylinder2OnTable1_Collider.enabled = false;
        cylinder3OnTable1_Collider.enabled = false;
        cylinder4OnTable1_Collider.enabled = false;
    }

    void Update()
    {
        if(table1Data_M.IsClicked)
        {
            //B-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(22));
        }

        /*����� ���̰� å�� �ö� ���̰� �Ǵ��� Ȯ��*/
        if (table1Data_M.IsCollision)
        {
            table1Data_M.IsCenterButtonDisabled = false;
        }

        else if (table1Data_M.IsUpDown)
        {
            table1Data_M.IsCenterButtonDisabled = false;
        }

        else
        {
            table1Data_M.IsCenterButtonDisabled = true;
        }


        if(table1Data_M.IsUpDown==false)
        {
            table1Data_M.IsCenterButtonChanged = false;

            /*            canPackData_M.IsNotInteractable = true;
                        canPackOutline_M.OutlineWidth = 0;*/
        }

        else
        {
            table1Data_M.IsCenterButtonChanged = true;

            canPackData_M.IsNotInteractable = false;
            canPackOutline_M.OutlineWidth = 8;
        }

        if(table1Data_M.IsObserve)
        {
            Table1_Collider.enabled = false;
        }

        else
        {
            Table1_Collider.enabled = true;
        }

        if(canPackData_M.IsBite)
        {
            canPackData_M.IsNotInteractable = false;
            canPackOutline_M.OutlineWidth = 8;
        }
    }


    void DisableButton()
    {
        barkButton_M_Table1.transform.gameObject.SetActive(false);
        sniffButton_M_Table1.transform.gameObject.SetActive(false);
        biteButton_M_Table1.transform.gameObject.SetActive(false);
        pressButton_M_Table1.transform.gameObject.SetActive(false);
        observeButton_M_Table1.transform.gameObject.SetActive(false);
        upButton_M_Table1.transform.gameObject.SetActive(false);
        upDisableButton_M_Table1.transform.gameObject.SetActive(false);
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

        table1Data_M.IsCenterButtonChanged = true;

        //Invoke("changeObserve", 3f);

        table1Data_M.IsObserve = false; //�� �����⸸ �޴µ� �����ϱⰡ �˾Ƽ� üũ �Ǳ淡 �־��ذ�

        //B-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(23));

        /*å�� ���� �ö󰡸� å�� �� ������Ʈ�� ��ȣ�ۿ� �����ϵ���*/
        PackOnTable1_Collider.enabled = true;
        Beaker1OnTable1_Collider.enabled = true;
        Beaker2OnTable1_Collider.enabled = true;
        cylinder1OnTable1_Collider.enabled = true;
        cylinder2OnTable1_Collider.enabled = true;
        cylinder3OnTable1_Collider.enabled = true;
        cylinder4OnTable1_Collider.enabled = true;

        /*���̺� �� �ö����� �����ؼ� ���� �����ѵ� ���̺� �� ���ǵ� �׻� ��ȣ�ۿ� �����ϰ�*/
        GameManager.gameManager._gameData.IsUpTable1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (!table1Data_M.IsUpDown)
        {
            //table1Data_M.IsCenterButtonChanged = false;

            /* ������ ����� �� �����ϱ� ���� ������Ʈ ���� */
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* ������Ʈ�� ������ ���� true �� �ٲ� */
            table1Data_M.IsUpDown = true;

            /* ���� ��ư� �̵��� ������ ��ġ ��ǥ�� x, z ���� ���� */
            Table1RisePos.x = table1ObjData_M.UpPos.position.x;
            Table1RisePos.z = table1ObjData_M.UpPos.position.z;

            /* ������ �ִϸ��̼� 1/2 ���� */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* ������ ��ġ ��ǥ�� ���� */
            InteractionButtonController.interactionButtonController.risePosition = Table1RisePos;
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
        table1Data_M.IsCenterButtonChanged = true;
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = table1ObjData_M.ObserveView;

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
