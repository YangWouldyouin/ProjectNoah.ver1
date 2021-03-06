using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton1 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton1 = false;

    /*연관있는 오브젝트*/
    public GameObject M_Box_Obj3;
    //public GameObject M_Noah_Obj3;
    public GameObject M_IsMeteoritesStorage1;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton1, sniffButton_M_MeteorBoxButton1, biteButton_M_MeteorBoxButton1,
        pressButton_M_MeteorBoxButton1, noCenterButton_M_MeteorBoxButton1;

    /*ObjData*/
    ObjData meteorBoxButton1ObjData_M;
    public ObjectData meteorBoxButton1Data_M;

    public ObjectData Box_Obj3Data_M;
    public ObjectData IsMeteoritesStorage1Data_M;


    /*Outline*/
    Outline IsMeteoritesStorage1Outline_M;
    public Outline MeteorBoxButton1Outline_M;

    /*애니메이션*/
    public Animator meteorBox1Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton1_Collider;
    BoxCollider Box3_Collider;
    //BoxCollider Noah3_Collider;
    BoxCollider IsMeteoritesStorage1_Collider;

    public GameObject dialog_CS;


    void Start()
    {


        /*Collider*/
        MeteorBoxButton1_Collider = GetComponent<BoxCollider>();
        Box3_Collider = M_Box_Obj3.GetComponent<BoxCollider>();
        //Noah3_Collider = M_Noah_Obj3.GetComponent<BoxCollider>();
        IsMeteoritesStorage1_Collider = M_IsMeteoritesStorage1.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage1Outline_M = M_IsMeteoritesStorage1.GetComponent<Outline>();
        //MeteorBoxButton1Outline_M = GetComponent<Outline>();


        /*ObjData*/
        meteorBoxButton1ObjData_M = GetComponent<ObjData>();

        /*버튼 연결*/
        barkButton_M_MeteorBoxButton1 = meteorBoxButton1ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton1.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton1 = meteorBoxButton1ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton1.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton1 = meteorBoxButton1ObjData_M.BiteButton;
        biteButton_M_MeteorBoxButton1.onClick.AddListener(OnBite);

        pressButton_M_MeteorBoxButton1 = meteorBoxButton1ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton1.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton1 = meteorBoxButton1ObjData_M.CenterButton1;

        /*선언시작*/
        //IsMeteoritesStorage1Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage1Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Box_Obj3Data_M.IsUpDown)
        {
            Box3_Collider.enabled = false;
            MeteorBoxButton1_Collider.enabled = true;
        }
        else
        {
            Box3_Collider.enabled = true;
            MeteorBoxButton1_Collider.enabled = false;
            meteorBoxButton1Data_M.IsCollision = false;
        }

        /*버튼에 부딪히면 버튼에 상호작용 가능*/
        if(meteorBoxButton1Data_M.IsCollision && GameManager.gameManager._gameData.IsStartPretendDead)
        {
            meteorBoxButton1Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
            MeteorBoxButton1Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage1Data_M.IsCenterButtonDisabled = false;  // 관찰하기 활성화
        }
        else
        {
            meteorBoxButton1Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton1Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage1Data_M.IsCenterButtonDisabled = true; // 관찰하기 비 활성화
        }


        /*운석 보관함에 관찰하기를 하면*/
        if (IsMeteoritesStorage1Data_M.IsObserve)
        {
            IsMeteoritesStorage1_Collider.enabled = false;

            //Noah3_Collider.enabled = false; // 노아 콜라이더도 꺼준다.

            meteorBoxButton1Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton1Outline_M.OutlineWidth = 0;

            MeteorBoxButton1_Collider.enabled = false;

        }

        /*운석 보관함에 관찰하면 && 버튼을 1번이라도 클릭했다면,
          항상 켜지는 거 방지로 조건을 하나 더*/
        else if (!IsMeteoritesStorage1Data_M.IsObserve && IsClickMeteorBoxButton1==true)
        {
            IsMeteoritesStorage1_Collider.enabled = true;

            //Noah3_Collider.enabled = true;

            MeteorBoxButton1_Collider.enabled = true;
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

        Invoke("OpenMeteorBox", 2f);
    }

    void OpenMeteorBox()
    {
        meteorBox1Anim_M.SetBool("isMeteorBox1Open", true);
        meteorBox1Anim_M.SetBool("isMeteorBox1End", true);

        IsMeteoritesStorage1Data_M.IsNotInteractable = false; // 박스에 상호작용 가능하게
        IsMeteoritesStorage1Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton1 = true;

/*     MeteorBoxButton1Data_M.IsNotInteractable = true; // 버튼에 두번 다시 상호작용 못하게
        MeteorBoxButton1Outline_M.OutlineWidth = 0;*/

        //IsMeteoritesStorage1_Collider.enabled = true;
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
