using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton4 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton4 = false;

    /*연관있는 오브젝트*/
    public GameObject M_Box_Obj6;
    public GameObject M_Noah_Obj6;
    public GameObject M_IsMeteoritesStorage4;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton4, sniffButton_M_MeteorBoxButton4, biteButton_M_MeteorBoxButton4,
        pressButton_M_MeteorBoxButton4, noCenterButton_M_MeteorBoxButton4;


    /*ObjData*/
    ObjData MeteorBoxButton4ObjData_M;
    public ObjectData MeteorBoxButton4Data_M;

    public ObjectData Box_Obj6Data_M;
    public ObjectData IsMeteoritesStorage4Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage4Outline_M;
    Outline MeteorBoxButton4Outline_M;

    /*애니메이션*/
    public Animator meteorBox4Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton4_Collider;
    BoxCollider Box6_Collider;
    BoxCollider Noah6_Collider;
    BoxCollider IsMeteoritesStorage4_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton4_Collider = GetComponent<BoxCollider>();
        Box6_Collider = M_Box_Obj6.GetComponent<BoxCollider>();
        Noah6_Collider = M_Noah_Obj6.GetComponent<BoxCollider>();
        IsMeteoritesStorage4_Collider = M_IsMeteoritesStorage4.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage4Outline_M = M_IsMeteoritesStorage4.GetComponent<Outline>();
        MeteorBoxButton4Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton4ObjData_M = GetComponent<ObjData>();


        /*버튼 연결*/
        barkButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton4.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton4.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton4.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.CenterButton1;

        /*선언시작*/
        //IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage4Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Box_Obj6Data_M.IsUpDown)
        {
            Box6_Collider.enabled = false;
            MeteorBoxButton4_Collider.enabled = true;
        }
        else
        {
            Box6_Collider.enabled = true;
            MeteorBoxButton4_Collider.enabled = false;
            MeteorBoxButton4Data_M.IsCollision = false;
        }

        /*버튼에 부딪히면 버튼에 상호작용 가능*/
        if (MeteorBoxButton4Data_M.IsCollision)
        {
            MeteorBoxButton4Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
            MeteorBoxButton4Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = false;  // 관찰하기 활성화
        }
        else
        {
            MeteorBoxButton4Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton4Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = true; // 관찰하기 비 활성화
        }


        /*운석 보관함에 관찰하기를 하면*/
        if (IsMeteoritesStorage4Data_M.IsObserve)
        {
            IsMeteoritesStorage4_Collider.enabled = false;

            //Noah6_Collider.enabled = false; // 노아 콜라이더도 꺼준다.

            MeteorBoxButton4Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton4Outline_M.OutlineWidth = 0;

            MeteorBoxButton4_Collider.enabled = false;

        }

        /*운석 보관함에 관찰하면 && 버튼을 1번이라도 클릭했다면,
          항상 켜지는 거 방지로 조건을 하나 더*/
        else if (!IsMeteoritesStorage4Data_M.IsObserve && IsClickMeteorBoxButton4 == true)
        {
            IsMeteoritesStorage4_Collider.enabled = true;

            //Noah6_Collider.enabled = true;

            MeteorBoxButton4_Collider.enabled = true;
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

        Invoke("OpenMeteorBox4", 2f);
    }

    void OpenMeteorBox4()
    {
        meteorBox4Anim_M.SetBool("isMeteorBox4Open", true);
        meteorBox4Anim_M.SetBool("isMeteorBox4End", true);

        IsMeteoritesStorage4Data_M.IsNotInteractable = false; // 박스에 상호작용 가능하게
        IsMeteoritesStorage4Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton4 = true;

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
