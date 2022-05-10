using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ReMeteorButton : MonoBehaviour, IInteraction
{
    public bool MeteorMissionEnd = false;

    /*시간 알림*/
    public InGameTime inGameTime;

    /*연관있는 오브젝트*/
    public GameObject T_canMeteorCollectMachine_T;
    public GameObject T_canNormalMeteor1_T;
    public GameObject T_canImportantMeteor_T;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_MeteorButton_T, sniffButton_T_MeteorButton_T, biteButton_T_MeteorButton_T,
        pressButton_T_MeteorButton_T, noCenterButton_T_MeteorButton_T;

    /*ObjData*/
    ObjData T_meteorButtonObjData_T;
    public ObjectData T_meteorButtonData_T;

    public ObjectData T_canMeteorCollectMachineData_T;
    public ObjectData T_canNormalMeteor1Data_T;
    public ObjectData T_canImportantMeteorData_T;

    /*Outline*/
    Outline T_canMeteorCollectMachineOutline_T;
    Outline T_meteorButtonOutline_T;

    /*Animator*/
    public Animator T_meteorBoxAnim_T;

    /*Collider*/
    BoxCollider T_collectMachineCollider;

    public GameObject dialog;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        /*Collider*/
        T_collectMachineCollider = T_canMeteorCollectMachine_T.GetComponent<BoxCollider>();

        /*ObjData*/
        T_meteorButtonObjData_T = GetComponent<ObjData>();

        /*Outline*/
        T_canMeteorCollectMachineOutline_T = T_canMeteorCollectMachine_T.GetComponent<Outline>();
        T_meteorButtonOutline_T = GetComponent<Outline>();

        /*버튼 연결*/
        barkButton_T_MeteorButton_T = T_meteorButtonObjData_T.BarkButton;
        barkButton_T_MeteorButton_T.onClick.AddListener(OnBark);

        sniffButton_T_MeteorButton_T = T_meteorButtonObjData_T.SniffButton;
        sniffButton_T_MeteorButton_T.onClick.AddListener(OnSniff);

        biteButton_T_MeteorButton_T = T_meteorButtonObjData_T.BiteButton;

        pressButton_T_MeteorButton_T = T_meteorButtonObjData_T.PushOrPressButton;
        pressButton_T_MeteorButton_T.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_MeteorButton_T = T_meteorButtonObjData_T.CenterButton1;


        /*임무 시작*/
        //시간이 되면 
        GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (GameManager.gameManager._gameData.IsStartCollectMeteorites)
        {
            //C-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }

    }

    void DisableButton()
    {
        barkButton_T_MeteorButton_T.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorButton_T.transform.gameObject.SetActive(false);
        biteButton_T_MeteorButton_T.transform.gameObject.SetActive(false);
        pressButton_T_MeteorButton_T.transform.gameObject.SetActive(false);
        noCenterButton_T_MeteorButton_T.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        //높이가 된다면 가운데 버튼이 활성화
        if (T_meteorButtonData_T.IsCollision)
        {
            T_meteorButtonData_T.IsNotInteractable = false; // 상호작용 가능하게
            T_meteorButtonOutline_T.OutlineWidth = 8;

            T_canMeteorCollectMachineData_T.IsCenterButtonChanged = false;
        }

        else if (!T_meteorButtonData_T.IsCollision)
        {
            T_meteorButtonData_T.IsNotInteractable = true; // 상호작용 가능하게
            T_meteorButtonOutline_T.OutlineWidth = 0;

            T_canMeteorCollectMachineData_T.IsCenterButtonChanged = true;
        }

        if ((inGameTime.days + 1) % 2 != 8 && (inGameTime.hours) == 30 && MeteorMissionEnd == false)
        {
            Debug.Log("운석 수집 정기 업무 시작");
            GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //C-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            //지예야 대사에 만약 오랜학습을 통해 먼저 임무를 선행했다면 다음 임무를 준비하라고 쓰는 게 좋을거 같은디
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(42));

            MeteorMissionEnd = true;
        }
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

        //C-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(43));

        T_canMeteorCollectMachineData_T.IsNotInteractable = false; // 상호작용 가능하게
        T_canMeteorCollectMachineOutline_T.OutlineWidth = 8;

        T_collectMachineCollider.enabled = true;

        Debug.Log("아 문이 열릴겁니다.");
        T_meteorBoxAnim_T.SetBool("isMeteorBoxOpen", true);
        T_meteorBoxAnim_T.SetBool("isMeteorBoxOpenEnd", true);
    }

    public void OnSniff()
    {
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
