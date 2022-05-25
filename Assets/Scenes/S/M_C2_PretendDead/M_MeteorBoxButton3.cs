using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton3 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton3 = false;

    /*연관있는 오브젝트*/
    public GameObject M_Box_Obj5;
    public GameObject M_Noah_Obj5;
    public GameObject M_IsMeteoritesStorage3;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteorBoxButton3, sniffButton_M_MeteorBoxButton3, biteButton_M_MeteorBoxButton3,
        pressButton_M_MeteorBoxButton3, noCenterButton_M_MeteorBoxButton3;


    /*ObjData*/
    ObjData MeteorBoxButton3ObjData_M;
    public ObjectData MeteorBoxButton3Data_M;

    public ObjectData Box_Obj5Data_M;
    public ObjectData IsMeteoritesStorage3Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage3Outline_M;
    Outline MeteorBoxButton3Outline_M;

    /*애니메이션*/
    public Animator meteorBox3Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton3_Collider;
    BoxCollider Box5_Collider;
    BoxCollider Noah5_Collider;
    BoxCollider IsMeteoritesStorage3_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton3_Collider = GetComponent<BoxCollider>();
        Box5_Collider = M_Box_Obj5.GetComponent<BoxCollider>();
        Noah5_Collider = M_Noah_Obj5.GetComponent<BoxCollider>();
        IsMeteoritesStorage3_Collider = M_IsMeteoritesStorage3.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage3Outline_M = M_IsMeteoritesStorage3.GetComponent<Outline>();
        MeteorBoxButton3Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton3ObjData_M = GetComponent<ObjData>();

        /*버튼 연결*/
        barkButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton3.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton3.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton3.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.CenterButton1;

        /*선언시작*/
        //IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage3Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Box_Obj5Data_M.IsUpDown)
        {
            Box5_Collider.enabled = false;
            MeteorBoxButton3_Collider.enabled = true;
        }
        else
        {
            Box5_Collider.enabled = true;
            MeteorBoxButton3_Collider.enabled = false;
            MeteorBoxButton3Data_M.IsCollision = false;
        }

        /*버튼에 부딪히면 버튼에 상호작용 가능*/
        if (MeteorBoxButton3Data_M.IsCollision)
        {
            MeteorBoxButton3Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
            MeteorBoxButton3Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = false;  // 관찰하기 활성화
        }
        else
        {
            MeteorBoxButton3Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton3Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = true; // 관찰하기 비 활성화
        }


        /*운석 보관함에 관찰하기를 하면*/
        if (IsMeteoritesStorage3Data_M.IsObserve)
        {
            IsMeteoritesStorage3_Collider.enabled = false;

            //Noah5_Collider.enabled = false; // 노아 콜라이더도 꺼준다.

            MeteorBoxButton3Data_M.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            MeteorBoxButton3Outline_M.OutlineWidth = 0;

            MeteorBoxButton3_Collider.enabled = false;

        }

        /*운석 보관함에 관찰하면 && 버튼을 1번이라도 클릭했다면,
          항상 켜지는 거 방지로 조건을 하나 더*/
        else if (!IsMeteoritesStorage3Data_M.IsObserve && IsClickMeteorBoxButton3 == true)
        {
            IsMeteoritesStorage3_Collider.enabled = true;

            //Noah5_Collider.enabled = true;

            MeteorBoxButton3_Collider.enabled = true;
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

        Invoke("OpenMeteorBox3", 2f);
    }

    void OpenMeteorBox3()
    {
        meteorBox3Anim_M.SetBool("isMeteorBox3Open", true);
        meteorBox3Anim_M.SetBool("isMeteorBox3End", true);

        IsMeteoritesStorage3Data_M.IsNotInteractable = false; // 박스에 상호작용 가능하게
        IsMeteoritesStorage3Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton3 = true;

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
