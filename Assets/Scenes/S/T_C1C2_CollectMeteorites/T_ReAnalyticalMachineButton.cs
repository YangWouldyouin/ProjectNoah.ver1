using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ReAnalyticalMachineButton : MonoBehaviour, IInteraction
{

    /*연관있는 오브젝트*/
    public GameObject T_RealNormalMeteor1;
    public GameObject T_RealImportantMeteor;
    public GameObject T_RealAnalyticalMachine;
    //public GameObject T_RealAnalyticalMachinePlate;

    /*오브젝트의 상호작용 버튼들*/
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
        /*항상 운석을 수집기에 넣기 전 노아의 후각을 통해 운석의 상태를 검증하는 단계가 필요하다는 식으로
         운석 냄새를 먼저 맡아야 된다는 것을 AI가 알려준다.*/

        //높이가 되면 수집기계의 가운데 버튼을 켜준다.
        if (realAnalyticalMachineButtonData_T.IsCollision && GameManager.gameManager._gameData.IsIsReallySmellDone_T_C2)
        {
            realAnalyticalMachineButtonData_T.IsNotInteractable = false; // 상호작용 가능하게
            realAnalyticalMachineButtonOutline_T.OutlineWidth = 8;

            realAnalyticalMachineData_T.IsCenterButtonDisabled = false;
        }
        else if (!realAnalyticalMachineButtonData_T.IsCollision)
        {
            realAnalyticalMachineButtonData_T.IsNotInteractable = true; // 상호작용 불가능하게
            realAnalyticalMachineButtonOutline_T.OutlineWidth = 0;

            realAnalyticalMachineData_T.IsCenterButtonDisabled = true;
        }

        if(GameManager.gameManager._gameData.IsAnalyticalMachineOpen)
        {
            realAnalyticalMachineData_T.IsNotInteractable = false; // 상호작용 가능하게
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

        realAnalyticalMachineData_T.IsNotInteractable = false; // 상호작용 가능하게
        realAnalyticalMachineOutline_T.OutlineWidth = 8;

        realAnalyticalMachine_Collider.enabled = true;

        //운석 분석기 열린거 저장
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
