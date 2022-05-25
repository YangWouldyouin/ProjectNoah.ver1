using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton2 : MonoBehaviour, IInteraction
{

    public bool IsClickMeteorBoxButton2 = false;

    /*연관있는 오브젝트*/
    public GameObject M_Box_Obj4;
    public GameObject M_Noah_Obj4;
    public GameObject M_IsMeteoritesStorage2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton2, sniffButton_M_MeteorBoxButton2, biteButton_M_MeteorBoxButton3,
        pressButton_M_MeteorBoxButton4, noCenterButton_M_MeteorBoxButton5;


    /*ObjData*/
    ObjData MeteorBoxButton2ObjData_M;
    public ObjectData MeteorBoxButton2Data_M;
    public ObjectData Box_Obj4Data_M;
    public ObjectData IsMeteoritesStorage2Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage2Outline_M;
    Outline MeteorBoxButton2Outline_M;

    /*애니메이션*/
    public Animator meteorBox2Anim_M;


    /*Collider*/
    BoxCollider MeteorBoxButton2_Collider;
    BoxCollider Box4_Collider;
    BoxCollider Noah4_Collider;
    BoxCollider IsMeteoritesStorage2_Collider;


    void Start()
    {
        /*Collider*/
        MeteorBoxButton2_Collider = GetComponent<BoxCollider>();
        Box4_Collider = M_Box_Obj4.GetComponent<BoxCollider>();
        Noah4_Collider = M_Noah_Obj4.GetComponent<BoxCollider>();
        IsMeteoritesStorage2_Collider = M_IsMeteoritesStorage2.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage2Outline_M = M_IsMeteoritesStorage2.GetComponent<Outline>();
        MeteorBoxButton2Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton2ObjData_M = GetComponent<ObjData>();

        barkButton_M_MeteorBoxButton2 = MeteorBoxButton2ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton2.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton2 = MeteorBoxButton2ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton2.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton3 = MeteorBoxButton2ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton4 = MeteorBoxButton2ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton4.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton5 = MeteorBoxButton2ObjData_M.CenterButton1;

        /*선언시작*/
        //IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage2Data_M.IsObserve = false;

    }

    void Update()
    {
        if (Box_Obj4Data_M.IsUpDown)
        {
            Box4_Collider.enabled = false;
            MeteorBoxButton2_Collider.enabled = true;
        }
        else
        {
            Box4_Collider.enabled = true;
            MeteorBoxButton2_Collider.enabled = false;
            MeteorBoxButton2Data_M.IsCollision = false;
        }

        /*버튼에 부딪히면 버튼에 상호작용 가능*/
        if (MeteorBoxButton2Data_M.IsCollision)
        {
            MeteorBoxButton2Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
            MeteorBoxButton2Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = false;  // 관찰하기 활성화
        }
        else
        {
            MeteorBoxButton2Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton2Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = true; // 관찰하기 비 활성화
        }


        /*운석 보관함에 관찰하기를 하면*/
        if (IsMeteoritesStorage2Data_M.IsObserve)
        {
            IsMeteoritesStorage2_Collider.enabled = false;

            //Noah4_Collider.enabled = false; // 노아 콜라이더도 꺼준다.

            MeteorBoxButton2Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton2Outline_M.OutlineWidth = 0;

            MeteorBoxButton2_Collider.enabled = false;

        }

        /*운석 보관함에 관찰하면 && 버튼을 1번이라도 클릭했다면,
          항상 켜지는 거 방지로 조건을 하나 더*/
        else if (!IsMeteoritesStorage2Data_M.IsObserve && IsClickMeteorBoxButton2 == true)
        {
            IsMeteoritesStorage2_Collider.enabled = true;

            //Noah4_Collider.enabled = true;

            MeteorBoxButton2_Collider.enabled = true;
        }

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton2.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton2.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
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

        Invoke("OpenMeteorBox2", 2f);
    }


    void OpenMeteorBox2()
    {
        meteorBox2Anim_M.SetBool("isMeteorBox2Open", true);
        meteorBox2Anim_M.SetBool("isMeteorBox2End", true);

        IsMeteoritesStorage2Data_M.IsNotInteractable = false; // 박스에 상호작용 가능하게
        IsMeteoritesStorage2Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton2 = true;
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
