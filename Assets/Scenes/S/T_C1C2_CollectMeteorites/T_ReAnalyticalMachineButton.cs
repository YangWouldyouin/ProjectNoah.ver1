using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ReAnalyticalMachineButton : MonoBehaviour, IInteraction
{

    /*�����ִ� ������Ʈ*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    public GameObject T_RealAnalyticalMachine;
    //public GameObject T_RealAnalyticalMachinePlate;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_RealAnalyticalMachineButton, sniffButton_T_RealAnalyticalMachineButton, 
        biteButton_T_RealAnalyticalMachineButton,
        pressButton_T_RealAnalyticalMachineButton, noCenterButton_T_RealAnalyticalMachineButton;


    /*ObjData*/
    ObjData realAnalyticalMachineButtonObjData_T;
    public ObjectData realAnalyticalMachineButtonData_T;

    public ObjectData realNormalMeteor1Data_T;
    public ObjectData realImportantMeteorData_T;
    public ObjectData realAnalyticalMachineData_T;


    /*Outline*/
    Outline realAnalyticalMachineButtonOutline_T;
    Outline realAnalyticalMachineOutline_T;
    //Outline areNormalMeteor1Outline_T;
    //Outline areimportantMeteorOutline_T;

    /*Animator*/
    public Animator realAnalyticalMachineAnim_T;

    /*Collider*/
    BoxCollider realAnalyticalMachine_Collider;
    //BoxCollider realAnalyticalMachinePlate_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        realAnalyticalMachine_Collider = T_RealAnalyticalMachine.GetComponent<BoxCollider>();
        //realAnalyticalMachinePlate_Collider = T_RealAnalyticalMachinePlate.GetComponent<BoxCollider>();

        /*ObjData*/
        realAnalyticalMachineButtonObjData_T = GetComponent<ObjData>();

        /*Outline*/
        realAnalyticalMachineButtonOutline_T = GetComponent<Outline>();
        realAnalyticalMachineOutline_T = T_RealAnalyticalMachine.GetComponent<Outline>();
        //areNormalMeteor1Outline_T = T_RealNormalMeteor1.GetComponent<Outline>();
        //areimportantMeteorOutline_T = T_RealImportantMeteor.GetComponent<Outline>();


        barkButton_T_RealAnalyticalMachineButton = realAnalyticalMachineButtonObjData_T.BarkButton;
        barkButton_T_RealAnalyticalMachineButton.onClick.AddListener(OnBark);

        sniffButton_T_RealAnalyticalMachineButton = realAnalyticalMachineButtonObjData_T.SniffButton;
        sniffButton_T_RealAnalyticalMachineButton.onClick.AddListener(OnSniff);

        biteButton_T_RealAnalyticalMachineButton = realAnalyticalMachineButtonObjData_T.BiteButton;
        biteButton_T_RealAnalyticalMachineButton.onClick.AddListener(OnBite);

        pressButton_T_RealAnalyticalMachineButton = realAnalyticalMachineButtonObjData_T.PushOrPressButton;
        pressButton_T_RealAnalyticalMachineButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_RealAnalyticalMachineButton = realAnalyticalMachineButtonObjData_T.CenterButton1;
    }

    void Update()
    {
        /*�׻� ��� �����⿡ �ֱ� �� ����� �İ��� ���� ��� ���¸� �����ϴ� �ܰ谡 �ʿ��ϴٴ� ������
         � ������ ���� �þƾ� �ȴٴ� ���� AI�� �˷��ش�.*/

        //���̰� �Ǹ� ��������� ��� ��ư�� ���ش�.
        if (realAnalyticalMachineButtonData_T.IsCollision && GameManager.gameManager._gameData.IsIsReallySmellDone_T_C2)
        {
            realAnalyticalMachineButtonData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            realAnalyticalMachineButtonOutline_T.OutlineWidth = 8;

            realAnalyticalMachineData_T.IsCenterButtonDisabled = false;
        }
        else if (!realAnalyticalMachineButtonData_T.IsCollision)
        {
            realAnalyticalMachineButtonData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            realAnalyticalMachineButtonOutline_T.OutlineWidth = 0;

            realAnalyticalMachineData_T.IsCenterButtonDisabled = true;
        }

        if(GameManager.gameManager._gameData.IsAnalyticalMachineOpen)
        {
            realAnalyticalMachineData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            realAnalyticalMachineOutline_T.OutlineWidth = 8;

            realAnalyticalMachine_Collider.enabled = true;
        }
    }

    void DisableButton()
    {
        barkButton_T_RealAnalyticalMachineButton.transform.gameObject.SetActive(false);
        sniffButton_T_RealAnalyticalMachineButton.transform.gameObject.SetActive(false);
        biteButton_T_RealAnalyticalMachineButton.transform.gameObject.SetActive(false);
        pressButton_T_RealAnalyticalMachineButton.transform.gameObject.SetActive(false);
        noCenterButton_T_RealAnalyticalMachineButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        realAnalyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", true);
        realAnalyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", true);

        realAnalyticalMachineData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        realAnalyticalMachineOutline_T.OutlineWidth = 8;

        realAnalyticalMachine_Collider.enabled = true;

        //� �м��� ������ ����
        GameManager.gameManager._gameData.IsAnalyticalMachineOpen = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
