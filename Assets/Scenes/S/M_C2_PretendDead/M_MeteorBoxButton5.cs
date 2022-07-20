using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton5 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton5 = false;

    /*연관있는 오브젝트*/
    public GameObject M_Box_Obj7;
    //public GameObject M_Noah_Obj7;
    public GameObject M_IsMeteoritesStorage5;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton5, sniffButton_M_MeteorBoxButton5, biteButton_M_MeteorBoxButton5,
        pressButton_M_MeteorBoxButton5, noCenterButton_M_MeteorBoxButton5;


    /*ObjData*/
    ObjData MeteorBoxButton5ObjData_M;
    public ObjectData MeteorBoxButton5Data_M;

    public ObjectData Box_Obj7Data_M;
    public ObjectData IsMeteoritesStorage5Data_M;


    /*Outline*/
    Outline IsMeteoritesStorage5Outline_M;
    Outline MeteorBoxButton5Outline_M;

    /*애니메이션*/
    public Animator meteorBox5Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton5_Collider;
    BoxCollider Box7_Collider;
    //BoxCollider Noah7_Collider;
    BoxCollider IsMeteoritesStorage5_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton5_Collider = GetComponent<BoxCollider>();
        Box7_Collider = M_Box_Obj7.GetComponent<BoxCollider>();
        //Noah7_Collider = M_Noah_Obj7.GetComponent<BoxCollider>();
        IsMeteoritesStorage5_Collider = M_IsMeteoritesStorage5.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage5Outline_M = M_IsMeteoritesStorage5.GetComponent<Outline>();
        MeteorBoxButton5Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton5ObjData_M = GetComponent<ObjData>();

        /*버튼 연결*/
        barkButton_M_MeteorBoxButton5 = MeteorBoxButton5ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton5.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton5 = MeteorBoxButton5ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton5.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton5 = MeteorBoxButton5ObjData_M.BiteButton;
        biteButton_M_MeteorBoxButton5.onClick.AddListener(OnBite);

        pressButton_M_MeteorBoxButton5 = MeteorBoxButton5ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton5.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton5 = MeteorBoxButton5ObjData_M.CenterButton1;

        /*선언시작*/
        //IsMeteoritesStorage5Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage5Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Box_Obj7Data_M.IsUpDown)
        {
            Box7_Collider.enabled = false;
            MeteorBoxButton5_Collider.enabled = true;
        }
        else
        {
            Box7_Collider.enabled = true;
            MeteorBoxButton5_Collider.enabled = false;
            MeteorBoxButton5Data_M.IsCollision = false;
        }

        /*버튼에 부딪히면 버튼에 상호작용 가능*/
        if (MeteorBoxButton5Data_M.IsCollision && GameManager.gameManager._gameData.IsStartPretendDead)
        {
            MeteorBoxButton5Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
            MeteorBoxButton5Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage5Data_M.IsCenterButtonDisabled = false;  // 관찰하기 활성화
        }
        else
        {
            MeteorBoxButton5Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton5Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage5Data_M.IsCenterButtonDisabled = true; // 관찰하기 비 활성화
        }


        /*운석 보관함에 관찰하기를 하면*/
        if (IsMeteoritesStorage5Data_M.IsObserve)
        {
            IsMeteoritesStorage5_Collider.enabled = false;

            //Noah7_Collider.enabled = false; // 노아 콜라이더도 꺼준다.

            MeteorBoxButton5Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton5Outline_M.OutlineWidth = 0;

            MeteorBoxButton5_Collider.enabled = false;

        }

        /*운석 보관함에 관찰하면 && 버튼을 1번이라도 클릭했다면,
          항상 켜지는 거 방지로 조건을 하나 더*/
        else if (!IsMeteoritesStorage5Data_M.IsObserve && IsClickMeteorBoxButton5 == true)
        {
            IsMeteoritesStorage5_Collider.enabled = true;

            //Noah7_Collider.enabled = true;

            MeteorBoxButton5_Collider.enabled = true;
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

        Invoke("OpenMeteorBox5", 2f);

    }

    void OpenMeteorBox5()
    {
        meteorBox5Anim_M.SetBool("isMeteorBox5Open", true);
        meteorBox5Anim_M.SetBool("isMeteorBox5End", true);

        IsMeteoritesStorage5Data_M.IsNotInteractable = false; // 박스에 상호작용 가능하게
        IsMeteoritesStorage5Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton5 = true;

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
