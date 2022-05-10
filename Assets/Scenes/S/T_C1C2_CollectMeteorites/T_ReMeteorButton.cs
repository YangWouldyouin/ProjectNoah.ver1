using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ReMeteorButton : MonoBehaviour, IInteraction
{
    public bool MeteorMissionEnd = false;

    /*�ð� �˸�*/
    public InGameTime inGameTime;

    /*�����ִ� ������Ʈ*/
    public GameObject T_canMeteorCollectMachine_T;
    public GameObject T_canNormalMeteor1_T;
    public GameObject T_canImportantMeteor_T;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
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

        /*��ư ����*/
        barkButton_T_MeteorButton_T = T_meteorButtonObjData_T.BarkButton;
        barkButton_T_MeteorButton_T.onClick.AddListener(OnBark);

        sniffButton_T_MeteorButton_T = T_meteorButtonObjData_T.SniffButton;
        sniffButton_T_MeteorButton_T.onClick.AddListener(OnSniff);

        biteButton_T_MeteorButton_T = T_meteorButtonObjData_T.BiteButton;

        pressButton_T_MeteorButton_T = T_meteorButtonObjData_T.PushOrPressButton;
        pressButton_T_MeteorButton_T.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_MeteorButton_T = T_meteorButtonObjData_T.CenterButton1;


        /*�ӹ� ����*/
        //�ð��� �Ǹ� 
        GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (GameManager.gameManager._gameData.IsStartCollectMeteorites)
        {
            //C-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
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
        //���̰� �ȴٸ� ��� ��ư�� Ȱ��ȭ
        if (T_meteorButtonData_T.IsCollision)
        {
            T_meteorButtonData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            T_meteorButtonOutline_T.OutlineWidth = 8;

            T_canMeteorCollectMachineData_T.IsCenterButtonChanged = false;
        }

        else if (!T_meteorButtonData_T.IsCollision)
        {
            T_meteorButtonData_T.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            T_meteorButtonOutline_T.OutlineWidth = 0;

            T_canMeteorCollectMachineData_T.IsCenterButtonChanged = true;
        }

        if ((inGameTime.days + 1) % 2 != 8 && (inGameTime.hours) == 30 && MeteorMissionEnd == false)
        {
            Debug.Log("� ���� ���� ���� ����");
            GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //C-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            //������ ��翡 ���� �����н��� ���� ���� �ӹ��� �����ߴٸ� ���� �ӹ��� �غ��϶�� ���� �� ������ ������
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

        //C-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(43));

        T_canMeteorCollectMachineData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        T_canMeteorCollectMachineOutline_T.OutlineWidth = 8;

        T_collectMachineCollider.enabled = true;

        Debug.Log("�� ���� �����̴ϴ�.");
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
